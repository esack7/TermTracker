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
    public partial class CourseConstructPage : ContentPage
    {
        public CourseConstructPage()
        {
            InitializeComponent();
            SaveEditButton.IsVisible = false;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void SaveEditButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}