using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ColumnsSample {
    public class Employee {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Cities { get; set; }
        public string StateProvinceName { get; set; }
    }
    public class EmployeesDataModel {
        public static IList<Employee> GetEmployees() {
            ObservableCollection<Employee> people = new ObservableCollection<Employee> {
            new Employee() { FirstName = "Bruce", LastName = "Cambell", Cities = new List<string>() { "Kansas City", "Springfield" }, StateProvinceName = "Missouri"},
            new Employee() { FirstName = "Cindy", LastName = "Haneline", Cities = new List<string>() { "Oklahoma City", "Tulsa" }, StateProvinceName = "Oklahoma"},
            new Employee() { FirstName = "Andrea", LastName = "Deville", Cities = new List<string>() { "Denver", "Colorado Springs" }, StateProvinceName = "Colorado"},
            new Employee() { FirstName = "Anita", LastName = "Ryan", Cities = new List<string>() { "Denver", "Aurora" }, StateProvinceName = "Colorado"},
            };
            return people;
        }
    }
}