using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1911061027_DoTrongThuong_BigSchool.Startup))]
namespace _1911061027_DoTrongThuong_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
