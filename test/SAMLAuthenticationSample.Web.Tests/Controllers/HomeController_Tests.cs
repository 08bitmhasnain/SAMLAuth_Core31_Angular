using System.Threading.Tasks;
using SAMLAuthenticationSample.Models.TokenAuth;
using SAMLAuthenticationSample.Web.Controllers;
using Shouldly;
using Xunit;

namespace SAMLAuthenticationSample.Web.Tests.Controllers
{
    public class HomeController_Tests: SAMLAuthenticationSampleWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}