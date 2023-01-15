
using Wtt.Services.Dto;
using Wtt.Services.Dto.Food;

namespace Wtt.Services.Interfaces
{
    public interface IFoodService
    {
        Task<int> AddFood(FoodCreateDto food);
        Task UpdateFood(FoodUpdateDto food);
        Task DeleteFood(int Id);
        Task<FoodReadDto> GetFoodById(int Id);
        Task<List<FoodReadDto>> GetFoods(string Name, int pageNumber, int pageSize);
    }
}

