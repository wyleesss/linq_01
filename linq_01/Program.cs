using System.Text;

namespace Requests
{
    class Students
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int GroupNumber { get; set; }

        public string FullName => $"{Surname} {Name}";
    }

    class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    class Program
    {
        static void Main(string[] арґументи)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Group> groups = new List<Group>
            {
                new Group { Id = 1, Name = "індивідуальні" },
                new Group { Id = 2, Name = "групові" }
            };

            List<Students> students = new List<Students> 
            {
                new Students { Name = "Вадим",      Surname = "Тесліцький", GroupNumber = 2 },
                new Students { Name = "Олександра", Surname = "Мандиринка", GroupNumber = 2 },
                new Students { Name = "Анна",       Surname = "Ґант",       GroupNumber = 1 },
                new Students { Name = "Мирослав",   Surname = "Садовський", GroupNumber = 1 },
                new Students { Name = "Ніколь",     Surname = "Князева",    GroupNumber = 3 }
            };

            
            var query = from _student in students
                        from _group in groups
                        where _student.GroupNumber == _group.Id
                        select new { _student.FullName, _group.Name };


            Console.WriteLine("\t    таблиця студентів по групах:\n\n" +
                               "---------------------------------------------------\n" +
                              $"// {"      ім'я студента", -25} // {" група студента", -16} //\n" +
                               "---------------------------------------------------");

            foreach (var element in query)
                Console.WriteLine($"|| {element.FullName, -25} || {element.Name, -16} ||\n" +
                                   "- - - - - - - - - - - - - - - - - - - - - - - - - -");
        }
    }
}