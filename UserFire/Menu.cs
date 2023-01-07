using System;

namespace UserFire
{
    class Menu
    {
        // prop for program cs from mew branch
        public static bool IsProgramClosed { get; private set; } = false;

        private static string[] OptionsArr { get; set; } =
        {
            "Show all students in database",
            "Add Student to Database",
            "Find Students by core class",
            "Close Program",
        };
        private enum MenuOptions
        {
            ShowAllStudentsInDatabase = 0,
            AddStudentToDatabase = 1,
            FindStudentsByCoreClass = 2,
            CloseProgram = 3,
        }
        private static int optionIndex = 0;
        private static int OptionIndex
        {
            get { return optionIndex; }
            set
            {
                if (value < 0) optionIndex = 0;
                else if (value >= OptionsArr.Length) optionIndex = OptionsArr.Length - 1;
                else optionIndex = value;
            }
        }

        //Public methods
        /// <summary>
        /// Write menu option
        /// </summary>
        public static void WriteMenuOptions()
        {
            Console.Clear();
            for (int i = 0; i < OptionsArr.Length; i++)
            {
                if (OptionIndex == i) WriteActiveOption($"{i + 1}. {OptionsArr[i]}");
                else Console.WriteLine($"{i + 1}. {OptionsArr[i]}");
            }
            DetectKeyPress();
        }

        /// <summary>
        /// Return program to menu
        /// </summary>
        public static void BackToMenu()
        {
            Console.Write("Return to menu..");
            Console.ReadLine();
        }

        //Private methods
        /// <summary>
        /// Write option in active* style
        /// </summary>
        /// <param name="option"></param>
        private static void WriteActiveOption(string option)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(option);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Key press detect for move in menu
        /// </summary>
        private static void DetectKeyPress()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    OptionIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    OptionIndex++;
                    break;
                case ConsoleKey.Enter:
                    RunOption();
                    break;
            }
        }

        /// <summary>
        /// Run chosen option
        /// </summary>
        private static void RunOption()
        {
            switch ((MenuOptions) OptionIndex)
            {
                case MenuOptions.ShowAllStudentsInDatabase:
                    Console.Clear();
                    Student.WriteStudentsToTable();
                    break;

                case MenuOptions.AddStudentToDatabase:
                    Console.Clear();
                    AddStudentToDatabase();
                    break;

                case MenuOptions.FindStudentsByCoreClass:
                    Console.Clear();
                    FindStudentsByCoreClass();
                    break;

                case MenuOptions.CloseProgram:
                    IsProgramClosed = true;
                    break;
            }
        }
        
        /// <summary>
        /// Create student and add to database
        /// </summary>
        private static void AddStudentToDatabase()
        {
            DataBase.AddStudent(Student.CreateStudent());
            Console.WriteLine("Student added..");
            Console.ReadLine();
        }

        /// <summary>
        /// Write table of students with specific core class 
        /// </summary>
        private static void FindStudentsByCoreClass()
        {
            Console.Write("Enter core class name: ");
            Student.WriteStudentsToTable(DataBase.FindStudentByCoreClass(Console.ReadLine()));
        }


    }
}
