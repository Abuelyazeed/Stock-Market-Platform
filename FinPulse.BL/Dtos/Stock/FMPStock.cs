namespace FinPulse.BL;

public class FMPStock
{
    public required string symbol { get; set; }
    public required double price { get; set; }
    public double beta { get; set; }
    public int volAvg { get; set; }
    public required long mktCap { get; set; }
    public required double lastDiv { get; set; }
    public string? range { get; set; }
    public double changes { get; set; }
    public required string companyName { get; set; }
    public string? currency { get; set; }
    public string? cik { get; set; }
    public string? isin { get; set; }
    public string? cusip { get; set; }
    public string? exchange { get; set; }
    public string? exchangeShortName { get; set; }
    public required string industry { get; set; }
    public string? website { get; set; }
    public string? description { get; set; }
    public string? ceo { get; set; }
    public string? sector { get; set; }
    public string? country { get; set; }
    public string? fullTimeEmployees { get; set; }
    public string? phone { get; set; }
    public string? address { get; set; }
    public string? city { get; set; }
    public string? state { get; set; }
    public string? zip { get; set; }
    public double dcfDiff { get; set; }
    public double dcf { get; set; }
    public string? image { get; set; }
    public string? ipoDate { get; set; }
    public bool? defaultImage { get; set; }
    public bool? isEtf { get; set; }
    public bool? isActivelyTrading { get; set; }
    public bool? isAdr { get; set; }
    public bool? isFund { get; set; }
}