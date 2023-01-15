using Microsoft.AspNetCore.Mvc;
using Wtt.Domain.Entities;
using Wtt.Services.Dto;
using Wtt.Services.Dto.FoodReservation;
using Wtt.Services.Interfaces;

namespace Wtt.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodReservationController
    {
        private readonly ILogger<FoodReservationController> _logger;
        private readonly IFoodReservationService _foodreservationService;

        public FoodReservationController(ILogger<FoodReservationController> logger, IFoodReservationService foodreservationService)
        {
            _logger = logger;
            _foodreservationService = foodreservationService;
        }

        [HttpPost]
        public async Task<int> AddFoodReservation(FoodReservationCreateDto foodReservation)
        {
            return await _foodreservationService.AddFoodReservation(foodReservation);
        }

        [HttpDelete]
        public async System.Threading.Tasks.Task DeleteFoodReservation(int foodreservationId)
        {
            await _foodreservationService.DeleteFoodReservation(foodreservationId);

        }

        [HttpGet]
        public async Task<FoodReservationReadDto> GetFoodReservationById(int foodreservationId)
        {
            return await _foodreservationService.GetFoodReservationById(foodreservationId);
        }

        [HttpGet("all")]
        public async Task<List<FoodReservationReadDto>> GetFoodReservations(int EmployeeId, DateTime ReservedDate, int pageNumber, int pageSize)
        {

            return await _foodreservationService.GetFoodReservations(EmployeeId, ReservedDate, pageNumber, pageSize);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task UpdateFoodReservation(FoodReservationUpdateDto foodreservation)
        {
            await _foodreservationService.UpdateFoodReservation(foodreservation);
        }


    }
}
