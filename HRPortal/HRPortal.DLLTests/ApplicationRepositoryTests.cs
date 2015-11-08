//using HRPortal.DLL;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using HRPortal.Models;
//using HRPortal.BLL;

//namespace HRPortal.DLL.Tests
//{
//    [TestFixture]
//    public class ApplicationRepositoryTests
//    {
//        [Test]
//        public void CanLoadAccount()
//        {
//            var repo = new ApplicationRepository();
//            var application = repo.LoadApplication(1);

//            Assert.AreEqual(1, application.AppID);
//            Assert.AreEqual("", application.FirstName);
//        }

//        [Test]
//        public void UpdateApplicationTest()
//        {
//            var repo = new ApplicationRepository();
//            var applicationToUpdate = repo.LoadApplication(1);
//            repo.UpdateApplication(applicationToUpdate);

//            var result = repo.LoadApplication(1);

//            Assert.AreSame("", result.FirstName);
//        }
//    }
//}