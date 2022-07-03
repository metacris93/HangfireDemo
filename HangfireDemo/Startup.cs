using System;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace HangfireDemo
{
	public static class Startup
	{
		public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<ApplicationDbContext>(p => p.UseNpgsql(connectionString));
		}
		public static void ConfigureHangfire(IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddHangfire(configuration => configuration
				.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
				.UseSimpleAssemblyNameTypeSerializer()
				.UseRecommendedSerializerSettings()
				.UsePostgreSqlStorage(connectionString)
			);
			// Cada 15 segundos Hangfire revisa la base de datos para verificar si hay jobs en el Scheduler
			services.AddHangfireServer();
		}
	}
}

