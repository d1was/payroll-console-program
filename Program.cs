using System;
using System.Collections.Generic;
using Payroll_Program.Staffs;
using System.IO;
using Payroll_Program.Files;
using Payroll_Program.Slip;

namespace Payroll_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff;
            FileReader fs = new FileReader();
            int month = 0, year = 0;

            while(year == 0)
            {
                System.Console.Write("\nPlease enter the year: ");

                try
                {
                    year = Convert.ToInt32(System.Console.ReadLine());

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

            while(month == 0)
            {
                System.Console.Write("\n Please enter the month:");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());

                    if(month < 1 || month > 12)
                    {
                        Console.WriteLine("Invalid Month. Please enter again");
                        month = 0;
                    }
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Please enter valid number");
                }
            }

            myStaff = fs.ReadFile();

            for(int i = 0; i< myStaff.Count; i++)
            {
                try
                {
                    Console.Write("Enter number of hours worked by {0}: ", myStaff[i].NameOfStaff);
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());

                    myStaff[i].calculatePay();

                    myStaff.ToString();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    i--;
                }
            }

            PaymentSlip ps = new PaymentSlip(month, year);
            ps.GeneratPaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            Console.Read();




    }
    }
}
