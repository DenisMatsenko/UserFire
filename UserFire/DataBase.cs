using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace UserFire
{
    class DataBase
    {
        private const string DatabaseName = "Person";
        private const string CollectionName = "student";

        public static MongoClient Client { get; set; }
        public static IMongoDatabase Datebase { get; set; }
        public static IMongoCollection<Student> Collection { get; set; }

        static DataBase()
        {
            Client = new MongoClient("mongodb+srv://FirstDBUser:Dm2016dM@cluster0.oi18chy.mongodb.net/?retryWrites=true&w=majority");
            Datebase = Client.GetDatabase(DatabaseName);
            Collection = Datebase.GetCollection<Student>(CollectionName);
        }

        /// <summary>
        /// Add student to database
        /// </summary>
        /// <param name="student"></param>
        public static void AddStudent(Student student)
        {
            Collection.InsertOne(student);
        }

        /// <summary>
        /// Return list of students with specific core class
        /// </summary>
        /// <param name="coreClass"></param>
        /// <returns></returns>
        public static List<Student> FindStudentByCoreClass(string coreClass)
        {
            return DataBase.Collection.Find(student => student.CoreClass == coreClass).ToList();
        }
    }
}
