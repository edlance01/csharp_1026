namespace NTier.Aviation
{
    internal abstract class AirplanePart
    {

        public string? PartNumber { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

        public virtual string GetPartInfo()
        {
            return $"Part Number: {PartNumber}\nDescription: {Description}\nPrice: {Price:C}";
        }
    }
}
