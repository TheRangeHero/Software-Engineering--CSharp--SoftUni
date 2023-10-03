using Forum.ViewModels.Post;

namespace Forum.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostListViewModel>> ListAllAsync();

        Task AddPostAsync(PostFormModel postViewModel);

        Task<PostFormModel> GetForEditOrDeleteByIdAsync(string id);

        Task EditByIdAsync(string id, PostFormModel postEditedModel);

        Task DeleteByIdAsync(string id);
    }
}
