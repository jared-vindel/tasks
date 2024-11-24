
using Microsoft.EntityFrameworkCore;

namespace Tasks.EntityModels;

public partial class TasksContext : DbContext
{
    DbSet<Activity> Activities { set; get; }

    DbSet<Person> Persons { set; get; }

    DbSet<Task> Tasks { set; get; }

    DbSet<TaskException> TaskExceptions { set; get; }

    DbSet<ActivityDetail> ActivityDetails { set; get; }

    public TasksContext()
    {
    }

    public TasksContext( DbContextOptions<TasksContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            string database = "db\\tasks.db";
            string dir = Environment.CurrentDirectory;
            string path = String.Empty;

            if (dir.EndsWith("net8.0"))
            {
                // En el directorio <proyecto>\bin\<Debug|Release>\net8.0.
                path = Path.Combine("..", "..", "..", "..", database);
            }
            else
            {
                // En el directorio del proyecto.
                path = Path.Combine("..", database);
            }

            path = Path.GetFullPath(path);

            try
            {
                TasksContextLogger.WriteLine($"Ruta a Base de Datos: {path}");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            if(!File.Exists(path))
            {
                throw new FileNotFoundException(
                    message: $"{path} no encontrado.", fileName: path);
            }

            optionsBuilder.UseSqlite($"Data Source={path}");

            optionsBuilder.LogTo(TasksContextLogger.WriteLine,
                new[] { Microsoft.EntityFrameworkCore
                    .Diagnostics.RelationalEventId.CommandExecuting });
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>( entity =>
        {
            entity.Property(e => e.Description).HasDefaultValue("");
        });

        modelBuilder.Entity<Task>( entity =>
        {
            entity.Property( e => e.Description).HasDefaultValue("");
        });
    }

}
