using Moq;
using System.Threading.Tasks;
using VatanAPI.Domain.Models;
using VatanAPI.Domain.Repositories;
using VatanAPI.Domain.Services;
using Xunit;

namespace VatanAPITest.Services
{
    public class ImageServiceTests
    {
        private Mock<IImageRepository> _imageRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        private ImageService _imageService;

        public ImageServiceTests()
        {
            SetupMocks();
            _imageService = new ImageService(_imageRepository.Object, _unitOfWork.Object);
        }

        private void SetupMocks()
        {

            _imageRepository = new Mock<IImageRepository>();
            _imageRepository.Setup(r => r.FindByIdAsync(1000)).ReturnsAsync(new Image { Id = 1000, Name = "TestImage", Url = "http://www.yalova.edu.tr/Uploads/www/images/Yalova-U%CC%88niversitesi-Logo.png", ProductId = It.IsAny<int>() });
            _imageRepository.Setup(r => r.FindByIdAsync(1001)).Returns(Task.FromResult<Image>(null));
            _imageRepository.Setup(r => r.AddAsync(It.IsAny<Image>())).Returns(Task.CompletedTask);

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(u => u.CompleteAsync()).Returns(Task.CompletedTask);
        }
        [Fact]
        public async Task Should_Create_Non_Existing_Image()
        {
            var image = new Image { Id = 1003, Name = "TestImage3", Url = "http://www.yalova.edu.tr/Uploads/www/images/Yalova-U%CC%88niversitesi-Logo.png", ProductId = It.IsAny<int>() };

            var response = await _imageService.SaveAsync(image);

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal(image.Name, response.Image.Name);
            Assert.Equal(image.Url, response.Image.Url);
            Assert.Equal(image.Id, response.Image.Id);
            Assert.Equal(image.ProductId, response.Image.ProductId);
        }
        /*
        [Fact]
        public async Task Should_Not_Create_User_When_Name_Is_Alreary_In_Use()
        {
            var image = new Image { Id = 1003, Name = "TestImage", Url = "http://www.yalova.edu.tr/Uploads/www/images/Yalova-U%CC%88niversitesi-Logo.png", ProductId = It.IsAny<int>() };

            var response = await _imageService.SaveAsync(image);

            Assert.False(response.Success);
            Assert.Equal("Image already in use.", response.Message);
        }*/
        [Fact]
        public async Task Should_Delete_Existing_Image_By_ID()
        {
            var image = await _imageService.DeleteAsync(1001);
            Assert.NotNull(image);
        }
    }
}