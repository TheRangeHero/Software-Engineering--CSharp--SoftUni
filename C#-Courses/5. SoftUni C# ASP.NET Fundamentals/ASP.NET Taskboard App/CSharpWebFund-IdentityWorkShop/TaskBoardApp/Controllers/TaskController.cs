using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Extensions;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IBoardService boardService;
        private readonly ITaskService taskService;
        public TaskController(IBoardService _boardService, ITaskService _taskService)
        {
            this.boardService = _boardService;   
            this.taskService = _taskService;
        }

        [HttpGet]
        public async Task<IActionResult >Create()
        {
            TaskFormViewModel viewModel = new TaskFormViewModel()
            {
                AllBoards = await this.boardService.AllForSelectAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllBoards = await this.boardService.AllForSelectAsync();
                return this.View(model);
            }
            
            bool boardExists = await this.boardService.ExistsByIdAsync(model.BoardId);
            if(!boardExists)
            {
                ModelState.AddModelError(nameof(model.BoardId), "Selected board does not exist!");
                model.AllBoards = await this.boardService.AllForSelectAsync();
                return this.View(model);
            }

            string currentUserId = this.User.GetId();

            await this.taskService.AddAsync(currentUserId, model);

            return this.RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string Id)
        {
            try
            {
                TaskDetailsViewModel viewModel = await this.taskService.GetForDetailsByIdAsync(Id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.RedirectToAction("All", "Board");
                
            }
        }
    }
}
