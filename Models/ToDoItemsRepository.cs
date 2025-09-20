namespace serverManagement2.Models
{
    public static class ToDoItemsRepository
    {
        private static List<ToDoItem> items = new List<ToDoItem>()
        {
            new ToDoItem { Id = 1, Name = "Task 1"},
            new ToDoItem { Id = 2, Name = "Task 2"},
            new ToDoItem { Id = 3, Name = "Task 3"},
            new ToDoItem { Id = 4, Name = "Task 4"},
            new ToDoItem { Id = 5, Name = "Task 5"}
        };

        public static void AddItem(ToDoItem item)
        {
            if (items.Count > 0)
            {
                var maxId = items.Max(i => i.Id);
                item.Id = maxId + 1;
                items.Add(item);
            }
            else
            {
                item.Id = 1;
                items.Add(item);
            }
        }

        public static List<ToDoItem> GetItems()
        {
            var sortedItems = items.
                OrderBy(item => item.IsCompleted)
                .ThenByDescending(item => item.Id)
                .ToList();
            return sortedItems;
        }

        public static ToDoItem? GetItemById(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                return new ToDoItem
                {
                    Id = item.Id,
                    Name = item.Name,
                };
            }
            return null;
        }

        public static void UpdateItem(int itemId, ToDoItem item)
        {
            if (itemId != item.Id) return;
            var itemToUpdate = items.FirstOrDefault(i => i.Id == itemId);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
            }
        }

        public static void DeleteItem(int itemId)
        {
            var itemToDelete = items.FirstOrDefault(i => i.Id == itemId);
            if (itemToDelete != null)
            {
                items.Remove(itemToDelete);
            }
        }

        public static List<ToDoItem> SearchItem(string itemFilter)
        {
            return items.Where(i => i.Name.Contains(itemFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
