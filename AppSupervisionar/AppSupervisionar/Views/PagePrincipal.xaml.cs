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
    public partial class PagePrincipal : MasterDetailPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
            btHome_Clicked(new object(), new EventArgs());
            Task.Run(AnimatedBackground);
        }
       
        private async void AnimatedBackground()
        {
            Action<double> forward = input => bcGradient.AnchorY = input;
            Action<double> backward = input => bcGradient.AnchorY = input;
            while (true)
            {
                bcGradient.Animate(name: "forward", callback: forward, start: 0, end: 1, length:5000,easing: Easing.SinIn);
                await Task.Delay(5000);
                bcGradient.Animate(name: "backward", callback: backward, start: 1, end: 0, length: 5000, easing: Easing.SinIn);
                await Task.Delay(5000);
            }
           
        }

        private void btHome_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageHome());
            IsPresented = false;
        }

        private void btCadastrar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageCadastrar());
            IsPresented = false;
        }

        private void btLocalizar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageListarFunc());
            IsPresented = false;
        }

        private void btDetalhes_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageDetalhes());
            IsPresented = false;
        }
    }
}