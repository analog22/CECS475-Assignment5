using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        //----------------------------------------- Slots ------
        static BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();



                    SearchStandardStudents();
                    break;
               
        
        //------------------- SearchStandardStudents ------
        private static void SearchStandardStudents()
        {
            Console.Write("Enter Standard ID: ");
            ReadChoice();
            Standard s = bl.GetStandardByIDWithStudents(choice);
            if (s == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            else if (s.Students == null || s.Students.Count == 0)
            {
                Console.WriteLine("This Standard has no Students!");
                return;
            }

            Console.WriteLine("\nContaining Students: {0}", s.Students.Count);
            foreach (Student student in s.Students)
                Console.WriteLine("- " + student.StudentName);
        }

            static void Main(string[] args)
        {
        }
    }
}
