using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using DevExpress.Data;
using DevExpress.Mvvm;

namespace Model {
    public class ViewModel : ViewModelBase {
        public ObservableCollection<string> States {
            get { return GetProperty(() => States); }
            private set { SetProperty(() => States, value); }
        }
        public IList<Employee> Source {
            get { return GetProperty(() => Source); }
            private set { SetProperty(() => Source, value); }
        }
        public ObservableCollection<Column> Columns {
            get { return GetProperty(() => Columns); }
            private set { SetProperty(() => Columns, value); }
        }
        public ObservableCollection<Summary> TotalSummary {
            get { return GetProperty(() => TotalSummary); }
            private set { SetProperty(() => TotalSummary, value); }
        }
        public ObservableCollection<Summary> GroupSummary {
            get { return GetProperty(() => GroupSummary); }
            private set { SetProperty(() => GroupSummary, value); }
        }
        public ViewModel() {
            Source = EmployeesData.DataSource;
            States = new ObservableCollection<string>(Source.Select(x => x.StateProvinceName).Distinct());
            Columns = new ObservableCollection<Column>() {
                new Column() { FieldName="FirstName" },
                new Column() { FieldName="LastName" },
                new Column() { FieldName="BirthDate", Settings = SettingsType.Date },
                new ComboColumn() { Settings = SettingsType.Combo, FieldName="StateProvinceName", Source = States },
                new HeaderColumn() { Settings = SettingsType.Binding, FieldName = "Cities[0]", Header = "City1" },
                new HeaderColumn() { Settings = SettingsType.Binding, FieldName = "Cities[1]", Header = "City2" },
                new Column() { FieldName="ImageData", Settings = SettingsType.Image }
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

    public enum SettingsType { Default, Combo, Image, Binding , Date}

    public class Summary : BindableBase {
        public SummaryItemType Type {
            get { return GetProperty(() => Type); }
            set { SetProperty(() => Type, value); }
        }
        public string FieldName {
            get { return GetProperty(() => FieldName); }
            set { SetProperty(() => FieldName, value); }
        }
    }

    public class Column : BindableBase {
        public string FieldName {
            get { return GetProperty(() => FieldName); }
            set { SetProperty(() => FieldName, value); }
        }
        public SettingsType Settings {
            get { return GetProperty(() => Settings); }
            set { SetProperty(() => Settings, value); }
        }
    }
    public class ComboColumn : Column {
        public IList Source {
            get { return GetProperty(() => Source); }
            set { SetProperty(() => Source, value); }
        }
    }
    public class HeaderColumn : Column {
        public string Header {
            get { return GetProperty(() => Header); }
            set { SetProperty(() => Header, value); }
        }
    }

    [XmlRoot("Employees")]
    public class EmployeesData : List<Employee> {
        public static IList<Employee> DataSource {
            get {
                XmlSerializer s = new XmlSerializer(typeof(EmployeesData));
                var list = (List<Employee>)s.Deserialize(Assembly.GetExecutingAssembly().GetManifestResourceStream("WPFGridMVVMBindableColumns.EmployeesWithPhoto.xml"));
                return new ObservableCollection<Employee>(list);
            }
        }
    }


    public class Employee : BindableBase {
        public int Id {
            get { return GetProperty(() => Id); }
            set { SetProperty(() => Id, value); }
        }
        public int ParentId {
            get { return GetProperty(() => ParentId); }
            set { SetProperty(() => ParentId, value); }
        }
        public string FirstName {
            get { return GetProperty(() => FirstName); }
            set { SetProperty(() => FirstName, value); }
        }
        public string MiddleName {
            get { return GetProperty(() => MiddleName); }
            set { SetProperty(() => MiddleName, value); }
        }
        public string LastName {
            get { return GetProperty(() => LastName); }
            set { SetProperty(() => LastName, value); }
        }
        public string JobTitle {
            get { return GetProperty(() => JobTitle); }
            set { SetProperty(() => JobTitle, value); }
        }
        public string Phone {
            get { return GetProperty(() => Phone); }
            set { SetProperty(() => Phone, value); }
        }
        public string EmailAddress {
            get { return GetProperty(() => EmailAddress); }
            set { SetProperty(() => EmailAddress, value); }
        }
        public string AddressLine1 {
            get { return GetProperty(() => AddressLine1); }
            set { SetProperty(() => AddressLine1, value); }

        }
        public List<string> Cities {
            get { return GetProperty(() => Cities); }
            set { SetProperty(() => Cities, value); }
        }
        public string StateProvinceName {
            get { return GetProperty(() => StateProvinceName); }
            set { SetProperty(() => StateProvinceName, value); }
        }
        public string PostalCode {
            get { return GetProperty(() => PostalCode); }
            set { SetProperty(() => PostalCode, value); }
        }
        public string CountryRegionName {
            get { return GetProperty(() => CountryRegionName); }
            set { SetProperty(() => CountryRegionName, value); }

        }
        public string GroupName {
            get { return GetProperty(() => GroupName); }
            set { SetProperty(() => GroupName, value); }
        }
        public DateTime BirthDate {
            get { return GetProperty(() => BirthDate); }
            set { SetProperty(() => BirthDate, value); }
        }
        public DateTime HireDate {
            get { return GetProperty(() => HireDate); }
            set { SetProperty(() => HireDate, value); }
        }
        public string Gender {
            get { return GetProperty(() => Gender); }
            set { SetProperty(() => Gender, value); }
        }
        public string MaritalStatus {
            get { return GetProperty(() => MaritalStatus); }
            set { SetProperty(() => MaritalStatus, value); }
        }
        public string Title {
            get { return GetProperty(() => Title); }
            set { SetProperty(() => Title, value); }
        }
        public byte[] ImageData {
            get { return GetProperty(() => ImageData); }
            set { SetProperty(() => ImageData, value); }
        }
    }
}
