using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Xml.Serialization;
using DevExpress.Data;

namespace Model {
    public class ViewModel {
        public List<string> Cities { get; private set; }
        public IList<Employee> Source { get; private set; }
        public ObservableCollection<Column> Columns { get; private set; }
        public ObservableCollection<Summary> TotalSummary { get; private set; }
        public ObservableCollection<Summary> GroupSummary { get; private set; }
        public ViewModel() {
            Source = EmployeesData.DataSource;
            List<string> cities = new List<string>();
            foreach(Employee employee in Source) {
                if(!cities.Contains(employee.City))
                    cities.Add(employee.City);
            }
            Cities = cities;
            Columns = new ObservableCollection<Column>() {
                new Column() { FieldName="FirstName", Settings = SettingsType.Default },
                new Column() { FieldName="LastName", Settings = SettingsType.Default},
                new Column() { FieldName="BirthDate", Settings = SettingsType.Default},
                new ComboColumn() { FieldName="City", Settings = SettingsType.Combo, Source = Cities },
                new Column() { FieldName="ImageData", Settings = SettingsType.Image },

            };
            TotalSummary = new ObservableCollection<Summary>() {
                new Summary() { Type = SummaryItemType.Count, FieldName = "FirstName" },
                new Summary() { Type = SummaryItemType.Max, FieldName = "BirthDate" },
            };
            GroupSummary = new ObservableCollection<Summary>() {
                new Summary() { Type = SummaryItemType.Count, FieldName = "FirstName" },
            };
        }
    }

    public enum SettingsType { Default, Combo, Image }

    public class Summary {
        public SummaryItemType Type { get; set; }
        public string FieldName { get; set; }
    }

    public class Column {
        public string FieldName { get; set; }
        public SettingsType Settings { get; set; }
    }
    public class ComboColumn : Column {
        public IList Source { get; set; }
    }

    [XmlRoot("Employees")]
    public class EmployeesData : List<Employee> {
        public static IList<Employee> DataSource {
            get {

                XmlSerializer s = new XmlSerializer(typeof(EmployeesData));

                return (List<Employee>)s.Deserialize(Assembly.GetExecutingAssembly().GetManifestResourceStream("WPFGridMVVMBindableColumns.EmployeesWithPhoto.xml"));

            }
        }
    }


    public class Employee {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string StateProvinceName { get; set; }
        public string PostalCode { get; set; }
        public string CountryRegionName { get; set; }
        public string GroupName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
    }
}
