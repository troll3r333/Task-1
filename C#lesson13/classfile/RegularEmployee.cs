using System;
using C_lesson13;

namespace C_lesson13
{
    public class RegularEmployee : Employee
    {
        private DepartmentHead manager;

        public RegularEmployee()
        {
            // Constructor mặc định
        }

        public RegularEmployee(string id, string fullName, string phoneNumber, int workdays)
            : base(id, fullName, phoneNumber, workdays)
        {
            // Constructor với các thuộc tính cơ bản
        }

        public RegularEmployee(string id, string fullName, string phoneNumber, int workdays, double dailySalary)
            : base(id, fullName, phoneNumber, workdays, dailySalary) 
        {
            this.manager = null;
        }

        public override double SalaryCaculation()
        {
            return dailySalary * workDays;
        }

    }
}
