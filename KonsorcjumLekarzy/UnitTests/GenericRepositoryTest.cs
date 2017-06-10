using System.Linq;
using System.Web.Mvc;
using KonsorcjumLekarzy.Areas.Administration.Controllers;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class GenericRepositoryTest
    {
        private IRepository<Specialization> mainRepository;
        private IGenericService<Specialization> mainServices;

        [TestInitialize]
        public void Initialize()
        {
            var mock = new Mock<IRepository<Specialization>>();
            mock.Setup(m => m.GetAll()).Returns(new[]
            {
                new Specialization
                {
                    SpecializationId = 1,
                    SpecializationName = "Fake name ver 1",
                    SpecializationDescription = "Fake description ver 1"
                },
                new Specialization
                {
                    SpecializationId = 2,
                    SpecializationName = "Fake name ver 2",
                    SpecializationDescription = "Fake description ver 2"
                },
                new Specialization
                {
                    SpecializationId = 3,
                    SpecializationName = "Fake name ver 3",
                    SpecializationDescription = "Fake description ver 3"
                }
            }.AsQueryable());

            mock.Setup(m => m.Get(It.Is<int>(i => (i == 1) || (i == 2) || (i == 3))))
                .Returns<int>(r => new Specialization
                {
                    SpecializationId = r,
                    SpecializationName = $"Fake name ver {r}",
                    SpecializationDescription = $"Fake description ver {r}"
                });

            mainRepository = mock.Object;
            mainServices = new SpecialisationService(mainRepository);
        }

        [TestMethod]
        public void is_index_returns_iqueryble_name()
        {
            // Arange 
            var specialisationService = new SpecialisationService(mainRepository);

            // Act
            var entityId = specialisationService.ShowEntity(1).SpecializationName;

            // Assert 
            Assert.AreEqual("Fake name ver 1", entityId);
        }


        [TestMethod]
        public void is_index_returns_iqueryable_foo_count_of_4()
        {
            //Arrange
            //Create the services instance
            var specialisationService = new SpecialisationService(mainRepository);

            //Act
            var indexModel = specialisationService.EntietiesList();

            //Assert
            Assert.AreEqual(3, indexModel.Count());
        }

        [TestMethod]
        public void is_details_returns_type_of_ViewResult()
        {
            //Arrange
            //Create the controller instance
            var specjalizationController = new SpecializationController(mainServices);

            //Act
            var detailsResult = specjalizationController.Details(1);

            //Assert
            Assert.IsInstanceOfType(detailsResult, typeof(ViewResult));
        }

        [TestMethod]
        public void is_details_returns_type_of_ViewResult_ver2()
        {

            //Arrange
            //Create the controller instance
            SpecializationController specjalizationController = new SpecializationController(mainServices);

            //Act
            var detailsResult = specjalizationController.Details(5);

            //Assert
            Assert.IsInstanceOfType(detailsResult, typeof(ActionResult));
        }

        [TestMethod]
        public void is_details_returns_type_of_HttpNotFoundResult()
        {

            //Arrange
            //Create the controller instance
            SpecializationController specjalizationController = new SpecializationController(mainServices);

            //Act
            var result = specjalizationController.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
    }
}