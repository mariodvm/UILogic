using System;
using System.ComponentModel;

namespace UILogic
{
    public static class TriggerExtension
    {
        public static object Get(this object x, string propertyName)
        {
            return x.GetType().GetProperty(propertyName).GetValue(x, null);
        }

        private static void ApplyTrigger(INotifyPropertyChanged elem, PropertyChangedEventHandler handler, ApplyMoment times)
        {
            if ((times & ApplyMoment.Now) == ApplyMoment.Now)
            {
                handler(elem, new PropertyChangedEventArgs(null));
                if ((times & ApplyMoment.Once) == ApplyMoment.Once)
                    return;
            }
            elem.PropertyChanged += handler;
        }

        public static void AddTrigger<T>(this T elem, Func<T, bool> when, 
                                              Action<ValuePropertyChangedArgs> then, Action<ValuePropertyChangedArgs> otherwise = null,
                                              ApplyMoment times = ApplyMoment.Always)
            where T : INotifyPropertyChanged
        {
            PropertyChangedEventHandler handler = null;
            handler = delegate (object sender, PropertyChangedEventArgs e)
            {
                if (when(elem))
                    then(ValuePropertyChangedArgs.From(sender, e));
                else if (otherwise != null)
                {
                    otherwise(ValuePropertyChangedArgs.From(sender, e));
                    if ((times & ApplyMoment.Once) == ApplyMoment.Once)
                        elem.PropertyChanged -= handler;
                } else
                    if ((times & ApplyMoment.Once) == ApplyMoment.Once)
                        elem.PropertyChanged -= handler;

            };

            ApplyTrigger(elem, handler, times);
        }

        public static void AddTrigger<T1, T2>(T1 elem1, T2 elem2, Func<T1, T2, bool> when, 
                                              Action<ValuePropertyChangedArgs> then, 
                                              Action<ValuePropertyChangedArgs> otherwise = null,
                                              ApplyMoment times = ApplyMoment.Always)
            where T1 : INotifyPropertyChanged
            where T2 : INotifyPropertyChanged
        {
            PropertyChangedEventHandler handler = null;
            handler = delegate(object sender, PropertyChangedEventArgs e)
            {
                if (when(elem1, elem2))
                    then(ValuePropertyChangedArgs.From(sender, e));
                else if (otherwise != null)
                {
                    otherwise(ValuePropertyChangedArgs.From(sender, e));
                    if ((times & ApplyMoment.Once) == ApplyMoment.Once)
                    {
                        elem1.PropertyChanged -= handler;
                        elem2.PropertyChanged -= handler;
                    }
                }
                else
                    if ((times & ApplyMoment.Once) == ApplyMoment.Once)
                    {
                        elem1.PropertyChanged -= handler;
                        elem2.PropertyChanged -= handler;
                    }
            };
            ApplyTrigger(elem1, handler, times);
            ApplyTrigger(elem2, handler, times);
        }

        public static void AddTrigger<T1, T2, T3>(T1 elem1, T2 elem2, T3 elem3, Func<T1, T2, T3, bool> when,
                                                  Action<ValuePropertyChangedArgs> then, 
                                                  Action<ValuePropertyChangedArgs> otherwise = null,
                                                  ApplyMoment times = ApplyMoment.Always)
            where T1 : INotifyPropertyChanged
            where T2 : INotifyPropertyChanged
            where T3 : INotifyPropertyChanged
        {
            PropertyChangedEventHandler handler = null;
            handler = delegate(object sender, PropertyChangedEventArgs e)
            {
                if (when(elem1, elem2, elem3))
                    then(ValuePropertyChangedArgs.From(sender, e));
                else if (otherwise != null)
                {
                    otherwise(ValuePropertyChangedArgs.From(sender, e));
                    if ((times & ApplyMoment.Once) == ApplyMoment.Once)
                    {
                        elem1.PropertyChanged -= handler;
                        elem2.PropertyChanged -= handler;
                        elem3.PropertyChanged -= handler;
                    }
                }
                else
                    if ((times & ApplyMoment.Once) == ApplyMoment.Once)
                    {
                        elem1.PropertyChanged -= handler;
                        elem2.PropertyChanged -= handler;
                        elem3.PropertyChanged -= handler;
                    }
            };
            ApplyTrigger(elem1, handler, times);
            ApplyTrigger(elem2, handler, times);
            ApplyTrigger(elem3, handler, times);
        }
    }

    public class ValuePropertyChangedArgs : PropertyChangedEventArgs
    {
        public ValuePropertyChangedArgs(object source, string propertyName)
            : base(propertyName)
        {
        }

        public object Source { get; set; }

        public object Value 
        {
            get { return Source.Get(PropertyName); }
        }

        public static ValuePropertyChangedArgs From(object sender, PropertyChangedEventArgs args)
        {
            return new ValuePropertyChangedArgs(sender, args.PropertyName);
        }
    }

    public enum ApplyMoment { Always = 0, Once = 1, Now = 2 }
}
