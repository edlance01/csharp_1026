using System;
using System.Collections.Generic;
using System.Text;

namespace NTier.Aviation
{
    internal class PartNumberInvalidFormatException : Exception
    {

        //property for bad data for the challenge
        public string? InvalidPartNumber { get;}

        public PartNumberInvalidFormatException() : base("Invalide part number format.") { }
        public PartNumberInvalidFormatException(string partNumber) : 
            base($"Invalid part number format: {partNumber}") 
        {
            InvalidPartNumber = partNumber;
        }

        public PartNumberInvalidFormatException(string message, Exception innerException) : base(message, innerException) { }

    }
}
