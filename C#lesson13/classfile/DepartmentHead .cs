using System;

namespace C_lesson13
{
    public class DepartmentHead : Employee
    {
        private int subordinatesCount;

        // Constructor với các thuộc tính cơ bản
        public DepartmentHead(string id, string fullName, string phoneNumber, int workdays)
           : base(id, fullName, phoneNumber, workdays)
        {
            SubordinatesCount = 0;
        }

        // Constructor với tất cả các thuộc tính, bao gồm số lượng cấp dưới và lương hằng ngày
        public DepartmentHead(string id, string fullName, string phoneNumber, int workdays, double dailySalary, int subordinatesCount)
           : base(id, fullName, phoneNumber, workdays, dailySalary)
        {
            this.SubordinatesCount = subordinatesCount;
        }

        public int SubordinatesCount { get => subordinatesCount; set => subordinatesCount = value; }

        // Phương thức để tăng số lượng cấp dưới
        public void IncreaseSubordinates()
        {
            SubordinatesCount++;
        }

        public override double SalaryCaculation()
        {
            return dailySalary * workDays + 100*SubordinatesCount;
        }
        public override string ToString()
        {
            return base.ToString() + $", Subordinates Count: {SubordinatesCount}";
        }
    }
}
