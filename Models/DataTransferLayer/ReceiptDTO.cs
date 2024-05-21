using System.Collections.ObjectModel;

namespace Supermarket.Models.DataTransferLayer;

public class ReceiptDTO
{
    public int? Id { get; init; }
    public UserDTO? Cashier { get; init; }
    public string? IssueDate { get; init; }
    public float? AmountReceived { get; init; }
    public ObservableCollection<ReceiptItemDTO>? Items { get; init; }
}