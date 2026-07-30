using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Xml.Linq;
using Task3;
using static Task3.Student;

namespace Task3
{

    public class Student
    {
        public int studentId;
        public string name;
        public int age;
        public List<Course> courses = new();

        public Student(int studentId, string name, int age)
        {
            this.studentId = studentId;
            this.name = name;
            this.age = age;
        }

        //Methods
        public bool Enroll(Course course)
        {
            // check if course already addded 
            for (int i = 0; i < courses.Count; i++)
            {    // check by id
                if (courses[i].courseId == course.courseId)
                {
                    return false;
                }
            }

            courses.Add(course);
            return true;
        }


        public string PrintDetails()
        {

            string students = $"Student ID: {studentId}, Student Name: {name}, Age: {age} , ";
            students += "Courses : ";

            if (courses.Count == 0)
            {
                students += "No enrolled courses";
            }
            else
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    students += $"{courses[i].title}  ";//,
                }
            }
            return students;
        }
    }

}
    public class Instructor
    {
        public int instructorId;
        public string name;
        public string specialization;

        public Instructor(int instructorId, string name, string specialization)
        {
            this.instructorId = instructorId;
            this.name = name;
            this.specialization = specialization;
        }

        // Methods
        public string PrintDetails()
        {
        return $"Instructor ID = {instructorId}  \nInstructor Name = {name} \n Specialization = {specialization}\n ========================================= ";
    }
    }

    public class Course
    {
        public int courseId;
        public string title;
        public Instructor Instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            this.courseId = courseId;
            this.title = title;
            this.Instructor = instructor;
        }

        // Methods
        public string PrintDetails()
        {
        return $"Course Id = {courseId}\n \nCourse Name = {title}\n Instructor = {Instructor.name}\n ===========================================";
    }
    }

    class StudentManager
    {
        public List<Student> students = new();
        public List<Course> courses = new();
        public List<Instructor> instructors = new();

        //Methods
        public bool AddStudent(Student student)
        {
            for (int i = 0; i < students.Count; i++)
            {
                //(check id ==> id in list ==id by user )
                if (students[i].studentId == student.studentId)
                {
                    return false;
                }

            }
            students.Add(student);
            return true;
        }

        public bool AddCourse(Course course)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].courseId == course.courseId)
                {
                    return false;
                }
            }
            courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].instructorId == instructor.instructorId)//in list == by user new
                {
                    return false;
                }
            }

            instructors.Add(instructor);
            return true;

        }
        public Student? FindStudent(int studentId)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (studentId == students[i].studentId)
                {
                    return students[i];
                }
            }
            return null;
        }

        public Student? FindStudent(string studentName)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (studentName == students[i].name)
                {
                    return students[i];
                }
            }
            return null;
        }


        public Course? FindCourse(int courseId)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].courseId == courseId)
                {
                    return courses[i];
                }
            }
            return null;
        }

        public Course? FindCourse(string courseName)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].title == courseName)
                {
                    return courses[i];
                }
            }
            return null;
        }

        public Instructor? FindInstructor(int instructorId)
        {
            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].instructorId == instructorId)
                {
                    return instructors[i];
                }
            }
            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student == null || course == null)
                return false;

            return student.Enroll(course);
        }

        public bool StudentSpecificCourse(int studentId, int courseId)
        {
            Student student= FindStudent(studentId);
            if (student == null)
            {
                return false;
            }
            for (int i = 0; i < student.courses.Count; i++)
            {
                if (student.courses[i].courseId == courseId)
                {
                    return true;
                }
            }
            return false;
        }

        public string? GetInstructor(string courseName)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].title==courseName)
                {
                    return courses[i].Instructor.name;
                }
            }
            return null;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
 
            StudentManager studentManager = new StudentManager(); 
            int choice;
            do
            {
                Console.WriteLine("\t\t\t\t\t Student Managment System ");
                Console.WriteLine("\t\t\t\t1. Add Student (hint: start with empty list of courses) ");
                Console.WriteLine("\n\t\t\t\t2. Add Instructor");
                Console.WriteLine("\n\t\t\t\t3. Add Course (hint: select the instructor by id)");
                Console.WriteLine("\n\t\t\t\t4. Enroll Student in Course");
                Console.WriteLine("\n\t\t\t\t5. Show All Students");
                Console.WriteLine("\n\t\t\t\t6. Show All Courses ");
                Console.WriteLine("\n\t\t\t\t7. Show All Instructors");
                Console.WriteLine("\n\t\t\t\t8. Find the student by id or name ");
                Console.WriteLine("\n\t\t\t\t9. Find the course by id or name");
                Console.WriteLine("\n\t\t\t\t10. Check if the student enrolled in specific course ");
                Console.WriteLine("\n\t\t\t\t11. Return the instructor name by course name");
                Console.WriteLine("\n\t\t\t\t12. Exit ");

                Console.Write("\nEnter your Choice===> ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.Write("Enter StudentId: ");
                            int studentid = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter StudentName: ");
                            string studentName = Console.ReadLine();

                            Console.Write("Enter StudentAge: ");
                            int studentAge = Convert.ToInt32(Console.ReadLine());

                            Student student1 = new Student(studentid, studentName, studentAge);

                            if (studentManager.AddStudent(student1))
                            {
                                Console.WriteLine("Student Added Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Student Already Exists");
                            }

                        }
                        break;

                    case 2:
                        {
                            Console.Write("Enter InstructorId: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter InstructorName: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter specialization: ");
                            string specialization =Console.ReadLine();

                            Instructor instructor= new Instructor (id,name,specialization);
                             if(studentManager.AddInstructor(instructor))
                            {
                            Console.WriteLine("Instructor added successfully");
                            }
                            else
                            {
                                Console.WriteLine("instructor Already Exists");
                            }
                        
                }
                        break;

                    case 3:
                        {
                            if (studentManager.instructors.Count == 0)
                            {
                                Console.WriteLine("Enter Instructor first: ");
                                break;
                            }
                            Console.Write("Enter Course Id: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Title: ");
                            string title = Console.ReadLine();

                            Console.Write("enter instructor Id : ");
                            int instructorId = Convert.ToInt32(Console.ReadLine());
                            Instructor finins = studentManager.FindInstructor(instructorId);
                            if(finins != null)
                            {
                                studentManager.AddCourse(new Course (  id,  title,  finins ));
                                Console.WriteLine(" Course added successfully ");
                            }
                            else
                            {
                                Console.WriteLine("instructor not found");
                            }
                                
                        }
                        break;

                    case 4:
                        {
                            if (studentManager.students.Count == 0 || studentManager.courses.Count == 0)
                            {
                                Console.WriteLine("No student or No courses");
                                break;
                            }

                            Console.Write("Enter studenteId: ");
                            int studentId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter CourseId: ");
                            int courseId =Convert.ToInt32(Console.ReadLine());

                          bool result=  studentManager.EnrollStudentInCourse(studentId, courseId);
                            if (result)
                            {
                                Console.WriteLine("Student enrolled successfully");
                            }
                            else
                            {
                                Console.WriteLine("Enrollment failed");
                            }


                        }
                        break;

                    case 5:
                        {
                            if (studentManager.students.Count == 0)
                            {
                                Console.WriteLine("No students , Enter students first !");
                                break;
                            }
                            Console.WriteLine("\n=========  All Students ==============");
                            for (int i = 0; i < studentManager.students.Count; i++)
                            {
                                    Console.WriteLine(studentManager.students[i].PrintDetails()); 
                            }

                        }
                        break;

                    case 6:
                        {
                            if (studentManager.courses.Count == 0)
                            {
                                Console.WriteLine("No Courses , Enter courses first !");
                                break;
                            }
                        Console.WriteLine("\n======== All Courses ============");
                            for (int i = 0; i < studentManager.courses.Count; i++)
                            {
                                Console.WriteLine(studentManager.courses[i].PrintDetails());

                            }
                        Console.WriteLine();
                        }
                        break;

                    case 7:
                        {
                            if (studentManager.instructors.Count == 0)
                            {
                                Console.WriteLine("No Instructors , Enter instructors first!");
                            }
                        Console.WriteLine("\n========== All Instructors ============");
                            for (int i = 0; i < studentManager.instructors.Count; i++)
                            {
                                Console.WriteLine(studentManager.instructors[i].PrintDetails());
                            }
                        }
                        break;

                    case 8:
                        {
                            if (studentManager.students.Count == 0)
                            {
                                Console.WriteLine("There are no students , please enter Students first !");
                                break;
                            }
                            //يحدد هو عايز يعمل سيرش بال id ولا بال name
                            Console.WriteLine("Search by: ");
                            Console.WriteLine("1- Id");
                            Console.WriteLine("2- Name");
                            int search=Convert.ToInt32(Console.ReadLine());
                            if(search == 1)
                            {
                                Console.Write("Enter Student id : ");
                                int id = Convert.ToInt32(Console.ReadLine());

                                Student student = studentManager.FindStudent(id);

                                if (student != null)//لو معملتهاش واليوزر دخل id غلط هيعمل expection 
                                    Console.WriteLine(student.PrintDetails());
                                else
                                    Console.WriteLine("Student not found");
                            }
                            else if (search == 2)
                            {
                                Console.WriteLine("Enter Student Name : ");
                                string studentName = Console.ReadLine();

                                Student student = studentManager.FindStudent(studentName);

                                if (student != null)//لو معملتهاش واليوزر دخل id غلط هيعمل expection 
                                    Console.WriteLine(student.PrintDetails());
                                else
                                    Console.WriteLine("Student not found");
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice");
                            }
                            
                        }
                        break;

                    case 9:
                        {
                            if (studentManager.courses.Count == 0)
                            {
                                Console.WriteLine("There are no courses , please Enter Course first !");
                                break;
                            }
                            //يحدد هو عايز يعمل سيرش بال id ولا بال name
                            Console.WriteLine("Search by: ");
                            Console.WriteLine("1- Id");
                            Console.WriteLine("2- Name");
                            int search = Convert.ToInt32(Console.ReadLine());
                            if (search == 1)
                            {
                                Console.Write("Enter Courseid : ");
                                int id = Convert.ToInt32(Console.ReadLine());

                                Course course = studentManager.FindCourse(id);

                                if (course != null)//لو معملتهاش واليوزر دخل id غلط هيعمل expection 
                                    Console.WriteLine(course.PrintDetails());
                                else
                                    Console.WriteLine("Course not found");
                            }
                            else if (search == 2)
                            {
                                Console.Write("Enter Course Name: ");
                                string courseName = Console.ReadLine();

                                Course course = studentManager.FindCourse(courseName);

                                if (course != null)//لو معملتهاش واليوزر دخل id غلط هيعمل expection 
                                    Console.WriteLine(course.PrintDetails());
                                else
                                    Console.WriteLine("Course not found");
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice");
                            }
                        }
                        break;

                    case 10:
                        {
                            Console.Write("Enter Sudente Id: ");
                            int studentId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Course Id: ");
                            int courseId = Convert.ToInt32(Console.ReadLine());

                            bool result=studentManager.StudentSpecificCourse(studentId, courseId);
                            if (result)
                            {
                                Console.WriteLine("Student is enrolled in this course");
                            }
                            else
                            {
                                Console.WriteLine("Student is not enrolled in this course");
                            }
                        }
                        break;

                    case 11:
                        {
                            Console.Write("Enter Course Name: ");
                            string courseName = Console.ReadLine();

                            string instructorName= studentManager.GetInstructor(courseName);
                            if(instructorName == null)
                            {
                                Console.WriteLine("Course not found");
                            }
                            else
                            {
                                Console.WriteLine(instructorName);
                            }
                        }
                        break;
                    case 12:
                        {
                            Console.WriteLine("good bye...");
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Unknown choice, Enter correct choice");
                        }
                        break;
                }
            } while (choice != 12);
        }
    }

                
            
       
