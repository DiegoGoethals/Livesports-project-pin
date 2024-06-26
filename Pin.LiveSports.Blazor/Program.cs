using Microsoft.AspNetCore.ResponseCompression;
using Pin.LiveSports.Blazor.Hubs;
using Pin.LiveSports.Core.Interfaces;
using Pin.LiveSports.Core.Interfaces.Services;
using Pin.LiveSports.Core.Services;
using Pin.LiveSports.Infrastructure.Data;

namespace Pin.LiveSports.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSignalR();
            builder.Services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                   new[] { "application/octet-stream" });
            });

			builder.Services.AddSingleton<IFakeDataBase, FakeDatabase>();

            builder.Services.AddSingleton<IUserService, UserService>();

            builder.Services.AddScoped<IGameService, GameService>();
            builder.Services.AddScoped<IMatchEventService, MatchEventService>();

			var app = builder.Build();

			app.UseResponseCompression();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();

            app.MapHub<GamesHub>("/gameshub");

            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}