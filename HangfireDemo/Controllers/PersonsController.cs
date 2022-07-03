using System;
using Hangfire;
using HangfireDemo.Models;
using HangfireDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemo.Controllers
{
	public class PersonsController : ControllerBase
	{
		private readonly ApplicationDbContext context;
        private readonly IBackgroundJobClient backgroundJobClient;

        public PersonsController(ApplicationDbContext context, IBackgroundJobClient backgroundJobClient)
		{
			this.context = context;
            this.backgroundJobClient = backgroundJobClient;
        }

		[HttpPost("create")]
		public ActionResult Create(string personName)
		{
			//backgroundJobClient.Enqueue(() => Console.WriteLine(personName));
			//backgroundJobClient.Enqueue(() => AddPerson(personName));
			backgroundJobClient.Enqueue<IPersonRepository>(repo => repo.AddPerson(personName));
			return Ok();
		}
		[HttpPost("schedule")]
		public ActionResult Schedule(string personName)
        {
            var jobId = backgroundJobClient.Schedule(() => Console.WriteLine("El nombre es " + personName), TimeSpan.FromSeconds(5));
            backgroundJobClient.ContinueJobWith(jobId, () => Console.WriteLine($"El job {jobId} ha concluido"));
			return Ok();
        }
		//public async Task AddPerson(string personName)
		//{
		//	var person = new Person { Name = personName };
		//	context.Add(person);
		//	await Task.Delay(5000);
		//	await context.SaveChangesAsync();
		//	Console.WriteLine($"person was inserted {personName}");
		//}
	}
}

