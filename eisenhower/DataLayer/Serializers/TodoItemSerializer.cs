using System;

namespace eisenhower.DataLayer.Serializers
{
    public class TodoItemSerializer : ITodoItemSerializer
    {
        // this is stupid. isImportant should be member of the item itself
        // also - error handling: IndexOurOfRangeException, NullReferenceException etc.
        public (TodoItem item, bool isImportant) Deserialize(string format)
        {
            var segments = format.Split("|");
            var item = new TodoItem
            {
                Title = segments[0],
                Deadline = DateTime.Parse(segments[1])
            };

            var isImportant = segments[3] == "important";

            return (item, isImportant);
        }

        public string Serialize(TodoItem item, bool isImportant)
        {
            return $"{item.Title}|{item.Deadline}|{(isImportant ? "important" : "")}";
        }
    }
}
