namespace NTier.Aviation
{
    internal abstract class AirplanePart
    {

        private double _price;

        public string? PartNumber { get; set; }
        public string? Description { get; set; }
        
        public double Price
        {
            get { return _price; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                else
                {
                    _price = value;
                }
            }
        }
      
    }
}
