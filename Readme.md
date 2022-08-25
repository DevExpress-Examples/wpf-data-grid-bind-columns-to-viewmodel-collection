<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128648485/20.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T273154)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Bind the WPF Data Grid to a Collection of Columns Specified in a ViewModel

This example demonstrates how to define columns in a ViewModel and display them in the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl).

![](/Images/mvvm-columnbinding-result14130.png)

## Files to Look at

* [MainWindow.xaml](./CS/ColumnsSample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/ColumnsSample/MainWindow.xaml))
* [EmployeesViewModel.cs](./CS/ColumnsSample/EmployeesViewModel.cs) (VB: [EmployeesViewModel.vb](./VB/ColumnsSample/EmployeesViewModel.vb))
* [EmployeesDataModel.cs](./CS/ColumnsSample/EmployeesDataModel.cs) (VB: [EmployeesDataModel.vb](./VB/ColumnsSample/EmployeesDataModel.vb))
* [ColumnTemplateSelector.cs](./CS/ColumnsSample/ColumnTemplateSelector.cs) (VB: [ColumnTemplateSelector.vb](./VB/ColumnsSample/ColumnTemplateSelector.vb))

## Documentation

* [How to: Bind the Grid to a Collection of Columns](http://docs.devexpress.com/WPF/10121/controls-and-libraries/data-grid/mvvm-enhancements/binding-to-a-collection-of-columns)
* [ColumnsSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.ColumnsSource)
* [ColumnGeneratorTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.ColumnGeneratorTemplate)
* [ColumnGeneratorTemplateSelector](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.ColumnGeneratorTemplateSelector)

## More Examples

* [Bind the WPF Data Grid to a Collection of Summaries Specified in a ViewModel](https://github.com/DevExpress-Examples/wpf-mvvm-how-to-bind-the-gridcontrol-to-total-and-group-summaries-specified-in-viewmodel)
* [Bind the WPF Data Grid to a Collection of Bands Specified in ViewModel](https://github.com/DevExpress-Examples/how-to-generate-bands-based-on-a-collection-in-a-viewmodel-e5217)
* [Bind the WPF Data Grid to Data](https://github.com/DevExpress-Examples/how-to-bind-wpf-grid-to-data)
