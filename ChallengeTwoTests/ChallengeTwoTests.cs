using ChallengeTwoRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwoTests
{
    [TestClass]
    public class ChallengeTwoTests
    {
        private ClaimRepository _claimRepo;

        [TestInitialize]
        public void Initialize()
        {
            _claimRepo = new ClaimRepository();
        }
        [TestMethod]
        public void AddClaimToQueue_ShouldReturnTrue()
        {
            Claim claim = new Claim();
            bool addClaimResult = _claimRepo.AddClaimToQueue(claim);
            Assert.IsTrue(addClaimResult);
        }

        [TestMethod]
        public void GetAllClaims_ShouldReturnTrue()
        {
            List<Claim> claimList = _claimRepo.GetAllClaims();
            Assert.IsInstanceOfType(claimList, typeof(List<Claim>));
        }

        [TestMethod]
        public void ClaimIDExists_ShouldReturnTrue()
        {
            Claim claim = new Claim(3, ClaimType.Theft, "nothing", 4m, DateTime.Now, DateTime.Now);
            _claimRepo.AddClaimToQueue(claim);
            bool claimExists = _claimRepo.ClaimIDExists(3);
            Assert.IsTrue(claimExists);
        }

        [TestMethod]
        public void GetNextClaim()
        {
            Claim claim1 = new Claim(3, ClaimType.Theft, "nothing", 4m, DateTime.Now, DateTime.Now);
            Claim claim2 = new Claim(5, ClaimType.Home, "nothing", 4m, DateTime.Now, DateTime.Now);
            _claimRepo.AddClaimToQueue(claim1);
            _claimRepo.AddClaimToQueue(claim2);
            Claim calledClaim = _claimRepo.GetNextClaim();
            Console.WriteLine(calledClaim.ClaimID);
            Assert.AreEqual(3, calledClaim.ClaimID);
        }

        [TestMethod]
        public void DeleteClaim()
        {
            Claim claim1 = new Claim(3, ClaimType.Theft, "nothing", 4m, DateTime.Now, DateTime.Now);
            Claim claim2 = new Claim(5, ClaimType.Home, "nothing", 4m, DateTime.Now, DateTime.Now);
            _claimRepo.AddClaimToQueue(claim1);
            _claimRepo.AddClaimToQueue(claim2);
            bool claimDeleted = _claimRepo.DeleteClaim(claim1);
            Assert.IsTrue(claimDeleted);
        }
    }
}
