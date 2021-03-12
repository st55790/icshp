using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegat
{
    public delegate Student DelegateGetKey(int key);
    class StudentsTable
    {

        public Students Students { get; set; }
        
        public Student FindStudent(DelegateGetKey del, int key) {
            DelegateGetKey deleg = del;
            return deleg(key);
        }

        public bool AddStudent(DelegateGetKey del, Student student) {
            DelegateGetKey deleg = del;
            if (deleg(student.Number) == null) {
                Students.ListStudents.Add(student);
                return true;
            }
            return false;
        }

        public bool RemoveStudent(DelegateGetKey del, int key) {
            DelegateGetKey deleg = del;
            if (deleg(key) != null )
            {
                Students.ListStudents.Remove(deleg(key));
                return true;
            }
            return false;
        }

        public Student GetKey(int key) {
            foreach (var item in Students.ListStudents)
            {
                if (key == item.Number) {
                    return item;
                }
            }
            return null;
        }

    }
}
