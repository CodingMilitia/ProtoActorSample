using System;
using Proto;
using Proto.Cluster;
using Proto.Cluster.Consul;
using Proto.Remote;

namespace CodingMilitia.ProtoActorSample.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Serialization.RegisterFileDescriptor(CodingMilitia.ProtoActorSample.Messages.ProtosReflection.Descriptor);
            var props = Actor.FromProducer(() => new CounterActor());

            Remote.RegisterKnownKind("CounterKind", props);
            Remote.Start("127.0.0.1", 0);
            Cluster.Start("MyCluster", new ConsulProvider(new ConsulProviderOptions()));

            Console.ReadLine();
        }
    }
}
