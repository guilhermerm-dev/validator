using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Validator.Api;

namespace Validator.Integration.Test.Context
{
    public class TestContext
    {
        public HttpClient Client { get; private set; }
        private readonly TestServer _server;
        public TestContext()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }
    }
}