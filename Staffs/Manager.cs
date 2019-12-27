using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_Program.Staffs
{
    class Manager: Staff
    {
        private const int managerHourlyRate = 50;

        public int Allowance
        {
            get; private set;
        }

        public Manager(string name): base(name, managerHourlyRate)
        {

        }

        public override void calculatePay()
        {
            base.calculatePay();

            Allowance = 1000;

            if(HoursWorked > 160)
            {
                TotalPay += Allowance;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
