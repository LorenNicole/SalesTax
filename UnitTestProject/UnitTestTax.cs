using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxWeb.Business;
using System;
using System.Linq;
using System.Reflection;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestTax
    {       
        [TestMethod]
        [DataTestMethod]
        [DataRow(1.23, 1.25)]
        [DataRow(1.00, 1.00)]
        [DataRow(1.26, 1.30)]
        [DataRow(1.19, 1.20)]
        public void TestMethodRoundUp(double cost, double result)
        {
            // Arrange
            decimal originalCost = (decimal)cost;
            var expectedResult = (decimal)result;

            Type type = typeof(ReceiptService);
            var roundUp = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "RoundUp" && x.IsPrivate)
                .First();

            //Act
            var roundingResult = method.Invoke(roundUp, new object[] { originalCost });

            //Assert
            Assert.AreEqual(roundingResult, expectedResult);
        }
    }
}
