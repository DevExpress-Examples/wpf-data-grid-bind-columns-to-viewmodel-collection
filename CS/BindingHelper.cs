using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace WPFGridMVVMBindableColumns {
    public static class BindingHelper {
        public static string GetPath(GridColumn obj) {
            return (string)obj.GetValue(PathProperty);
        }
        public static void SetPath(GridColumn obj, string value) {
            obj.SetValue(PathProperty, value);
        }
        // Using a DependencyProperty as the backing store for Path.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.RegisterAttached("Path", typeof(string), typeof(BindingHelper), new PropertyMetadata((d, e) => {
                if (!string.IsNullOrWhiteSpace(e.NewValue as string))
                    ((GridColumn)d).Binding = new Binding("RowData.Row." + e.NewValue) { Mode = BindingMode.TwoWay };
            }));
    }
}
