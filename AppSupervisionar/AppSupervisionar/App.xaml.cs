using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppSupervisionar.Views;//adicionado

namespace AppSupervisionar
{
    public partial class App : Application
    {
        public static String DbNome;
        public static String DbCaminho;
        public App()
        {
            InitializeComponent();

            MainPage = new PagePrincipal ();
        }
        public App(string dbCaminho, string dbNome)
        {
            InitializeComponent();
            App.DbNome = dbNome;
            App.DbCaminho = dbCaminho;
            MainPage = new PagePrincipal();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
