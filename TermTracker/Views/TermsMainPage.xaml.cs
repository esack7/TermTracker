using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermTracker.Database;
using TermTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermsMainPage : ContentPage
    {
        ObservableCollection<Term> terms = new ObservableCollection<Term>();
        public ObservableCollection<Term> Terms { get { return terms; } }
        public TermsMainPage()
        {
            InitializeComponent();
            updateData();
            BindingContext = this;
        }

        public void addToTermsList(Term term)
        {
            Terms.Add(term);
        }

        private void updateData()
        {
            var data = GetData();
            terms = new ObservableCollection<Term>(data);
        }

        private List<Term> GetData()
        {
            var database = new SqliteDataService();
            database.Initialize();
            return database.GetAllTerms();
        }

        private async void AddTerm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TermConstructPage(this));
        }
    }
}