using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uber_Ride_Booking_System.DTOs;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllDrivers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDrivers()
        {
            var users = await _unitOfWork.authRepo.GetAll();

            var drivers = users?.Where(x => x.Role == "Driver").ToList();

            if (drivers == null)
            {
                return NotFound();
            }

            var res = _mapper.Map<ICollection<UserDTO>>(drivers);
            return Ok(res);
        }

        [HttpGet("GetAllRides")]
        public async Task<IActionResult> GetAllRides(string name)
        {
            var users = await _unitOfWork.authRepo.GetAll();

            var riders = users?.Where(x => x.Role == "Rider").ToList();

            if (riders == null)
            {
                return NotFound();
            }
            var search = await _unitOfWork.authRepo.GetByName(name);
            var res = _mapper.Map<ICollection<UserDTO>>(search);
            return Ok(res);
        }

    }
}
