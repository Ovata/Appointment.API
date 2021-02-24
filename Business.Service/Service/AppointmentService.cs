using AutoMapper;
using Business.Abstraction.Model;
using Business.Abstraction.Service;
using Data.Service.Repository;
using Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly AppointmentRepository _appointmentRepository;

        public AppointmentService(IMapper mapper, AppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task AddAppointment(AppointmentModel model)
        {
            var data = _mapper.Map<Appointment>(model);
            data.CreatedAt = DateTime.Now;
            data.UpdatedAt = DateTime.Now;
            data.CreatedBy = "SYSTEM";
            data.UpdatedBy = "SYSTEM";
            await _appointmentRepository.AddAppointment(data);
        }

        public async Task<AppointmentModel> GetAppointment(int id)
        {
            var rsc = await _appointmentRepository.GetAppointment(id);
            var appScore = _mapper.Map<AppointmentModel>(rsc);
            return appScore;
        }

        public async Task RemoveAppointment(int id)
        {
            await _appointmentRepository.RemoveAppointment(id);
        }

        public async Task UpdateAppointment(AppointmentModel model, int id)
        {
            var data = await _appointmentRepository.GetAppointment(id);
            data.Address = model.Address;
            data.Email = model.Email;
            data.FirstName = model.FirstName;
            data.Gender = model.Gender;
            data.LastName = model.LastName;
            data.Phone = model.Phone;
            data.TimeOfAppointment = model.TimeOfAppointment;
            data.WhoToSee = model.WhoToSee;
            data.UpdatedAt = DateTime.Now;
            await _appointmentRepository.UpdateAppointment(data, id);
        }
    }
}
