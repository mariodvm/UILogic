using System;
using System.ComponentModel;

namespace UILogic
{
    public class View<TData, TVisual> : Tuple<TData>
        where TData : INotifyPropertyChanged
    {
        public View(TData data, TVisual visual)
            : base(data)
        {
            Visual = visual;
            Initialize();
        }

        public TData Data1 { get; set; }

        public TVisual Visual { get; set; }
        protected virtual void Initialize() { }
    }

    public class View<TData1, TData2, TVisual> : Tuple<TData1, TData2>
        where TData1 : INotifyPropertyChanged
        where TData2 : INotifyPropertyChanged
    {
        public View(TData1 data1, TData2 data2, TVisual visual)
            : base (data1, data2)
        {
            Visual = visual;
            Initialize();
        }

        public TVisual Visual { get; set; }

        protected virtual void Initialize() { }
    }

    public class View<TData1, TData2, TData3, TVisual> : Tuple<TData1, TData2, TData3>
        where TData1 : INotifyPropertyChanged
        where TData2 : INotifyPropertyChanged
        where TData3 : INotifyPropertyChanged
    {
        public View(TData1 data1, TData2 data2, TData3 data3, TVisual visual)
            : base(data1, data2, data3)
        {
            Visual = visual;
            Initialize();
        }

        public TVisual Visual { get; set; }

        protected virtual void Initialize() { }
    }
}
