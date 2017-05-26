using System.Threading.Tasks;
using APIHealthChecker.Repositories;
using NUnit.Framework;
using Xamarin.UITest;
using System.Linq;
using Xamarin.UITest.Queries;
using APIHealthChecker.Services;

namespace UnitTests
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

		[Test]
		public async Task Must_Return_API_EndPoint()
		{
            var mobApp = await MobAppRepo.GetMobApp("Guess");

			Assert.IsNotNull(mobApp);
            Assert.IsNotEmpty(mobApp.EndPoints);
		}

        [Test]
        public async Task Must_Successfull_Test_Endpoint()
		{
            var testResult = await EndPointTestService.TestEndPoint("https://jsonplaceholder.typicode.com/posts", false);

			Assert.IsNotNull(testResult);
            Assert.IsTrue(testResult.IsWorking);
		}

		[Test]
		public async Task Must_Successfull_Get_AppList()
		{
            var testResult = await MobAppRepo.GetAllAppNames();

			Assert.IsNotNull(testResult);
            Assert.IsNotEmpty(testResult);
		}
    }
}
