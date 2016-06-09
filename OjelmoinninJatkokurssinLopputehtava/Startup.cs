using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OjelmoinninJatkokurssinLopputehtava.Startup))]
namespace OjelmoinninJatkokurssinLopputehtava
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
