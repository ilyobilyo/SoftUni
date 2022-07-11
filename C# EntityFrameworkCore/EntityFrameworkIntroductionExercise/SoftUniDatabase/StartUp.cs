using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            Console.WriteLine(RemoveTown(context));
        }

        public static string RemoveTown(SoftUniContext context)
        {
            foreach (var employee in context.Employees.Where(x => x.Address.Town.Name == "Seattle"))
            {
                employee.AddressId = null;
            }

            int count = 0;
            foreach (var address in context.Addresses.Where(x => x.Town.Name == "Seattle"))
            {
                context.Addresses.Remove(address);
                count++;
            }

            var townToRemove = context.Towns.FirstOrDefault(x => x.Name == "Seattle");
            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToRemove = context
                .Projects
                .Where(x => x.ProjectId == 2)
                .FirstOrDefault();

            foreach (var employeeProject in context.EmployeesProjects.Where(x => x.ProjectId == 2))
            {
                context.EmployeesProjects.Remove(employeeProject);
            }

            context.Projects.Remove(projectToRemove);
            context.SaveChanges();

            var projectsToPrint = context
                .Projects
                .Take(10)
                .Select(x => new
                {
                    x.Name
                })
                .ToList();
            var sb = new StringBuilder();
            foreach (var project in projectsToPrint)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.FirstName.ToLower().StartsWith("sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.Department.Name == "Engineering" || x.Department.Name == "Tool Design"
                        || x.Department.Name == "Marketing" || x.Department.Name == "Information Services");

            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 0.12m;
            }
                
            var sb = new StringBuilder();
            foreach (var employee in employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList())
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context
                .Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    Date = x.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.Date);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(x => x.Employees.Count > 5)
                .Select(x => new
                {
                    x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    EmployyesInDep = x.Employees
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        })
                })
                .OrderBy(x => x.EmployyesInDep.Count())
                .ThenBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();
            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (var employee in department.EmployyesInDep.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var empWithId147 = context
                .Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(x => x.EmployeeId == 147)
                .FirstOrDefault();


            var sb = new StringBuilder();
            sb.AppendLine($"{empWithId147.FirstName} {empWithId147.LastName} - {empWithId147.JobTitle}");
            foreach (var project in empWithId147.EmployeesProjects.OrderBy(x => x.Project.Name))
            {
                sb.AppendLine($"{project.Project.Name}");
            }

            return sb.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context
                .Addresses
                .Select(x => new
                {
                    x.AddressText,
                    TownName = x.Town.Name,
                    Count = x.Employees.Count()
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year > 2000 && p.Project.StartDate.Year < 2004))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ep.Project.StartDate,
                        ep.Project.EndDate,
                    })
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var p in employee.Projects)
                {
                    var startDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                    var endDate = p.EndDate.HasValue ?
                        p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") :
                        "not finished";

                    sb.AppendLine($"--{p.ProjectName} - {startDate} - {endDate}");
                }

            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };


            var employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            employee.Address = newAddress;
            context.SaveChanges();


            var employees = context
                .Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(x => new { x.Address })
                .ToList();

            var sb = new StringBuilder();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.Address.AddressText}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name,
                    x.Salary
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.DepartmentName} - ${emp.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.Salary > 50000)
                .Select(x => new { x.FirstName, x.Salary })
                .OrderBy(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Select(x => new { x.EmployeeId, x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
