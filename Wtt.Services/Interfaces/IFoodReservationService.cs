
using Wtt.Services.Dto;
using Wtt.Services.Dto.FoodReservation;

namespace Wtt.Services.Interfaces
{
    public interface IFoodReservationService
    {
        Task<int> AddFoodReservation(FoodReservationCreateDto foodReservation);
        Task UpdateFoodReservation(FoodReservationUpdateDto foodReservation);
        Task DeleteFoodReservation(int Id);
        Task<FoodReservationReadDto> GetFoodReservationById(int Id);
        Task<List<FoodReservationReadDto>> GetFoodReservations(int EmployeeId, DateTime ReservedDate, int pageNumber, int pageSize);

    }

   
}
