Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Namespace ColumnsSample

    Public Class Employee

        Public Property FirstName As String

        Public Property LastName As String

        Public Property Cities As List(Of String)

        Public Property StateProvinceName As String
    End Class

    Public Class EmployeesDataModel

        Public Shared Function GetEmployees() As IList(Of Employee)
            Dim people As ObservableCollection(Of Employee) = New ObservableCollection(Of Employee) From {New Employee() With {.FirstName = "Bruce", .LastName = "Cambell", .Cities = New List(Of String)() From {"Kansas City", "Springfield"}, .StateProvinceName = "Missouri"}, New Employee() With {.FirstName = "Cindy", .LastName = "Haneline", .Cities = New List(Of String)() From {"Oklahoma City", "Tulsa"}, .StateProvinceName = "Oklahoma"}, New Employee() With {.FirstName = "Andrea", .LastName = "Deville", .Cities = New List(Of String)() From {"Denver", "Colorado Springs"}, .StateProvinceName = "Colorado"}, New Employee() With {.FirstName = "Anita", .LastName = "Ryan", .Cities = New List(Of String)() From {"Denver", "Aurora"}, .StateProvinceName = "Colorado"}}
            Return people
        End Function
    End Class
End Namespace
