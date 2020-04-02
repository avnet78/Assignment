using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using UserSignUp.BusinessServices.Implementation;
using UserSignUp.BusinessServices.Inteface;
using UserSignUp.BusinessServices.Repository.Implementation;
using UserSignUp.BusinessServices.Repository.Interface;

namespace UserSignUp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            RegisterServices(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static void RegisterServices(UnityContainer container)
        {
            container.RegisterType<IRegistrationService, RegistrationService>();
            container.RegisterType<IUserRepository, UserRepository>();
        }
    }
}