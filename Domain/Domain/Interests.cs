using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Interests:Base
	{
		public string EnjoyedSub { get; set; }
		public string Hobbies { get; set; }
		public string CareerEnv { get; set; }

		public int UserID { get; set; }
		//public User User { get; set; }
	}
}
