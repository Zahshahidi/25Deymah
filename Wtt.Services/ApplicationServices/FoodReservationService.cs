using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.DataAccess;
using Wtt.Domain.Entities;
using Wtt.Services.Dto;
using Wtt.Services.Dto.FoodReservation;
using Wtt.Services.Interfaces;

namespace Wtt.Services.ApplicationServices
{
    internal class FoodReservationService : IFoodReservationService
    {
        private readonly IWttDataAccess _wttDataAccess;

        public FoodReservationService(IWttDataAccess wttDataAccess)
        {
            _wttDataAccess = wttDataAccess;
        }
        public async Task<int> AddFoodReservation(FoodReservationCreateDto foodReservation)
        {
            var foodres = new FoodReservation
            {
                FoodId = foodReservation.FoodId,
                EmployeeId = foodReservation.EmployeeId,
                ReservedDate = foodReservation.ReservedDate
        };
            await _wttDataAccess.SaveFoodReservationAsync(foodres);
            return foodres.Id;
        }

        public async System.Threading.Tasks.Task DeleteFoodReservation(int Id)
        {
            var foodreservation = await _wttDataAccess.GetFoodReservationAsync(Id);
            if(foodreservation == null)
            {
                throw new Exception("not found exception");
            }
            await _wttDataAccess.DeleteFoodReservation(foodreservation);
                
        }

        public async Task<FoodReservationReadDto> GetFoodReservationById(int Id)
        {
            var foodreservation = await _wttDataAccess.GetFoodReservationAsync(Id);
            return new FoodReservationReadDto
            {
                Id = foodreservation.Id,
                EmployeeId = foodreservation.EmployeeId,
                FoodId=foodreservation.FoodId,
                ReservedDate = foodreservation.ReservedDate 

            };
         
        }

        public async Task<List<FoodReservationReadDto>> GetFoodReservations(int EmployeeId, DateTime ReservedDate, int pageNumber, int pageSize)
        {
            var foodreservations=await _wttDataAccess.GetFoodReservationsAsync(EmployeeId,ReservedDate, pageNumber, pageSize);
            return foodreservations.Select(f => new FoodReservationReadDto
            {
                Id=f.Id,
                EmployeeId=f.EmployeeId,
                FoodId=f.FoodId,
                ReservedDate=f.ReservedDate
            }
            ).ToList();
        }

        public async System.Threading.Tasks.Task UpdateFoodReservation(FoodReservationUpdateDto foodReservation)
        {
            var foodres = await _wttDataAccess.GetFoodReservationAsync(foodReservation.Id);
            if (foodReservation==null)
            {
                throw new Exception("not found exception");
            }
            foodres.EmployeeId = foodReservation.EmployeeId;
            foodres.FoodId = foodReservation.FoodId;
            foodres.ReservedDate = foodReservation.ReservedDate;
            foodres.Id = foodReservation.Id;

            await _wttDataAccess.UpdateFoodReservationAsync(foodres);

        }

       
    }
}
