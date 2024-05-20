using System.Collections.ObjectModel;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Extensions.EnumExtensions;

public static class EUserTypeExtension
{
    public static ObservableCollection<string> ToStringCollection()
    {
        var stringCollection = new ObservableCollection<string>();

        foreach (EUserType value in Enum.GetValues(typeof(EUserType)))
        {
            stringCollection.Add(value.ToString());
        }

        return stringCollection;
    }
}