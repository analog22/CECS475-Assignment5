using BusinessLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Program
    {
        BusinessLayer.BusinessLayer b1 = new BusinessLayer.BusinessLayer();
        IEnumerable<Standard> StandardData;
        IEnumerable<Student> StudentData;

        string[] arr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
        bool run = true;

        static void Main(string[] args)
        {
            Program tester = new Program();
            tester.mainMenu();
        }

        public void mainMenu()
        {
            //Standard newStandard = new Standard();
            //Student newStudent = new Student();
            StandardData = b1.GetAllStandards();
            StudentData = b1.GetAllStudents();
            string x = Console.ReadLine();
            while (!arr.Contains(x))
            {
                Console.WriteLine("Invalid input... Try again...");
                x = Console.ReadLine();
            }
            Console.WriteLine("Selected: " + x);

            switch (Convert.ToInt32(x))
            {
                case 1:
                    AddStandard();
                    break;
            }

            /*
             *  Standard options
             *  Add
             *  Update
             *  Delete
             *  Search by id or name
             *  Display all standards
             *  display all students by standard id
             *  
             *  Student options
             *  add
             *  update
             *  delete
             *  search by id or name
             *  display all
             */
        }

        private void AddStandard()
        {
            Standard newStandard = new Standard();
            Console.WriteLine("Enter Standard Name: ");
            string name = Console.ReadLine();
            newStandard.StandardName = name;
        }
    }
}
