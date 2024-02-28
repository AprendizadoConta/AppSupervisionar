using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppSupervisionar.Models;
using AppSupervisionar.Services;

namespace AppSupervisionar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastrar : ContentPage
    {
        public PageCadastrar()
        {
            InitializeComponent();
        }
        public PageCadastrar(ModelFunc func)
        {
            InitializeComponent();
            btnCadastrar.Text = "Editar";
            txtCodigo.IsVisible = true;
            btnExcluir.IsVisible = true;
            txtCodigo.Text = func.Id.ToString();
            txtFuncionario.Text = func.Nome;
            pckSetor.SelectedItem = func.Setor; //vir aqui e tentar apagar esse .toString();
            pckTurno.SelectedItem = func.Turno;
        }

        private void pckSetor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pckTurno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                ModelFunc func = new ModelFunc();
                func.Nome = txtFuncionario.Text;
                func.Setor = pckSetor.SelectedItem.ToString();
                func.Turno = pckTurno.SelectedItem.ToString();
                ServiceDBFunc dBFunc = new ServiceDBFunc(App.DbCaminho);
                if (btnCadastrar.Text == "Cadastrar")
                {
                    dBFunc.Inserir(func);
                    DisplayAlert("Resultado", dBFunc.StatusMessage, "Ok");
                }
                else
                {
                   func.Id = Convert.ToInt32(txtCodigo.Text);
                    dBFunc.Alterar(func);
                    DisplayAlert("Funcionário Alterado com Sucesso!", dBFunc.StatusMessage, "OK");
                }
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PageHome());
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", "Preencha os Campos","OK");
            }
        }

        private async void btnExcluir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Excluir Funcionário", "Deseja EXCLUIR os dados do funcionário selecionado ?", "Sim", "Não");
            if (resp==true)
            {
                ServiceDBFunc dBFunc = new ServiceDBFunc(App.DbCaminho);
                int id = Convert.ToInt32(txtCodigo.Text);
                dBFunc.Excluir(id);
                DisplayAlert("Dados Excluídos com Sucesso!", dBFunc.StatusMessage, "Ok");
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PageHome());
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageHome());
        }
    }
}