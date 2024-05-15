using System.Collections.ObjectModel;
using Supermarket.Models.DataTransferLayer;

namespace Supermarket.Models.DataTransferObjects;

public class ReceiptDTO
{
    public int? Id { get; set; }
    public string? UserName { get; set; }
    public string? IssueDate { get; set; }
    public float? AmountReceived { get; set; }
    public ObservableCollection<ProductDTO>? Products { get; set; }
}