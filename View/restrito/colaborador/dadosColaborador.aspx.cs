using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View.restrito.colaborador
{
    public partial class dadosColaborador : PageBase
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                CarregarCombo();
                if (Request.QueryString["itemSel"] != null)
                {
                    Carregar();
                    
                }
            }

        }

        public void CarregarCombo()
        {

            List<Unidade> lst = new UnidadeController().Listar(new Unidade());

            foreach (Unidade item in lst)
            {
                cmbUnidades.Items.Add(new ListItem(item.nome, item.idUnidade.ToString()));
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            int idSelecionado = 0;

            if (cmbUnidades.SelectedIndex > 0)
                idSelecionado = int.Parse(cmbUnidades.SelectedValue);

            if (Request.QueryString["itemSel"] == null)
                Incluir();
            else
                Alterar();

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../menu.aspx");
        }

        #endregion

        #region Métodos

        public void Carregar()
        {

            Colaborador u = new Colaborador();

            u.idColaborador = int.Parse(Request.QueryString["itemSel"]);

            u = new ColaboradorController().Listar(u, 0)[0];

            ViewState.Add("itemSel", u);

            txtNome.Text = u.nome;
            txtCpf.Text = u.cpf;
            cmbUnidades.SelectedValue = u.idUnidade.ToString();

        }

        public void Incluir()
        {

            try
            {

                Colaborador colaborador = new Colaborador();

                colaborador.nome = txtNome.Text;

                colaborador.cpf = txtCpf.Text;

                if (cmbUnidades.SelectedIndex > 0)
                    colaborador.idUnidade = int.Parse(cmbUnidades.SelectedValue);

                colaborador.usuario = UsuarioLogado;

                new ColaboradorController().Incluir(colaborador);

                Response.Redirect("../menu.aspx");

            }
            catch (ConsistenciaException ex)
            {
                ExibirMensagemAlert(ex.Mensagem);
            }


        }

        public void Alterar()
        {

            try
            {

                Colaborador colaborador = (Colaborador)ViewState["itemSel"];

                colaborador.nome = txtNome.Text;
                colaborador.cpf = txtCpf.Text;

                if (cmbUnidades.SelectedIndex > 0)
                    colaborador.idUnidade = int.Parse(cmbUnidades.SelectedValue);

                colaborador.usuario = UsuarioLogado;

                new ColaboradorController().Atualizar(colaborador);

                Response.Redirect("listaColaborador.aspx");

            }
            catch (ConsistenciaException ex)
            {
                ExibirMensagemAlert(ex.Mensagem);
            }

        }

        #endregion

    }
}