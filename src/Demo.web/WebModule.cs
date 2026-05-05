using Autofac;
using Demo.web.Codes;

namespace Demo.web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        public WebModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ImprovedMembership>().As<IMembership>();
            //builder.RegisterType<ImprovedMembership>().As<IMembership>().InstancePerLifetimeScope(); // add scoped
            //builder.RegisterType<ImprovedMembership>().As<IMembership>().SingleInstance(); // add singleton
            //builder.RegisterType<ImprovedMembership>().As<IMembership>().InstancePerDependency(); // addTransient
            //builder.RegisterType<ImprovedMembership>().As<IMembership>().InstancePerDependency().WithParameter("name", "asp dot net");

            base.Load(builder);
        }
    }
}
