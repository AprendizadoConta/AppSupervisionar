using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppSupervisionar.Models;//adicionei
using AppSupervisionar.Services;//adicionei

namespace AppSupervisionar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListarFunc : ContentPage
    {
        public PageListarFunc()
        {
            InitializeComponent();
            AtualizarLista();
        }

        public void AtualizarLista()
        {
            string nome = txtFuncionario.Text ?? "";
            string turno = pckTurno.SelectedItem?.ToString() ?? "";

            ServiceDBFunc dBFunc = new ServiceDBFunc(App.DbCaminho);
            List<ModelFunc> listaFunc = dBFunc.Localizar(nome, turno);

            ListFunc.ItemsSource = listaFunc.Where(f => f.Turno == "Manhã ☀").ToList();
            ListFuncTarde.ItemsSource = listaFunc.Where(f => f.Turno == "Tarde 🌇").ToList();
            ListFuncNoite.ItemsSource = listaFunc.Where(f => f.Turno == "Noite 🌕").ToList();

            
            qtdManha.Text = $"Qtd: {ListFunc.ItemsSource?.Cast<object>().Count() ?? 0}";
            qtdTarde.Text = $"Qtd: {ListFuncTarde.ItemsSource?.Cast<object>().Count() ?? 0}";
            qtdNoite.Text = $"Qtd: {ListFuncNoite.ItemsSource?.Cast<object>().Count() ?? 0}";

            ListFunc.IsVisible = true;
            ListFuncTarde.IsVisible = true;
            ListFuncNoite.IsVisible = true;
        }

        private void pckTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void btnLocalizar_Clicked(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void ListFunc_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListFuncTarde.IsVisible = false;
            ListFuncNoite.IsVisible = false;
            ModelFunc func = (ModelFunc)ListFunc.SelectedItem;
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastrar());
            p.Detail= new NavigationPage(new PageCadastrar(func));
        }

        private void ListFuncTarde_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListFunc.IsVisible = false;
            ListFuncNoite.IsVisible = false;
            ModelFunc func = (ModelFunc)ListFuncTarde.SelectedItem;
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastrar());
            p.Detail = new NavigationPage(new PageCadastrar(func));
        }

        private void ListFuncNoite_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListFunc.IsVisible = false;
            ListFuncTarde.IsVisible = false;
            ModelFunc func = (ModelFunc)ListFuncNoite.SelectedItem;
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastrar());
            p.Detail = new NavigationPage(new PageCadastrar(func));
        }

        private void btnLimpar_Clicked(object sender, EventArgs e)
        {
            txtFuncionario.Text = null;
            pckTurno.SelectedItem = null;
            AtualizarLista();
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageHome());
        }
    }
}
