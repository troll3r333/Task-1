Bài tập thực hành:
Human Resource Management System: Develop a Human Resource Management application for a company with the following requirements:
The company has a name, tax code, and monthly revenue.
There are 3 types of employees: Director, Department Head, and Regular Employee.
Each person in the company must have the following information: ID, full name, phone number, number of working days, daily salary, and salary calculation method.
In addition to general information, each role in the company has its own attributes:
o	Regular Employee:
Has an optional Department Head who manages them. If there is no manager, set to null.
Monthly salary calculation formula: daily salary * number of working days. The daily salary for a Regular Employee is 100.
o	Department Head:
Has a count of subordinates. This attribute increases when a new employee is added under their management.
Monthly salary calculation formula: daily salary * number of working days + 100 * number of subordinates. The daily salary for a Department Head is 200.
o	Director:
Has an additional attribute for company shares. This value is a percentage and must not exceed 100%.
Monthly salary calculation formula: daily salary * number of working days. The daily salary for a Director is 300.
Menu Options:
1.	Enter company information.
2.	Assign Regular Employees to Department Heads.
3.	Add or delete employee information. Note: When deleting a Department Head, disconnect from any employees managed by them.
4.	Output information for all employees in the company.
5.	Calculate and display the total salary for the entire company.
6.	Find the Regular Employee with the highest salary.
7.	Find the Department Head with the highest number of subordinates.
8.	Sort all employees in the company in alphabetical order.
9.	Sort all employees in the company by descending salary.
10.	Find the Director with the highest share percentage.
11.	Calculate and display the total income for each Director.
