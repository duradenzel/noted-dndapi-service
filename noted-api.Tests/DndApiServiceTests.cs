using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using noted_dndapi_service.Controllers;

namespace noted_dndapi_service.Tests
{
    public class DndApiServiceTests
    {

        // private readonly Mock<DndApiRepository> _mockRepository;
        // private readonly DndApiService _service;

        public DndApiServiceTests()
        {}

        [Fact]
        public async Task GetSpells_Returns_Successful_Response()
        {
            // Arrange
            var httpClient = new HttpClient();
            var repository = new DndApiRepository();

            // Act
            var response = await repository.GetSpells();

            // Assert
            Assert.True(response is ContentResult);
            var contentResponse = response as ContentResult;
           
          
            Assert.NotNull(contentResponse);
        }
           
    }
}
