using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;
using SklepHkr2025.Components;
using SklepHkr2025.Components.Account;
using SklepHkr2025.Data;
using SklepHkr2025.Services;
using SklepHkr2025.Services.Email;
using SklepHkr2025.Services.Files;
using SklepHkr2025.Services.Incom;
using SklepHkr2025.Services.Shop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();
//builder.Services.AddMediatR(cfg => {
//    cfg.RegisterServicesFromAssembly(typeof(AddFilesToDiskCommand).Assembly);
//    //cfg.AddBehavior<PingPongBehavior>();
//    //cfg.AddStreamBehavior<PingPongStreamBehavior>();
//    //cfg.AddRequestPreProcessor<PingPreProcessor>();
//    //cfg.AddRequestPostProcessor<PingPongPostProcessor>();
//    //cfg.AddOpenBehavior(typeof(GenericBehavior<,>));
//});
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IIncomService, IncomService>();
builder.Services.AddTransient<IShopService, ShopService>();
builder.Services.AddScoped<RecaptchaService>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();
app.MapHub<ProgressHub>("/progressHub");
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
