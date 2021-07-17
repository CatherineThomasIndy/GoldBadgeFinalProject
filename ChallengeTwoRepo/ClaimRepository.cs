using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepo
{
    public class ClaimRepository
    {
        List<Claim> _listOfClaims = new List<Claim>();
        public bool AddClaimToQueue(Claim claim)
        {
            int initialClaimsCount = _listOfClaims.Count();
            _listOfClaims.Add(claim);
            if (_listOfClaims.Count() == initialClaimsCount + 1)
            {
                return true;
            }
            else return false;
        }
        public List<Claim> GetAllClaims()
        {
            return _listOfClaims;
        }
        public bool ClaimIDExists(int claimID)
        {
            foreach(Claim claim in _listOfClaims)
            {
                if (claim.ClaimID == claimID)
                {
                    return true;
                }
            }
            return false;
        }
        public Claim GetNextClaim()
        {
            var firstClaim = _listOfClaims.FirstOrDefault();
            return firstClaim;
        }
        public bool DeleteClaim(Claim claim)
        {
            _listOfClaims.Remove(claim);
            if (_listOfClaims.Contains(claim))
            {
                return false;
            }
            else return true;
        }
    }
}
