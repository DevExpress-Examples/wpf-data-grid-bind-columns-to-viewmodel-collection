Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Reflection
Imports System.Xml.Serialization
Imports DevExpress.Data

Namespace Model
    Public Class ViewModel
        Private privateCities As List(Of String)
        Public Property Cities() As List(Of String)
            Get
                Return privateCities
            End Get
            Private Set(ByVal value As List(Of String))
                privateCities = value
            End Set
        End Property
        Private privateSource As IList(Of Employee)
        Public Property Source() As IList(Of Employee)
            Get
                Return privateSource
            End Get
            Private Set(ByVal value As IList(Of Employee))
                privateSource = value
            End Set
        End Property
        Private privateColumns As ObservableCollection(Of Column)
        Public Property Columns() As ObservableCollection(Of Column)
            Get
                Return privateColumns
            End Get
            Private Set(ByVal value As ObservableCollection(Of Column))
                privateColumns = value
            End Set
        End Property
        Private privateTotalSummary As ObservableCollection(Of Summary)
        Public Property TotalSummary() As ObservableCollection(Of Summary)
            Get
                Return privateTotalSummary
            End Get
            Private Set(ByVal value As ObservableCollection(Of Summary))
                privateTotalSummary = value
            End Set
        End Property
        Private privateGroupSummary As ObservableCollection(Of Summary)
        Public Property GroupSummary() As ObservableCollection(Of Summary)
            Get
                Return privateGroupSummary
            End Get
            Private Set(ByVal value As ObservableCollection(Of Summary))
                privateGroupSummary = value
            End Set
        End Property
        Public Sub New()
            Source = EmployeesData.DataSource

            Dim cities_Renamed As New List(Of String)()
            For Each employee As Employee In Source
                If Not cities_Renamed.Contains(employee.City) Then
                    cities_Renamed.Add(employee.City)
                End If
            Next employee
            Cities = cities_Renamed
            Columns = New ObservableCollection(Of Column)() From { _
                New Column() With {.FieldName="FirstName", .Settings = SettingsType.Default}, _
                New Column() With {.FieldName="LastName", .Settings = SettingsType.Default}, _
                New Column() With {.FieldName="BirthDate", .Settings = SettingsType.Default}, _
                New ComboColumn() With {.FieldName="City", .Settings = SettingsType.Combo, .Source = Cities}, _
                New Column() With {.FieldName="ImageData", .Settings = SettingsType.Image} _
            }
            TotalSummary = New ObservableCollection(Of Summary)() From { _
                New Summary() With {.Type = SummaryItemType.Count, .FieldName = "FirstName"}, _
                New Summary() With {.Type = SummaryItemType.Max, .FieldName = "BirthDate"} _
            }
            GroupSummary = New ObservableCollection(Of Summary)() From { _
                New Summary() With {.Type = SummaryItemType.Count, .FieldName = "FirstName"} _
            }
        End Sub
    End Class

    Public Enum SettingsType
        [Default]
        Combo
        Image
    End Enum

    Public Class Summary
        Public Property Type() As SummaryItemType
        Public Property FieldName() As String
    End Class

    Public Class Column
        Public Property FieldName() As String
        Public Property Settings() As SettingsType
    End Class
    Public Class ComboColumn
        Inherits Column

        Public Property Source() As IList
    End Class

    <XmlRoot("Employees")> _
    Public Class EmployeesData
        Inherits List(Of Employee)

        Public Shared ReadOnly Property DataSource() As IList(Of Employee)
            Get
                Dim s As New XmlSerializer(GetType(EmployeesData))
                Dim stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("EmployeesWithPhoto.xml")
                Dim out = DirectCast(s.Deserialize(stream), List(Of Employee))
                Return out
            End Get
        End Property
    End Class


    Public Class Employee
        Public Property Id() As Integer
        Public Property ParentId() As Integer
        Public Property FirstName() As String
        Public Property MiddleName() As String
        Public Property LastName() As String
        Public Property JobTitle() As String
        Public Property Phone() As String
        Public Property EmailAddress() As String
        Public Property AddressLine1() As String
        Public Property City() As String
        Public Property StateProvinceName() As String
        Public Property PostalCode() As String
        Public Property CountryRegionName() As String
        Public Property GroupName() As String
        Public Property BirthDate() As Date
        Public Property HireDate() As Date
        Public Property Gender() As String
        Public Property MaritalStatus() As String
        Public Property Title() As String
        Public Property ImageData() As Byte()
    End Class
End Namespace
