using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLThuVienMVC.Models;
using QLThuVienMVC.Models.UserModel;

var builder = WebApplication.CreateBuilder(args);

// 1. Cấu hình DbContext
builder.Services.AddDbContext<LibDataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<InterfaceSach, SachRepository>();
builder.Services.AddScoped<InterfaceThongTin, ThongTinRepository>();
builder.Services.AddSession();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.RequireUniqueEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<LibDataContext>()
.AddDefaultTokenProviders();

builder.Services.AddRazorPages();

var app = builder.Build();

// 2. TỰ ĐỘNG MIGRATION (Rất quan trọng khi deploy Azure lần đầu)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<LibDataContext>();
        // Tự động tạo database và bảng trên Azure nếu chưa có
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
    catch (Exception ex)
    {
        // Log lỗi nếu không kết nối được DB
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Lỗi khi chạy Migration Database.");
    }
}

app.UseSession();

// 3. HIỆN LỖI CHI TIẾT ĐỂ KIỂM TRA (Tạm thời cho Azure)
if (app.Environment.IsDevelopment() || true) // Ép buộc hiện lỗi chi tiết để bạn đọc log
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();