namespace IdentityServer
{
    using Config;
    using IdentityServer3.Core.Configuration;
    using Owin;
    using System;
    using System.Security.Cryptography.X509Certificates;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var factory = new IdentityServerServiceFactory()
            //       .UseInMemoryUsers(Users.Get())
            //       .UseInMemoryClients(Clients.Get())
            //       .UseInMemoryScopes(Scopes.Get());

            //var cors = new InMemoryCorsPolicyService(Clients.Get());
            
            //factory.CorsPolicyService = new Registration<ICorsPolicyService>(cors);

            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "Embedded IdentityServer",
                SigningCertificate = LoadCertificate1(),
                //Factory = factory
                Factory = new IdentityServerServiceFactory()
                    .UseInMemoryUsers(Users.Get())
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get())
            });
        }

        //private static X509Certificate2 LoadCertificate()
        //{
        //    return new X509Certificate2(
        //        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Config\idsrv3test.pfx"), "idsrv3test");
        //}

        X509Certificate2 LoadCertificate1()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\\Config\SchoolWebApiCARoot.pfx", AppDomain.CurrentDomain.BaseDirectory), "trinity999");
        }
    }
}