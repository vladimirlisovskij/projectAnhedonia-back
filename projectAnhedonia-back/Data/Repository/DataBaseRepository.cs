using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projectAnhedonia_back.Data.Entity;
using projectAnhedonia_back.Data.Models;
using projectAnhedonia_back.Domain.Entity;
using projectAnhedonia_back.Domain.Exceptions;
using projectAnhedonia_back.Domain.Repository;
using projectAnhedonia_back.Tools;

namespace projectAnhedonia_back.Data.Repository
{
    public class DataBaseRepository : IDataBaseRepository
    {
        private readonly IServiceProvider _serviceProvider;
        private TestDataBaseContext Database => _serviceProvider.GetRequiredService<TestDataBaseContext>();
        public DataBaseRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<List<TestItemDto>> GetAllTestItems()
        {
            return Database
                .GetAllTestItems()
                .MapResult(result => result.Select(item => item.ConvertToDomainLayer()).ToList());
        }

        public Task<TestItemDto> GetItemById(long id)
        {
            return Database
                .GetItemById(id)
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
                .MapResult(result => result.ConvertToDomainLayer());
        }

        public Task InsertTestItem(TestItemDto data)
        {
           return Database
               .InsertTestItem(data.ConvertToDataLayer())
               .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        ArgumentException => new InvalidEntityKeyException("the database already contains this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }

        public Task DeleteItemById(long id)
        {
            return Database
                .DeleteById(id)
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        DbUpdateException => new InvalidEntityKeyException("the database does not contain an item with this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }

        public Task UpdateItem(TestItemDto data)
        {
            return Database
                .UpdateTestItem(data.ConvertToDataLayer())
                .MapError(errors =>
                {
                    var error = errors[0];
                    return error switch
                    {
                        DbUpdateException => new InvalidEntityKeyException("the database does not contain an item with this key"),
                        _ => new UnknownException(error.Message)
                    };
                });
        }
    }
}