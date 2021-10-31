using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projectAnhedonia_back.Domain.Usecase;
using projectAnhedonia_back.Presentation.Entity;
using projectAnhedonia_back.Presentation.ExceptionFilter;
using projectAnhedonia_back.Presentation.Tools;
using projectAnhedonia_back.Tools;

namespace projectAnhedonia_back.Presentation.Controllers
{
    [CustomExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly GetAllTestItemsCase _getAllTestItemsCase;
        private readonly InsertTestItemsCase _insertTestItemsCase;
        private readonly GetTestItemByIdCase _getTestItemByIdCase;
        private readonly DeleteTestItemByIdCase _deleteTestItemByIdCase;
        private readonly UpdateItemCase _updateItemCase;

        public WeatherForecastController(
            GetAllTestItemsCase getAllTestItemsCase,
            InsertTestItemsCase insertTestItemsCase,
            GetTestItemByIdCase getTestItemByIdCase,
            DeleteTestItemByIdCase deleteTestItemByIdCase,
            UpdateItemCase updateItemCase)
        {
            _getAllTestItemsCase = getAllTestItemsCase;
            _insertTestItemsCase = insertTestItemsCase;
            _getTestItemByIdCase = getTestItemByIdCase;
            _deleteTestItemByIdCase = deleteTestItemByIdCase;
            _updateItemCase = updateItemCase;
        }

        [HttpGet]
        public async Task<Result<List<TestItem>>> Get()
        {
            return await _getAllTestItemsCase
                .GetAllTestItems()
                .MapResult(result => result.Select(item => item.ConvertToDataLayer()).ToList())
                .ConvertToResult("items received successfully");
        }


        [HttpGet("single")]
        public async Task<Result<TestItem>> GetById(long id)
        {
            return await _getTestItemByIdCase
                .GetItemById(id)
                .MapResult(result => result.ConvertToDataLayer())
                .ConvertToResult("item received successfully");
        }

        [HttpPost]
        public async Task<Result<string>> Post(TestItem data)
        {
            return await _insertTestItemsCase
                .InsertTestItem(data.ConvertToDomainLayer())
                .ConvertToResult("item inserted successfully");
        }

        [HttpDelete]
        public async Task<Result<string>> Delete(long id)
        {
            return await _deleteTestItemByIdCase
                .DeleteItemById(id)
                .ConvertToResult("item deleted successfully");
        }

        [HttpPatch]
        public async Task<Result<string>> Patch(TestItem data)
        {
            return await _updateItemCase
                .UpdateItem(data.ConvertToDomainLayer())
                .ConvertToResult("item updated successfully");
        }
    }
}