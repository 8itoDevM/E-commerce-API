using fakeshop.API.Data;
using fakeshop.API.Mappings;
using fakeshop.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FakeShopDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("FakeShopConnectionString")));

builder.Services.AddScoped<IProductRepository, SQLProductRepository>();

builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<MappingProfiles>();
});

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.WithOrigins("http://localhost:3000") // origem do React
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // necessário para arquivos wwwroot

app.UseRouting();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();