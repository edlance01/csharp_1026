using System.Text.RegularExpressions;

namespace NTier.Aviation
{
    internal abstract class AirplanePart
    {

        private double _price;
        private string? _partNumber;
        private static readonly Regex PartNumberRegex = new Regex(@"^[^\s?*]+$");

   
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

        public string PartNumber
        {
            get { return _partNumber; }
            set
            {
                if (string.IsNullOrEmpty(value) || !PartNumberRegex.IsMatch(value))
                {
                   // throw new PartNumberInvalidFormatException($"Part number cannot be null, empty, only spaces, or have ? or *: \"{value ?? "(null)"}\"");
                    throw new PartNumberInvalidFormatException(value);
                }
               
                else
                {
                    _partNumber = value;
                }
            }
        }

        public int Count { get; set; }
        public int Threshold { get; set; }

    }
}
