using System;

namespace C_lesson13
{
    public class Director : Employee
    {
        private double companyShares;

        // Constructor của Director
        public Director(string id, string fullName, string phoneNumber, int workdays, double dailySalary, double companyShares)
            : base(id, fullName, phoneNumber, workdays, dailySalary)
        {
            // Kiểm tra tỷ lệ cổ phần
            if (companyShares <= 100)
            {
                this.companyShares = companyShares;
            }
            else
            {
                throw new ArgumentException("Company shares must be less than or equal to 100%");
            }
        }

        // Thuộc tính cho companyShares với kiểm tra điều kiện
        public double CompanyShares
        {
            get => companyShares;
            set
            {
                if (value <= 100)
                {
                    companyShares = value;
                }
                else
                {
                    throw new ArgumentException("Company shares must be less than or equal to 100%");
                }
            }
        }

        // Ghi đè phương thức tính lương
        public override double SalaryCaculation()
        {
            return dailySalary * workDays;
        }

        // Ghi đè phương thức ToString để in thông tin của Director
        public override string ToString()
        {
            return base.ToString() + $", Company Shares: {companyShares}%";
        }
    }
}
