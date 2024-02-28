using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppSupervisionar.Models;//adicionei
using AppSupervisionar.Services;//adicionei

namespace AppSupervisionar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageListarFunc : ContentPage
	{
		public PageListarFunc ()
		{
			InitializeComponent();
            AtualizarLista();
		}
        public void AtualizarLista()
        {
            String nome = "";
            String turno = "";
            if (txtFuncionario.Text != null) nome = txtFuncionario.Text;
            if (pckTurno.SelectedItem != null) 
            {
                turno = pckTurno.SelectedItem.ToString();
            }
            ServiceDBFunc dBFunc = new ServiceDBFunc(App.DbCaminho);
            ListFunc.ItemsSource = dBFunc.Localizar(nome,turno);
        }

        private void pckTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnLocalizar_Clicked(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void ListFunc_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ServiceDBFunc dBFunc = new ServiceDBFunc(App.DbCaminho);
            List<ModelFunc> listaFunc = dBFunc.Listar();
           
            if (e.SelectedItem == null)
                return;
            var selectItem = e.SelectedItem as ModelFunc;
            if (selectItem.Turno == "Manhã ☀️")
            {
                ListFuncTarde.IsVisible = false;
                ListFuncNoite.IsVisible = false;
                var funcionariosManha = listaFunc.Where(f => f.Turno == "Manhã ☀️").ToList();
                ListFunc.ItemsSource= funcionariosManha;
                ListFunc.IsVisible = true;
            }
        }

        private void ListFuncTarde_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ServiceDBFunc dBFunc = new ServiceDBFunc(App.DbCaminho);
            List<ModelFunc> listaFunc = dBFunc.Listar();
            if (e.SelectedItem == null)
                return;
            var selectItem = e.SelectedItem as ModelFunc;
            if (selectItem.Turno == "Tarde 🌇")
            {
                ListFunc.IsVisible= false;
                ListFuncNoite.IsVisible = false;
                var funcionariosTarde = listaFunc.Where(f => f.Turno == "Tarde 🌇").ToList();
                ListFuncTarde.ItemsSource = funcionariosTarde;
                ListFuncTarde.IsVisible = true;
            }
        }

        private void ListFuncNoite_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ServiceDBFunc dBFunc = new ServiceDBFunc(App.DbCaminho);
            List<ModelFunc> listaFunc = dBFunc.Listar();
            if (e.SelectedItem == null)
                return;
            var selectItem = e.SelectedItem as ModelFunc;
            if (selectItem.Turno == "Noite 🌕")
            {
                ListFunc.IsVisible= false;
                ListFuncTarde.IsVisible = false;
                var funcionariosNoite = listaFunc.Where(f => f.Turno == "Noite 🌕").ToList();
                ListFuncNoite.ItemsSource = funcionariosNoite;
                ListFuncNoite.IsVisible = true;
            }
        }
    }
}