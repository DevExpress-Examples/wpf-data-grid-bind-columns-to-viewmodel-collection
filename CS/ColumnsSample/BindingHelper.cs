using DevExpress.Xpf.Grid;
using System.Windows;
using System.Windows.Data;

namespace ColumnsSample {
    public static class BindingHelper {
        public static string GetPath(GridColumn obj) {
            return (string)obj.GetValue(PathProperty);
        }
        public static void SetPath(GridColumn obj, string value) {
            obj.SetValue(PathProperty, value);
        }
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.RegisterAttached("Path", typeof(string), typeof(BindingHelper), new PropertyMetadata((d, e) => { if (!string.IsNullOrWhiteSpace(e.NewValue as string)) ((GridColumn)d).Binding = new Binding("RowData.Row." + e.NewValue) { Mode = BindingMode.TwoWay }; }));
    }
}