using SoftUniBazar.Models;

namespace SoftUniBazar.Contracts
{
    public interface IAdService
    {
        Task<IEnumerable<AllAdsViewModel>> GetAllAdsAsync();
        Task<AddAdViewModel> GetNewAddBookModelAsync();
        Task AddBookAsync(AddAdViewModel model, string userId);
        Task<AddAdViewModel?> GetAdByIdForEditAsync(int id);
        Task EditAdAsync(AddAdViewModel model, int id);

        Task<AllAdsViewModel?> GetAdByIdAsync(int id);
        Task AddAdToCollectionAsync(string userId, AllAdsViewModel ad);
        Task<IEnumerable<AllAdsViewModel>> GetMyAdsAsync(string userId);
        Task RemoveAdFromCollectionAsync(string userId, AllAdsViewModel ad);
        Task<bool> AdAlreadyAddedToCartAsync(string userId,int id);

    }
}
