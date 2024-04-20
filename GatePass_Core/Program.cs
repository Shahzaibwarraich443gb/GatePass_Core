using GatePass_DBContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                          policy.WithHeaders("*");
                          policy.WithMethods("*");
                      });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContextPool<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GatePassDBConnection"), x => x.MigrationsAssembly("GatePass_Migrations")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>();

builder.Services.Configure<IdentityOptions>(options => //change default password restrictions
{
    options.Password.RequireNonAlphanumeric = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
