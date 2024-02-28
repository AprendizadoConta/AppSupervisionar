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

        }

        private void ListFuncTarde_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ListFuncNoite_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}