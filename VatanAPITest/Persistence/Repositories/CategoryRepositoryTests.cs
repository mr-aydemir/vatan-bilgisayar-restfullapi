using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VatanAPITest.Persistence.Repositories
{

    [TestClass()]
    public class CategoryRepositoryTests
    {/*
        ICategoryRepository _repository;

        private int Id;
        private string Name;

        [TestInitialize]
        public void SetUp()
        {
            _repository = (ICategoryRepository)RepositoryFactory.Instance("CompetitionRepository");
             InitialiseParameters();
        }

        [TestMethod]
        public void CategoryCrud()
        {
            int newID = Create();
            GetByID(newID);
            GetAll();
            Update(newID);
            Delete(newID);
        }
        private void InitialiseParameters()
        {
            Id = 1000;
            Name = "TestCategory";
        }
        private int Create()
        {
            // Arrange
            Category category = new Category();
            category.Id = Id;
            category.Name = Name;

            // Act
            _repository.AddAsync(category);

            // Assert
            Assert.AreNotEqual(Guid.Empty, category.Id, "Creating new record does not return id");

            return category.Id;
        }
        private void Update(int id)
        {
            // Arrange
            Category category = _repository.FindByIdAsync(id).Result ;
            category.CompetitionKey = "SWQ";
            competition.SetCompetitionState(new ClosedState());
            competition.CreatedBy = new User() { ID = CREATED_BY_ID };

            // Act
            _repository.Update(competition);

            Competition updatedCompetition = _repository.FindByID(id);

            // Assert
            Assert.AreEqual("SWQ", updatedCompetition.CompetitionKey, "Record is not updated.");
            Assert.AreEqual(CLOSED_STATE, updatedCompetition.State.Status, "Competition status is not updated.");
        }
        */
    }
}
