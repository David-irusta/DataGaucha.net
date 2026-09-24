using Datagaucha.DAL.EntityFramework;
using Datagaucha.Domain.Auth;
using Datagaucha.Domain.Social;
using Microsoft.EntityFrameworkCore;
namespace Datagaucha.DAL.EntityFramework;

public class DatagauchaDbContext(DbContextOptions<DatagauchaDbContext> options)
    : DbContext(options)
{
    // Agregar DbSet<T> aquí a medida que se creen las entidades.
    // Ejemplo:
    // public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de entidades aquí.
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Follow> Follows => Set<Follow>();
    public DbSet<Datagaucha.Domain.FileSystem.File> Files => Set<Datagaucha.Domain.FileSystem.File>();
    public DbSet<Datagaucha.Domain.FileSystem.Image> Images => Set<Datagaucha.Domain.FileSystem.Image>();
    public DbSet<Datagaucha.Domain.Post.Post> Posts => Set<Datagaucha.Domain.Post.Post>();
}