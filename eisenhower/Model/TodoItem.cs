using System;
using Newtonsoft.Json;

namespace eisenhower
{
    public class TodoItem
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public bool Done {  get; private set; }

        public void Mark() => Done = true;
        public void UnMark() => Done = false;
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
