using Panda.Models.Enums;

namespace Panda.Models
{
    public class Order
    {
        public string Id { get; set; }
        
        public DateTime RegistrationTime { get; set; }

        public string OwnerFullName { get; set; }

        public string OwnerPhoneNumber { get; set; }

        public string PetName { get; set; }

        public Family Family { get; set; }

        public DateTime CheckInDate { get; set; }

        public int DurationDays { get; set; }

        public OrderStatus Status { get; set; }

        public House House { get; set; }

        public string HouseId { get; set; }

        public double Total => House.Price * DurationDays;
    }
}
