using Application.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                  //The GET endpoint should omit the user “email” property if “marketingConsent” is false.
                  .ForMember(d => d.Email, o => o.MapFrom(s => s.MarketingConsent ? s.Email : ""));
            CreateMap<UserDTO, User>();
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<User, UserForUpdateDto>().ReverseMap();
        }
    }
}
