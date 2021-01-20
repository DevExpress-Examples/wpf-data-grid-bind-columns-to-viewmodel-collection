using System.Windows;
using System.Windows.Controls;

namespace ColumnsSample {
    public class ColumnTemplateSelector : DataTemplateSelector {

        public DataTemplate DefaultColumnTemplate { get; set; }
        public DataTemplate LookupColumnTemplate { get; set; }
        public DataTemplate BindingColumnTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            Column column = item as Column;
            if(column == null) return null;
            switch(column.Settings) {
                case SettingsType.Default:
                    return DefaultColumnTemplate;
                case SettingsType.Lookup:
                    return LookupColumnTemplate;
                case SettingsType.Binding:
                    return BindingColumnTemplate;
            }
            return null;
        }
    }
}
