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

        public DndApiServiceTests()
        {}

        [Fact]
        public async Task GetSpells_Returns_Successful_Response()
        {
            
            var httpClient = new HttpClient();
            var repository = new DndApiRepository();

           
            var response = await repository.GetSpells();

            
          
            Assert.NotNull(contentResponse);
        }

        
           
    }
}
