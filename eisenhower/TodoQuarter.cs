using System.Collections.Generic;
using System.Linq;
using eisenhower.Wizards;

namespace eisenhower
{
    public class TodoQuarter
    {
        private ITodoItemWizard consoleWizard = new TodoItemConsoleWizard(); 
        
        private IList<TodoItem> Items { get; set; } = new List<TodoItem>();

        public void AddItem()
        {
            // this is fucked up. Wizard should not be here. Item should be passed as parameter
            var item = consoleWizard.CreateItem();
            
            Items.Add(item);
        } 
        public bool RemoveItem(TodoItem item) => Items.Remove(item);

        public void Archieve()
        {
            // todo what?
        }

        public override string ToString()
        {
            return string.Join('\n', Items.Select(item => item.ToString()));
        }
    }
}
