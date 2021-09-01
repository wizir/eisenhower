using System.IO;
using System.Linq;
using eisenhower.DataLayer.Serializers;
using eisenhower.Model;

namespace eisenhower.DataLayer
{
    // From requirements:
    // "Create database layer that allows einsenhower matrix to save and load tasks from file."
    // This is stupid. It looks like the DAL should be a member of the matrix itself.
    // We are not doing it.
    
    
    public class TodoMatrixFileDataAccessLayer : IToDoMatrixDal
    {
        private string FilePath { get; set; } 
        
        private ITodoItemSerializer serializer = new TodoItemSerializer();
        
        public TodoMatrixFileDataAccessLayer(string sourcePath)
        {
            this.FilePath = sourcePath;
        }
        
        public TodoMatrix LoadMatrix()
        {
            var lines = File.ReadAllLines(FilePath);
            var matrix = new TodoMatrix();

            foreach (var line in lines)
            {
                var (item, isImportant) = serializer.Deserialize(line);
                matrix.AddItem(item, isImportant);
            }

            return matrix;
        }

        public void SaveMatrix(TodoMatrix matrix)
        {
            File.Delete(FilePath);
            foreach (var quarter in matrix.Quarters)
            {
                var isImportant = quarter.Key == Significance.ImportantNonurgent || quarter.Key == Significance.ImportantUrgent;

                var lines = quarter.Value.Items.Select(item => serializer.Serialize(item, isImportant));
                
                File.AppendAllLines(FilePath, lines);
            }
        }
    }
}
