using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using System.Security.Principal;
using System.Web.Security;
using GAtec.Seletivo.Business;
using GAtec.Seletivo.Data;
using GAtec.Seletivo.Domain.Business;
using GAtec.Seletivo.Domain.Repository;
using GAtec.Seletivo.Util;
using GAtec.Seletivo.Util.Validation;
using GAtec.Seletivo.Web.Libs;

namespace GAtec.Seletivo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public UnityContainer Container { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Container = new UnityContainer();

            Container.RegisterType<IExamRepository, ExamRepository>();
            Container.RegisterType<IExamService, ExamService>();
            Container.RegisterType<IQuestionRepository, QuestionRepository>();
            Container.RegisterType<IQuestionService, QuestionService>();
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<IUserService, UserService>();
            Container.RegisterType<IRecruitmentRepository, RecruitmentRepository>();
            Container.RegisterType<IRecruitmentService, RecruitmentService>();
            Container.RegisterType<IValidationError, DefaultValidation>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            // obtem o cookie
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // se o cookie tiver algum valor
                if (!string.IsNullOrEmpty(authCookie.Value))
                {
                    // remove a criptografia do cookie
                    var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    // se deu certo a decriptografia e o cookie nao expirou
                    if (authTicket != null && !authTicket.Expired)
                    {
                        // obtem os dados do usuario
                        var roles = authTicket.UserData.Split(',');

                        var principal = new GenericPrincipal(new FormsIdentity(authTicket), roles);

                        // define um objeto de usuario no contexto da aplicacao
                        HttpContext.Current.User = principal;
                        System.Threading.Thread.CurrentPrincipal = principal;
                    }
                }
            }
        }
    }
}
