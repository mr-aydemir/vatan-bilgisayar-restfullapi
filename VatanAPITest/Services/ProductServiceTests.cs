using Moq;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Repositories;
using VatanAPI.Domain.Services;
using Xunit;

namespace VatanAPITest.Services
{
    public class ProductServiceTests
    {
        private Mock<IProductRepository> _productRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        private ProductService _productService;

        public ProductServiceTests()
        {
            SetupMocks();
            _productService = new ProductService(_productRepository.Object, _unitOfWork.Object);
        }

        private void SetupMocks()
        {

            _productRepository = new Mock<IProductRepository>();
            _productRepository.Setup(r => r.FindByIdAsync(1000)).ReturnsAsync(new Product { Id = 1000, Name = "TestProduct", Url = "http://www.yalova.edu.tr/", CategoryId = It.IsAny<int>() });
            _productRepository.Setup(r => r.FindByIdAsync(1001)).Returns(Task.FromResult<Product>(null));
            _productRepository.Setup(r => r.AddAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(u => u.CompleteAsync()).Returns(Task.CompletedTask);
        }
        [Fact]
        public async Task Should_Create_Non_Existing_Product()
        {
            var product = new Product { Id = 1003, Name = "TestProduct3", Url = "http://www.yalova.edu.tr/", CategoryId = It.IsAny<int>() };

            var response = await _productService.SaveAsync(product);

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal(product.Name, response.Product.Name);
            Assert.Equal(product.Url, response.Product.Url);
            Assert.Equal(product.Id, response.Product.Id);
            Assert.Equal(product.CategoryId, response.Product.CategoryId);
        }
        /*
        [Fact]
        public async Task Should_Not_Create_User_When_Name_Is_Alreary_In_Use()
        {
            var product = new Product { Id = 1003, Name = "TestProduct", Url = "http://www.yalova.edu.tr/Uploads/www/products/Yalova-U%CC%88niversitesi-Logo.png", ProductId = It.IsAny<int>() };

            var response = await _productService.SaveAsync(product);

            Assert.False(response.Success);
            Assert.Equal("Product already in use.", response.Message);
        }*/
        [Fact]
        public async Task Should_Delete_Existing_Product_By_ID()
        {
            var product = await _productService.DeleteAsync(1001);
            Assert.NotNull(product);
        }
    }
}
