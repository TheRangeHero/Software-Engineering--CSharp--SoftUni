using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data.Configurations
{
    internal class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Models.Task> builder)
        {
            builder.HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateTasks());
        }

        private ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {

            new Task()
            {
                Title = "Improve CSS style",
                Description = "Implement better styling for all public pages",
                CreatedOn = DateTime.UtcNow.AddDays(-200),
                OwnerId = "4192ab0d-b447-4cbe-8ec9-355ec9dfa86d",
                BoardId = 1

            },
            new Task()
            {
                Title = "Android Client App",
                Description = "Create Android client App for the Restfull TaskBoard Service",
                CreatedOn = DateTime.UtcNow.AddMonths(-5),
                OwnerId = "b6a8cf17-27fe-4a4b-80dc-ad92c21837d4",
                BoardId = 1
            },
            new Task()
            {
                Title = "Desktop Client App",
                Description = "Create Desktop client App for the Restfull TaskBoard Service",
                CreatedOn = DateTime.UtcNow.AddMonths(-1),
                OwnerId = "4192ab0d-b447-4cbe-8ec9-355ec9dfa86d",
                BoardId = 2
            },
            new Task()
            {
                Title = "Create Tasks",
                Description = "Implement [Create Task] page for adding tasks",
                CreatedOn = DateTime.UtcNow.AddMonths(-1),
                OwnerId = "4192ab0d-b447-4cbe-8ec9-355ec9dfa86d",
                BoardId = 3

            }
          };

            return tasks;

        }

    }
}
