using System;
using System.Collections.Generic;
using System.Text;
using Payroll_Program.Staffs;
using System.IO;

namespace Payroll_Program.Files
{
    class FileReader
    {

        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new String[2];
            string path = "staff.txt";
            string[] separator = {"," };

            if (File.Exists(path))
            {
                Console.WriteLine("Reading File...");
                StreamReader reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    string results = reader.ReadLine();
                    result[0] = results.Split(separator[0])[0];
                    result[1] = results.Split(separator[0])[1];

                    if (result[1] == "Manager")
                    {
                        Staff staff = new Manager(result[0]);
                        myStaff.Add(staff);
                    }
                    else if(result[1] == "Admin")
                    {
                        Staff staff = new Admin(result[0]);
                        myStaff.Add(staff);
                    }                       
                }

                reader.Close();
            }

            else
            {
                System.Console.WriteLine("File doesnot exist.. go and place a file you idiot");
            }

            return myStaff;
        }



    }
}
