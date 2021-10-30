using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projectAnhedonia_back.Domain.Entity;
using projectAnhedonia_back.Domain.Usecase;

namespace projectAnhedonia_back.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly GetAllTestItemsCase _getAllTestItemsCase;
        private readonly InsertTestItemsCase _insertTestItemsCase;
        
        public WeatherForecastController(GetAllTestItemsCase getAllTestItemsCase, InsertTestItemsCase insertTestItemsCase)
        {
            _getAllTestItemsCase = getAllTestItemsCase;
            _insertTestItemsCase = insertTestItemsCase;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            await _insertTestItemsCase.InsertTestItem(new TestItemDto(1L, "", true));
            return await _getAllTestItemsCase.GetAllTestItems().ContinueWith(task =>
                task.Result.Select(item => item.Id.ToString())
            );
        }
    }
}
