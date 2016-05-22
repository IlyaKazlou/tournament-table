using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TournamentTable.Data.Repository;

namespace TournamentTable.App_Start
{
    public static class AutofacConfig
    {
        public static void Register() 
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // регистрируем споставление типов
            builder.RegisterType<TournamentRepository>().As<ITournamentRepository>().InstancePerHttpRequest();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}