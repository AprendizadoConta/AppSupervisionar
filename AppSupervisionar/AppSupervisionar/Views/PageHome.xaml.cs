using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSupervisionar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageHome : ContentPage
    {
        public PageHome()
        {
            InitializeComponent();
            
        }
        

        private void qtdCadastrar_Tapped(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)App.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastrar());
            p.IsPresented = false;
        }

        private void qtdLocalizar_Tapped(object sender, EventArgs e)
        {

        }
    }
}