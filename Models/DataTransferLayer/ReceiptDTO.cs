using Supermarket.Models.DataTransferLayer;

namespace Supermarket.Models.DataTransferObjects;

public class ReceiptDTO
{
    public string UserName { get; set; }
    public string IssueDate { get; set; }
    public float AmountReceived { get; set; }
    public List<ProductDTO> Products { get; set; }
}