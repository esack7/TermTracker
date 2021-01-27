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
            TermsCollection.ItemsSource = terms;

            terms.Add(new Term{ Title = "Term 1" });
            terms.Add(new Term{ Title = "Term 2" });
            terms.Add(new Term{ Title = "Term 3" });
        }
    }
}