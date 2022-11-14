using System.Net;
using OpenAqAirQuality.Common.Constants;
using Polly;
using Polly.Extensions.Http;
using OpenAqAirQuality.Services.OpenAq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddApplicationInsightsTelemetry(); - Have installed required Nuget to install, if production code would enable app insights
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IOpenAqService, OpenAqService>();

AddOpenAqClient(builder);

var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
    {
        context.Request.Path = RoutingConstants.PageNotFound;
        await next();
    }
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler(RoutingConstants.WebsiteError);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void AddOpenAqClient(WebApplicationBuilder webApplicationBuilder)
{
    //Add a retry policy that will handle 500 errors, timeouts and 429 (too many requests) errors. 
    var retryPolicy = HttpPolicyExtensions
    .HandleTransientHttpError()
        .OrResult(r =>
            {
                var statusCode = (int)r.StatusCode;
                return statusCode == (int)HttpStatusCode.TooManyRequests;
            } 
        )
        .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(retryAttempt));

    webApplicationBuilder.Services.AddHttpClient(ConfigurationConstants.OpenAq.HttpClient, client =>
    {
        client.BaseAddress = new Uri(webApplicationBuilder.Configuration[ConfigurationConstants.OpenAq.ApiUrl] ??
                                     throw new InvalidOperationException());
    }).AddPolicyHandler(retryPolicy);
}
