using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Education:Base
	{
		public string UniversityName { get; set; }
		public string Speciality {get; set; }
		public double CurrentGrade { get; set; }
		public double GPA { get; set;}

		public int UserID { get; set; }
		//public User User { get; set; }
	}
}
