using System;
using System.Collections.Generic;
using System.Linq;

namespace C_lesson13
{
    public class Company
    {
        private string name;
        private string taxCode;
        private double monthlyRevenue;
        private List<Employee> employees; // Danh sách các nhân viên trong công ty

        // Constructor rỗng cũng phải có List để có thể thực hiện lưu trữ và sử dụng các hàm 
        public Company()
        {
            this.employees = new List<Employee>();
        }

        // Constructor để nhập thông tin công ty
        public Company(string name, string taxCode, double monthlyRevenue)
        {
            this.name = name;
            this.taxCode = taxCode;
            this.monthlyRevenue = monthlyRevenue;
            this.employees = new List<Employee>(); // Khởi tạo danh sách nhân viên
        }

        public string Name { get => name; set => name = value; }
        public string TaxCode { get => taxCode; set => taxCode = value; }
        public double MonthlyRevenue { get => monthlyRevenue; set => monthlyRevenue = value; }

        // Phương thức thêm nhân viên
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        // Phương thức xóa nhân viên
        public void RemoveEmployee(string empId)
        {
            for (int i = 0; i < employees.Count(); i++)
            {
                Employee emp = employees[i];
                if (emp.id.Equals(empId))
                {
                    employees.Remove(emp);
                    break;
                }
            }
        }

        // Lấy hết các nhân viên trong công ty
        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        // Phương thức tìm nhân viên theo id
        public Employee FindEmployeeById(string Id)
        {
            return employees.OfType<RegularEmployee>().FirstOrDefault(e => e.id.Equals(Id, StringComparison.OrdinalIgnoreCase));
        }

        //phương thức tìm trưởng phòng theo id
        public DepartmentHead FIndDepartmentHead(string Id)
        {
            return employees.OfType<DepartmentHead>().FirstOrDefault(e => e.id.Equals(Id, StringComparison.OrdinalIgnoreCase));
        }
        //Phương thức tìm tổng lương của toàn bộ công ty
        public double CalculatorTotalSalary()
        {
            return employees.Sum(e => e.SalaryCaculation());
        }
        //Phương thích tìm nhân viên thường có lương cao nhất
        public double HighestRegularSalary()
        {
            double HightSalary = 0;
            foreach (RegularEmployee emp in employees)
            {

                if (HightSalary < emp.SalaryCaculation())
                {
                    HightSalary = emp.SalaryCaculation();
                }
            }
            return HightSalary;
        }

        //Tìm trưởng phòng có nhiều nhân viên nhất
        public DepartmentHead MostEmployeeManager()
        {
            DepartmentHead topDHM = null;
            int maxSubordinates = -1;

            foreach (Employee emp in employees)
            {
                // Down-casting xuống DepartmentHead và lấy số lượng nhân viên để so sánh với biến maxSubordinates
                if (emp is DepartmentHead manager)
                {
                    int subordinatesCount = manager.SubordinatesCount; // Đảm bảo có thuộc tính SubordinatesCount trong DepartmentHead

                    // Logic condition
                    if (subordinatesCount > maxSubordinates)
                    {
                        maxSubordinates = subordinatesCount;
                        topDHM = manager;
                    }
                }
            }

            return topDHM;
        }
        //Phương thức sắp xếp nhân viên theo bảng chữ cái
        public void SortEmByAlphabet()
        {
            employees.Sort((emp1, emp2) => string.Compare(emp1.fullName, emp2.fullName, StringComparison.OrdinalIgnoreCase));
           
        }

        //Phương thức sắp xếp nhân viên theo lương (giảm dần)
        public void SortEmBySalary()
        {
            employees.Sort((emp1, emp2) => emp2.SalaryCaculation().CompareTo(emp1.SalaryCaculation()));
        }

        //Phương thức tìm sếp có mức cổ phần cao nhất
        public Director FindDirectorWithHighestShares()
        {
            Director topDirector = null;
            double highestShares = 0;

            foreach (Employee emp in employees)
            {
                if (emp is Director director)
                {
                    if (director.CompanyShares > highestShares)
                    {
                        highestShares = director.CompanyShares;
                        topDirector = director;
                    }
                }
            }

            return topDirector;
        }
        
        //Phương thức tính tổng lương của giám đốc
        public void CalculateAndDisplayTotalIncomeForDirectors()
        {
            foreach (Employee emp in employees)
            {
                if (emp is Director director)
                {
                    double baseSalary = director.SalaryCaculation();
                    double revenueShare = (director.CompanyShares / 100) * monthlyRevenue;
                    double totalIncome = baseSalary + revenueShare;
                    Console.WriteLine("Director: " + director.fullName + " - Total Income: " + totalIncome + "$");
                }
            }
        }


    }
}