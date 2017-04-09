using System.Threading;
using CodingMilitia.ProtoActorSample.Messages;
using Proto.Cluster;
using Proto.Cluster.Consul;
using Proto.Remote;

namespace CodingMilitia.ProtoActorSample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Serialization.RegisterFileDescriptor(CodingMilitia.ProtoActorSample.Messages.ProtosReflection.Descriptor);

            Remote.Start("127.0.0.1", 0);
            Cluster.Start("MyCluster", new ConsulProvider(new ConsulProviderOptions()));
            Thread.Sleep(100);
            
            Increment("Actor1");
            Increment("Actor1");
            Increment("Actor2");
            Increment("Actor3");
            Increment("Actor4");
            Increment("Actor1");
            Increment("Actor2");

            System.Console.ReadLine();
        }

        private static void Increment(string actorName)
        {
            var pid = Cluster.GetAsync(actorName, "CounterKind").Result;
            var res = pid.RequestAsync<PlusOneResponse>(new PlusOneRequest()).Result;
            System.Console.WriteLine($"{actorName} incremented {res.CurrentCount} times so far");
        }
    }
}
