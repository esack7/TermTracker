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
    public partial class TermsPage : ContentPage
    {
        ObservableCollection<Term> terms = new ObservableCollection<Term>();
        public ObservableCollection<Term> Terms { get { return terms; } }
        public TermsPage()
        {
            InitializeComponent();
            var data = GetData();
            terms = new ObservableCollection<Term>(data);

            BindingContext = this;
        }

        private List<Term> GetData()
        {
            var database = new SqliteDataService();
            database.Initialize();
            return database.GetAllTerms();
        }
    }
}