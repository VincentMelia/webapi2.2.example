using System.Reflection;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;
using DotVVM.Framework.Controls.Bootstrap;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Runtime.Filters;
using DotVVM.BusinessPack;
using DotVVM.Framework.ViewModel.Validation;
using DotVVM.Framework.Hosting;
namespace webapi2._2.ui
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.AddBootstrapConfiguration(new DotvvmBootstrapOptions
            {
                BootstrapCssUrl = "~/lib/bootstrap/dist/css/bootstrap.min.css",
                BootstrapJsUrl = "~/lib/bootstrap/dist/js/bootstrap.min.js"
            });
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);

            //var assembly = typeof(BusinessPackResources).GetTypeInfo().Assembly;
            //config.Resources.Register(BusinessPackResources.JQueryScript,
            //    new ScriptResource
            //    {
            //        Location = new EmbeddedResourceLocation(assembly, "DotVVM.BusinessPack.Resources.Libs.jquery.min.js") //.min
            //    });

            //config.Resources.Register("test",
            //    new StylesheetResource { Location = new UrlResourceLocation("~/lib/BusinessPack-7.css") });//BusinessPackResources.BusinessPackStyleDefault

        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/logon.dothtml");
            config.RouteTable.Add("TodosWithList", "Todos/{todoListId?}/{displayTodo?}","Views/todos.dothtml");
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));    
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.Register("bootstrap-css", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/dist/css/bootstrap.min.css")
            });
            config.Resources.Register("bootstrap-theme", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/dist/css/bootstrap-theme.min.css"),
                Dependencies = new[] { "bootstrap-css" }
            });
            config.Resources.Register("bootstrap", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/dist/js/bootstrap.min.js"),
                Dependencies = new[] { "bootstrap-css" , "jquery" }
            });
            config.Resources.Register("jquery", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/jquery/dist/jquery.min.js")
            });
        }
		public void ConfigureServices(IDotvvmServiceCollection options)
        {
		
            options.AddBusinessPack();
            options.AddDefaultTempStorages("temp");
		}
    }
}
