using CMS_Individueel_Project.Data;
using CMS_Individueel_Project.Data.Data.Repositories;
using CMS_Individueel_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void TestInit()
        {
            var options = new DbContextOptionsBuilder<CMSContext>()
            .UseInMemoryDatabase(databaseName: "Test_DB")
            .Options;

            using var context = new CMSContext(options);
        }

        [TestMethod]
        public void ALamp_Add_TrueIsId1()
        {
            LampRepository lampRepository;
            ProducentRepository producentRepository;

            producentRepository = new ProducentRepository(context);
            lampRepository = new LampRepository(context);

            Producent producent = new Producent()
            {
                Naam = "Phillips",
                Rekeningnummer = "60",
                Gemeente = "Budel",
                Straat = "Berk",
                Huisnummer = "14B",
                PostCode = "2060NJ" 

            };
            producentRepository.Add(producent);


            Lamp lamp = new Lamp()
            {
                Model = "Test",
                Watt = 30,
                Kleur = 30,
                Prijs = 4,
                ProducentId = 1,
                Aantal = 5

            };

            lampRepository.Add(lamp);
            lampRepository.Save();

            Assert.IsTrue(lampRepository.GetById(1) != null);
        }

        [TestMethod]
        public async Task BLamp_GetAllLampsByModelAsync_TrueIsLampnaamAsync()
        {
            LampRepository lampRepository;

            var options = new DbContextOptionsBuilder<CMSContext>()
            .UseInMemoryDatabase(databaseName: "Test_DB")
            .Options;

            using var context = new CMSContext(options);

            lampRepository = new LampRepository(context);

            Lamp lamp = lampRepository.GetById(1);
            string searchstring = lamp.Model;
            var lampen = await lampRepository.GetAllLampsByModelAsync(searchstring);

            Assert.IsTrue(lampen.First().Model == "Test");
        }

        [TestMethod]
        public async Task CLamp_GetProducentLampen_TrueIsTestLampAsync()
        {
            LampRepository lampRepository;

            var options = new DbContextOptionsBuilder<CMSContext>()
            .UseInMemoryDatabase(databaseName: "Test_DB")
            .Options;

            using var context = new CMSContext(options);

            lampRepository = new LampRepository(context);

            Lamp lamp = lampRepository.GetAll().First();

            var producentLampen = await lampRepository.GetProducentLampen(1);

            Assert.IsTrue(producentLampen.First().Model == "Test");
        }

        [TestMethod]
        public void DLamp_Edit_NewEditIsTrue()
        {
            LampRepository lampRepository;

            var options = new DbContextOptionsBuilder<CMSContext>()
            .UseInMemoryDatabase(databaseName: "Test_DB")
            .Options;

            using var context = new CMSContext(options);

            lampRepository = new LampRepository(context);

            const int resultWatt = 50;

            Lamp lamp = lampRepository.GetAll().First();
            lamp.Watt = resultWatt;

            lampRepository.Update(lamp);
            lampRepository.Save();

            Assert.IsTrue(lampRepository.GetById(lamp.Id).Watt == 50);
        }


        [TestMethod]
        public void ELamp_Delete_TrueIsNull()
        {
            LampRepository lampRepository;

            var options = new DbContextOptionsBuilder<CMSContext>()
            .UseInMemoryDatabase(databaseName: "Test_DB")
            .Options;

            using var context = new CMSContext(options);

            lampRepository = new LampRepository(context);

            Lamp lamp = lampRepository.GetAll().First();

            lampRepository.Remove(lamp);
            lampRepository.Save();

            Assert.IsTrue(lampRepository.GetById(1) == null);
        }

    }
}
