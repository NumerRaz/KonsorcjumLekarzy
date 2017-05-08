
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(KonsorcjumLekarzy.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(KonsorcjumLekarzy.App_Start.NinjectWebCommon), "Stop")]

namespace KonsorcjumLekarzy.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                //Repository
                kernel.Bind<IRepository<Doctor>>().To<GenericRepository<Doctor>>();
                kernel.Bind<IRepository<Specialization>>().To<GenericRepository<Specialization>>();
                kernel.Bind<IRepository<Patient>>().To<GenericRepository<Patient>>();
                kernel.Bind<IRepository<ApplicationUser>>().To<GenericRepository<ApplicationUser>>();
                kernel.Bind<IRepository<Visit>>().To<GenericRepository<Visit>>();
                //Services
                kernel.Bind<IGenericService<Doctor>>().To<DoctorService>();
                kernel.Bind<IGenericService<Specialization>>().To<SpecialisationService>();
                kernel.Bind<IGenericService<Patient>>().To<PatientService>();
                kernel.Bind<IGenericService<ApplicationUser>>().To<UserService>();
                kernel.Bind<IGenericService<Visit>>().To<VisitService>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }
}
