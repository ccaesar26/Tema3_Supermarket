using System.Collections.ObjectModel;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Models.DataTransferLayer;

public class ReceiptDTO
{
    public int? Id { get; init; }
    public UserDTO? Cashier { get; set; }
    public string? IssueDate { get; set; }
    public float? AmountReceived { get; set; }
    public ObservableCollection<ReceiptItemDTO>? Items { get; set; }
}