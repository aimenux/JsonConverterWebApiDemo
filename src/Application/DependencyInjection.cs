namespace Application;

public static class DependencyInjection
{
    private static readonly Assembly CurrentAssembly = typeof(DependencyInjection).Assembly;
    
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(CurrentAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(CurrentAssembly);
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });
        return services;
    }
}