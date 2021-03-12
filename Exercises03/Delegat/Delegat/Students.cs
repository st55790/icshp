using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegat
{
    public class Students
    {
        public Students() {
            ListStudents = new List<Student>();
        }
        public List<Student> ListStudents { get; set; }

        public void LoadStudentsFromKeyboard()
        {
            Console.Write("Zadej počet studentů: ");
            string input = Console.ReadLine();
            int count = 0;
            if (!int.TryParse(input, out count))
            {
                Console.WriteLine("Zadal si nekorektní vstup pro počet studentů");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Zadej jméno {i+1}. studenta: ");
                string name = Console.ReadLine();

                Console.Write($"Zadejte číslo {i+1}. studenta: ");
                input = Console.ReadLine();
                int num;
                if (!int.TryParse(input, out num))
                {
                    Console.WriteLine("Zadal si nekorektní číslo, použije se tedy 0");
                    num = 0;
                }

                foreach (Faculty faculty in (Faculty[])Enum.GetValues(typeof(Faculty)))
                {
                    Console.WriteLine($"{(int)faculty} -> {faculty}");
                }
                Console.Write($"Zadej odpovídající číslo pro fakultu: ");
                input = Console.ReadLine();
                Faculty fac = (Faculty)Convert.ToInt32(input);

                Student student = new Student(name, num, fac);
                ListStudents.Add(student);
            }
        }

        public void PrintListStudents() {
            for (int i = 0; i < ListStudents.Count; i++)
            {
                ListStudents[i].Print();
            }
        }

        public void SortByNumber() {
            //ListStudents = ListStudents.OrderBy(o=> o.Number).ToList();
            DelegateStudent delegateNumber = CompareNumber;
            SortList(ListStudents, delegateNumber);
        }

        public void SortByName() {
            //ListStudents = ListStudents.OrderBy(o => o.Name).ToList();
            DelegateStudent delegateName = CompareName;
            SortList(ListStudents, delegateName);
        }

        public void SortByFaculty() {
            //ListStudents = ListStudents.OrderBy(o => o.Faculty).ToList();
            DelegateStudent delegateFaculty = CompareFaculty;
            SortList(ListStudents, delegateFaculty);
        }

        public delegate int DelegateStudent(Student first, Student second);
        //public delegate int DelegateFaculty(Faculty first, Faculty second);
        //public delegate int DelegateName(string first, string second);

        public int CompareNumber(Student first, Student second)
        {
            return first.Number - second.Number;
        }
        public int CompareName(Student first, Student second) {
            return String.Compare(first.Name, second.Name);
        }

        public int CompareFaculty(Student first, Student second) {
            return first.Faculty - second.Faculty;
        }

        public void SortList(List<Student> list, DelegateStudent del) {
            for (int i = 0; i < ListStudents.Count-1; i++)
            {
                for (int j = 0; j < ListStudents.Count-i-1; j++)
                {
                    int result = del(list[j + 1], list[j]);
                    if (result < 1) {
                        Student tmp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = tmp;
                    }
                }
            }
        }

        public Student GenerateRandomStudent() {
            return new Student(RandomString(5), RandomNum(9), RandomFaculty(1));
        }

        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public int RandomNum(int length)
        {
            const string chars = "0123456789";
            string result = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return int.Parse(result);
        }

        public Faculty RandomFaculty(int length)
        {
            const string chars = "0123";
            string result = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            int fac = int.Parse(result);
            return (Faculty)fac;
        }

        public void LoadRandomStudents() {
            Console.Write("Zadej počet studentů: ");
            string input = Console.ReadLine();
            int count = 0;
            if (!int.TryParse(input, out count))
            {
                Console.WriteLine("Zadal si nekorektní vstup pro počet studentů");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                ListStudents.Add(GenerateRandomStudent());
            }

        }

    }
}
