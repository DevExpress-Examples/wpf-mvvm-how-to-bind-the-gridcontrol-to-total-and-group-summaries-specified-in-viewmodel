Imports DevExpress.Mvvm
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Namespace SummarySample
	Public Enum SummaryItemType
		Max
		Count
		None
	End Enum

	Public Class CustomersViewModel
		Inherits ViewModelBase

		Public Sub New()
			Customers = CustomersDataModel.GetCustomers()
			TotalSummary = New ObservableCollection(Of Summary)() From {
				New Summary(SummaryItemType.Count, NameOf(Customer.Name)),
				New Summary(SummaryItemType.Max, NameOf(Customer.Visits))
			}
			GroupSummary = New ObservableCollection(Of Summary)() From {New Summary(SummaryItemType.Count, NameOf(Customer.Name))}
		End Sub
		Public ReadOnly Property Customers() As IList(Of Customer)
		Public ReadOnly Property TotalSummary() As ObservableCollection(Of Summary)
		Public ReadOnly Property GroupSummary() As ObservableCollection(Of Summary)
	End Class

	Public Class Summary
		Inherits BindableBase

		Public Sub New(ByVal type As SummaryItemType, ByVal fieldname As String)
			Me.Type = type
			Me.FieldName = fieldname
		End Sub
		Public ReadOnly Property Type() As SummaryItemType
		Public ReadOnly Property FieldName() As String
	End Class
End Namespace