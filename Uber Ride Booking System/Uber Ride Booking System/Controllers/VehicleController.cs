using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uber_Ride_Booking_System.DTOs;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("CreateVehicle")]
        public async Task<IActionResult> Create(CreateVehicleDTO dto)
        {
            var exidriver = await _unitOfWork.authRepo.GetById(dto.DriverId);
            if (exidriver == null)
            {
                return BadRequest("Driver Not Found");
            }

            var res = _mapper.Map<Vehicle>(dto);
            await _unitOfWork.vehicle.Add(res);
            await _unitOfWork.SaveChanges();
            return Ok(res);
        }

        [HttpPut("UpdateVehicle")]
        public async Task<IActionResult> Update(int id, CreateVehicleDTO dto)
        {
            var exidriver = await _unitOfWork.authRepo.GetById(dto.DriverId);

            if (exidriver == null)
            {
                return BadRequest("Driver Not Found");
            }
            var veh = _unitOfWork.vehicle.GetById(id);
            if (veh == null)
            {
                return BadRequest("Vehicle Not Found");
            }

            var res = _mapper.Map(veh, dto);
            await _unitOfWork.SaveChanges();
            return NoContent();
        }

        [HttpDelete("DeleteVehicle")]
        public async Task<IActionResult> Delete(int id)
        {
            var veh = await _unitOfWork.vehicle.GetById(id);

            if (veh == null)
            {
                return BadRequest("Vehicle Not Found");
            }

            _unitOfWork.vehicle.Delete(veh);
            await _unitOfWork.SaveChanges();
            return NoContent();
        }

    }
}
