using IMS.Api.Common.Model.DataModel;
using static IMS.Api.Common.Enumerations.Eumeration;

namespace IMS.Api.Gateway
{
    public class GatewayFactory
    {
        public static IProcessor GetProcessor(ProcessorConfiguration processorConfiguration)
        {
            int ProcessorId = processorConfiguration != null ? processorConfiguration.ProcessorId : 0;
            switch (ProcessorId)
            {
                case (int)ProcessorType.Stripe:
                    return new Stripe.Stripe(processorConfiguration?.ConfigData);
                default:
                    return new Stripe.Stripe(processorConfiguration?.ConfigData);
            }

        }
    }
}
