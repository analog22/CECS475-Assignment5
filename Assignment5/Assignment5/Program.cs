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
        private BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        private IEnumerable<Standard> StandardData;
        private IEnumerable<Student> StudentData;
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
            while (run)
            {
                Console.WriteLine("------- Standard -------");
                Console.WriteLine("0)  Exit");
                Console.WriteLine("1)  Add Standard");
                Console.WriteLine("2)  Update Standard");
                Console.WriteLine("3)  Remove Standard");
                Console.WriteLine("4)  Search for Standard by ID");
                Console.WriteLine("5)  Search for Standard by Name");
                Console.WriteLine("6)  Get Standard and all Students");
                Console.WriteLine("------- Student -------");
                Console.WriteLine("7)  Add Student");
                Console.WriteLine("8)  Update Student");
                Console.WriteLine("9)  Remove Student");
                Console.WriteLine("10) Search for Student by ID");
                Console.WriteLine("11) Search for Student by Name");
                Console.WriteLine("12) Get all Students");
                //Standard newStandard = new Standard();
                //Student newStudent = new Student();
                StandardData = bl.GetAllStandards();
                StudentData = bl.GetAllStudents();
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
                        #region Standard Switch
                        case 1: // Add
                            AddStandard();
                            break;
                        case 2: // Update
                            UpdateStandard();
                            break;
                        case 3: // Remove
                            RemoveStandard();
                            break;
                        case 4: // Search by ID
                            SearchStandardID();
                            break;
                        case 5: // Search by name
                            SearchStandardName();
                            break;
                        case 6: // Display standard & all students
                            GetStandardAndStudents();
                            break;
                        #endregion

                        #region Student Switch
                        case 7: // Add
                            break;
                        case 8: // Update
                            break;
                        case 9: // Remove
                            break;
                        case 10: // Search by ID
                            break;
                        case 11: // Search by name
                            break;
                        case 12: // Display all students
                            break;
                        case 0: // end
                            run = false;
                            break;
                        default:
                            Console.WriteLine("Switch statement error...");
                            break;
                            #endregion
                    }
                }
            }
        }

        #region Standard Methods
        private void AddStandard()
        {
            Standard add = new Standard();

            Console.WriteLine("Enter Standard ID: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            add.StandardId = id;

            Console.WriteLine("[optional] Enter Standard Name: ");
            string name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Standard Name is null!");
            }
            else
            {
                add.StandardName = name;
            }

            Console.WriteLine("[optional] Enter Standard Description: ");
            string desc = Console.ReadLine();
            if (desc == null)
            {
                Console.WriteLine("Standard Description is null!");
            }
            else
            {
                add.Description = desc;
            }

            bl.AddStandard(add);
        }

        private void UpdateStandard()
        {
            Console.WriteLine("Enter Standard ID to modify: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            Standard update = (from standard in SchoolDBEntity.schoolDB.Standards
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
                update.StandardName = name;
            }

            Console.WriteLine("[optional] Enter Standard Description: ");
            string desc = Console.ReadLine();
            if (desc == null)
            {
                Console.WriteLine("Standard Description is null!");
            }
            else
            {
                update.Description = desc;
            }

            bl.UpdateStandard(update);
        }

        private void RemoveStandard()
        {
            Console.WriteLine("Enter Standard ID to remove: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            Standard remove = (from standard in SchoolDBEntity.schoolDB.Standards
                        where standard.StandardId == id
                        select standard).SingleOrDefault();

            bl.RemoveStandard(remove);
        }

        private void SearchStandardID()
        {
            Console.WriteLine("Enter Standard ID to search: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            Standard s = bl.GetStandardByID(id);
            if (s == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            Console.WriteLine("Standard found: {0}, {1}", s.StandardId, s.StandardName);
        }

        private void SearchStandardName()
        {
            Console.WriteLine("Enter Standard Name to search: ");
            name = Console.ReadLine();
            Standard s = bl.GetStandardByName(name);
            if (s == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            Console.WriteLine("Standard found: {0}, {1}", s.StandardId, s.StandardName);
        }

        private void GetStandardAndStudents()
        {
            Console.Write("Enter Standard ID: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            Standard s = bl.GetStandardByIDWithStudents(id);
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
        #endregion

        #region Student Methods
        private void AddStudent()
        {
            Student add = new Student();

            Console.WriteLine("Enter Standard ID: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            add.StandardId = id;

            Console.WriteLine("[optional] Enter Student ID: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            if (id == null)
            {
                Console.WriteLine("Student ID is null!");
            }
            else
            {
                add.StudentID = id;
            }

            Console.WriteLine("[optional] Enter Student Name: ");
            string name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Student Name is null!");
            }
            else
            {
                add.StudentName = name;
            }

            bl.AddStudent(add);
        }

        private void UpdateStudent()
        {
            Console.WriteLine("Enter Student ID to modify: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            Student update = (from student in SchoolDBEntity.schoolDB.Students
                               where student.StudentID == id
                               select student).SingleOrDefault();

            Console.WriteLine("[optional] Enter Student Name: ");
            string name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Student Name is null!");
            }
            else
            {
                update.StudentName = name;
            }

            bl.UpdateStudent(update);
        }

        private void RemoveStudent()
        {
            Console.WriteLine("Enter Student ID to remove: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            Student remove = (from student in SchoolDBEntity.schoolDB.Students
                               where student.StudentID == id
                               select student).SingleOrDefault();

            bl.RemoveStudent(remove);
        }

        private void SearchStudentID()
        {
            Console.WriteLine("Enter Student ID to search: ");
            strID = Console.ReadLine();
            id = Convert.ToInt32(strID);
            Student s = bl.GetStudentByID(id);
            if (s == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }
            Console.WriteLine("Student found: {0}, {1}", s.StudentID, s.StudentName);
        }

        private void SearchStudentName()
        {
            Console.WriteLine("Enter Student Name to search: ");
            name = Console.ReadLine();
            Student s = bl.GetStudentByName(name);
            if (s == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }
            Console.WriteLine("Standard found: {0}, {1}", s.StudentID, s.StudentName);
        }

        private void GetStudents()
        {
            
        }
        #endregion
    }
}
