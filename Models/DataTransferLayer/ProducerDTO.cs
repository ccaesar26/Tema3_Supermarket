using System.ComponentModel;

namespace Supermarket.Models.DataTransferLayer;

public class ProducerDTO
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? OriginCountry { get; init; }
}