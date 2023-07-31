using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common
{
    public class ECommerceConstants
    {
        public const string RabbitMQHost = "DESKTOP-S7T0RAS";
        public const string DefaultExchangeType = "direct";

        public const string UserExchangeName = "UserExchange";
        public const string UserEmailChangeQueueName = "UserEmailChangeQueue";
    }
}
