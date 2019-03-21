using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{ 
    public enum ClaimType
    {
        car,home , theft
    }
   public class Claim
    {
        public string ClaimID { get; set; }
        public ClaimType
           ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim () { }
        public Claim(string claimID ,ClaimType claimType, string description , decimal claimAmount, DateTime dateofincident , DateTime dateofclaim, bool isValid )
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateofincident;
            DateOfClaim = dateofclaim;
            IsValid = isValid;
        }
    }
}
