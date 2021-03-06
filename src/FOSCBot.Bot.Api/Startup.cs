using System;
using FOSCBot.Core.Domain.Inline.Default;
using FOSCBot.Infrastructure.Contract.Client;
using FOSCBot.Infrastructure.Contract.Service;
using FOSCBot.Infrastructure.Implementation.Client;
using FOSCBot.Infrastructure.Implementation.Service;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Navigator;
using Polly;

namespace FOSCBot.Bot.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddHealthChecks();

            #region Navigator

            services.AddNavigator(options =>
            {
                options.BotToken = Configuration["TELEGRAM_TOKEN"];
                options.BaseWebHookUrl = Configuration["BOT_URL"];
                options.MultipleLaunchEnabled = false;
            }, typeof(DefaultInlineAction).Assembly);

            #endregion

            #region Pipeline

            services.AddMediatR(typeof(DefaultInlineAction).Assembly);

            #endregion

            #region Infrastructure

            services.AddOptions<BaconClient.BaconClientOptions>().Configure(options => { options.ApiUrl = Configuration["BACON_API_URL"]; });

            services.AddOptions<MetaphorClient.MetaphorClientOptions>().Configure(options => { options.ApiUrl = Configuration["METAPHOR_API_URL"]; });

            services.AddOptions<InspiroClient.InspiroClientOptions>().Configure(options => { options.ApiUrl = Configuration["INSPIRO_API_URL"]; });

            services.AddOptions<InsultClient.InsultClientOptions>().Configure(options => { options.ApiUrl = Configuration["INSULT_API_URL"]; });

            services.AddOptions<YesNoClient.YesNoClientOptions>().Configure(options => { options.ApiUrl = Configuration["YESNO_API_URL"]; });

            services.AddHttpClient<IBaconClient, BaconClient>()
                .AddTransientHttpErrorPolicy(builder =>
                    builder.WaitAndRetryAsync(3, retryCount =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryCount))));

            services.AddHttpClient<IMetaphorClient, MetaphorClient>()
                .AddTransientHttpErrorPolicy(builder =>
                    builder.WaitAndRetryAsync(3, retryCount =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryCount))));

            services.AddHttpClient<IInspiroClient, InspiroClient>()
                .AddTransientHttpErrorPolicy(builder =>
                    builder.WaitAndRetryAsync(3, retryCount =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryCount))));
            
            services.AddHttpClient<IInsultClient, InsultClient>()
                .AddTransientHttpErrorPolicy(builder =>
                    builder.WaitAndRetryAsync(3, retryCount =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryCount))));
            
            services.AddHttpClient<IYesNoClient, YesNoClient>()
                .AddTransientHttpErrorPolicy(builder =>
                    builder.WaitAndRetryAsync(3, retryCount =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryCount))));

            services.AddScoped<ILipsumService, LipsumService>();
            services.AddScoped<IInspiroService, InspiroService>();
            services.AddScoped<IInsultService, InsultService>();
            services.AddScoped<IYesNoService, YesNoService>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapNavigator();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}