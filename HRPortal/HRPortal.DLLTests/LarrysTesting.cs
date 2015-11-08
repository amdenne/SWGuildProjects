//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using HRPortal.BLL;
//using HRPortal.DLL;
//using HRPortal.Models;

//namespace HRPortal.DLLTests
//{
//    [TestFixture]
//    public class ApplicationRepositoryTests
//    {
//        [Test]
//        public void CreateOrderTest()
//        {
//            var manager = new ApplicationManager();
//            Application application = new Application();

//            application.AppID = 1;
//            application.FirstName = "Larry";
//            application.LastName = "Powell";
//            application.PhoneNumber = "1112223333";
//            application.Address = "1111 Fake RD";
//            application.City = "Louisville";
//            application.State = "KY";
//            application.Zip = "47129";

//            var response = manager.CreateApplication(application);

//            Assert.IsTrue(response.Success);
//            Assert.AreEqual(1, application.AppID);

//        }

//        [Test]
//        public void CanLoadAccount()
//        {
//            var repo = new ApplicationRepository();
//            var application = repo.LoadApplication(1);

//            Assert.AreEqual(1, application.AppID);
//            Assert.AreEqual("Larry", application.FirstName);
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
