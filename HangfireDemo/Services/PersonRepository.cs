using System;
using HangfireDemo.Models;

namespace HangfireDemo.Services
{
	public interface IPersonRepository
	{
		Task AddPerson(string personName);
	}
	public class PersonRepository : IPersonRepository
	{
        private readonly ApplicationDbContext context;
        private readonly ILogger<PersonRepository> logger;

        public PersonRepository(ApplicationDbContext context, ILogger<PersonRepository> logger)
		{
            this.context = context;
            this.logger = logger;
        }
		public async Task AddPerson(string personName)
		{
			logger.LogInformation($"trying to add person {personName}");
			var person = new Person { Name = personName };
			context.Add(person);
			await Task.Delay(5000);
			await context.SaveChangesAsync();
			logger.LogInformation($"person was inserted {personName}");
		}
	}
}

