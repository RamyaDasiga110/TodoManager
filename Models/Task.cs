using Microsoft.AspNetCore.Mvc;

namespace TodoWebApplication.Models
{
   public enum TaskPriority
   {
      Low,
      Medium,
      High
    }
    public class Task
        {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
