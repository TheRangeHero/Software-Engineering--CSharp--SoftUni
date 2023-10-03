using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services
{
    public class BoardService : IBoardService
    {
        private readonly ApplicationDbContext dbContext;

        public BoardService(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

       

        public async Task<IEnumerable<BoardAllViewModel>> AllAsync()
        {
            IEnumerable<BoardAllViewModel> allBoards = await dbContext.Boards
                .Select(b => new BoardAllViewModel()
                {
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id.ToString(),
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName

                    }).ToArray(),
                }).ToArrayAsync();

            return allBoards;
        }

        public async Task<IEnumerable<BoardSelectViewModel>> AllForSelectAsync()
        {
            IEnumerable<BoardSelectViewModel> allBoards = await this.dbContext.Boards
                .Select(b => new BoardSelectViewModel()
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToArrayAsync();

            return allBoards;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext.Boards.AnyAsync(b => b.Id == id);

            return result;
        }
    }
}
