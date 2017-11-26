using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using AndersonExamData;
using AndersonExamFunction;

namespace AndersonExamWeb.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            #region Data
            container.RegisterType<IDAnswer, DAnswer>(new PerRequestLifetimeManager());
            container.RegisterType<IDChoice, DChoice>(new PerRequestLifetimeManager());
            container.RegisterType<IDChoiceImage, DChoiceImage>(new PerRequestLifetimeManager());
            container.RegisterType<IDExamPosition, DExamPosition>(new PerRequestLifetimeManager());
            container.RegisterType<IDExam, DExam>(new PerRequestLifetimeManager());
            container.RegisterType<IDExaminee, DExaminee>(new PerRequestLifetimeManager());
            container.RegisterType<IDPosition, DPosition>(new PerRequestLifetimeManager());
            container.RegisterType<IDQuestion, DQuestion>(new PerRequestLifetimeManager());
            container.RegisterType<IDQuestionImage, DQuestionImage>(new PerRequestLifetimeManager());
            container.RegisterType<IDTakenExam, DTakenExam>(new PerRequestLifetimeManager());
            #endregion

            #region Function
            container.RegisterType<IFAnswer, FAnswer>(new PerRequestLifetimeManager());
            container.RegisterType<IFChoice, FChoice>(new PerRequestLifetimeManager());
            container.RegisterType<IFChoiceImage, FChoiceImage>(new PerRequestLifetimeManager());
            container.RegisterType<IFExamPosition, FExamPosition>(new PerRequestLifetimeManager());
            container.RegisterType<IFExam, FExam>(new PerRequestLifetimeManager());
            container.RegisterType<IFExaminee, FExaminee>(new PerRequestLifetimeManager());
            container.RegisterType<IFPosition, FPosition>(new PerRequestLifetimeManager());
            container.RegisterType<IFQuestion, FQuestion>(new PerRequestLifetimeManager());
            container.RegisterType<IFQuestionImage, FQuestionImage>(new PerRequestLifetimeManager());
            container.RegisterType<IFTakenExam, FTakenExam>(new PerRequestLifetimeManager());
            #endregion
        }
    }
}
