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
        LampRepository lampRepository;
        ProducentRepository producentRepository;
        KoperRepository koperRepository;
        VerkoopRepository verkoopRepository;

        [TestInitialize]
        public void TestInit()
        {
            var options = new DbContextOptionsBuilder<CMSContext>()
            .UseInMemoryDatabase(databaseName: "Test_DB")
            .Options;

            var context = new CMSContext(options);

            lampRepository = new LampRepository(context);
            producentRepository = new ProducentRepository(context);
            verkoopRepository = new VerkoopRepository(context);
            koperRepository = new KoperRepository(context);

        }

        [TestMethod]
        public void ALamp_Add_TrueIsId1()
        {
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
        public void AVerkoop_Add_TrueVerkoopExists()
        {
            lampRepository.GetAll();

            Koper koper = new Koper()
            {
                Naam = "Jan",
                Rekeningnummer = "10",
                Gemeente = "Weert",
                Straat = "Erk",
                Huisnummer = "26",
                PostCode = "3084KI"
            };
            koperRepository.Add(koper);

            Verkoop verkoop = new Verkoop()
            {
                LampId = 1,
                KoperId = 1,
                Aantal = 20
            };
            verkoopRepository.Add(verkoop);
            verkoopRepository.Save();

            Assert.IsTrue(verkoopRepository.GetById(1).Lamp.Model == "Test");

        }

        [TestMethod]
        public async Task BLamp_GetAllLampsByModelAsync_TrueIsLampnaamAsync()
        {
            Lamp lamp = lampRepository.GetById(1);
            string searchstring = lamp.Model;
            var lampen = await lampRepository.GetAllLampsByModelAsync(searchstring);

            Assert.IsTrue(lampen.First().Model == "Test");
        }

        [TestMethod]
        public async Task BVerkoop_GetAllVerkopenByModelAsync_TrueIsVerkoopnaamAsync()
        {
            lampRepository.GetAll();

            Verkoop verkoop = verkoopRepository.GetAll().First();
            string searchstring = verkoop.Lamp.Model;
            var verkopen = await verkoopRepository.GetAllVerkopenByModelAsync(searchstring);

            Assert.IsTrue(verkopen.First().Lamp.Model == "Test");
        }

        [TestMethod]
        public async Task CLamp_GetProducentLampen_TrueIsTestLampAsync()
        {
            var producentLampen = await lampRepository.GetProducentLampen(1);

            Assert.IsTrue(producentLampen.First().Model == "Test");
        }

        [TestMethod]
        public async Task CVerkoop_GetKopersVerkopen_TrueIsTestVerkoopAsync()
        {
            var koperVerkopen = await verkoopRepository.GetKoperAankopen(1);

            Assert.IsTrue(koperVerkopen.First().Lamp.Model == "Test");
        }

        [TestMethod]
        public void DLamp_Edit_NewEditIsTrue()
        {
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
            Lamp lamp = lampRepository.GetAll().First();

            lampRepository.Remove(lamp);
            lampRepository.Save();

            Assert.IsTrue(lampRepository.GetById(1) == null);
        }

    }
}
