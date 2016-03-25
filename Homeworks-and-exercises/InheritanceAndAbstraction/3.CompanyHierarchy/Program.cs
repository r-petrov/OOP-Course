using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CompanyHierarchy
{
    public enum Departaments
    {
        Production,
        Accounting,
        Sales,
        Marketing,
    }

    public enum ProjectStates
    {
        open,
        closed
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Sale> salesOfEmployee1 = new List<Sale>()
                {
                    new Sale("Bank softare", new DateTime(2015, 03, 10), 10000m),
                    new Sale("Modul \"Payments\"", new DateTime(2015, 05, 03), 3540m),
                };

                List<Sale> salesOfEmployee2 = new List<Sale>()
                {
                    new Sale("Insurance softare", new DateTime(2015,04,04), 8000m),
                    new Sale("Insurance softare, modul \"Damages\"", new DateTime(2015, 04, 21), 5500m),
                    new Sale("Hosrital softare", new DateTime(2015, 03, 03), 8000m),
                };

                Project project1Developer1 = new Project("Virtual library", DateTime.Today, "Software for libraries", ProjectStates.open);
                Project project2Developer1 = new Project("Let's shop from home!", new DateTime(2015, 04, 01), "Online shopping application", ProjectStates.open);

                IDictionary<string, Project> projectsDeveloper1 = new Dictionary<string, Project>()
                {
                    {project1Developer1.ProjectName, project1Developer1},
                    {project2Developer1.ProjectName, project2Developer1},
                };

              //  Console.WriteLine(String.Join("\n", projectsDeveloper1.Values));

                Project project1Developer2 = new Project("Online radio", DateTime.Today, "Software for free online listening of music", ProjectStates.open);

                IDictionary<string, Project> projectsDeveloper2 = new Dictionary<string, Project>()
                {
                    {project1Developer2.ProjectName, project1Developer2},
                };
               // Console.WriteLine(String.Join("\n", projectsDeveloper2.Values));

                SalesEmployee salesEmployee1 = new SalesEmployee("Boyan", "Boev", "0123456789", 1025m, Departaments.Sales, salesOfEmployee1);
                SalesEmployee salesEmployee2 = new SalesEmployee("Ivelina", "Petrova", "1234567980", 1500, Departaments.Sales, salesOfEmployee2);
                //Console.WriteLine(salesEmployee2.ToString());
                Developer developer1 = new Developer("Ivan", "Cherkalovski", "2345678910", 3500m, Departaments.Production, projectsDeveloper1);
                Developer developer2 = new Developer("Kristina", "Dimitrova", "3456789012", 3500m, Departaments.Production, projectsDeveloper2);
                //Console.WriteLine(developer2.ToString());
                IDictionary<string, SalesEmployee> salesEmployees = new Dictionary<string, SalesEmployee>()
                {
                    {salesEmployee1.ID, salesEmployee1},
                    {salesEmployee2.ID, salesEmployee2},
                };

                //salesEmployees.ToList().ForEach(se=>Console.WriteLine(se.Value.ToString()));

                IDictionary<string, Developer> developers = new Dictionary<string, Developer>()
                {
                    {developer1.ID, developer1},
                    {developer2.ID, developer2},
                };
                //developers.ToList().ForEach(dse => Console.WriteLine(dse.Value.ToString()));

                Manager employeesManager = new Manager("Petar", "Georgiev", "4567891230", 5800m, Departaments.Sales, salesEmployees, developers);
                Manager developersManager = new Manager("Belin", "Petrov", "5678912340", 7500, Departaments.Production, salesEmployees, developers);
                //Console.WriteLine(employeesManager.ToString());

                IDictionary<string, Employee> employees = new Dictionary<string, Employee>()
                {
                    {salesEmployee1.ID, salesEmployee1},
                    {salesEmployee2.ID, salesEmployee2},
                    {developer1.ID, developer1},
                    {developer2.ID, developer2},
                    {developersManager.ID, developersManager},
                    {employeesManager.ID, employeesManager}
                };

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.Value.ToString());
                    Console.WriteLine();
                }
            }
            catch (ArgumentNullException aex)
            {
                Console.Error.WriteLine(aex.StackTrace);
            }
            catch (ArgumentOutOfRangeException aorex)
            {
                Console.Error.WriteLine(aorex.StackTrace);
            }
        }
    }
}
