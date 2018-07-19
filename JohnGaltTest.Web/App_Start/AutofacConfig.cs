using Autofac;
using Autofac.Integration.Mvc;
using JohnGaltTest.Data;
using JohnGaltTest.Data.Repository;
using JohnGaltTest.Services.Series;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JohnGaltTest.Web
{
    public class AutofacConfig
    {
	  public static void Register()
	  {
		var containerBuilder = new ContainerBuilder();

		containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);

		containerBuilder.RegisterFilterProvider();

		containerBuilder.RegisterSource(new ViewRegistrationSource());

		RegisterServices(containerBuilder);
		RegisterRepositories(containerBuilder);
		RegisterDbConnection(containerBuilder);

		var container = containerBuilder.Build();

		DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
	  }

	  private static void RegisterRepositories(ContainerBuilder containerBuilder)
	  {
		containerBuilder.RegisterType<HierarchyRepository>().AsImplementedInterfaces();
	  }

	  private static void RegisterDbConnection(ContainerBuilder containerBuilder)
	  {
		containerBuilder.Register<IDbConnection>((context) =>
		{
		    return new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
		});
	  }

	  private static void RegisterServices(ContainerBuilder containerBuilder)
	  {
		containerBuilder.RegisterType<HierarchyProvider>().AsImplementedInterfaces();
	  }
    }
}