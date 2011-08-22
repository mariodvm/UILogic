using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UILogic;
using System.Windows.Media;

namespace TestApp
{
    public class PersonHomeView : View<Person, MainWindow>
    {
        public PersonHomeView(Person person, MainWindow mainWindow)
            : base(person, mainWindow)
        {
        }

        protected override void Initialize()
        {
            Item1.AddTrigger(
                when: p => p.Email.Contains(".com") && p.Age < 18,
                    then:      (e) => { Visual.button1.IsEnabled = false; Visual.textBox1.Background = Brushes.Red; },
                    otherwise: (e) => { Visual.button1.IsEnabled = true; Visual.textBox1.Background = Brushes.Transparent; });
        }

    }
}
