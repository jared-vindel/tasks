using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tasks.EntityModels;

public static class TasksContextExtensions {

    public static IServiceCollection AddTasksContext (
        this IServiceCollection services,
        string relative = "..\\db",
        string database = "tasks.db"
    ) 
    {
        string path = Path.Combine(relative, database);

        if(!File.Exists(path))
        {
            throw new FileNotFoundException(
                message: $"{path} no encontrado.", fileName: path);
        }

        services.AddDbContext<TasksContext>(options =>
            {
                options.UseSqlite($"Data Source={path}");

                options.LogTo(TasksContextLogger.WriteLine,
                    new[] { Microsoft.EntityFrameworkCore
                        .Diagnostics.RelationalEventId.CommandExecuting });

            },
            contextLifetime: ServiceLifetime.Transient,
            optionsLifetime: ServiceLifetime.Transient
        );

        return services;
    }

}