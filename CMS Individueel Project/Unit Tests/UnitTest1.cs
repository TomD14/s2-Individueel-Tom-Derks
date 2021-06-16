using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS_Individueel_Project.Data;

namespace Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void Lamp_Add_LampToegevoegdTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_Lamp")
                .Options;
            using var context = new ApplicationDbContext(options);
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.LampRepository.Add(new Lamp()
            {
                Model = "Lamp Unit Test"
            });
            unitOfWork.Save();

            var lampen = LampRepository.GetAll();
            var lamp = LampRepository.GetById(lampen.first().Id);

            Assert.istrue(lamp);
        }
    }
}
