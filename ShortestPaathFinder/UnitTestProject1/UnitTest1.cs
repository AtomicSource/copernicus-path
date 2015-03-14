using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
using ShortestPaathfinder;
using System.Diagnostics;
using Rhino.Mocks;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDistance()
        {
            //MockRepository.GenerateStub<IGeoCode> mock;
            double dist = ShortestPaathFinder.Models.IGeocode.CalcDistance(37.4,42.42, 37.9, 42.52);
            //Debug.WriteLine(dist, "distance between points");

            Assert.Equals(dist, 56290.192933584549);
        }
    }
}
