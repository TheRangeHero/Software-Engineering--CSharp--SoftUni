using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();

        Console.WriteLine(RemoveTown(dbContext));
    }

    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.MiddleName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();


        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var employeesWithSalaryOver50000 = context.Employees
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .ToArray();

        foreach (var e in employeesWithSalaryOver50000)
        {
            stringBuilder.AppendLine($"{e.FirstName} - {e.Salary:f2}");
        }
        return stringBuilder.ToString().TrimEnd();
    }

    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {

        StringBuilder builder = new StringBuilder();
        var employeesFromRnD = context.Employees.
            Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToArray();

        foreach (var e in employeesFromRnD)
        {
            builder.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
        }

        return builder.ToString().TrimEnd();
    }

    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address newAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        Employee? employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

        employee!.Address = newAddress;

        context.SaveChanges();

        var employeeAddresses = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address!.AddressText)
            .ToArray();

        return string.Join(Environment.NewLine, employeeAddresses);
    }

    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeesWithProjects = context
            .Employees
            //.Where(e => e.EmployeesProjects
            //.Any(ep => ep.Project.StartDate.Year >= 2001 &&
            //           ep.Project.StartDate.Year <= 2003))
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager!.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                 ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    })
                    .ToArray()
            })
            .ToArray();

        foreach (var e in employeesWithProjects)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
            foreach (var p in e.Projects)
            {
                sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
            }
        }
        return sb.ToString().TrimEnd();
    }

    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town!.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    Town = a.Town!.Name,
                    EmployeesCount = a.Employees.Count
                })
                .ToArray();

        foreach (var e in addresses)
        {
            sb.AppendLine($"{e.AddressText}, {e.Town} - {e.EmployeesCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        var employee = context.Employees
        .Select(e => new
        {
            e.FirstName,
            e.LastName,
            e.JobTitle,
            Projects = e.EmployeesProjects
                .Select(ep => ep.Project.Name)
                .OrderBy(p => p)
                .ToArray()
        })
        .First();

        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
        sb.AppendLine($"{string.Join(Environment.NewLine, employee.Projects)}");

        return sb.ToString().TrimEnd();
    }

    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {

        StringBuilder stringBuilder = new StringBuilder();
        var department = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count).ThenBy(d => d.Name)
            .Select(d => new
            {
                d.Name,
                ManagerFirstname = d.Manager.FirstName,
                MangerLastName = d.Manager.LastName,
                Employees = d.Employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle
                })
                .ToArray()
            }).ToArray();

        foreach (var item in department)
        {
            stringBuilder.AppendLine($"{item.Name} - {item.ManagerFirstname} {item.MangerLastName}");
            foreach (var emp in item.Employees)
            {
                stringBuilder.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
            }
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public static string GetLatestProjects(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var projects = context.Projects
            .OrderByDescending(d => d.StartDate)
            .Take(10)
            .Select(p => new
            {
                p.Name,
                p.Description,
                StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            })
            .OrderBy(p => p.Name)
            .ToArray();

        foreach (var project in projects)
        {
            sb.AppendLine($"{project.Name}");
            sb.AppendLine($"{project.Description}");
            sb.AppendLine($"{project.StartDate}");
        }

        return sb.ToString().TrimEnd();
    }

    public static string IncreaseSalaries(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        string[] departmentNames = { "Engineering", "Tool Design", "Marketing", "Information Services" };

        //var employeesToUpdate = context.Employees.Where(e=>e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")

        var employeesToUpdate = context.Employees
        .Where(e => departmentNames.Contains(e.Department.Name))
        .Select(x => new
        {
            x.FirstName,
            x.LastName,
            Salary = x.Salary + x.Salary * 0.12m
        })
        .OrderBy(e => e.FirstName)
        .ThenBy(e => e.LastName)
        .ToArray();


        foreach (var employee in employeesToUpdate)        {

            sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
        }
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.FirstName
            .StartsWith("Sa"))
            .Select(e => new 
            { e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary})
            .OrderBy(e => e.FirstName)
            .ThenBy(e=>e.LastName)
            .ToArray();

        foreach (var employee in employees) 
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
        }

        return sb.ToString().TrimEnd();

    }

    public static string DeleteProjectById(SoftUniContext context)
    {
        IQueryable<EmployeeProject> epToDelete = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);

        context.EmployeesProjects.RemoveRange(epToDelete);

        Project projectToDelete = context.Projects.Find(2)!;

        context.Projects.Remove(projectToDelete);
        context.SaveChanges();

        string[] projectNames = context.Projects.Take(10).Select(p => p.Name).ToArray();

        return string.Join(Environment.NewLine, projectNames);
    }

    public static string RemoveTown(SoftUniContext context)
    {
        var townToDelete = context.Towns
            .FirstOrDefault(t => t.Name == "Seattle");

        var addressToDelete = context.Addresses
            .Where(a => a.TownId == townToDelete!.TownId);


        var employeesOnDeletedAddresses = context.Employees
            .Where(e => addressToDelete
                .Any(a => a.AddressId == e.AddressId)).ToArray();
        int addressesCount = addressToDelete.Count();

        foreach (var e in employeesOnDeletedAddresses)
        {
            e.AddressId = null;
        }

        foreach (var address in addressToDelete)
        {
            context.Addresses.Remove(address);
        }

        context.Remove(townToDelete!);

        context.SaveChanges();

        return $"{addressesCount} addresses in Seattle were deleted";
    }
}