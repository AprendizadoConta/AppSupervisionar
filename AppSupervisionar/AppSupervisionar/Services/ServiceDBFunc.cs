using System;
using System.Collections.Generic;
using System.Text;

using AppSupervisionar.Models;//adicionado
using SQLite;//adicionado

namespace AppSupervisionar.Services
{
    public class ServiceDBFunc
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public ServiceDBFunc(string dbCaminho)
        {
            if (dbCaminho == "") dbCaminho = App.DbCaminho;
            conn = new SQLiteConnection(dbCaminho);
            conn.CreateTable<ModelFunc>();
        }

        public void Inserir(ModelFunc Funcionario)
        {
            try
            {
                if (string.IsNullOrEmpty(Funcionario.Nome))
                    throw new Exception("Nome do Funcionário não foi informado!");
                if (string.IsNullOrEmpty(Funcionario.Setor))
                    throw new Exception("Setor do Funcionário não foi informado!");
                if (string.IsNullOrEmpty(Funcionario.Turno))
                    throw new Exception("Turno do Funcionário não foi informado!");
                int result = conn.Insert(Funcionario);
                if (result != 0)
                {
                    this.StatusMessage = string.Format("{0} funcionários(s) foi adicionado(s). Funcionario: {1}", result, Funcionario.Nome);
                }
                else
                {
                    this.StatusMessage = string.Format("Nenhum funcionário adicionado! Por Favor, informe o Nome, Setor e o Turno do Funcionário!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ModelFunc> Listar() 
        {
            List<ModelFunc> lista = new List<ModelFunc>();
            try
            {
                lista = conn.Table<ModelFunc>().ToList();
                this.StatusMessage = "Listagem de Funcionários";
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            return lista;
        }

        public void Alterar(ModelFunc Funcionario)
        {
            try
            {
                if (string.IsNullOrEmpty(Funcionario.Nome))
                    throw new Exception("Nome do Funcionário não foi informado!");
                if (string.IsNullOrEmpty(Funcionario.Setor))
                    throw new Exception("Setor do Funcionário não foi informado!");
                if (string.IsNullOrEmpty(Funcionario.Turno))
                    throw new Exception("Turno do Funcionário não foi informado!");
                if(Funcionario.Id <=0)
                    throw new Exception("Id do Funcionário não foi informado!");
                int result = conn.Update(Funcionario);
                StatusMessage = string.Format("Registros do Funcionário {0} foram alterados!", result);//vir aqui Conferir depois
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }
        
        public void Excluir(int id)
        {
            try
            {
                int result = conn.Table<ModelFunc>().Delete(r => r.Id == id);
                StatusMessage = string.Format("Dados do Funcionário {0} foram deletados!", result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        public List<ModelFunc> Localizar(string nome, int Id)//localizar geral
        {
            List<ModelFunc> lista = new List<ModelFunc>();
            try
            {
                var resp = from p in conn.Table<ModelFunc>() where p.Id == Id && p.Nome.ToLower().Contains(nome.ToLower())select p;//Caso fica chato de procurar tirar o Id
                lista=resp.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro: {0}",ex.Message));
            }
            return lista;
        }

        public ModelFunc GetFunc(int id)//fazer um teste depois sem esse getFuc
        {
            ModelFunc m = new ModelFunc();
            try
            {
                m = conn.Table<ModelFunc>().First(n => n.Id == id);
                StatusMessage = "Funcionário Encontrado!";
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro: {0}",ex.Message));
            }
            return m;
        }

    }
}
