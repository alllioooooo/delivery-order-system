namespace Domain.Models.Orders;

    public class OrderBuilder : Order
    {

        public OrderBuilder SetSenderCity(string senderCity)
        {
            if (string.IsNullOrWhiteSpace(senderCity))
                throw new ArgumentException("Sender City cannot be empty.");
            SenderCity = senderCity;
            return this;
        }

        public OrderBuilder SetSenderAddress(string senderAddress)
        {
            if (string.IsNullOrWhiteSpace(senderAddress))
                throw new ArgumentException("Sender Address cannot be empty.");
            SenderAddress = senderAddress;
            return this;
        }

        public OrderBuilder SetReceiverCity(string receiverCity)
        {
            if (string.IsNullOrWhiteSpace(receiverCity))
                throw new ArgumentException("Receiver City cannot be empty.");
            ReceiverCity = receiverCity;
            return this;
        }

        public OrderBuilder SetReceiverAddress(string receiverAddress)
        {
            if (string.IsNullOrWhiteSpace(receiverAddress))
                throw new ArgumentException("Receiver Address cannot be empty.");
            ReceiverAddress = receiverAddress;
            return this;
        }

        public OrderBuilder SetWeight(double weight)
        {
            if (weight <= 0)
                throw new ArgumentException("Weight must be greater than zero.");
            Weight = weight;
            return this;
        }

        public OrderBuilder SetPickupDate(DateTime pickupDate)
        {
            if (pickupDate == default)
                throw new ArgumentException("Pickup date must be valid.");
            PickupDate = pickupDate;
            return this;
        }
        
        public Order Build()
        {
            if (string.IsNullOrWhiteSpace(SenderCity) ||
                string.IsNullOrWhiteSpace(SenderAddress) ||
                string.IsNullOrWhiteSpace(ReceiverCity) ||
                string.IsNullOrWhiteSpace(ReceiverAddress) ||
                Weight <= 0 ||
                PickupDate == default)
            {
                throw new InvalidOperationException("Cannot build order, all fields must be set correctly.");
            }

            OrderId = Guid.NewGuid().ToString();

            return this;
        }
    }