using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budgie;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDoubleBetweenOneAndZero()
        {
            List<double> randomNumbers = Randomizer.RandomDistribution(new Random(),1,50);
            double sum = 0;
            foreach (double number in randomNumbers)
            {
                sum += number;
            }
            Assert.AreEqual(sum, 1);

        }

        [TestMethod]
        public void TestDoubleBetweenOneAndZero2()
        {
            List<double> randomNumbers = Randomizer.RandomDistribution(new Random(), 1, 5);
            double sum = 0;
            foreach (double number in randomNumbers)
            {
                sum += number;
            }
            Assert.AreEqual(sum, 1);

        }
    }
}
