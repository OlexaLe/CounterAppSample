using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CounterApp
{
    public partial class MainPage : ContentPage
    {
        private CounterStore store;

        public MainPage()
        {
            store = new CounterStore(new CounterState(0));
            BindingContext = store;
            InitializeComponent();
        }

        private void Decrement_Clicked(object sender, EventArgs e)
        {
            store.Dispatch(new DecrementAction());
        }

        private void Increment_Clicked(object sender, EventArgs e)
        {
            store.Dispatch(new IncrementAction());
        }
    }
}