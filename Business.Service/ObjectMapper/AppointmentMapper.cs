using AutoMapper;
using Business.Abstraction.Model;
using Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service.ObjectMapper
{
    public class AppointmentMapper : Profile
    {
        public AppointmentMapper()
        {
            CreateMap<AppointmentModel, Appointment>().ReverseMap();
        }
    }
}
