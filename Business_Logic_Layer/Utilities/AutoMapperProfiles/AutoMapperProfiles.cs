using AutoMapper;
using Business_Logic_Layer.Models;
using Data_Access_Layer.Entities;

namespace Business_Logic_Layer.Utilities.AutoMapperProfiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Event, EventModel>().ReverseMap();
        }
    }
}
