using Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Abstraction.Model
{
    public class Appointment : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string WhoToSee { get; set; }
        public DateTime TimeOfAppointment { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
