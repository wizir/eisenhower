using System;
using eisenhower.DataLayer;
using eisenhower.Model;

namespace eisenhower
{
    public class EisenhowerMain
    {
        private readonly IToDoMatrixDal dataAccessLayer;

        private TodoMatrix matrix;

        public EisenhowerMain(IToDoMatrixDal dataAccessLayer)
        {
            this.dataAccessLayer = dataAccessLayer;
        }

        public void Run()
        {
            // I dunno, do sth with what we have
            var runProgram = true;
            while (runProgram)
            {
                DisplayGlobalOptionsToUser();

                var input = Console.ReadLine();

                if (int.TryParse(input, out int selectedOption))
                {
                    switch (selectedOption)
                    {
                        case 1:
                            LoadMatrix();
                            break;
                        case 2:
                            DisplayMatrix();
                            break;
                        case 3:
                            ArchiveMatrix();
                            break;
                        case 4:
                            // ask user which quarter and Console.WriteLine(quarter)
                            break;
                        case 5:
                            AddItem();
                            break;
                        case 6:
                            SaveMatrix();
                            break;
                        case 7:
                            runProgram = false;
                            break;
                    }
                }
            }
        }

        private void DisplayGlobalOptionsToUser()
        {
            Console.WriteLine("What do you want to do? Pick a number");
            Console.WriteLine("1. Load matrix");
            Console.WriteLine("2. Display matrix");
            Console.WriteLine("3. Archive tasks that are done");
            Console.WriteLine("4. Display Specific quarter");
            Console.WriteLine("5. Add TODO item");
            Console.WriteLine("6. Save matrix");
            Console.WriteLine("7. Exit");
        }

        private void LoadMatrix() => this.matrix = this.dataAccessLayer.LoadMatrix();
        private void DisplayMatrix() => Console.WriteLine(matrix);
        private void ArchiveMatrix() => this.matrix.ArchieveItems();
        private void AddItem() => this.matrix.AddItem();
        private void SaveMatrix() => this.dataAccessLayer.SaveMatrix(this.matrix);
    }
}
