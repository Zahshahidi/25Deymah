using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.DataAccess;
using Wtt.Domain.Entities;
using Wtt.Services.Dto.Food;
using Wtt.Services.Interfaces;

namespace Wtt.Services.ApplicationServices
{
    internal class FoodService : IFoodService
    {
        private readonly IWttDataAccess _wttDataAccess;

        public FoodService(IWttDataAccess wttDataAccess)
        {
            _wttDataAccess = wttDataAccess;
        }
        public async Task<int> AddFood(FoodCreateDto food)
        {
            var f = new Food
            {
                Name = food.Name,
                Price = food.Price
            };
            await _wttDataAccess.SaveFoodAsync(f);
            return f.Id;
        }

        public async System.Threading.Tasks.Task DeleteFood(int Id)
        {
            var food = await _wttDataAccess.GetFoodAsync(Id);
            if (food == null)
            {
                throw new Exception("not found exception");
            }
            await _wttDataAccess.DeleteFoodAsync(food);
        }

        public async Task<FoodReadDto> GetFoodById(int Id)
        {
            var food = await _wttDataAccess.GetFoodAsync(Id);
            return new FoodReadDto
            {
                Name = food.Name,
                Price = food.Price
            };
        }

        public async Task<List<FoodReadDto>> GetFoods(string Name, int pageNumber, int pageSize)
        {
            var foods = await _wttDataAccess.GetFoodsAsync(Name, pageNumber, pageSize);
            return foods.Select(f => new FoodReadDto
            {
                Name = f.Name,
                Price=f.Price
            }
            ).ToList();

        }
        public async System.Threading.Tasks.Task UpdateFood(FoodUpdateDto food)
        {
            var foo = await _wttDataAccess.GetFoodAsync(food.Id);
            if (food == null)
            {
                throw new Exception("not found exception");
            }
            foo.Name = food.Name;
            foo.Price = food.Price;

            await _wttDataAccess.UpdateFoodAsync(foo);
        }
    }
}
