using DevExpress.Mvvm;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ColumnsSample {
    public enum SettingsType { Default, Lookup, Binding }

    public class ViewModel : ViewModelBase {
        public ViewModel() {
            Source = EmployeesDataModel.GetEmployees();
            States = Source.Select(x => x.StateProvinceName).Distinct().ToList();
            Columns = new ObservableCollection<Column>() {
                new Column( SettingsType.Default, nameof(Employee.FirstName) ),
                new Column( SettingsType.Default, nameof(Employee.LastName) ),
                new LookupColumn( SettingsType.Lookup, nameof(Employee.StateProvinceName), States ),
                new BindingColumn( SettingsType.Binding, "Cities[0]", "City1" ),
                new BindingColumn( SettingsType.Binding, "Cities[1]", "City2" )
            };
        }
        public IList<Employee> Source { get; }
        public List<string> States { get; }
        public ObservableCollection<Column> Columns { get; }
    }

    public class Column : BindableBase {
        public Column(SettingsType settings, string fieldname) {
            Settings = settings;
            FieldName = fieldname;
        }
        public SettingsType Settings { get; }
        public string FieldName { get; }
    }

    public class LookupColumn : Column {
        public LookupColumn(SettingsType settings, string fieldname, IList source): base(settings, fieldname) {
            Source = source;
        }
        public IList Source { get; }
    }

    public class BindingColumn : Column {
        public BindingColumn(SettingsType settings, string fieldname, string header): base(settings, fieldname) {
            Header = header;
        }
        public string Header { get; }
    }
}
