using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_lesson13
{
    public abstract class Employee
    {
        //thuộc tính lớp Employee
        private string Id;
        private string FullName;
        private string PhoneNumber;
        private int WorkDays;
        private double DailySalary;

        //Constructor rỗng
        public Employee()
        {

        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {FullName}, Phone: {PhoneNumber}, WorkDays: {WorkDays}, DailySalary: {DailySalary}";
        }

        // Build constructor có tham số của employee để truyền thông tin nhân viên vào trong mảng (class main)
        public Employee(String id, String fullName, String phoneNumber, int workDays)
        {
            this.Id = id;
            this.FullName = fullName;
            this.PhoneNumber = phoneNumber;
            this.WorkDays = workDays;
        }
        
        //Build tiếp một constructor phục vụ cho việc tính lương cho các role nhân viên(Subclass)
        public Employee(String id, String fullName, String phoneNumber, int workDays, double dailySalary)
        {
            this.Id = id;
            this.FullName = fullName;
            this.PhoneNumber = phoneNumber;
            this.WorkDays = workDays;
            this.DailySalary = dailySalary;
        }

        public string id { get => Id; set => Id = value; }
        public string fullName { get => FullName; set => FullName = value; }
        public string phoneNumber { get => PhoneNumber; set => PhoneNumber = value; }
        public int workDays { get => WorkDays; set => WorkDays = value; }
        public double dailySalary { get => DailySalary; set => DailySalary = value; }
       
        //Phương thức trừu tượng để tính lương tổng cho cả 3 roles
        public abstract double SalaryCaculation();
        
        //Phương thức ghi đè chuỗi
        public String toString()
        {
            return "Employee ID: " + id + ",Full Name: " + fullName + " ,Phone Number: " + phoneNumber + " ,Number of woring days: " + workDays + ",Daily salary: " + dailySalary + "$";
        }
    }


}