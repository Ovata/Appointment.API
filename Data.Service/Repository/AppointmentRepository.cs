using Database;
using Database.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service.Repository
{
    public class AppointmentRepository : GenericRepository<Appointment, ApplicationDbContext>
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddAppointment(Appointment model)
        {
            _context.Set<Appointment>().Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAppointment(Appointment model, int Id)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Appointment> GetAppointment(int Id)
        {
            return await _context.Set<Appointment>().FindAsync(Id);
        }

        public async Task RemoveAppointment(int Id)
        {
            var data = await _context.Set<Appointment>().FindAsync(Id);
            if (data == null)
            {
                await Task.FromException(new Exception("The Id can't be found"));
            }

            _context.Set<Appointment>().Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}
