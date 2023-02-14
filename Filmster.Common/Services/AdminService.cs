namespace Filmster.Common.Services
{
    public class AdminService : IAdminService
    {
        private readonly MembershipHttpClient _http;
        public AdminService(MembershipHttpClient http)
        {
            _http = http;
        }

        public async Task<List<TDto>> GetAsync<TDto>(string uri)
        {
            try
            {
                using HttpResponseMessage response = await _http.Client.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var result = JsonSerializer.Deserialize<List<TDto>>(await response.Content.ReadAsStreamAsync(),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result ?? new List<TDto>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }



    }
}
