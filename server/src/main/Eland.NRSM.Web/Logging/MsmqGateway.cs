using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eland.NRSM.Web.Logging
{
    public class MsmqGateway : Spring.Messaging.Core.MessageQueueGatewaySupport
    {
        public bool Logged { get; set; }

        public void Send(IDictionary<string, object> logMessage)
        {
            MessageQueueTemplate.ConvertAndSend(JsonConvert.SerializeObject(logMessage));
        }
    }
}