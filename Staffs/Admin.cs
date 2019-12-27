using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_Program.Staffs
{
    class Admin : Staff
    {
        private const float overtimeRate = 15.5f, adminHourlyRate = 30.0f;

        public float Overtime { get; private set; }

        public Admin(string name) : base(name, adminHourlyRate)
        {

        }

        public override void calculatePay()
        {
            base.calculatePay();

            if(HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }
        }



    }
}
