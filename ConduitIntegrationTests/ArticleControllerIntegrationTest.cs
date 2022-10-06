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
    public class ArticleControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        public ArticleControllerIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Authorization =
          new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI1IiwiRnVsbF9OYW1lIjoieWFoeWEiLCJuYmYiOjE2NjUwNTU0NzYsImV4cCI6MTY2NTA1OTA3NiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIwMyIsImF1ZCI6ImNvbmR1aXRhcGkifQ.9IkfS4vAc_VAgFEnTIgLmqhuC_iPUf--a0dsnobYrlk");

        }

        [Fact]
        public async Task GETArticle()
        {
            // Act
            var response = await _client.GetAsync("https://localhost:7203/api/articles/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task POSTArticle()
        {
            // Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7203/api/articles");
            ArticleForInsertDTO articleForInsertDTO = new ArticleForInsertDTO { UserId=1,ArticleTitle="",ArticleBody="",date=DateTime.Now };
            postRequest.Content = JsonContent.Create(articleForInsertDTO);

            // Act
            var response = await _client.SendAsync(postRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
        [Fact]
        public async Task  DELETEArticle()
        {
            // Act
            var response = await _client.DeleteAsync("https://localhost:7203/api/articles/1");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task PUTUser()
        {
            // Arrange
            var putRequest = new HttpRequestMessage(HttpMethod.Put, "https://localhost:7203/api/articles/1");
            ArticleForUpdateDTO articleForUpdateDTO = new ArticleForUpdateDTO { ArticleTitle = "POPO", ArticleBody = "Jjaj"};
            putRequest.Content = JsonContent.Create(articleForUpdateDTO);

            // Act
            var response = await _client.SendAsync(putRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
