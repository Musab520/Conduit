using Conduit;
using Conduit.Core.DTOModels;
using IntegrationTestingProject;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConduitIntegrationTests
{
    public class FavoriteControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        public FavoriteControllerIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Authorization =
          new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI1IiwiRnVsbF9OYW1lIjoieWFoeWEiLCJuYmYiOjE2NjUwNTk3MjIsImV4cCI6MTY2NTA2MzMyMiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIwMyIsImF1ZCI6ImNvbmR1aXRhcGkifQ.wwL3BYFY0CA9vx5Du0m19eV-a9fryITqoW_8excg-gE");

        }

        [Fact]
        public async Task GETFavorite()
        {
            // Act
            var response = await _client.GetAsync("https://localhost:7203/api/favoriteArticles/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task POSTFavorite()
        {
            // Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7203/api/favoriteArticles");
            FavoriteArticlesForInsertDTO favoriteForInsertDTO = new FavoriteArticlesForInsertDTO { ArticleId = 1, UserId = 3};
            postRequest.Content = JsonContent.Create(favoriteForInsertDTO);

            // Act
            var response = await _client.SendAsync(postRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task DELETEFavorite()
        {
            // Act
            var response = await _client.DeleteAsync("https://localhost:7203/api/favoriteArticles/1");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GETUserFavorites()
        {
            // Act
            var response = await _client.GetAsync("https://localhost:7203/api/users/1/favoriteArticles");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
