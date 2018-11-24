using Autofac;
using Shuttle.Core.Autofac;
using Shuttle.Core.ServiceHost;
using Shuttle.Esb;

namespace InternetScanner.Bus
{
	public class Host : IServiceHost
	{
		private IServiceBus _bus;

		public void Start()
		{
			var containerBuilder = new ContainerBuilder();
			var registry = new AutofacComponentRegistry(containerBuilder);

			ServiceBus.Register(registry);

			var resolver = new AutofacComponentResolver(containerBuilder.Build());

			_bus = ServiceBus.Create(resolver).Start();
		}

		public void Stop()
		{
			_bus.Dispose();
		}
	}
}
