using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace nima.Data
{
    public class TodoStorage
    {
        private const string TodosKey = "todos";
        private int _nextId = 1;

        public List<TodoItem> LoadTodos()
        {
            var json = Preferences.Get(TodosKey, "[]");
            var todos = JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
            if (todos.Any())
                _nextId = todos.Max(t => t.Id) + 1;
            return todos;
        }

        public void SaveTodos(List<TodoItem> todos)
        {
            var json = JsonSerializer.Serialize(todos);
            Preferences.Set(TodosKey, json);
        }

        public int GetNextId() => _nextId++;
    }
}