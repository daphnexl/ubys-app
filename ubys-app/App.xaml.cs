using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using ubys_app.Data;
using System.IO;
using System.Windows;
using ubys_app.MVVM.ViewModel;
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
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "ubysDatabase.db3");
            services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data source={dbPath}"));
            services.AddScoped<StudentService>();
            services.AddScoped<TeacherService>();
            services.AddScoped<AdminService>();
            services.AddScoped<CourseService>();
            services.AddScoped<UserService>();
            services.AddScoped<GradeService>();
            services.AddScoped<SemesterService>();
            services.AddScoped<RoleService>();
            services.AddScoped<EnrollmentService>();

            services.AddSingleton<MainVM>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainVM>()
            });
            serviceProvider = services.BuildServiceProvider();
            EnsureDataBaseCreated();


        }
        protected override void OnStartup(StartupEventArgs e)
        {
            //var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            //mainWindow.Show();
            //base.OnStartup(e);
        }
        private void EnsureDataBaseCreated()
        {
            using (var scope = serviceProvider.CreateScope())
            {

                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
            }


        }
    }
}