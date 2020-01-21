Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Reflection
Imports System.Xml.Serialization
Imports DevExpress.Data

Namespace Model
	Public Class ViewModel
		Private privateStates As List(Of String)
		Public Property States() As List(Of String)
			Get
				Return privateStates
			End Get
			Private Set(ByVal value As List(Of String))
				privateStates = value
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
			States = Source.Select(Function(x) x.StateProvinceName).Distinct().ToList()
			Columns = New ObservableCollection(Of Column)() From {
				New Column() With {.FieldName="FirstName"},
				New Column() With {.FieldName="LastName"},
				New ComboColumn() With {
					.Settings = SettingsType.Combo,
					.FieldName="StateProvinceName",
					.Source = States
				},
				New HeaderColumn() With {
					.Settings = SettingsType.Binding,
					.FieldName = "Cities[0]",
					.Header = "City1"
				},
				New HeaderColumn() With {
					.Settings = SettingsType.Binding,
					.FieldName = "Cities[1]",
					.Header = "City2"
				},
				New Column() With {
					.FieldName="ImageData",
					.Settings = SettingsType.Image
				}
			}
			TotalSummary = New ObservableCollection(Of Summary)() From {
				New Summary() With {
					.Type = SummaryItemType.Count,
					.FieldName = "FirstName"
				},
				New Summary() With {
					.Type = SummaryItemType.Max,
					.FieldName = "BirthDate"
				}
			}
			GroupSummary = New ObservableCollection(Of Summary)() From {
				New Summary() With {
					.Type = SummaryItemType.Count,
					.FieldName = "FirstName"
				}
			}
		End Sub
	End Class

	Public Enum SettingsType
		[Default]
		Combo
		Image
		Binding
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
	Public Class HeaderColumn
		Inherits Column

		Public Property Header() As String
	End Class

	<XmlRoot("Employees")>
	Public Class EmployeesData
		Inherits List(Of Employee)

		Public Shared ReadOnly Property DataSource() As IList(Of Employee)
			Get
				Dim s As New XmlSerializer(GetType(EmployeesData))
				Return DirectCast(s.Deserialize(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("WPFGridMVVMBindableColumns.EmployeesWithPhoto.xml")), List(Of Employee))
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
		Public Property Cities() As List(Of String)
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
