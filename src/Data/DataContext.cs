using Microsoft.EntityFrameworkCore;
using tutorial1.Models;

namespace tutorial1.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{ }

	public DbSet<CharacterModel> Characters => Set<CharacterModel>();
}
