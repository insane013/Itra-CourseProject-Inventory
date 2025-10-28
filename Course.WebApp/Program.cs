using Course.Database;
using Course.Database.Entity.Inventory;
using Course.Database.Entity.User;
using Course.Database.Repository;
using Course.Database.Repository.Interfaces;
using Course.Services.Authentication;
using Course.Services.Inventory;
using Course.Services.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task5.WebApi.Services.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = Environment.GetEnvironmentVariable("SQLITE_CONNECTION")
    ?? builder.Configuration["ConnectionStrings:Sqlite"];

builder.Services.AddDbContext<InventoryDbContext>(opt =>
    opt.UseSqlite(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<InventoryDbContext>()
                .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Login";
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;
});

builder.Services.AddAutoMapper(cfg => { }, typeof(InventoryMapper));
builder.Services.AddAutoMapper(cfg => { }, typeof(UserMapper));

builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IFieldInfoRepository, FieldInfoRepository>();
builder.Services.AddScoped<IRepository<InventoryFieldValue>, FieldValueRepository>();

builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

var app = builder.Build();

DbInitializer.Initialize(app.Services);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
