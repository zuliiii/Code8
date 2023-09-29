using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class User : IdentityUser
	{
		public string Name { get; set; }
        public DateTime BirthDate { get; set; }
		public bool Gender { get; set; }
        public string Email { get; set; }
		public string Password { get; set; }
		public DateTime AppointmentDate { get; set; }
		public int DeviceId { get; set; }
	}
}
