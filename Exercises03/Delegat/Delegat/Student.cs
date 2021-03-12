using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegat
{
    public enum Faculty { 
        FES,
        FF,
        FEI,
        FCHT
    }
    public class Student
    {
        private string name;
        private int number;
        private Faculty fac;

        public Student(string name, int number, Faculty fac) {
            Name = name;
            Number = number;
            Faculty = fac;
        }

        public string Name { 
            get=>name;
            set =>name = value; 
        }
        public int Number { 
            get=>number; 
            set=>number=value;
        }
        public Faculty Faculty { 
            get=>fac; 
            set=>fac=value;
        }

        public void Print() {
            Console.WriteLine($"Name: {Name}, Number: {Number}, Faculty: {Faculty} ");
        }

    }
}
