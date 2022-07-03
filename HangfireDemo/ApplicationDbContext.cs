using System;
using HangfireDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace HangfireDemo
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Person> Persons { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
    }
}

