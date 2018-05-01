using Course.Data;
using Course.Service;
using System;
using Unity;

namespace Course.API
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container

        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;

        #endregion Unity Container

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ICourseService, CourseService>();
            container.RegisterType<ICourseRepository, CourseRepository>();
        }
    }
}