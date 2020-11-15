using Moq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Repositories;
using VatanAPI.Domain.Services;
using Xunit;

namespace VatanAPITest.Services
{
    public class CategoryServiceTests
    {
        private Mock<ICategoryRepository> _categoryRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        private CategoryService _categoryService;

        public CategoryServiceTests()
        {
            SetupMocks();
            _categoryService = new CategoryService(_categoryRepository.Object, _unitOfWork.Object);
        }

        private void SetupMocks()
        {

            _categoryRepository = new Mock<ICategoryRepository>();
            _categoryRepository.Setup(r => r.FindByIdAsync(1000)).ReturnsAsync(new Category { Id = 1000, Name = "TestCategory", Products = new Collection<Product>() });
            _categoryRepository.Setup(r => r.FindByIdAsync(1001)).Returns(Task.FromResult<Category>(null));
            _categoryRepository.Setup(r => r.AddAsync(It.IsAny<Category>())).Returns(Task.CompletedTask);

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(u => u.CompleteAsync()).Returns(Task.CompletedTask);
        }
        [Fact]
        public async Task Should_Create_Non_Existing_Category()
        {
            var category = new Category { Id = 1003, Name = "TestKategory3", Products = new Collection<Product>() };

            var response = await _categoryService.SaveAsync(category);

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal(category.Name, response.Category.Name);
            Assert.Equal(category.Products, response.Category.Products);
            Assert.Equal(category.Id, response.Category.Id);
        }
        /* [Fact]
         public async Task Should_Not_Create_User_When_Name_Is_Alreary_In_Use()
         {
             var category = new Category { Name="TestCategory" ,Products = new Collection<Product>() };

             var response = await _categoryService.SaveAsync(category);

             Assert.False(response.Success);
             Assert.Equal("Category already in use.", response.Message);
         }*/
        [Fact]
        public async Task Should_Delete_Existing_Category_By_ID()
        {
            var category = await _categoryService.DeleteAsync(1001);
            Assert.NotNull(category);
        }/*
        [Fact]
        public async Task Should_Update_Non_Existing_Category_By_ID()
        {
            c
            var category = await _categoryService.UpdateAsync(1005, await _categoryService);
            Assert.NotNull(category);
            Assert.Equal("", category.Category.Name);
        }*/
    }
}