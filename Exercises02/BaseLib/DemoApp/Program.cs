using Fei.BaseLib;
using System;
using System.Linq;

namespace DemoApp
{
    class Program
    {
        public static int[] array;
        static void Main(string[] args)
        {
            ShowMenu();
            Console.ReadKey();
        }

        public static void ShowMenu() {
            bool repeat = true;

            while (repeat) {

                Console.WriteLine("1.Zadaní prvků pole z klávesnice\n" +
                                  "2.Výpis pole na obrazovku\n" +
                                  "3.Utřídění pole vzestupně\n" +
                                  "4.Utřídění pole sestupně\n" +
                                  "5.Hledání minimálního prvku\n" +
                                  "6.Hledání prvního výskytu zadaného čísla\n" +
                                  "7.Hledání posledního výskytu zadaného čísla\n" +
                                  "8.Konec programu");
                string choice = Reading.ReadString("Zadej volbu");
                switch (choice)
                {
                    case "1":
                        ReadFromKeyboard();
                        break;
                    case "2":
                        PrintArray();
                        break;
                    case "3":
                        SortAsc();
                        break;
                    case "4":
                        SortDesc();
                        break;
                    case "5":
                        GetMin();
                        break;
                    case "6":
                        GetFirstOccurenceInArray();
                        break;
                    case "7":
                        GetLastOccurenceInArray();
                        break;
                    case "8":
                        repeat = false;
                        Console.WriteLine("Konec programu");
                        break;
                    default:
                        Console.WriteLine("Neplatná volba!\nLze zadat pouze 1-8\n");
                        break;
                }
            }
        }

        private static void SortDesc()
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Pole je prázdné!");
                return;
            }

            array = array.OrderByDescending(x => x).ToArray();
        }

        private static void GetLastOccurenceInArray()
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Pole je prázdné!");
                return;
            }

            int choice = Reading.ReadInt("Zadej hledané číslo");
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == choice)
                {
                    index = i;
                }
            }

            if (index != -1)
            {
                Console.WriteLine("První výskyt čísla " + choice + " je na indexu: " + index + "\n");
            }
            else { 
                Console.WriteLine("Hledané číslo není v poli");
            }
        }

        private static void GetFirstOccurenceInArray()
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Pole je prázdné!");
                return;
            }

            int choice = Reading.ReadInt("Zadej hledané číslo");
            for (int i = 0; i < array.Length; i++) {
                if (array[i] == choice) {
                    Console.WriteLine("První výskyt čísla " + choice + " je na indexu: " + i + "\n");
                    break;
                }
            }
            Console.WriteLine("Hledané číslo není v poli");
        }

        private static void GetMin()
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Pole je prázdné!");
                return;
            }

            Console.WriteLine("Nejmenší prvek je: " + array.Min());
        }

        private static void SortAsc()
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Pole je prázdné!");
                return;
            }
            array = array.OrderBy(x => x).ToArray();
        }

        private static void PrintArray()
        {
            if (array == null || array.Length == 0) {
                Console.WriteLine("Pole je prázdné!");
                return;
            }
           
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(i + ". ->" + array[i]);
            }
        }

        private static void ReadFromKeyboard()
        {
            int size = Reading.ReadInt("Zadej velikost pole");
            array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = Reading.ReadInt("Zadej prvek");
            }
        }
    }
}
