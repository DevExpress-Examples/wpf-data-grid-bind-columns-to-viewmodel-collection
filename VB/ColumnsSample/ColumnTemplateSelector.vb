Imports System.Windows
Imports System.Windows.Controls

Namespace ColumnsSample
	Public Class ColumnTemplateSelector
		Inherits DataTemplateSelector

		Public Property DefaultColumnTemplate() As DataTemplate
		Public Property LookupColumnTemplate() As DataTemplate
		Public Property BindingColumnTemplate() As DataTemplate

		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
			Dim column As Column = TryCast(item, Column)
			If column Is Nothing Then
				Return Nothing
			End If
			Select Case column.Settings
				Case SettingsType.Default
					Return DefaultColumnTemplate
				Case SettingsType.Lookup
					Return LookupColumnTemplate
				Case SettingsType.Binding
					Return BindingColumnTemplate
			End Select
			Return Nothing
		End Function
	End Class
End Namespace
