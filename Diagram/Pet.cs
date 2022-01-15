using Panda.Models.Enums;

namespace Panda.Models
{
    public class Pet
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Age { get; set; }

        public Owner Owner { get; set; }

        public string OwnerId { get; set; }

        public Family Family { get; set; }

        public string Note { get; set; }

        public House House { get; set; }

        public string HouseId { get; set; }

        public string Photo { get; set; }
    }
}
