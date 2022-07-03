using System;
namespace HangfireDemo.Services
{
    public interface IHourService
    {
        void PrintHour();
    }
	public class HourService : IHourService
    {
        private readonly ILogger<HourService> logger;

        public HourService(ILogger<HourService> logger)
		{
            this.logger = logger;
        }
        public void PrintHour()
        {
            logger.LogInformation(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        }
	}
}

