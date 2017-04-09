using System;
using System.Threading.Tasks;
using Proto;
using CodingMilitia.ProtoActorSample.Messages;

namespace CodingMilitia.ProtoActorSample.Server
{
    public class CounterActor : IActor
    {
        private static Guid ActorServerInstanceGuid = Guid.NewGuid();
        private int _counter = 0;
        public Task ReceiveAsync(IContext context)
        {
            var msg = context.Message;
            if (msg is PlusOneRequest r)
            {
                ++_counter;
                Console.WriteLine($"Actor on server {ActorServerInstanceGuid} received plus one request, totalling {_counter} requests");
                context.Respond(new PlusOneResponse
                {
                    CurrentCount = _counter
                });
            }
            return Actor.Done;
        }
    }
}