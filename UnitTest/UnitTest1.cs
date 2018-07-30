using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidMLKeys;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Validacao CheckKeys = new Validacao();

        public static void Main() { }
        [TestMethod]

        public void TestMethod1()
        {
            string userID = "8768311780571816";
            String userKey = "amQVgJTc8Or6wnkQa0PLHoq6jIbidsxN";

            var retorno = CheckKeys.CheckKeys(userID, userKey);

            Assert.IsTrue(retorno); // Assert.IsFalse(retorno);

        }
    }
}
