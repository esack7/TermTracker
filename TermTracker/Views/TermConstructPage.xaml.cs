using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermConstructPage : ContentPage
    {
        public TermConstructPage()
        {
            InitializeComponent();
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}