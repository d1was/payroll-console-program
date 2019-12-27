using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_Program.Staffs
{
    class Staff
    {
        private float hourlyRate;
        private int hWorked;

        public float TotalPay {
            get;protected set;
        }
        public float BasicPay { get; private set; }

        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get
            {
                return hWorked;
            }

            set
            {
                if(value > 0)
                {
                    hWorked = value;
                }
                else
                {
                    hWorked = 0;
                }
            }
        }


        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        public virtual void calculatePay()
        {
            System.Console.WriteLine("Calculating Pay...");

            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;

        }

        public void toString()
        {
            System.Console.WriteLine("Staff Name: {0}\n Hours Worked: {1} \n Hourly Rate: {2} \n Basic Payment: {3}", NameOfStaff, hWorked, hourlyRate, BasicPay);
        }

    }
}
