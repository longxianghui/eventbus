using System;
using System.Data;
using System.Threading.Tasks;

namespace EventBus
{
    /// <summary>
    /// A publish service for publish a message.
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        ///  不带事务发布消息
        /// </summary>
        /// <typeparam name="T">The type of content object.</typeparam>
        /// <param name="name">the topic name or exchange router key.</param>
        /// <param name="contentObj">message body content, that will be serialized of json.</param>
        void Publish<T>(string name, T contentObj) where T : class;
        /// <summary>
        /// 不带事务订阅消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="handler"></param>
        void Subscribe<T>(string name, Action<T> handler) where T : class;
    }
}