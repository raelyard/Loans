using Autofac;
using NServiceBus;
using NServiceBus.Features;

namespace MediaLoanLIbrary.Loans.Processor
{
    [EndpointName("Loans")]
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseContainer<AutofacBuilder>(customizations => customizations.ExistingLifetimeScope(ConfigureContainer()));

            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableFeature<TimeoutManager>();
        }

        private IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();

            return container;
        }
    }
}
