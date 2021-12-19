using Panda.Models.Enums;

namespace Panda.Models
{
    public class House
    {
        public string Id { get; set; }

        public int Number { get; set; }

        public double Price { get; set; }

        public Family Family { get; set; }

        public double SizeLength { get; set; }

        public double SizeWidth { get; set; }

        public double SizeHeight { get; set; }

        public HouseStatus Status { get; set; }
    }
}
