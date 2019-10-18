using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forma1Example.Models
{
    public class FeedDatabase
    {
        public FeedDatabase()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Teams")
                .Options;

            using (var context = new AppDbContext(options))
            {

                context.Teams.Add(new Team() { Name = "Name1", Year = 2019, Won = 11, Paid = true });
                context.Teams.Add(new Team() { Name = "Name2", Year = 2011, Won = 1, Paid = false });
                context.Teams.Add(new Team() { Name = "Name3", Year = 2014, Won = 12, Paid = true });

                context.SaveChanges();
            }
        }
    }
}
