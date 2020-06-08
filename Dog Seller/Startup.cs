using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dog_Seller.Startup))]
namespace Dog_Seller
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
