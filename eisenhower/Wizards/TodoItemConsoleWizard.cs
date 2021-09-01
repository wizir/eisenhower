using System;
using System.Globalization;

namespace eisenhower.Wizards
{
    public class TodoItemConsoleWizard : ITodoItemWizard
    {
        public TodoItem CreateItem()
        {
            Console.Write("Enter Title: ");
            var title = Console.ReadLine();

            var deadline = DateTime.MinValue;
            var parsed = false;
            do
            {
                Console.Write("Enter Deadline in correct format (dd.MM.yyyy hh:mm): ");
                var deadlineFormat = Console.ReadLine();
                parsed = DateTime.TryParseExact(deadlineFormat, "dd.MM.yyyy hh:mm", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out deadline);
            } while (parsed == false);


            return new TodoItem
            {
                Title = title,
                Deadline = deadline
            };
        }
    }
}
