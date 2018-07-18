using Owin;

namespace SRL_Portal_API
{
    public partial class Startup
    {
        /// <summary>
        /// Startup class to set entry point
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
