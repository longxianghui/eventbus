using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace EventBus
{
    public class KafkaEventBus : IEventBus
    {
        private KafkaOptions _kafkaOptions;


        public KafkaEventBus(KafkaOptions kafkaOptions)
        {
            _kafkaOptions = kafkaOptions;

        }

        public void Publish<T>(string name, T contentObj) where T : class
        {
            using (var producer = new Producer(_kafkaOptions.AsKafkaConfig()))
            {
                var contentBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(contentObj));
                producer.ProduceAsync(name, null, contentBytes);
                producer.Flush(TimeSpan.FromSeconds(10));
            }
        }

        public void Subscribe<T>(string name, Action<T> handler) where T : class
        {
            
            using (var consumer = new Consumer<Null, string>(_kafkaOptions.AsKafkaConfig(), null, new StringDeserializer(Encoding.UTF8)))
            {
                //handler怎么传进来
                consumer.OnMessage += (_, msg) =>
                {

                };      ;
                consumer.Subscribe(name);
            }
        }

     
    }
}
