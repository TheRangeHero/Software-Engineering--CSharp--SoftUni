using ForumApp.Data.Models;

namespace ForumApp.Data.Seeding
{
    internal class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();
            Post currentPost;

            currentPost = new Post()
            {
                Title = "My first post",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at libero maximus, gravida diam ac, blandit nisl. Curabitur vehicula diam.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at libero maximus, gravida diam ac, blandit nisl. Curabitur vehicula diam."
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My second post",
                Content = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My third",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin tristique urna neque, a porta libero volutpat ac. Nulla pulvinar."
            };
            posts.Add(currentPost);

            return posts.ToArray();
        }
    }
}
