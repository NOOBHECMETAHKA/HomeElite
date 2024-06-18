using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows;
using System.Reflection.Emit;
using System.Windows.Media.Media3D;
using NUnit.Framework;

namespace HomeWorkFishingElite
{
    [TestFixture]
    public class MainFunctionForHomeFishingEliteTest
    {
        [Test]
        public void hashStringByMD5Test2()
        {
            MainFunctionForHomeFishingElite testFunctionForHomeFishingElite = new MainFunctionForHomeFishingElite();
            string login = "Admin";
            string hashLogin = "E3AFED0047B08059D0FADA10F400C1E5";
            Assert.That(Equals(testFunctionForHomeFishingElite.hashStringByMD5(login), hashLogin));
        }

        [Test]
        public void authUserByLoginAndPasswordAndGetJobList2()
        {
            MainFunctionForHomeFishingElite testFunctionForHomeFishingElite = new MainFunctionForHomeFishingElite();
            string login = "Admin";
            string password = "Password123";

            List<HomeWorkFishingElite.responsbilities> jobs = testFunctionForHomeFishingElite.authUserByLoginAndPassword(login, password);

            Assert.That(Equals(jobs.Count > 0, true));
        }

        [Test]
        public void getCategoryList2()
        {
            MainFunctionForHomeFishingElite testFunctionForHomeFishingElite = new MainFunctionForHomeFishingElite();
            List<HomeWorkFishingElite.category> categories = testFunctionForHomeFishingElite.getCategory();
            Assert.That(Equals(categories != null, true));
        }
    }
}
