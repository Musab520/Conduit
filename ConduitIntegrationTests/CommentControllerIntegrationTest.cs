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
    public class CommentControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        public CommentControllerIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Authorization =
          new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI1IiwiRnVsbF9OYW1lIjoieWFoeWEiLCJuYmYiOjE2NjUwNTk3MjIsImV4cCI6MTY2NTA2MzMyMiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIwMyIsImF1ZCI6ImNvbmR1aXRhcGkifQ.wwL3BYFY0CA9vx5Du0m19eV-a9fryITqoW_8excg-gE");

        }

        [Fact]
        public async Task GETComment()
        {
            // Act
            var response = await _client.GetAsync("https://localhost:7203/api/comments/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task POSTComment()
        {
            // Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7203/api/comments");
            CommentForInsertDTO commentForInsertDTO = new CommentForInsertDTO {ArticleId=1, UserId = 1, BodyText="WOAH",date=DateTime.Now};
            postRequest.Content = JsonContent.Create(commentForInsertDTO);

            // Act
            var response = await _client.SendAsync(postRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
        [Fact]
        public async Task DELETEComment()
        {
            // Act
            var response = await _client.DeleteAsync("https://localhost:7203/api/comments/1");

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task GETUserComments()
        {
            // Act
            var response = await _client.GetAsync("https://localhost:7203/api/users/1/comments");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
        [Fact]
        public async Task GETArticleComments()
        {
            // Act
            var response = await _client.GetAsync("https://localhost:7203/api/articles/1/comments");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

    }
}
