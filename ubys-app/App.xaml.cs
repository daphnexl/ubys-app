using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using ubys_app.Data;
using ubys_app.Services;

namespace ubys_app
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;
    
    public App()
        {
            IServiceCollection services = new ServiceCollection();

            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "AppDatabase.db3");
            services.AddDbContext<AppDbContext>(options=> options.UseSqlite($"Data source={dbPath}"));
            services.AddScoped<StudentService>();
            services.AddScoped<TeacherService>();
            services.AddScoped<AdminService>();
            services.AddScoped<CourseService>();
            services.AddScoped<UserService>();
            services.AddScoped<GradeService>();
            services.AddScoped<SemesterService>();
            services.AddScoped<RoleService>();
            services.AddScoped<EnrollmentService>();
         
        }


    }
}
