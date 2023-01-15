using Microsoft.AspNetCore.Mvc;
using Wtt.Services.Dto.Food;
using Wtt.Services.Interfaces;

namespace Wtt.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController
    {
        private readonly ILogger<FoodController> _logger;
        private readonly IFoodService _foodService;

        public FoodController(ILogger<FoodController> logger, IFoodService foodService)
        {
            _logger = logger;
            _foodService = foodService;
        }


        [HttpPost]
        public async Task<int> AddFood(FoodCreateDto food)
        {
            return await _foodService.AddFood(food);
        }

        [HttpDelete]
        public async System.Threading.Tasks.Task DeleteFood(int foodId)
        {
            await _foodService.DeleteFood(foodId);

        }


        [HttpGet]
        public async Task<FoodReadDto> GetFoodById(int Id)
        {
             return await _foodService.GetFoodById(Id);
        }

        [HttpGet("all")]
        public async Task<List<FoodReadDto>> GetFoods(string Name, int pageNumber, int pageSize)
        {
            return await _foodService.GetFoods(Name, pageNumber, pageSize);
        }


        [HttpPut]
        public async System.Threading.Tasks.Task UpdateFood(FoodUpdateDto food)
        {
            await _foodService.UpdateFood(food);
        }
    }
}
