using Deneme.Business.Managers;
using Deneme.Business.Services;
using Deneme.Data.Context;
using Deneme.Data.Entities;
using Deneme.Data.InMemoryRepository;
using Deneme.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DenemeContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddDbContext<InMemoryContext>( options => options.UseInMemoryDatabase("CartDb"));

//builder.Services.AddDbContext<DenemeContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<InMemoryContext>(options => options.UseInMemoryDatabase("CartDb"));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    opt =>
    {

        opt.Password.RequireDigit = false;
        opt.Password.RequiredLength = 1;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireNonAlphanumeric = false;
        opt.SignIn.RequireConfirmedEmail = false;
    }).
AddEntityFrameworkStores<DenemeContext>().AddDefaultTokenProviders();
builder.Services.AddSession(

    options =>
    {
        options.Cookie.Name = "Session";
        options.IdleTimeout = TimeSpan.FromSeconds(2000000000);
        options.Cookie.IsEssential = false;

    }


    );
builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Index/";
    options.AccessDeniedPath = "/Admin/Index/";
});


builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));
builder.Services.AddScoped(typeof(InIRepository<>), typeof(InSqlRepository<>));


builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDetailService, ProductDetailManager>();
builder.Services.AddScoped<IVeriantService,VeriantManager>();
builder.Services.AddScoped<ICartItemService,CartItemManager>();
builder.Services.AddScoped<ICartService,CartManager>();
builder.Services.AddScoped<IOrderService,OrderManager>();
builder.Services.AddScoped<IOrderDetailService,OrderDetailManager>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");

});


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Card}/{action=index}/{id?}"
    );


app.Run();
