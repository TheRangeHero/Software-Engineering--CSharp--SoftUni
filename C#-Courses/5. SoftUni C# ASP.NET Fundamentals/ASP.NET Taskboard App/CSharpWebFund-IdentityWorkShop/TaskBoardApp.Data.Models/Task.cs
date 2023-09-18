using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static TaskBoardApp.Common.EntityValidiationConstants.Task;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {

        public Task()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }
        public virtual Board Board { get; set; } = null!;

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;

        public virtual IdentityUser Owner { get; set; } = null!;


    }
}
