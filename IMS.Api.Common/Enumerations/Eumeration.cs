namespace IMS.Api.Common.Enumerations
{
    public class Eumeration
    {
        public enum UserRoleEnum
        {
            SuperAdmin = 1 ,
            Administrator ,
            Company ,
            Supervisior,
            Manager,
            Cashier,
            Customer
        }

        public enum TransactionType
        {
            Cash = 1,
            CreditCard,
            CreditCardVoid,
            CreditCardRefund,
            ACH,
            ACHVoid,
            ACHRefund
        }
        public enum CardType
        {
            NoCard = 0,
            Visa = 1,
            Master
        }
        public enum ProcessorType
        {
            None = 0,
            Stripe = 1
        }


    }
}
