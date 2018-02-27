using System;
using System.Collections.Generic;
using System.Text;
using Foundatio.Messaging;

namespace EventBus
{
    public class RabbitMQEventBus : IEventBus
    {


        public void Publish<T>(string name, T contentObj) where T : class
        {
            IMessageBus messageBus = new RabbitMQMessageBus(new RabbitMQMessageBusOptions { ConnectionString = "amqp://192.168.180.128", Topic = "aaa", ExchangeName = name });
            messageBus.PublishAsync<T>(contentObj);
        }

        public void Subscribe<T>(string name, Action<T> handler) where T : class
        {
            IMessageBus messageBus = new RabbitMQMessageBus(new RabbitMQMessageBusOptions { ConnectionString = "amqp://192.168.180.128", Topic = "aaa", ExchangeName = name });
            messageBus.SubscribeAsync<T>(handler);

        }
    }
}
