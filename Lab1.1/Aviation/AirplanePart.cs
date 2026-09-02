namespace NTier.Aviation
{
    internal class AirplanePart
    {

        public string? PartNumber { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        
        public string GetPartInfo()
        {
            return $"Part Number: {PartNumber}\nDescription: {Description}\nPrice: {Price:C}";
        }
    }
    
}
