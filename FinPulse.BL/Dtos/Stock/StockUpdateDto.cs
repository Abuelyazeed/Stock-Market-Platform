using System.ComponentModel.DataAnnotations;

namespace FinPulse.BL;

public class StockUpdateDto
{
    [Required]
    [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters.")]
    public string Symbol { get; set; } = string.Empty;
    [Required]
    [MaxLength(40, ErrorMessage = "Company name cannot be over 40 characters.")]
    public string CompanyName { get; set; } = string.Empty;
    [Required]
    [Range(1,1000000000)]
    public double Purchase { get; set; }
    [Required]
    [Range(0,100)]
    public double LastDiv { get; set; }
    [Required]
    [MaxLength(40, ErrorMessage = "Industry cannot be over 40 characters.")]
    public string Industry { get; set; } = string.Empty;
    [Range(1,5000000000000)]
    public long MarketCap { get; set; }
}