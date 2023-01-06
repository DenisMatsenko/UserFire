using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace UserFire
{
    [BsonIgnoreExtraElements]
    class Student
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("student_id")]
        public string StudentID { get; set; }
        [BsonElement("first_name")]
        public string FirstName { get; set; }
        [BsonElement("last_name")]
        public string LastName { get; set; }
        [BsonElement("core_class")]
        public string CoreClass { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("addres")]
        public Address Address { get; set; }

        /// <summary>
        /// Write student info to console
        /// </summary>
        public void WriteStudentInfo()
        {
            NormalizeTextWidth(FirstName, 14);
            NormalizeTextWidth(LastName, 14);
            NormalizeTextWidth(Age, 6);
            NormalizeTextWidth(CoreClass, 12);
            Console.WriteLine(StudentID);
        }

        /// <summary>
        /// Create Student (You need to fill the info)
        /// </summary>
        /// <returns></returns>
        public static Student CreateStudent()
        {
            Student NewStudent = new Student();
            NewStudent.StudentID = Guid.NewGuid().ToString();

            Console.Write("Enter first name: ");
            NewStudent.FirstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            NewStudent.LastName = Console.ReadLine();

            Console.Write("Enter age: ");
            NewStudent.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter core class: ");
            NewStudent.CoreClass = Console.ReadLine();

            Address NewAdress = new Address();

            Console.Write("Enter City: ");
            NewAdress.City = Console.ReadLine();

            Console.Write("Enter County: ");
            NewAdress.Country = Console.ReadLine();

            NewStudent.Address = NewAdress;

            return NewStudent;
        }

        /// <summary>
        /// Write to console title of table with student info
        /// </summary>
        private static void WriteStudentInfoTableTitle()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            NormalizeTextWidth("First Name", 14);
            NormalizeTextWidth("Last Name", 14);
            NormalizeTextWidth("Age", 6);
            NormalizeTextWidth("CoreClass", 12);
            NormalizeTextWidth("Student ID", 10);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Write all students and their info to console
        /// </summary>
        public static void WriteStudentsToTable()
        {
            WriteStudentInfoTableTitle();

            foreach (Student student in DataBase.Collection.Find(student => true).ToList())
                student.WriteStudentInfo();

            Menu.BackToMenu();
        }

        /// <summary>
        /// Write student list and their info to console
        /// </summary>
        public static void WriteStudentsToTable(List<Student> StudentList)
        {
            WriteStudentInfoTableTitle();

            foreach (Student student in StudentList)
                student.WriteStudentInfo();

            Menu.BackToMenu();
        }

        private static void NormalizeTextWidth(string text, int width)
        {
            Console.Write(text);
            for (int i = 0; i < width - text.Length; i++)
                Console.Write(" ");
        }
        private static void NormalizeTextWidth(int num, int width)
        {
            Console.Write(num);
            for (int i = 0; i < width - num.ToString().Length; i++)
                Console.Write(" ");
        }
    }
}
