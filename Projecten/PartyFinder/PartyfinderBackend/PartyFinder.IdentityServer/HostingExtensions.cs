using Azure.Identity;
using Duende.IdentityServer;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PartyFinder.Identityserver.Data;
using PartyFinder.Identityserver.Models;
using PartyFinder.Identityserver.Repositories;
using PartyFinder.Identityserver.Repositories.Interfaces;
using PartyFinder.Identityserver.Services;
using PartyFinder.Identityserver.Services.Interfaces;
using Serilog;

namespace PartyFinder.Identityserver;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        //keyvault
        builder.Configuration.AddAzureKeyVault(
            new Uri("https://raidlesspg3-keyvault.vault.azure.net/"),
            new DefaultAzureCredential()
        );
        builder.Services.AddRazorPages();

        builder.Services.AddControllers();
        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+";
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                "ReactApp",
                policy =>
                {
                    policy
                        .WithOrigins(
                            "https://hogent-partyfinderfrontend-svensnoeck-efcjbsenduhye5h7.northeurope-01.azurewebsites.net"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                }
            );
        });

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("PartyFinderDbIdentityserver")
            )
        );

        builder.Services.AddDbContext<ConfigurationDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("PartyFinderDbIdentityserver"),
                options => options.MigrationsAssembly(typeof(Program).Assembly.GetName().Name)
            )
        );

        builder
            .Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        builder
            .Services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                options.EmitStaticAudienceClaim = true;
            })
            .AddConfigurationStore()
            .AddAspNetIdentity<ApplicationUser>();

        builder.Services.AddAuthentication();

        builder
            .Services.AddAuthorizationBuilder()
            .AddPolicy(
                "AdminPartyFinderReadWritePolicy",
                policy =>
                {
                    policy.AddRequirements(
                        new ClaimOrRoleRequirement("partyfinder.api.Read", "Admin")
                    );
                    policy.AddRequirements(
                        new ClaimOrRoleRequirement("partyfinder.api.Write", "Admin")
                    );
                }
            );

        builder.Services.AddSingleton<IAuthorizationHandler, ClaimOrRoleHandler>();
        builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IProfileService, ProfileService>();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors("ReactApp");
        app.UseAuthentication();
        app.UseIdentityServer();
        app.UseAuthorization();

        app.MapRazorPages().RequireAuthorization();

        app.MapControllers();

        return app;
    }
}
