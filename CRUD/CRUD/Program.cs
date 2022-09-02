using CRUD.Data.Contexts;
using CRUD.Data.Repositories;
using CRUD.Dominio.Contract.Repositories;
using CRUD.Service.Contracts;
using CRUD.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", corsPolicyBuilder =>
    {
        corsPolicyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

RegisterServices(builder.Services);

var app = builder.Build();
app.UseCors("DefaultPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void RegisterServices(IServiceCollection services)
{
    // Databases.
    services.AddScoped<CRUDContext>();

    // Repositories.
    services.AddScoped<IAccountRepository, AccountRepository>();

    // Services.
    services.AddScoped<IAccountService, AccountService>();

    services.AddMvc();
}
