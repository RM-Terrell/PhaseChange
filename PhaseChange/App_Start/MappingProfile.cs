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
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
        }

    }
}