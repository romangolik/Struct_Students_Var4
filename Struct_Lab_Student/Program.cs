using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace struct_lab_student
{
    partial class Program
    {
        static Student[] ReadData(string fileName)
        {
            string line;
            int count = 0;
            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    count++;
                }
            }
            Student[] students = new Student[count];
            StreamReader strmRdr = new StreamReader(fileName, Encoding.Default);
            int i = 0;
            while ((line = strmRdr.ReadLine()) != null)
            {
                string result = string.Join(" ", line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                students[i] = new Student(result);
                i++;
            }
            return students;
        }

        static void runMenu(Student[] studs)
        {
            int scholarship = 1800;
            StreamWriter sw = new StreamWriter("data_new.txt");
            foreach (Student st in studs)
            {
                double GPA = ((Convert.ToDouble(st.mathematicsMark - 48) + Convert.ToDouble(st.physicsMark - 48) + Convert.ToDouble(st.informaticsMark - 48)) / 3);
                if (st.mathematicsMark == '5' && st.physicsMark == '5' && st.informaticsMark == '5')
                {
                    Console.WriteLine("Студент " + st.surName + " " + st.firstName + " " + st.patronymic + ", дата народження " + st.dateOfBirth + ", отримує пiдвищену стипендiю у розмiрi: " + scholarship);
                    sw.WriteLine(st.surName + " " + st.firstName + " " + st.patronymic + " " + st.dateOfBirth + " " + st.mathematicsMark + " " + st.physicsMark + " " + st.informaticsMark + " " + scholarship);
                }
                else
                { 
                    sw.WriteLine(st.surName + " " + st.firstName + " " + st.patronymic + " " + st.dateOfBirth + " " + st.scholarship);
                }
            }
            sw.Close();
        }

        static void Main(string[] args)
        {
            Student[] studs = ReadData("data.txt");
            runMenu(studs);
            Console.ReadKey();
        }
    }
}
