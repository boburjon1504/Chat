using Chat.Application.Common.Settings;
using Chat.Application.Interfaces;
using Chat.Infrastructure.Services;
using Chat.Persistence.DataContext;
using Chat.Persistence.Repositories;
using Chat.Persistence.Repositories.Interfaces;
using Chat.Web.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
builder.Services.AddDbContext<ChatDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder
    .Services
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IChatOrchestrationService, ChatOrchestrationService>()
    .AddScoped<IChatRoomRepository, ChatRoomRepository>()
    .AddScoped<IChatRoomService, ChatRoomService>()
    .AddScoped<IMessageRepository, MessageRepository>()
    .AddScoped<IMessageService, MessageService>()
    .AddScoped<ITokenGeneratorService, TokenGeneratorService>()
    .AddScoped<IAccountService, AccountService>();

builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();

var jwtSettings = new JwtSettings();
builder.Configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);


builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;

        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = jwtSettings.ValidateIssuer,
            ValidIssuer = jwtSettings.ValidIssuer,
            ValidAudience = jwtSettings.ValidAudience,
            ValidateAudience = jwtSettings.ValidateAudience,
            ValidateLifetime = jwtSettings.ValidateLifetime,
            ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };
        o.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["token"];
                return Task.CompletedTask;
            }
        };

    });

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/mychat");
app.MapHub<VideoHub>("/meeting");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Chat}/{action=Index}");

app.Run();
