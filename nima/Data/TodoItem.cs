using System;

namespace nima.Data
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public TimeSpan DueTime { get; set; } = new TimeSpan(9, 0, 0); 
        public bool IsCompleted { get; set; }
        public int Priority { get; set; }
        public string Category { get; set; } = "personal";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? CompletedAt { get; set; }
        public bool NotificationSent { get; set; } = false;
        public bool IsPinned { get; set; } = false;
        public DateTime DueDateTime => DueDate + DueTime;
    }
}