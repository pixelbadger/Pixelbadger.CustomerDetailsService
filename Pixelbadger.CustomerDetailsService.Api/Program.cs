using Pixelbadger.CustomerDetailsService.Core.Util;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

// bind our CustomerDetailsService appsettings to a discrete options class
var customerDetailsServiceConfig = new CustomerDetailsServiceConfiguration();
builder.Configuration.Bind("CustomerDetailsService", customerDetailsServiceConfig);
// call into service configuration extension method to register customer details-specific services
builder.Services.AddCustomerDetailsService(customerDetailsServiceConfig);

var app = builder.Build();

// configure swagger usage
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();

