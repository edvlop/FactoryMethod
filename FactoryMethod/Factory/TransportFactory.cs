using FactoryMethod.Enums;
using FactoryMethod.Transports;

namespace FactoryMethod.Factory
{
    public class TransportFactory : ITransportFactory
    {
        private readonly Dictionary<TransportType, Func<ITransport>> transports;

        public TransportFactory()
        {
            transports = new();
        }

        public ITransport CreateTransport(TransportType transportType)
        {
            Func<ITransport> funcion = transports[transportType];

            ITransport transport = funcion();

            return transport;
        }


        public void RegisterTransport(TransportType transportType, Func<ITransport> factoryMethod)
        {
            transports.Add(transportType, factoryMethod);
        }

        public class ProgramTest
        {
            public void Main()
            {
                TransportFactory  factory = new TransportFactory();

                factory.RegisterTransport(TransportType.Sea, () => new Ship());
                factory.RegisterTransport(TransportType.Road, () => new Truck());

                ITransport transport = factory.CreateTransport(TransportType.Sea);

            }
        }
    }
}
