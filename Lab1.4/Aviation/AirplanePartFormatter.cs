namespace NTier.Aviation
{
    internal class AirplanePartFormatter
    {
        // The base method that knows how to format the core part data
        public virtual string GetPartInfo(AirplanePart part)
        {
            return $"Part Number: {part.PartNumber}\nDescription: {part.Description}\nPrice: {part.Price:C}";
        }
      
    }
}