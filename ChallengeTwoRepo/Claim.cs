using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepo
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        {
            get
            {
                TimeSpan interval = DateOfClaim - DateOfAccident;
                if (interval.TotalDays > 30) { return false; }
                else return true;
            }
        }
        public Claim() { }
        public Claim(int claimID, ClaimType claimType, string description, decimal amount, DateTime dateOfAccident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
        }
    }
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
}
