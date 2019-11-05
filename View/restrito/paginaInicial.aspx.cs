using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View.restrito
{
    public partial class paginaInicial : System.Web.UI.Page
    {
        Usuario usuarioLogado;
        protected void Page_Load(object sender, EventArgs e)
        {
            BuscaUsuario();
        }

        public void BuscaUsuario()
        {
           
            usuarioLogado = (Usuario)Session["usuarioLogado"];
            lblNome.Text = usuarioLogado.Nome;
            lblDescricao.Text = usuarioLogado.Descricao;
            
        }
    }
}