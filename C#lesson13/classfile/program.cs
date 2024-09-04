using Microsoft.VisualBasic.FileIO;
using System;

namespace C_lesson13
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            bool exit = false;
            Console.WriteLine("Enter your number between 1 and 12 to pick an option from the menu below:");

            while (!exit) // Sửa điều kiện vòng lặp để đảm bảo vòng lặp sẽ chạy
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1.Nhap thong tin cua cong ty.");
                Console.WriteLine("2. Chi dinh day nhan vien cho truong phong.");
                Console.WriteLine("3. Them hoac xoa nhan vien.");
                Console.WriteLine("4. Hien thong tin toan bo nhan vien.");
                Console.WriteLine("5. Tinh tong so luong toan bo cong ty.");
                Console.WriteLine("6. Nhan vien binh thuong co muc luong cao nhat.");
                Console.WriteLine("7. Tim truong phong co so nhan vien cao nhat.");
                Console.WriteLine("8. Sap xep nhan vien theo bang chu cai.");
                Console.WriteLine("9. sap xep nhan vien theo luong(giam dan).");
                Console.WriteLine("10. Tim vi giam doc co co phan lon nhat trong cong ty.");
                Console.WriteLine("11. Tinh toan va hien thu nhap cua cac vi giam doc.");
                Console.WriteLine("12. Exit.");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Nhập thông tin công ty
                        Console.WriteLine("Nhap ten cong ty: ");
                        company.Name = Console.ReadLine();
                        Console.WriteLine("Nhap ma so thue: ");
                        company.TaxCode = Console.ReadLine();
                        Console.WriteLine("Nhap doanh thu: ");
                        company.MonthlyRevenue = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ten goi cua cong ty la: "+company.Name+"\n"+"Ma thue cua cong ty la: "+company.TaxCode+
                            "\n"+"Doanh thu vua roi cua cong ty la: "+company.MonthlyRevenue+"%");
                        Console.WriteLine("Thong tin ve cong ty ban da duoc cap nhat");
                        break;
                        case 2:
                        //gán thông nhân viên cho trưởng phòng
                        Console.WriteLine("Nhap id cua nhan vien: ");
                        string EmId = Console.ReadLine();
                        Console.WriteLine("Nhap id cua truong phong: ");
                        string HeadId = Console.ReadLine();
                        //in đối tượng
                         RegularEmployee regularEmployee = company.FindEmployeeById(EmId) as RegularEmployee;
                        DepartmentHead departmentHead = company.FIndDepartmentHead(HeadId);

                        // Kiểm tra xem cả hai đối tượng có tồn tại không
                        if (regularEmployee != null && departmentHead != null)
                        {
                            // Thêm logic ở đây để gán nhân viên thường cho trưởng phòng 
                            departmentHead.IncreaseSubordinates();
                            Console.WriteLine("Nhan vien " + regularEmployee.fullName + " da duoc gan cho truong phong " + departmentHead.fullName + ".");
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay nhan vien hoac truong phong.");
                        }
                        break;
                    case 3:
                        //Thêm thông tin nv hoặc xóa thông tin
                        Console.WriteLine("Lua chon them hoac xoa nhan vien: ");
                        Console.WriteLine("1. De them thong tin cua nhan vien: ");
                        Console.WriteLine("2. Xoa thong tin: ");
                        int subInt = int.Parse(Console.ReadLine());

                        if (subInt == 1)
                        {
                            Console.WriteLine("Nhap id cua nhan vien: ");
                            string id = Console.ReadLine();
                            Console.WriteLine("Nhap ho ten cua nhan vien: ");
                            string fullName = Console.ReadLine();
                            Console.WriteLine("Nhap so dien thoai cua nhan vien: ");
                            string phoneNumber = Console.ReadLine();
                            Console.WriteLine("Nhap so ngay lam viec: ");
                            int workDays = int.Parse(Console.ReadLine());

                            Console.WriteLine("Chuc vu trong cong ty: ");
                            Console.WriteLine("1. Nhan vien thuong.");
                            Console.WriteLine("2. Truong phong.");
                            Console.WriteLine("3. Giam doc.");
                            int role = int.Parse(Console.ReadLine());

                            Employee employee = null;

                            // Giá trị định sẵn cho các loại nhân viên
                            const double regularSalary = 100;
                            const double departmentHeadSalary = 200;
                            const double directorSalary = 300;

                            switch (role)
                            {
                                case 1:
                                    employee = new RegularEmployee(id, fullName, phoneNumber, workDays, regularSalary);
                                    break;

                                case 2:
                                    employee = new DepartmentHead(id, fullName, phoneNumber, workDays, departmentHeadSalary, 0);
                                    break;

                                case 3:
                                    Console.WriteLine("Nhap phan tram co phan: ");
                                    double companyShares = double.Parse(Console.ReadLine());
                                    employee = new Director(id, fullName, phoneNumber, workDays, directorSalary, companyShares);
                                    break;

                                default:
                                    Console.WriteLine("Loai nhan vien khong hop le.");
                                    break;
                            }

                            if (employee != null)
                            {
                                company.AddEmployee(employee);
                                Console.WriteLine("Ban da them nhan vien thanh cong cho cong ty.");
                            }
                            else
                            {
                                Console.WriteLine("Khong the them nhan vien. Vui long kiem tra thong tin nhap vao.");
                            }
                        }
                        else if (subInt == 2)
                        {
                            Console.WriteLine("Nhap id cua nhan vien can xoa: ");
                            string deleteEmpId = Console.ReadLine();
                            company.RemoveEmployee(deleteEmpId);
                            Console.WriteLine("Da xoa nhan vien thanh cong.");
                        }
                        else
                        {
                            Console.WriteLine("Lua chon khong hop le. Vui long chon 1 hoac 2, ban se duoc dua cho lai Menu.");
                        }
                        break;
                    case 4:
                        //hiện toàn bộ thông tin của nv
                        Console.WriteLine("Hien thong tin cua toan bo cong ty: ");
                        var allEmployees = company.GetAllEmployees();
                        if (allEmployees.Any())
                        {
                            foreach (Employee emp in allEmployees)
                            {
                                Console.WriteLine(emp.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Khong co nhan vien nao trong danh sach.");
                        }
                        break;
                    case 5:
                        //Tính tổng lương toàn công ty
                        double TotalSalary = company.CalculatorTotalSalary();
                        Console.WriteLine("Tong luong toan bo cong ty la: " + TotalSalary + "$");
                        break;
                    case 6:
                        // Tìm nhân viên thường có lương cao nhất
                        double highestRegularEmp = company.HighestRegularSalary();
                        if (highestRegularEmp != 0)
                        {
                            Console.WriteLine("The highest salary from a Regular Employee is: " + highestRegularEmp + "$");
                        }
                        else
                        {
                            Console.WriteLine("No information found!");
                        }
                        break;
                    case 7:
                        // Tìm trưởng phòng có số lượng nhân viên dưới quyền nhiều nhất
                        DepartmentHead withmostSub = company.MostEmployeeManager();
                        if (withmostSub != null)
                        {
                            Console.WriteLine("Đay la truong phong nhieu nhan vien nhat: ");
                            Console.WriteLine(withmostSub);
                        }
                        else
                        {
                            Console.WriteLine("There is no information about this stagement!");
                        }
                        break;
                    case 8:
                        // Sắp xếp danh sách nhân viên theo bảng chữ cái
                        company.SortEmByAlphabet();

                        Console.WriteLine("Nhân viên đã được sắp xếp theo bảng chữ cái:");

                        // Duyệt qua danh sách nhân viên và in tên
                        foreach (Employee emp in company.GetAllEmployees())
                        {
                            Console.WriteLine(emp.fullName);
                        }
                        break;
                    case 9:
                        //Sắp xếp danh sách nhân viên theo lương
                        company.SortEmBySalary();
                        Console.WriteLine("Nhân viên đã được sắp xếp theo luong:");
                        foreach (Employee emp in company.GetAllEmployees())
                        {
                            Console.WriteLine(emp.fullName);
                        }
                        break;
                    case 10:
                        //Tìm giám đốc có tỉ lệ cổ phần cao nhất
                        Director directorWithTheMostCompanyShares = company.FindDirectorWithHighestShares();
                        if (directorWithTheMostCompanyShares !=null)
                        {
                            Console.WriteLine("Đay la giam doc chiem nhieu co phan nhat: ");
                            Console.WriteLine(directorWithTheMostCompanyShares);
                        }
                        else
                        {
                            Console.WriteLine("There is no information about this stagement!");
                        }
                        break;
                    case 11:
                        //Tính tổng lương của các giám đốc
                            
                            company.FindDirectorWithHighestShares();
                        break;

                    case 12:
                        Console.WriteLine("Exiting...");
                        exit = true; // Đặt biến exit thành true để thoát khỏi vòng lặp
                        break;

                    default:
                        Console.WriteLine("Invalid number. Please type a number between 1 and 12.");
                        break;
                }
            }
        }
    }
}
