Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Reflection
Imports System.Xml.Serialization
Imports DevExpress.Data
Imports DevExpress.Mvvm

Namespace Model

    Public Class ViewModel
        Inherits ViewModelBase

        Public Property States As ObservableCollection(Of String)
            Get
                Return GetProperty(Function() Me.States)
            End Get

            Private Set(ByVal value As ObservableCollection(Of String))
                SetProperty(Function() States, value)
            End Set
        End Property

        Public Property Source As IList(Of Employee)
            Get
                Return GetProperty(Function() Me.Source)
            End Get

            Private Set(ByVal value As IList(Of Employee))
                SetProperty(Function() Source, value)
            End Set
        End Property

        Public Property Columns As ObservableCollection(Of Column)
            Get
                Return GetProperty(Function() Me.Columns)
            End Get

            Private Set(ByVal value As ObservableCollection(Of Column))
                SetProperty(Function() Columns, value)
            End Set
        End Property

        Public Property TotalSummary As ObservableCollection(Of Summary)
            Get
                Return GetProperty(Function() Me.TotalSummary)
            End Get

            Private Set(ByVal value As ObservableCollection(Of Summary))
                SetProperty(Function() TotalSummary, value)
            End Set
        End Property

        Public Property GroupSummary As ObservableCollection(Of Summary)
            Get
                Return GetProperty(Function() Me.GroupSummary)
            End Get

            Private Set(ByVal value As ObservableCollection(Of Summary))
                SetProperty(Function() GroupSummary, value)
            End Set
        End Property

        Public Sub New()
            Source = EmployeesData.DataSource
            States = New ObservableCollection(Of String)(Source.[Select](Function(x) x.StateProvinceName).Distinct())
            Columns = New ObservableCollection(Of Column)() From {New Column() With {.FieldName = "FirstName"}, New Column() With {.FieldName = "LastName"}, New Column() With {.FieldName = "BirthDate", .Settings = SettingsType.Date}, New ComboColumn() With {.Settings = SettingsType.Combo, .FieldName = "StateProvinceName", .Source = States}, New HeaderColumn() With {.Settings = SettingsType.Binding, .FieldName = "Cities[0]", .Header = "City1"}, New HeaderColumn() With {.Settings = SettingsType.Binding, .FieldName = "Cities[1]", .Header = "City2"}, New Column() With {.FieldName = "ImageData", .Settings = SettingsType.Image}}
            TotalSummary = New ObservableCollection(Of Summary)() From {New Summary() With {.Type = SummaryItemType.Count, .FieldName = "FirstName"}, New Summary() With {.Type = SummaryItemType.Max, .FieldName = "BirthDate"}}
            GroupSummary = New ObservableCollection(Of Summary)() From {New Summary() With {.Type = SummaryItemType.Count, .FieldName = "FirstName"}}
        End Sub
    End Class

    Public Enum SettingsType
        [Default]
        Combo
        Image
        Binding
        [Date]
    End Enum

    Public Class Summary
        Inherits BindableBase

        Public Property Type As SummaryItemType
            Get
                Return GetProperty(Function() Me.Type)
            End Get

            Set(ByVal value As SummaryItemType)
                SetProperty(Function() Type, value)
            End Set
        End Property

        Public Property FieldName As String
            Get
                Return GetProperty(Function() Me.FieldName)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() FieldName, value)
            End Set
        End Property
    End Class

    Public Class Column
        Inherits BindableBase

        Public Property FieldName As String
            Get
                Return GetProperty(Function() Me.FieldName)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() FieldName, value)
            End Set
        End Property

        Public Property Settings As SettingsType
            Get
                Return GetProperty(Function() Me.Settings)
            End Get

            Set(ByVal value As SettingsType)
                SetProperty(Function() Settings, value)
            End Set
        End Property
    End Class

    Public Class ComboColumn
        Inherits Column

        Public Property Source As IList
            Get
                Return GetProperty(Function() Me.Source)
            End Get

            Set(ByVal value As IList)
                SetProperty(Function() Source, value)
            End Set
        End Property
    End Class

    Public Class HeaderColumn
        Inherits Column

        Public Property Header As String
            Get
                Return GetProperty(Function() Me.Header)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() Header, value)
            End Set
        End Property
    End Class

    <XmlRoot("Employees")>
    Public Class EmployeesData
        Inherits List(Of Employee)

        Public Shared ReadOnly Property DataSource As IList(Of Employee)
            Get
                Dim s As XmlSerializer = New XmlSerializer(GetType(EmployeesData))
                Dim list = CType(s.Deserialize(Assembly.GetExecutingAssembly().GetManifestResourceStream("WPFGridMVVMBindableColumns.EmployeesWithPhoto.xml")), List(Of Employee))
                Return New ObservableCollection(Of Employee)(list)
            End Get
        End Property
    End Class

    Public Class Employee
        Inherits BindableBase

        Public Property Id As Integer
            Get
                Return GetProperty(Function() Me.Id)
            End Get

            Set(ByVal value As Integer)
                SetProperty(Function() Id, value)
            End Set
        End Property

        Public Property ParentId As Integer
            Get
                Return GetProperty(Function() Me.ParentId)
            End Get

            Set(ByVal value As Integer)
                SetProperty(Function() ParentId, value)
            End Set
        End Property

        Public Property FirstName As String
            Get
                Return GetProperty(Function() Me.FirstName)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() FirstName, value)
            End Set
        End Property

        Public Property MiddleName As String
            Get
                Return GetProperty(Function() Me.MiddleName)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() MiddleName, value)
            End Set
        End Property

        Public Property LastName As String
            Get
                Return GetProperty(Function() Me.LastName)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() LastName, value)
            End Set
        End Property

        Public Property JobTitle As String
            Get
                Return GetProperty(Function() Me.JobTitle)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() JobTitle, value)
            End Set
        End Property

        Public Property Phone As String
            Get
                Return GetProperty(Function() Me.Phone)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() Phone, value)
            End Set
        End Property

        Public Property EmailAddress As String
            Get
                Return GetProperty(Function() Me.EmailAddress)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() EmailAddress, value)
            End Set
        End Property

        Public Property AddressLine1 As String
            Get
                Return GetProperty(Function() Me.AddressLine1)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() AddressLine1, value)
            End Set
        End Property

        Public Property Cities As List(Of String)
            Get
                Return GetProperty(Function() Me.Cities)
            End Get

            Set(ByVal value As List(Of String))
                SetProperty(Function() Cities, value)
            End Set
        End Property

        Public Property StateProvinceName As String
            Get
                Return GetProperty(Function() Me.StateProvinceName)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() StateProvinceName, value)
            End Set
        End Property

        Public Property PostalCode As String
            Get
                Return GetProperty(Function() Me.PostalCode)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() PostalCode, value)
            End Set
        End Property

        Public Property CountryRegionName As String
            Get
                Return GetProperty(Function() Me.CountryRegionName)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() CountryRegionName, value)
            End Set
        End Property

        Public Property GroupName As String
            Get
                Return GetProperty(Function() Me.GroupName)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() GroupName, value)
            End Set
        End Property

        Public Property BirthDate As Date
            Get
                Return GetProperty(Function() Me.BirthDate)
            End Get

            Set(ByVal value As Date)
                SetProperty(Function() BirthDate, value)
            End Set
        End Property

        Public Property HireDate As Date
            Get
                Return GetProperty(Function() Me.HireDate)
            End Get

            Set(ByVal value As Date)
                SetProperty(Function() HireDate, value)
            End Set
        End Property

        Public Property Gender As String
            Get
                Return GetProperty(Function() Me.Gender)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() Gender, value)
            End Set
        End Property

        Public Property MaritalStatus As String
            Get
                Return GetProperty(Function() Me.MaritalStatus)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() MaritalStatus, value)
            End Set
        End Property

        Public Property Title As String
            Get
                Return GetProperty(Function() Me.Title)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() Title, value)
            End Set
        End Property

        Public Property ImageData As Byte()
            Get
                Return GetProperty(Function() Me.ImageData)
            End Get

            Set(ByVal value As Byte())
                SetProperty(Function() ImageData, value)
            End Set
        End Property
    End Class
End Namespace
