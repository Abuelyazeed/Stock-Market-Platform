using FinPulse.DAL;

namespace FinPulse.BL.Managers.Portfolios;

public interface IPortfolioManager
{
    Task<List<StockDto>> GetPorfolioAsync(AppUser user);
}