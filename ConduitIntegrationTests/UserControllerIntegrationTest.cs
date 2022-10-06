using Conduit;
using Conduit.Core.DTOModels;
using IntegrationTestingProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConduitIntegrationTests
{
    public class UserControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        public UserControllerIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI1IiwiRnVsbF9OYW1lIjoieWFoeWEiLCJuYmYiOjE2NjUwNTU0NzYsImV4cCI6MTY2NTA1OTA3NiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIwMyIsImF1ZCI6ImNvbmR1aXRhcGkifQ.9IkfS4vAc_VAgFEnTIgLmqhuC_iPUf--a0dsnobYrlk");

        }

        [Fact]
        public async Task GETUser()
        {
            // Act
            var response = await _client.GetAsync("https://localhost:7203/api/users/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task POSTUser()
        {
            // Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7203/api/users");
            UserForInsertDTO userForInsertDTO = new UserForInsertDTO { Username = "bobo", Password = "yoyoyo123", FullName = "Karma" };
            postRequest.Content = JsonContent.Create(userForInsertDTO);

            // Act
            var response = await _client.SendAsync(postRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task PUTUser()
        {
            // Arrange
            var putRequest = new HttpRequestMessage(HttpMethod.Put, "https://localhost:7203/api/users/1");
            UserForUpdateDTO userForUpdateDTO = new UserForUpdateDTO {Username="FAFAAFAF",Password="JAJAJAJ123", FullName = "Karma" };
            putRequest.Content = JsonContent.Create(userForUpdateDTO);

            // Act
            var response = await _client.SendAsync(putRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
