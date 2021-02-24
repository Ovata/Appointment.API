using Business.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstraction.Service
{
    public interface IAppointmentService
    {
        Task AddAppointment(AppointmentModel model);
        Task UpdateAppointment(AppointmentModel model, int id);
        Task<AppointmentModel> GetAppointment(int id);
        Task RemoveAppointment(int id);
    }
}
