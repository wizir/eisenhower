using System.Collections.Generic;
using System.Linq;
using eisenhower.Wizards;

namespace eisenhower.Model
{
    public class TodoQuarter
    {
        private ITodoItemWizard wizard = new TodoItemWizard(); 
        
        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();

        
        public void AddItem()
        {
            // this is fucked up. Wizard should not be here. Item should be passed as parameter.
            // dunno, this method might not be necessary
            var item = wizard.CreateItem();
            
            Items.Add(item);
        }

        public void AddItem(TodoItem item) => Items.Add(item);
        public bool RemoveItem(TodoItem item) => Items.Remove(item);

        public void SortItems()
        {
            Items = Items.OrderByDescending(item => item.Deadline).ToList();
        }
        
        public void Archieve()
        {
            Items = Items.Where(item => item.Done).ToList();
        }

        public override string ToString()
        {
            return string.Join('\n', Items.Select(item => item.ToString()));
        }
    }
}
