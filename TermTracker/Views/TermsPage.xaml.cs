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

            terms.Add(new Term{ Id = 1, Title = "Term 1" });
            terms.Add(new Term{ Id = 2, Title = "Term 2" });
            terms.Add(new Term{ Id = 3, Title = "Term 3" });

            BindingContext = this;
        }
    }
}