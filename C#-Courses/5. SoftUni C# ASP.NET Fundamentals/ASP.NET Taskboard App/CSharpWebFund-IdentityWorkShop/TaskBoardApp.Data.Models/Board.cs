using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskBoardApp.Common.EntityValidiationConstants.Board;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; } = null!;
    }
}
