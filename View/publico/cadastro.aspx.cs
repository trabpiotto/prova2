using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View
{
    public partial class inicio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            try
            {

                UsuarioController uc = new UsuarioController();

                Usuario us = new Usuario();

                us.Email = txtEmail.Text;
                us.Senha = txtSenha.Text;
                us.Descricao = txtDescricao.Text;
                us.Nome = txtNome.Text;

                uc.Cadastrar(us);

                ExibirMensagemAlert("Cadastro realizado com sucesso");

                //Response.Redirect("/publico/cadastro.aspx");
            }
            catch (ConsistenciaException ex)
            {
                ExibirMensagemAlert(ex.Mensagem);
            }
        }

        public void ExibirMensagemAlert(String textoMensagem)
        {
            ScriptManager.RegisterStartupScript(this.Page, GetType(), "mensagemAlert", String.Format("alert('{0}')", textoMensagem), true);
        }
    }
}