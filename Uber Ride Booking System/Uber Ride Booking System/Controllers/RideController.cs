using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uber_Ride_Booking_System.DTOs;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RideController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rides = await _unitOfWork.rideRepo.GetById(id);
            if (rides == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<RideDTO>(rides);

            return Ok(res);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateRideDTO dto)
        {
            var ride = await _unitOfWork.authRepo.GetById(dto.RiderId);
            if (ride == null)
            {
                return BadRequest("Ride not found");
            }
            var res = _mapper.Map<Ride>(dto);

            await _unitOfWork.rideRepo.Add(res);
            await _unitOfWork.SaveChanges();

            var result = _mapper.Map<RideDTO>(res);

            return CreatedAtAction(nameof(GetById), new { id = res.Id }, result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllWithPages(int pageno, int pagesize)
        {
            var rides = await _unitOfWork.rideRepo.GetAllByPages(pageno, pagesize);
            if (rides == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<ICollection<RideDTO>>(rides);

            return Ok(res);
        }
        [HttpPatch("/accept")]
        public async Task<IActionResult> ChangeStatusToActepted(int id)
        {
            var rides = await _unitOfWork.rideRepo.GetById(id);
            if (rides == null)
            {
                return NotFound();
            }

            rides.Status = "Accept";
            await _unitOfWork.SaveChanges();

            var res = _mapper.Map<RideDTO>(rides);

            return Ok(res);
        }
        [HttpPatch("/complete")]
        public async Task<IActionResult> ChangeStatusToComplete(int id)
        {
            var rides = await _unitOfWork.rideRepo.GetById(id);
            if (rides == null)
            {
                return NotFound();
            }

            rides.Status = "Complete";
            await _unitOfWork.SaveChanges();

            var res = _mapper.Map<RideDTO>(rides);

            return Ok(res);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var rides = await _unitOfWork.rideRepo.GetById(id);
            if (rides == null)
            {
                return NotFound();
            }

            _unitOfWork.rideRepo.Delete(rides);
            await _unitOfWork.SaveChanges();

            return NoContent();
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchByPickup(string pickup)
        {
            var rides = await _unitOfWork.rideRepo.SearchByPickup(pickup);
            if (rides == null)
            {
                return NotFound();
            }

            return Ok(rides);
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> Filter()
        {
            var rides = await _unitOfWork.rideRepo.Filter();
            if (rides == null)
            {
                return NotFound();
            }

            return Ok(rides);
        }


    }
}
