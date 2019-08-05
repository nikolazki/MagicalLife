﻿using System.Collections.Generic;
using MLAPI.Networking.Serialization;

namespace MLAPI.Networking.Client
{
    /// <summary>
    /// Handles client side message processing.
    /// </summary>
    public static class ClientProcessor
    {
        /// <summary>
        /// Key: The ID of the message to be handled.
        /// Value: The handler for that ID.
        /// </summary>
        private static Dictionary<NetMessageId, MessageHandler> MessageHandlers = new Dictionary<NetMessageId, MessageHandler>();

        internal static void Initialize(List<MessageHandler> handlers)
        {
            foreach (MessageHandler item in handlers)
            {
                AddHandler(item);
            }
        }

        public static void Process(BaseMessage msg)
        {
            MessageHandlers.TryGetValue(msg.Id, out MessageHandler handler);
            handler.HandleMessage(msg);
        }

        /// <summary>
        /// Properly adds a message handler.
        /// </summary>
        /// <param name="handler"></param>
        public static void AddHandler(MessageHandler handler)
        {
            MessageHandlers.Add(handler.MessageId, handler);
        }
    }
}