
using System.Text.Json;

internal class LegoPriceService
{
    private readonly HttpClient _httpClient = new();

    public async Task<LegoData> GetData(int id)
    {
        try
        {
            string url = $"https://api.promoklocki.pl/price/{id}";
            string res = await _httpClient.GetStringAsync(url);

            JsonDocument doc = JsonDocument.Parse(res);

            decimal price = doc.RootElement.GetProperty("price").GetDecimal();

            return new LegoData(id, price);
        }
        catch (HttpRequestException)
        {
            return new LegoData(id, null);
        }
    }
}
