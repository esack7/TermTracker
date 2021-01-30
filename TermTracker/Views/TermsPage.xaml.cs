using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //TermsCollection.ItemsSource = Terms;
            var thisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            terms.Add(new Term(1, "Term 1", thisMonth, thisMonth.AddMonths(4).AddDays(-1)));
            terms.Add(new Term(2, "Term 2", thisMonth.AddMonths(4), thisMonth.AddMonths(8).AddDays(-1)));
            terms.Add(new Term(3, "Term 3", thisMonth.AddMonths(8), thisMonth.AddMonths(12).AddDays(-1)));

            BindingContext = this;
        }
    }
}