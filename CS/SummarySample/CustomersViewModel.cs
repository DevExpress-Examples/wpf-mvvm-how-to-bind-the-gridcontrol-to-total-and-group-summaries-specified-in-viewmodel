using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SummarySample {
    public enum SummaryItemType { Max, Count, None }

    public class CustomersViewModel : ViewModelBase {
        public CustomersViewModel() {
            Customers = CustomersDataModel.GetCustomers();
            TotalSummary = new ObservableCollection<Summary>() {
                new Summary( SummaryItemType.Count, nameof(Customer.Name) ),
                new Summary(SummaryItemType.Max, nameof(Customer.Visits) )
            };
            GroupSummary = new ObservableCollection<Summary>() {
                new Summary( SummaryItemType.Count, nameof(Customer.Name) )
            };
        }
        public IList<Customer> Customers { get; }
        public ObservableCollection<Summary> TotalSummary { get; }
        public ObservableCollection<Summary> GroupSummary { get; }
    }

    public class Summary : BindableBase {
        public Summary(SummaryItemType type, string fieldname) {
            Type = type;
            FieldName = fieldname;
        }
        public SummaryItemType Type { get; }
        public string FieldName { get; }
    }
}