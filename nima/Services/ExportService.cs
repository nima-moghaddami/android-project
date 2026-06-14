using System.Text.Json;
using nima.Data;

namespace nima.Services
{
    public class ExportService
    {
        public async Task ExportToJson(List<TodoItem> todos)
        {
            var json = JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true });
            var filePath = Path.Combine(FileSystem.CacheDirectory, $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.json");
            File.WriteAllText(filePath, json);
            await Share.Default.RequestAsync(new ShareFileRequest
            {
                Title = "پشتیبان‌گیری از کارها",
                File = new ShareFile(filePath)
            });
        }

        public async Task<List<TodoItem>> ImportFromJson()
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "انتخاب فایل پشتیبان",
                    FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.WinUI, new[] { ".json" } },
                        { DevicePlatform.Android, new[] { "application/json" } }
                    })
                });

                if (result == null) return null;

                var json = await File.ReadAllTextAsync(result.FullPath);
                return JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
            }
            catch
            {
                return null;
            }
        }
    }
}