using System;
using System.Collections.Generic;
using System.Text;
using Payroll_Program.Staffs;
using System.IO;
using System.Linq;

namespace Payroll_Program.Slip
{
    class PaymentSlip
    {
        private int month, year;

        public enum monthsOfYear
        {
            January = 1, Febrauary, March, April, May, June, July, August, September, October, November, December
        }

        public PaymentSlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }


        public void GeneratPaySlip(List<Staff> myStaffs)
        {
            string path;

            foreach (Staff staff in myStaffs)
            {
                path = staff.NameOfStaff + ".txt";

                Console.WriteLine("Generating file {0}...", path);

                StreamWriter writer = new StreamWriter(path);
                writer.WriteLine("PAYSLIP for {0}/{1}", (monthsOfYear) month, year);
                writer.WriteLine("================================");
                writer.WriteLine("Name of the Staff: {0}", staff.NameOfStaff);
                writer.WriteLine("Hours Worked: {0}", staff.HoursWorked);
                writer.WriteLine("");
                writer.WriteLine("Basic Pay: {0}", staff.BasicPay);
                if (staff.GetType() == typeof(Manager))
                {
                    writer.WriteLine("Allowance: {0:c}", ((Manager)staff).Allowance);
                }
                else if (staff.GetType() == typeof(Admin))
                {
                    writer.WriteLine("Overtime: {0:c}", ((Admin)staff).Overtime);
                }
                writer.WriteLine("");
                writer.WriteLine("Total Pay: {0:c}", staff.TotalPay);

                writer.WriteLine("==========================================");

                writer.Close();

                Console.WriteLine("Succesfully generated file {0}", path);


            }
        }


        public void GenerateSummary(List<Staff> staffs)
        {
            var results = from staff in staffs
                          where staff.HoursWorked < 10
                          select new
                          {
                              staff.NameOfStaff,
                              staff.HoursWorked
                          };
            string path = "summary.txt";

            Console.WriteLine("Generating file {0}..", path);

            StreamWriter writer = new StreamWriter(path);

            writer.WriteLine("Staff less than 10 working hours");
            writer.WriteLine("");
            foreach (var r in results)
            {
                writer.WriteLine("Name of Staff: {0}, Hours Worked: {1}", r.NameOfStaff, r.HoursWorked);
            }
            writer.Close();
            Console.WriteLine("Succesfully Generated file {0}..", path);
        }

        public void toString()
        {
            System.Console.WriteLine("Payment Slip Generator");
        }
    }
}