
internal class LegoData(int id, decimal? price) : IComparable<LegoData>
{
    private int Id { get; } = id;
    private decimal? Price { get; } = price;

    public override string ToString()
    {
        if (!Price.HasValue) return $"{Id} - Nie znaleziono";
        return $"{Id} - {Price}zł";
    }

    public int CompareTo(LegoData other)
    {
        if(Price.HasValue && other.Price.HasValue) return Price.Value.CompareTo(other.Price.Value);
        if(Price.HasValue) return -1; 
        if(other.Price.HasValue) return 1;
        return 0;
    }
}