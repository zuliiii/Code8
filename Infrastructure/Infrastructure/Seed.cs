using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class Seed
{
    public static async Task SeedData(ApplicationDbContext context, UserManager<User> userManager)
    {
        if (!userManager.Users.Any())
        {
            var users = new List<User>
            {
                new User{ Id = "cdf5d0bf-825f-4ff6-a3fb-bcd7d91a5527", Name = "Valeh", BirthDate = new DateTime(2022, 9, 5), Gender = true, Email = "valeh@gmail.com", AppointmentDate = new DateTime(2022, 9, 5), DeviceId = 1},
                new User{ Id = "9feb9e71-b833-4275-a215-cef7af429331", Name = "Zuleyxa", BirthDate = new DateTime(2022, 9, 5), Gender = false, Email = "zuli@gmail.com", AppointmentDate = new DateTime(2022, 9, 5), DeviceId = 2},
                new User{ Id = "b8041798-ee7f-4347-afa2-a5fbb6e6fcf4", Name = "Name", BirthDate = new DateTime(2022, 9, 5), Gender = true, Email = "name@gmail.com", AppointmentDate = new DateTime(2022, 9, 5), DeviceId = 3}
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "Password123!");
            }
        }
    }

}
