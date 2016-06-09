using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OhjelmoinninJatkokurssinLopputehtava.Startup))]
namespace OhjelmoinninJatkokurssinLopputehtava
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
