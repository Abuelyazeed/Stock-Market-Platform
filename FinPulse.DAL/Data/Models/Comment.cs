namespace FinPulse.DAL;

public class Comment
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int StockId { get; set; }
    //Navigation property
    public Stock? Stock { get; set; }
}