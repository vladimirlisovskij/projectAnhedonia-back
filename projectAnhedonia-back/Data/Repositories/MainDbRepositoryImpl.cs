using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Common;
using projectAnhedonia_back.Data.Entities.Dto;
using projectAnhedonia_back.Data.Entities.Dto.Database;
using projectAnhedonia_back.Data.Models.Database.Main;
using projectAnhedonia_back.Domain.Entities.Dto.Article;
using projectAnhedonia_back.Domain.Entities.Dto.Comment;
using projectAnhedonia_back.Domain.Entities.Dto.User;
using projectAnhedonia_back.Domain.Entities.Exceptions;
using projectAnhedonia_back.Domain.Repositories;

namespace projectAnhedonia_back.Data.Repositories
{
    public class MainDbRepositoryImpl : IMainDbRepository
    {
        private readonly MainDatabaseContext _context;

        public MainDbRepositoryImpl(MainDatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        public Task CreateUser(UserRegistrationDto userRegistration)
        {
            return _context
                .AddUser(userRegistration.ConvertToDataLayer())
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        DbUpdateException => new InvalidEntityKeyException("the database already contains this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }

        public Task UpdateUserProfileById(UserUpdateDto profileInfo)
        {
            return _context
                .UpdateUser(profileInfo.ConvertToDataLayer())
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        DbUpdateException => new InvalidEntityKeyException("the database already contains this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }

        public Task<long> GetUserIdByUsername(string username)
        {
            return _context
                .GetUserIdByUserName(username);
        }

        public Task RemoveUserById(long id)
        {
            return _context
                .RemoveUserById(id)
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        DbUpdateException => new InvalidEntityKeyException(
                            "the database does not contain an item with this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }

        public Task<IEnumerable<UserProfileDto>> GetAllUsers()
        {
            return _context
                .GetAllUsers()
                .MapResult(l => l.Select(u => u.ConvertToDomainLayer()));
        }

        public Task<IEnumerable<ArticleViewDto>> GetAllArticles()
        {
            return _context
                .GetAllPosts()
                .MapResult(l => l.Select(p => p.ConvertToDomainLayer()));
        }

        public Task<UserProfileDto> GetUserProfileById(long id)
        {
            return _context
                .GetUserById(id)
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        InvalidOperationException  => new InvalidEntityKeyException(
                            "the database does not contain an item with this key"),
                        _ => new UnknownException(error.Message)
                    };
                })
                .MapResult(u => u.ConvertToDomainLayer());
        }

        public Task ChangeUserPasswordById(UserChangePasswordDto userChangePasswordDto)
        {
            return _context
                .ChangeUserPassword(userChangePasswordDto.ConvertToDataLayer())
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        DbUpdateException => new InvalidEntityKeyException("the database already contains this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }

        public Task<long> GetIdByCreds(UserCredsDto creds)
        {
            return _context.GetUserIdByCreds(creds.ConvertToDataLayer());
        }

        public Task<long> CreateArticle(ArticleRegistrationWithImageNameDto data)
        {
            return _context
                .AddArticle(data.ConvertToDataLayer())
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        DbUpdateException => new InvalidEntityKeyException("the database already contains this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }

        public Task UpdateArticle(ArticleUpdateDto data)
        {
            return _context
                .UpdateArticle(data.ConvertToDataLayer())
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        DbUpdateException => new InvalidEntityKeyException("the database already contains this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }

        public Task<string> RemoveArticleById(long selfId, long articleId)
        {
            return _context
                .RemoveArticleById(selfId, articleId)
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        DbUpdateException => new InvalidEntityKeyException(
                            "the database does not contain an item with this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }
        
        public Task<ArticleViewDto> GetArticleById(long id)
        {
            return _context
                .GetArticleById(id)
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        InvalidOperationException => new InvalidEntityKeyException(
                            "the database does not contain an item with this key"),
                        _ => new UnknownException(error.Message)
                    };
                })
                .MapResult(p => p.ConvertToDomainLayer());
        }

        public Task CreateComment(CommentCreateDto data)
        {
            return _context
                .CreateComment(data.ConvertToDataLayer())
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        DbUpdateException => new InvalidEntityKeyException("the database already contains this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }

        public Task<CommentViewDto> GetCommentById(long id)
        {
            return _context
                .GetCommentById(id)
                .MapResult(c => c.ConvertToDomainLayer());
        }

        public Task RemoveCommentById(long selfId, long commentId)
        {
            return _context
                .DeleteCommentById(selfId, commentId);
        }

        public Task UpdateCommentById(CommentUpdateDto data)
        {
            return _context
                .UpdateComment(data.ConvertToDataLayer());
        }

        public Task AddCoauthor(long selfId, long articleId, long coauthorId)
        {
            return _context
                .AddCoauthorById(selfId, articleId, coauthorId);
        }

        public Task RemoveCoauthor(long selfId, long articleId, long coauthorId)
        {
            return _context
                .RemoveCoauthorById(selfId, articleId, coauthorId);
        }

        public int AddImage(long articleId, string name)
        {
            return _context.AddImage(articleId, name);
        }
    }
}