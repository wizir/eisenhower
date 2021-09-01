namespace eisenhower.DataLayer.Serializers
{
    public interface ITodoItemSerializer
    {
        (TodoItem item, bool isImportant) Deserialize(string format);
        string Serialize(TodoItem item, bool isImportant);
    }
}
