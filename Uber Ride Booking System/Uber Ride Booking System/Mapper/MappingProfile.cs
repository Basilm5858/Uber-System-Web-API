using AutoMapper;
using Uber_Ride_Booking_System.DTOs;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();

            CreateMap<Vehicle, CreateVehicleDTO>();

        }
    }
}
