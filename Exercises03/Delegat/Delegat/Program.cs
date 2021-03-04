using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegat
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
            
            Console.ReadKey();
        }

        private static void ShowMenu()
        {
            string choice;
            Students students = new Students();
            do
            {  
                Console.WriteLine("1) Načtení studentů z klávesnice\n" +
                                    "2) Načtení random dat\n" +
                                    "3) Výpis studentů na obrazovku\n" +
                                    "4) Seřazení studentů podle čísla\n" +
                                    "5) Seřazení studentů podle jména\n" +
                                    "6) Seřazení studentů podle fakulty\n" +
                                    "0) Konec programu\n");

                Console.Write("Zadej volbu: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        students.LoadStudentsFromKeyboard();
                        break;
                    case "2":
                        students.LoadRandomStudents();
                        break;
                    case "3":
                        students.PrintListStudents();
                        break;
                    case "4":
                        students.SortByNumber();
                        break;
                    case "5":
                        students.SortByName();
                        break;
                    case "6":
                        students.SortByFaculty();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Neplatna volba!");
                        break;
                }
            } while (choice != "0");
        }
    }
}
