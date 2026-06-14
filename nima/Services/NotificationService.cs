using nima.Data;
using Microsoft.Maui.Controls;

namespace nima.Services
{
    public class NotificationService
    {
        public async Task CheckAndNotify(List<TodoItem> todos)
        {
            var today = DateTime.Now.Date;
            var now = DateTime.Now;

            foreach (var todo in todos.Where(t => !t.IsCompleted && t.DueDate.Date == today && !t.NotificationSent))
            {
                await SendNotification(todo);
                todo.NotificationSent = true;
            }
        }

        private async Task SendNotification(TodoItem todo)
        {
            var message = $"کار «{todo.Title}» برای امروز سررسید شده است!";
            await Shell.Current.DisplayAlert("📢 یادآوری", message, "باشه");
        }
    }
}