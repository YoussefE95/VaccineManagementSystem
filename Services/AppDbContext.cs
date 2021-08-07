using Microsoft.EntityFrameworkCore;
using VaccineManager.Models;

namespace VaccineManager
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Vaccine> Vaccines { get; set; }

		public DbSet<Patient> Patients { get; set; }
	}
}