using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(carbon_calculator.Startup))]
namespace carbon_calculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
