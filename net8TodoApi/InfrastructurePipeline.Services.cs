namespace TodoApi;

public static class InfrastructurePipelineServices
{
    public static WebApplicationBuilder RegisterInfrastructureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(opt =>
        {
            opt.LowercaseUrls = true;
        });
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("angular", opt =>
            {
                opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });
        builder.Services.AddDistributedMemoryCache();
        
        return builder;
    }
}
