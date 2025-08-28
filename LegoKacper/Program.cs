

public class Program
{
    public static async Task Main()
    {
        List<int> ids = GetIds();
        List<LegoData> data = await GetPrices(ids);
        data.Sort();
        DisplayData(data);
    }

    private static void DisplayData(List<LegoData> data)
    {
        foreach(LegoData dataItem in data) Console.WriteLine(dataItem);
    }

    private static async Task<List<LegoData>> GetPrices(List<int> ids)
    {
        LegoPriceService priceService = new();
        var tasks = ids.Select(id => priceService.GetData(id));
        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }

    private static List<int> GetIds()
    {
        Console.WriteLine("Podaj id zestawow, wpisz 0 zeby zakonczyc");

        bool quit = false;
        List<int> ids = [];

        while(!quit)
        {
            string? input = Console.ReadLine();
            int? id = ParseId(input);
            quit = id == 0;

            if(!quit && id.HasValue) ids.Add(id.Value);
        }
        Console.Clear();
        return ids;
    }

    private static int? ParseId(string? input)
    {
        return int.TryParse(input, out int result) ? result : null;
    }
}