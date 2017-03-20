using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PhaseChange.DTOs;
using PhaseChange.Models;

namespace PhaseChange.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Mapping domain to the DTO
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Game, GameDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();


            //Mapping DTO to the domain
            Mapper.CreateMap<CustomerDTO, Customer>()
            .ForMember(c => c.Id, opt => opt.Ignore()); //This is to prevent an exception being thrown when trying to map the id which should not be changed

            Mapper.CreateMap<GameDTO, Game>()
            .ForMember(c => c.Id, opt => opt.Ignore());
        }

    }
}