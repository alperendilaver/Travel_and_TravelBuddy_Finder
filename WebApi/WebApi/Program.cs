using Application.Features.Handlers.MessageHandlers;
using Application.Features.Handlers.UserHandlers;
using Application.Interfaces;
using Application.Interfaces.BlogRep;
using Application.Interfaces.ChatRep;
using Application.Interfaces.CountryRep;
using Application.Interfaces.FoodRep;
using Application.Interfaces.HotelRep;
using Application.Interfaces.IEmailService;
using Application.Interfaces.IGeneralRepository;
using Application.Interfaces.MatchRep;
using Application.Interfaces.NotificationRep;
using Application.Interfaces.PostRep;
using Application.Interfaces.RouteRep;
using Application.Interfaces.SuggestedUserRep;
using Application.Interfaces.UserHobbyRep;
using Application.Interfaces.UserKeyRep;
using Application.Interfaces.UserRepository;
using Application.Services;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Persistance.Context;
using Persistance.Repositories.BlogRepository;
using Persistance.Repositories.CityRepository;
using Persistance.Repositories.DestinationRepository;
using Persistance.Repositories.FoodRepository;
using Persistance.Repositories.GeneralRepository;
using Persistance.Repositories.HotelRepository;
using Persistance.Repositories.MatchRepository;
using Persistance.Repositories.MessageRepository;
using Persistance.Repositories.NotificationRepository;
using Persistance.Repositories.PostRepository;
using Persistance.Repositories.RouteRepository;
using Persistance.Repositories.SuggestedUserRepository;
using Persistance.Repositories.UserHobbyRepository;
using Persistance.Repositories.UserKeyRepository;
using Persistance.Repositories.UserRepository;
using WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<JourneyCloudContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));
builder.Services.AddScoped(typeof(IHotelRepository), typeof(HotelRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(IMatchRepository), typeof(MatchRepository));
builder.Services.AddScoped(typeof(IUserHobbyRepository), typeof(UserHobbyRepository));
builder.Services.AddScoped(typeof(IFoodRepository), typeof(FoodRepository));
builder.Services.AddScoped(typeof(IDestinationRepository), typeof(DestinationRepository));
builder.Services.AddScoped(typeof(IRouteRepository), typeof(RouteRepository));
builder.Services.AddScoped(typeof(IPostRepository), typeof(PostRepository));
builder.Services.AddScoped(typeof(ISuggestedUserRepository), typeof(SuggestedUserRepository));
builder.Services.AddScoped(typeof(INotificationRepository), typeof(NotificationRepository));
builder.Services.AddScoped(typeof(IUserKeyRepositry), typeof(UserKeyRepository));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<CheckAuthHandler>();
builder.Services.AddScoped<LogoutUserHandler>();
builder.Services.AddSingleton<IEmailService, EmailService>(i => new EmailService(
    builder.Configuration["EmailSender:Host"],
    builder.Configuration.GetValue<int>("EmailSender:Port"),
    builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
    builder.Configuration["EmailSender:UserName"],
    builder.Configuration["EmailSender:Password"]
));
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<JourneyCloudContext>()
    .AddDefaultTokenProviders();
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true; // Detaylı hata mesajlarını etkinleştir
});
builder.Services.AddScoped<IChatMessageRepository, ChatMessageRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Users/Login";
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Users/Login";
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJSApp", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});
builder.Services.AddApplicationService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware sıralaması
app.UseHttpsRedirection();
app.UseRouting(); // UseRouting burada ilk olarak çağrılmalı
app.UseCors("AllowNextJSApp"); // Cors, routing'in ardından gelmeli
app.UseAuthentication(); // UseAuthentication, UseAuthorization'dan önce olmalı
app.UseAuthorization();

// Endpoints tanımlama
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Controller endpoint'lerini tanımlama
    endpoints.MapHub<ChatHub>("/chatHub"); // SignalR ChatHub endpoint tanımlama
});

app.Run();

