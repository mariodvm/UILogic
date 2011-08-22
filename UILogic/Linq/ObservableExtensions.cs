using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace UILogic.Linq
{
    public static class ObservableExtensions
    {
        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> col)
        {
            return new ObservableCollection<T>(col);
        }
    }
}
