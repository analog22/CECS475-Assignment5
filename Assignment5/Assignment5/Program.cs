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
        private BusinessLayer.BusinessLayer b1 = new BusinessLayer.BusinessLayer();
        private IEnumerable<Standard> StandardData;
        private IEnumerable<Student> StudentData;
        private Standard newStandard = new Standard();
        private Student newStudent = new Student();
        private string strID;
        private int id;
        private string name;

        string[] arr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
        bool run = true;

        static void Main(string[] args)
        {
            Program starter = new Program();
            starter.mainMenu();
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
            if (arr.Contains(x))
            {
                Console.WriteLine("Selected: " + x);

                switch (Convert.ToInt32(x))
                {
                    #region Standard
                    case 1: // Add
                        AddStandard();
                        break;
                    case 2: // Update
                        UpdateStandard();
                        break;
                    case 3: // Remove
                        RemoveStandard();
                        break;
                    case 4: // search by ID
                        SearchStandardID();
                        break;
                    case 5: // search by Name
                        SearchStandardName();
                        break;
                    case 6: // display all standards
                        break;
                    #endregion
                }
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
            Console.WriteLine("Enter Standard ID: ");
            string strID = Console.ReadLine();
            int id = Convert.ToInt32(strID);
            newStandard.StandardId = id;

            Console.WriteLine("[optional] Enter Standard Name: ");
            string name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Standard Name is null!");
            }
            else
            {
                newStandard.StandardName = name;
            }

            Console.WriteLine("[optional] Enter Standard Description: ");
            string desc = Console.ReadLine();
            if (desc == null)
            {
                Console.WriteLine("Standard Description is null!");
            }
            else
            {
                newStandard.Description = desc;
            }

            b1.AddStandard(newStandard);
        }

        private void UpdateStandard()
        {
            Console.WriteLine("Enter Standard ID to modify: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            newStandard = (from standard in SchoolDBEntity.schoolDB.Standards
                            where standard.StandardId == id
                            select standard).SingleOrDefault();

            Console.WriteLine("[optional] Enter Standard Name: ");
            string name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Standard Name is null!");
            }
            else
            {
                newStandard.StandardName = name;
            }

            Console.WriteLine("[optional] Enter Standard Description: ");
            string desc = Console.ReadLine();
            if (desc == null)
            {
                Console.WriteLine("Standard Description is null!");
            }
            else
            {
                newStandard.Description = desc;
            }

            b1.UpdateStandard(newStandard);
        }

        private void RemoveStandard()
        {
            Console.WriteLine("Enter Standard ID to remove: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            newStandard = (from standard in SchoolDBEntity.schoolDB.Standards
                        where standard.StandardId == id
                        select standard).SingleOrDefault();

            b1.RemoveStandard(newStandard);
        }

        private void SearchStandardID()
        {
            
        }

        private void SearchStandardName()
        {

        }
    }
}
