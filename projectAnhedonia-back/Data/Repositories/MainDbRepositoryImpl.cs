using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Common;
using projectAnhedonia_back.Data.Entities.Dto;
using projectAnhedonia_back.Data.Models.Database.Main;
using projectAnhedonia_back.Domain.Entities.Dto.Article;
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

        public Task<long> GetIdByUsername(string username)
        {
            return _context
                .GetIdByUsername(username)
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        InvalidOperationException => new InvalidEntityKeyException(
                            "the database does not contain an item with this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }

        public Task CreateArticle(ArticleRegistrationDto data)
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

        public Task RemoveArticleById(long id)
        {
            return _context
                .RemoveArticleById(id)
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
    }
}