using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Board;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;

        public BoardController(IBoardService _boardService)
        {
            this.boardService = _boardService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<BoardAllViewModel> allBoards = await this.boardService.AllAsync();
            return View(allBoards);
        }
    }
}
