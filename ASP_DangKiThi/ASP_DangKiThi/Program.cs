using ASP_DangKiThi.Models;
using ASP_DangKiThi.Utiltity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ MVC và cấu hình DbContext
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<db_ASP_ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

// Thêm dịch vụ session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Đăng ký IHttpContextAccessor để truy cập HttpContext
builder.Services.AddHttpContextAccessor();

// Các dịch vụ thường dùng khác
builder.Services.AddHttpClient(); // Dịch vụ cho HttpClient
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Đường dẫn đăng nhập
        options.LogoutPath = "/Account/Logout"; // Đường dẫn đăng xuất
    });
builder.Services.AddAuthorization(); // Dịch vụ phân quyền (nếu cần)

// Nếu có dịch vụ nào khác, hãy thêm vào đây
builder.Services.AddScoped<CService>();

var app = builder.Build();

// Cấu hình pipeline yêu cầu HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Xử lý lỗi trong môi trường không phát triển
    app.UseHsts(); // Bật HSTS
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Đảm bảo middleware session được sử dụng
app.UseAuthentication(); // Bật xác thực
app.UseAuthorization();

// Cấu hình routing cho các controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Khởi chạy ứng dụng
