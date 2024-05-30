using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using noted_dndapi_service.Controllers;

namespace noted_dndapi_service.Tests
{
    public class DndApiControllerTests
    {
        [Fact]
        public async Task Example_Test()
        {
           var x = 1;
            
            Assert.Equal(x, 1);
        }
    }
}
