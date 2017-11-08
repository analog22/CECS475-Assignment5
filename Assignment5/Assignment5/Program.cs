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
        private Standard newStd = new Standard();
        private Student newStu = new Student();
        private string strID;
        private int id;
        private string name;
        private int choice;

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
                StandardData = bl.GetAllStandards();
                StudentData = bl.GetAllStudents();

                DisplayMenu();
                InputChoice();

                Console.WriteLine("Selected: " + choice +"\n");

                switch (Convert.ToInt32(choice))
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
                    case 6: // Display all standards
                        GetStandards();
                        break;
                    case 7: // Display standard & all students
                        GetStandardAndStudents();
                        break;
                    #endregion

                    #region Student Switch
                    case 8: // Add
                        AddStudent();
                        break;
                    case 9: // Update
                        UpdateStudent();
                        break;
                    case 10: // Remove
                        RemoveStudent();
                        break;
                    case 11: // Search by ID
                        SearchStudentID();
                        break;
                    case 12: // Search by name
                        SearchStudentName();
                        break;
                    case 13: // Display all students
                        GetStudents();
                        break;
                    case 0: // end
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Switch statement error...");
                        break;
                    #endregion
                }
            }
        }

        #region Methods
        public void DisplayMenu()
        {
            Console.WriteLine("\n\n- - - - -  Repository Program  - - - - -");
            Console.WriteLine("\n[          Standard          ]");
            Console.WriteLine("1)  Add Standard");
            Console.WriteLine("2)  Update Standard");
            Console.WriteLine("3)  Remove Standard");
            Console.WriteLine("4)  Search for Standard by ID");
            Console.WriteLine("5)  Search for Standard by Name");
            Console.WriteLine("6)  Get all Standards");
            Console.WriteLine("7)  Get Standard and all Students");
            Console.WriteLine("\n[          Student          ]");
            Console.WriteLine("8)  Add Student");
            Console.WriteLine("9)  Update Student");
            Console.WriteLine("10) Remove Student");
            Console.WriteLine("11) Search for Student by ID");
            Console.WriteLine("12) Search for Student by Name");
            Console.WriteLine("13) Get all Students");
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("0)  Exit");
            Console.WriteLine("\n - Select an option: ");
        }

        public void InputChoice()
        {
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a valid number...");
            }
            if (choice < 0 || choice > 13)
            {
                Console.WriteLine("Please enter a valid choice [0 - 13]...");
                InputChoice();
            }
        }

        public void InputID()
        {
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please enter a valid number...");
            }
        }

        public void Continue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        #endregion

        #region Standard Methods
        private void AddStandard()
        {
            Console.WriteLine("--- Add Standard ---");

            Console.WriteLine("[optional] Enter Standard Name: ");
            string name = Console.ReadLine();
            if (name == null || name == "")
            {
                Console.WriteLine("Standard Name is null!");
            }
            else
            {
                newStd.StandardName = name;
            }

            Console.WriteLine("[optional] Enter Standard Description: ");
            string desc = Console.ReadLine();
            if (desc == null || desc == "")
            {
                Console.WriteLine("Standard Description is null!");
            }
            else
            {
                newStd.Description = desc;
            }

            bl.AddStandard(newStd);
            Console.WriteLine("Standard has been added!");

            Continue();
        }

        private void UpdateStandard()
        {
            Console.WriteLine("--- Update Standard ---");

            Console.WriteLine("Enter Standard ID to modify: ");
            InputID();
            newStd = bl.GetStandardByID(id);

            if (newStd == null)
            {
                Console.WriteLine("Standard not found!");
            }
            else
            {
                Console.WriteLine("[optional] Enter Standard Name: ");
                string name = Console.ReadLine();
                if (name == null || name == "")
                {
                    Console.WriteLine("Standard Name is null!");
                    return;
                }
                else
                {
                    newStd.StandardName = name;
                }

                Console.WriteLine("[optional] Enter Standard Description: ");
                string desc = Console.ReadLine();
                if (desc == null || desc == "")
                {
                    Console.WriteLine("Standard Description is null!");
                }
                else
                {
                    newStd.Description = desc;
                }

                bl.UpdateStandard(newStd);
                Console.WriteLine("Standard has been updated!");
            }

            Continue();
        }

        private void RemoveStandard()
        {
            Console.WriteLine("--- Remove Standard ---");

            Console.WriteLine("Enter Standard ID to remove: ");
            InputID();
            newStd = bl.GetStandardByID(id);

            if (newStd == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            else
            {
                bl.RemoveStandard(newStd);
                Console.WriteLine("Standard has been removed!");
            }
            
            Continue();
        }

        private void SearchStandardID()
        {
            Console.WriteLine("--- Search for Standard by ID ---");

            Console.WriteLine("Enter Standard ID to search: ");
            InputID();
            newStd = bl.GetStandardByID(id);

            if (newStd == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            else
            {
                Console.WriteLine("Standard found: {0}, {1}", newStd.StandardId, newStd.StandardName);
            }

            Continue();
        }

        private void SearchStandardName()
        {
            Console.WriteLine("--- Search for Standard by name ---");

            Console.WriteLine("Enter Standard Name to search: ");
            name = Console.ReadLine();
            newStd = bl.GetStandardByName(name);
            
            if (newStd == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            else
            {
                Console.WriteLine("Standard found: {0}, {1}", newStd.StandardId, newStd.StandardName);
            }

            Continue();
        }

        private void GetStandards()
        {
            Console.WriteLine("--- Get all Standards ---");
            Console.WriteLine("{0, -5}{1, 5}{2, 20}", "ID", "Standard Name", "Description");

            foreach (var s in StandardData)
            {
                Console.WriteLine("{0, -5}{1, 5}{2, 20}", s.StandardId, s.StandardName, s.Description);
            }

            Continue();
        }

        private void GetStandardAndStudents()
        {
            Console.WriteLine("--- Get Standard and all Students ---");

            Console.Write("Enter Standard ID: ");
            InputID();
            newStd = bl.GetStandardByIDWithStudents(id);

            if (newStd == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            else if (newStd.Students == null || newStd.Students.Count == 0)
            {
                Console.WriteLine("This Standard has no Students!");
                return;
            }
            else
            {
                Console.WriteLine("\nContaining Students: {0}", newStd.Students.Count);
                foreach (Student student in newStd.Students)
                    Console.WriteLine("- " + student.StudentName);
            }

            Continue();
        }
        #endregion

        #region Student Methods
        private void AddStudent()
        {
            Console.WriteLine("--- Add Student ---");
            
            Console.WriteLine("[optional] Enter Student Name: ");
            string name = Console.ReadLine();
            if (name == null || name =="")
            {
                Console.WriteLine("Student Name is null!");
            }
            else
            {
                newStu.StudentName = name;
            }

            Console.WriteLine("[optional] Enter Standard ID: ");
            InputID();
            if (id == null)
            {
                Console.WriteLine("Standard ID is null!");
            }
            else
            {
                newStu.StandardId = id;
            }

            bl.AddStudent(newStu);
            Console.WriteLine("Student has been added!");

            Continue();
        }

        private void UpdateStudent()
        {
            Console.WriteLine("--- Update Student ---");

            Console.WriteLine("Enter Student ID to modify: ");
            InputID();
            newStu = bl.GetStudentByID(id);

            if (newStu == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }
            else
            {
                Console.WriteLine("[optional] Enter Student Name: ");
                string name = Console.ReadLine();
                if (name == null)
                {
                    Console.WriteLine("Student Name is null!");
                }
                else
                {
                    newStu.StudentName = name;
                }

                Console.WriteLine("[optional] Enter Standard ID: ");
                strID = Console.ReadLine();
                id = Convert.ToInt32(strID);
                if (strID == null)
                {
                    Console.WriteLine("Standard ID is null!");
                }
                else
                {
                    newStu.StandardId = id;
                }

                bl.UpdateStudent(newStu);
                Console.WriteLine("Student has been updated!");
            }

            Continue();
        }

        private void RemoveStudent()
        {
            Console.WriteLine("--- Remove Student ---");

            Console.WriteLine("Enter Student ID to remove: ");
            InputID();
            newStu = bl.GetStudentByID(id);

            if (newStu == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }
            else
            {
                bl.RemoveStudent(newStu);
                Console.WriteLine("Student has been removed!");
            }

            Continue();
        }

        private void SearchStudentID()
        {
            Console.WriteLine("--- Search for Student by ID ---");

            Console.WriteLine("Enter Student ID to search: ");
            InputID();
            newStu = bl.GetStudentByID(id);

            if (newStu == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }
            else
            {
                Console.WriteLine("Student found: {0}, {1}", newStu.StudentID, newStu.StudentName);
            }

            Continue();
        }

        private void SearchStudentName()
        {
            Console.WriteLine("--- Search for Student by name ---");

            Console.WriteLine("Enter Student Name to search: ");
            name = Console.ReadLine();
            newStu = bl.GetStudentByName(name);

            if (newStu == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }
            else
            {
                Console.WriteLine("Standard found: {0}, {1}", newStu.StudentID, newStu.StudentName);
            }

            Continue();
        }

        private void GetStudents()
        {
            Console.WriteLine("--- Get all Students ---");

            Console.WriteLine("{0, -5}{1, 5}{2, 20}", "ID", "Student Name", "Standard ID");
            foreach (var s in StudentData)
            {
                Console.WriteLine("{0, -5}{1, 5}{2, 20}", s.StudentID, s.StudentName, s.StandardId);
            }

            Continue();
        }
        #endregion
    }
}
