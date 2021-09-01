using System;
using System.Collections.Generic;
using System.Text;
using eisenhower.Wizards;

namespace eisenhower.Model
{
    public class TodoMatrix
    {
        private ITodoItemWizard consoleWizard = new TodoItemWizard();

        public IDictionary<Significance, TodoQuarter> Quarters { get; private set; } =
            new Dictionary<Significance, TodoQuarter>
            {
                [Significance.ImportantUrgent] = new TodoQuarter(),
                [Significance.ImportantNonurgent] = new TodoQuarter(),
                [Significance.UnimportantUrgent] = new TodoQuarter(),
                [Significance.UnimportantNonurgent] = new TodoQuarter()
            };

        public void AddItem()
        {
            // this is kinda weird,
            // if we save the "urgent" part here it will be off after some time

            var item = consoleWizard.CreateItem();
            Console.Write("Is task important? [y/n]");
            var input = Console.ReadLine();
            var isImportant = input?.ToLower() == "y";
            AddItemInternal(item, isImportant);
        }

        public void AddItem(TodoItem item, bool isImportant)
        {
            AddItemInternal(item, isImportant);
        }

        private void AddItemInternal(TodoItem item, bool isImportant)
        {
            var isUrgent = item.Deadline > DateTime.Now.AddHours(-72);
            TodoQuarter targetQuarter;

            if (isImportant)
            {
                targetQuarter = isUrgent
                    ? Quarters[Significance.ImportantUrgent]
                    : Quarters[Significance.ImportantNonurgent];
            }
            else
            {
                targetQuarter = isUrgent
                    ? Quarters[Significance.UnimportantUrgent]
                    : Quarters[Significance.UnimportantNonurgent];
            }

            targetQuarter.AddItem(item);
        }

        public void ArchieveItems()
        {
            foreach (var quarter in Quarters.Values)
            {
                quarter.Archieve();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var quarter in Quarters)
            {
                sb.AppendLine(quarter.Key.ToString());
                sb.AppendLine(quarter.Value.ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
