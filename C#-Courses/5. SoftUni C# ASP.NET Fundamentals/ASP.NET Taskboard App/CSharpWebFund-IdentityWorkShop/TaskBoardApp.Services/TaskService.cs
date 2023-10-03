using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext dbContext;

        public TaskService(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task AddAsync(string ownerId, TaskFormViewModel viewModel)
        {
            TaskBoardApp.Data.Models.Task task = new Data.Models.Task()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                BoardId = viewModel.BoardId,
                CreatedOn = DateTime.UtcNow,
                OwnerId = ownerId,
            };

            await this.dbContext.AddAsync(task);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<TaskDetailsViewModel> GetForDetailsByIdAsync(string id)
        {
            TaskDetailsViewModel viewModel = await this.dbContext.Tasks
                .Select(t => new TaskDetailsViewModel
                {
                    Id = id.ToString(),
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.Owner.UserName,
                    CreatedOn = t.CreatedOn.ToString("f"),
                    Board = t.Board.Name
                })
                .FirstAsync(t => t.Id == id);

            return viewModel;
        }
    }
}
