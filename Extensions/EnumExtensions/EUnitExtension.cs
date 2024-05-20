using System.Collections.ObjectModel;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Extensions.EnumExtensions;

public static class EUnitExtension
{
    public static ObservableCollection<string> ToStringCollection()
    {
        var stringCollection = new ObservableCollection<string>();

        foreach (EUnit value in Enum.GetValues(typeof(EUnit)))
        {
            stringCollection.Add(value.ToString());
        }

        return stringCollection;
    }
}