using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.IO;
using System.Windows;
using ubys_app.Data;
using ubys_app.MVVM.ViewModel;
using ubys_app.Services;
using ubys_app.Stores;

namespace ubys_app
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            // Stores
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();
            services.AddSingleton<AdminBarStore>();
            services.AddSingleton<StudentBarStore>();
            services.AddSingleton<TeacherBarStore>();

            // DbContext
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "ubysDatabase.db3");
            services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data source={dbPath}"));

            // Services
            services.AddScoped<StudentService>();
            services.AddScoped<TeacherService>();
            services.AddScoped<AdminService>();
            services.AddScoped<CourseService>();
            services.AddScoped<UserService>();
            services.AddScoped<GradeService>();
            services.AddScoped<SemesterService>();
            services.AddScoped<RoleService>();
            services.AddScoped<EnrollmentService>();

            // ViewModels
            services.AddSingleton<LoginPageViewModel>();
            services.AddSingleton<MainVM>();

            services.AddSingleton<AddAdminViewModel>();
            services.AddSingleton<AddStudentViewModel>();
            services.AddSingleton<AddTeacherViewModel>();
            services.AddSingleton<AddCourseViewModel>();
            services.AddSingleton<CourseSelectionViewModel>();
            services.AddSingleton<ExamScheduleViewModel>();
            services.AddSingleton<MyCoursesViewModel>();
            services.AddSingleton<EditNoteViewModel>();
            services.AddSingleton<StudentsViewModel>();

            services.AddSingleton<AdminHomeVM>(s => new AdminHomeVM(CreateAdminHomeNavigationService(s)));
            services.AddSingleton<StudentHomeViewModel>(s => new StudentHomeViewModel(CreateStudentHomeNavigationService(s)));
            services.AddSingleton<TeacherHomeVM>(s => new TeacherHomeVM(CreateTeacherHomeNavigationService(s)));

            services.AddSingleton<AdminLayoutVM>();
            services.AddSingleton<StudentLayoutVM>();
            services.AddSingleton<TeacherLayoutVM>();

            services.AddSingleton<AdminNavigationBarVM>(CreateAdminNavigationBarVM);
            services.AddSingleton<NavigationStudentBarViewModel>(CreateStudentNavigationBarVM);
            services.AddSingleton<NavigationTeacherBarViewModel>(CreateTeacherNavigationBarVM);

            // Navigation Services
            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));

            // Windows
            services.AddSingleton<MainWindow>(s => new MainWindow
            {
                DataContext = s.GetRequiredService<MainVM>()
            });

            _serviceProvider = services.BuildServiceProvider();
            EnsureDatabaseCreated();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        private void EnsureDatabaseCreated()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
            }
        }

        // Navigation Services

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<LoginPageViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginPageViewModel>());
        }

        private INavigationService CreateAdminHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<AdminHomeVM>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AdminHomeVM>());
        }

        private INavigationService CreateStudentHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<StudentHomeViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<StudentHomeViewModel>());
        }

        private INavigationService CreateTeacherHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<TeacherHomeVM>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<TeacherHomeVM>());
        }

        private INavigationService CreateAddCourseNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<AddCourseViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AddCourseViewModel>());
        }

        private INavigationService CreateAddTeacherNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<AddTeacherViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AddTeacherViewModel>());
        }

        private INavigationService CreateAddAdminNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<AddAdminViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AddAdminViewModel>());
        }

        private INavigationService CreateCourseSelectionStatusNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<CourseSelectionViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<CourseSelectionViewModel>());
        }

        private INavigationService CreateLogoutNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<LoginPageViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginPageViewModel>());
        }

        private INavigationService CreateMyCoursesNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<MyCoursesViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MyCoursesViewModel>());
        }

        private INavigationService CreateCourseSelectionNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<CourseSelectionViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<CourseSelectionViewModel>());
        }

        private INavigationService CreateExamScheduleNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ExamScheduleViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ExamScheduleViewModel>());
        }

        private INavigationService CreateTeacherMyCoursesNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<MyCoursesViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MyCoursesViewModel>());
        }

        private INavigationService CreateEditNoteNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<EditNoteViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<EditNoteViewModel>());
        }

        private INavigationService CreateStudentsNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<StudentsViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<StudentsViewModel>());
        }

        // NavigationBar ViewModel Factories

        private AdminNavigationBarVM CreateAdminNavigationBarVM(IServiceProvider serviceProvider)
        {
            return new AdminNavigationBarVM(
                serviceProvider.GetRequiredService<AdminBarStore>(),
                CreateAdminHomeNavigationService(serviceProvider),
                CreateAddCourseNavigationService(serviceProvider),
                CreateAddTeacherNavigationService(serviceProvider),
                CreateAddAdminNavigationService(serviceProvider),
                CreateCourseSelectionStatusNavigationService(serviceProvider),
                CreateLogoutNavigationService(serviceProvider));
        }

        private NavigationStudentBarViewModel CreateStudentNavigationBarVM(IServiceProvider serviceProvider)
        {
            return new NavigationStudentBarViewModel(
                serviceProvider.GetRequiredService<StudentBarStore>(),
                CreateStudentHomeNavigationService(serviceProvider),
                CreateMyCoursesNavigationService(serviceProvider),
                CreateCourseSelectionNavigationService(serviceProvider),
                CreateExamScheduleNavigationService(serviceProvider),
                CreateLogoutNavigationService(serviceProvider));
        }

        private NavigationTeacherBarViewModel CreateTeacherNavigationBarVM(IServiceProvider serviceProvider)
        {
            return new NavigationTeacherBarViewModel(
                serviceProvider.GetRequiredService<TeacherBarStore>(),
                CreateTeacherHomeNavigationService(serviceProvider),
                CreateTeacherMyCoursesNavigationService(serviceProvider),
                CreateEditNoteNavigationService(serviceProvider),
                CreateStudentsNavigationService(serviceProvider),
                CreateLogoutNavigationService(serviceProvider));
        }
    }
}