using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using Validator.Integration.Test.Context;
using Newtonsoft.Json;
using Validator.Domain.Commands.Output;
using System;

namespace Validator.Integration.Test.Scenarios
{
    public class ValidatePasswordTest
    {
        private readonly TestContext _testContext;
        private const string ContentTypeApplicationJson = "application/json";
        private const string Uri = "/Api/Validator/Password/Validate";
        public ValidatePasswordTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task ShouldReturnTrueWhenPasswordIsValid()
        {
            string payload = "{\"password\": \"AbTp9!fok\"}";
            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, ContentTypeApplicationJson);
            var response = await _testContext.Client.PostAsync(Uri, httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            CommandResult result = JsonConvert.DeserializeObject<CommandResult>(responseContent);
            Assert.Equal<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            Assert.True(result.Valid);
        }

        [Fact]
        public async Task ShouldReturnTrueWhenPasswordIsValidWithMoreThan9Characters()
        {
            string payload = "{\"password\": \"AbTp9!fokey\"}";
            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, ContentTypeApplicationJson);
            var response = await _testContext.Client.PostAsync(Uri, httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            CommandResult result = JsonConvert.DeserializeObject<CommandResult>(responseContent);
            Assert.Equal<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            Assert.True(result.Valid);
        }

        [Fact]
        public async Task ShouldReturnFalseWhenPasswordIsEmpty()
        {
            string payload = "{\"password\": \"\"}";
            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, ContentTypeApplicationJson);
            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _testContext.Client.PostAsync(Uri, httpContent));
            Assert.Equal<string>("Command is null or empty (Parameter 'command')", exception.Message);
        }

        [Fact]
        public async Task ShouldReturnFalseWhenPasswordIsNull()
        {
            string payload = "{\"password\": null}";
            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, ContentTypeApplicationJson);
            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _testContext.Client.PostAsync(Uri, httpContent));
            Assert.Equal<string>("Command is null or empty (Parameter 'command')", exception.Message);
        }

        [Fact]
        public async Task ShouldReturnFalseWhenPasswordIsOutOfPattern1()
        {
            string payload = "{\"password\": \"aa\"}";
            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, ContentTypeApplicationJson);
            var response = await _testContext.Client.PostAsync(Uri, httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            CommandResult result = JsonConvert.DeserializeObject<CommandResult>(responseContent);
            Assert.Equal<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            Assert.False(result.Valid);
        }

        [Fact]
        public async Task ShouldReturnFalseWhenPasswordIsOutOfPattern2()
        {
            string payload = "{\"password\": \"AAAbbbCc\"}";
            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, ContentTypeApplicationJson);
            var response = await _testContext.Client.PostAsync(Uri, httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            CommandResult result = JsonConvert.DeserializeObject<CommandResult>(responseContent);
            Assert.Equal<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            Assert.False(result.Valid);
        }

        [Fact]
        public async Task ShouldReturnFalseWhenPasswordIsOutOfPattern3()
        {
            string payload = "{\"password\": \"AbTp9!foo\"}";
            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, ContentTypeApplicationJson);
            var response = await _testContext.Client.PostAsync(Uri, httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            CommandResult result = JsonConvert.DeserializeObject<CommandResult>(responseContent);
            Assert.Equal<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            Assert.False(result.Valid);
        }

        [Fact]
        public async Task ShouldReturnFalseWhenPasswordIsOutOfPattern4()
        {
            string payload = "{\"password\": \"AbTp9!foA\"}";
            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, ContentTypeApplicationJson);
            var response = await _testContext.Client.PostAsync(Uri, httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            CommandResult result = JsonConvert.DeserializeObject<CommandResult>(responseContent);
            Assert.Equal<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            Assert.False(result.Valid);
        }

        [Fact]
        public async Task ShouldReturnFalseWhenPasswordIsOutOfPattern5()
        {
            string payload = "{\"password\": \"AbTp9 fok\"}";
            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, ContentTypeApplicationJson);
            var response = await _testContext.Client.PostAsync(Uri, httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            CommandResult result = JsonConvert.DeserializeObject<CommandResult>(responseContent);
            Assert.Equal<HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            Assert.False(result.Valid);
        }
    }
}