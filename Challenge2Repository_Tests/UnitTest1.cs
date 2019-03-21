
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge2;

namespace Challenge2Repository_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimRepository _claimRepo;
        [TestMethod]
        public void TestMethod1()
        {
            Claim claim = new Claim();
            _claimRepo = new ClaimRepository();

            _claimRepo.AddClaimToQueue(claim);
            int expected = 1;
            int actual = _claimRepo.GetClaims().Count;

            Assert.AreEqual(expected, actual);




        }
    }
}
