Imports DevExpress.Mvvm
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace ColumnsSample

    Public Enum SettingsType
        [Default]
        Lookup
        Binding
    End Enum

    Public Class ViewModel
        Inherits ViewModelBase

        Public Sub New()
            Source = EmployeesDataModel.GetEmployees()
            States = Source.[Select](Function(x) x.StateProvinceName).Distinct().ToList()
            Columns = New ObservableCollection(Of Column)() From {New Column(SettingsType.Default, NameOf(Employee.FirstName)), New Column(SettingsType.Default, NameOf(Employee.LastName)), New LookupColumn(SettingsType.Lookup, NameOf(Employee.StateProvinceName), States), New BindingColumn(SettingsType.Binding, "Cities[0]", "City1"), New BindingColumn(SettingsType.Binding, "Cities[1]", "City2")}
        End Sub

        Public ReadOnly Property Source As IList(Of Employee)

        Public ReadOnly Property States As List(Of String)

        Public ReadOnly Property Columns As ObservableCollection(Of Column)
    End Class

    Public Class Column
        Inherits BindableBase

        Public Sub New(ByVal settings As SettingsType, ByVal fieldname As String)
            Me.Settings = settings
            Me.FieldName = fieldname
        End Sub

        Public ReadOnly Property Settings As SettingsType

        Public ReadOnly Property FieldName As String
    End Class

    Public Class LookupColumn
        Inherits Column

        Public Sub New(ByVal settings As SettingsType, ByVal fieldname As String, ByVal source As IList)
            MyBase.New(settings, fieldname)
            Me.Source = source
        End Sub

        Public ReadOnly Property Source As IList
    End Class

    Public Class BindingColumn
        Inherits Column

        Public Sub New(ByVal settings As SettingsType, ByVal fieldname As String, ByVal header As String)
            MyBase.New(settings, fieldname)
            Me.Header = header
        End Sub

        Public ReadOnly Property Header As String
    End Class
End Namespace
