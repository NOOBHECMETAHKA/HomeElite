using HomeWorkFishingElite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HomeWorkFishingEliteTest
{
    [TestClass]
    public class MainFunctionForHomeFishingEliteTest
    {

        [TestMethod]
        public void hashStringByMD5Test()
        {
            MainFunctionForHomeFishingElite testFunctionForHomeFishingElite = new MainFunctionForHomeFishingElite();
            string login = "Admin";
            string hashLogin = "E3AFED0047B08059D0FADA10F400C1E5";
            Assert.AreEqual(testFunctionForHomeFishingElite.hashStringByMD5(login), hashLogin);  
        }

        [TestMethod]
        public void authUserByLoginAndPasswordAndGetJobList()
        {
            MainFunctionForHomeFishingElite testFunctionForHomeFishingElite = new MainFunctionForHomeFishingElite();
            string login = "Admin";
            string password = "Password123";

            List<HomeWorkFishingElite.responsbilities> jobs = testFunctionForHomeFishingElite.authUserByLoginAndPassword(login, password);

            Assert.IsTrue(jobs.Count > 0);
        }

        [TestMethod]
        public void getCategoryList()
        {
            MainFunctionForHomeFishingElite testFunctionForHomeFishingElite = new MainFunctionForHomeFishingElite();
            List<HomeWorkFishingElite.category> categories = testFunctionForHomeFishingElite.getCategory();
            Assert.IsNotNull(categories);
        }
    }
}
