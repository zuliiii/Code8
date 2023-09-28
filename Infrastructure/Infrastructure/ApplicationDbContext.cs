using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}


		public DbSet<Applicants> Applicants { get; set; }
		public DbSet<Education> Educations { get; set; }
		public DbSet<Interests> Interests { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
