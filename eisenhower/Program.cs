using eisenhower.DataLayer;

namespace eisenhower
{
    class Program
    {
        static void Main(string[] args)
        {
            var main = new EisenhowerMain(new TodoMatrixFileDataAccessLayer("./file.txt"));
            
            main.Run();
        }
    }
}
