using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Applicants:Base
	{
		public string Name { get; set; }
		public string Status { get; set; }

		public int UserID { get; set; }
		//public User User { get; set; }
	}
}
