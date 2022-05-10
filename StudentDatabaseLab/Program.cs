namespace StudentDatabaseLab {
    using StudentDatabaseLab.Models;
    public class Program
    {

        public static void Main()
        {
            StudentsContext db = new StudentsContext();
            List<StudentInfo> students = new List<StudentInfo>();
            students = db.StudentInfos.ToList();
         
            StudentsCRUD sc = new StudentsCRUD();
         

            bool runagain = true;
            while (runagain == true)
            {
                Console.WriteLine($"Index\t\tName\t\t");
                for (int i = 0; i < students.Count; i++)
                {
                    StudentInfo student = students[i];
                    Console.WriteLine($"{i}\t\t{student.Studentname}");
                }
                Console.WriteLine("Please Select a student from the index");
                int index = int.Parse(Console.ReadLine());
                StudentInfo Selected = students[index];
                Console.WriteLine("Would you like to learn about your students hometown, fav food or fav color");
                string info = Console.ReadLine();
                switch (info)
                {
                    case "food":
                        Console.WriteLine($"{Selected.Studentname}'s favorite food is {Selected.Favfood}");
                        break;
                    case "hometown":
                        Console.WriteLine($"{Selected.Studentname}'s hometown is {Selected.Hometown}");
                        break;
                    case "color":
                        Console.WriteLine($"{Selected.Studentname}'s favorite color is {Selected.Favcolor}");
                        break;
                    default:
                        Console.WriteLine("Sorry I didnt understand that please try again");
                        break;


                }
                Console.WriteLine("Would you like to add or delete a student input yes or no");
                string addOrDeleteCond = Console.ReadLine(); 
                if (addOrDeleteCond == "yes")
                {
                    Console.WriteLine("Would you like to add or delete");
                    string AorD = Console.ReadLine();
                    if(AorD == "add")
                    {
                        string name = GetUserInput("What is there name");
                        string hometown = GetUserInput("Where are they from");
                        string favFood = GetUserInput("What is their favorite food");
                        string favColor = GetUserInput("What is their favorite color");
                        StudentInfo newStudent = new StudentInfo() {  Studentname=name, Favcolor=favColor, Favfood=favFood, Hometown=hometown};
                        sc.CreateStudent(newStudent);
                        continue;
                    }
                    if(AorD == "delete")
                    {
                        int indexdelete = int.Parse(GetUserInput("Which index of student would you like to delete"));
                        sc.DeleteStudent(indexdelete);
                        continue;
                    }
                    else
                    {
                        return;
                    }

                    
                }
                runagain = RunAgain();

            }
        }
        public static string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            return input;
        }
        public static bool RunAgain()
        {
            string answer = GetUserInput("Would you like to run again? y/n");
            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I'm sorry I didn't understand that");
                Console.WriteLine("Please input y or n");
                Console.WriteLine("Lets try again");
                return RunAgain();
            }
        }



    }
    }
