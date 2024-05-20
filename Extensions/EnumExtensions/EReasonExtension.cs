using System.Collections.ObjectModel;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Extensions.EnumExtensions;

public static class EReasonExtension
{
    public static ObservableCollection<string> ToStringCollection()
    {
        var collection = new ObservableCollection<string>();
        foreach (var reason in Enum.GetValues<EReason>())
        {
            collection.Add(reason.ToString());
        }
        return collection;
    }
}