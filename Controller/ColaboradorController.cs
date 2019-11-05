using System;
using Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ColaboradorController
    {

        public void Incluir(Colaborador objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome do colaborador.");
            }

            if (String.IsNullOrEmpty(objEntrada.cpf))
            {
                throw new ConsistenciaException("Por favor, informe o cpf do colaborador.");
            }

            if (objEntrada.idUnidade < 1)
            {
                throw new ConsistenciaException("Por favor, informe a unidade do colaborador.");
            }

            MySqlCommand cmd = new MySqlCommand(@"insert into Colaborador values(
                 default,
                 @Nome,
                 @Cpf,
                 @idUnidade,
                 @idUsuario)");

            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.nome));
            cmd.Parameters.Add(new MySqlParameter("Cpf", objEntrada.cpf));
            cmd.Parameters.Add(new MySqlParameter("idUnidade", objEntrada.idUnidade));
            cmd.Parameters.Add(new MySqlParameter("idUsuario", objEntrada.usuario.idUsuario));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Atualizar(Colaborador objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome do colaborador.");
            }

            if (String.IsNullOrEmpty(objEntrada.cpf))
            {
                throw new ConsistenciaException("Por favor, informe o cpf do colaborador.");
            }

            MySqlCommand cmd = new MySqlCommand(@"update Colaborador
                 set Nome = @Nome,
                     Cpf = @Cpf,
                     idUnidade = @idUnidade,
                     idUsuario = @idUsuario
               where idColaborador = @idColaborador
             ");

            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.nome));
            cmd.Parameters.Add(new MySqlParameter("Cpf", objEntrada.cpf));
            cmd.Parameters.Add(new MySqlParameter("idUsuario", objEntrada.usuario.idUsuario));
            cmd.Parameters.Add(new MySqlParameter("idUnidade", objEntrada.idUnidade));
            cmd.Parameters.Add(new MySqlParameter("idColaborador", objEntrada.idColaborador));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Excluir(Colaborador objEntrada)
        {

            MySqlCommand cmd = new MySqlCommand("delete from Colaborador where idColaborador = @idColaborador");

            cmd.Parameters.Add(new MySqlParameter("idColaborador", objEntrada.idColaborador));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public List<Colaborador> Listar(Colaborador objEntrada, int i)
        {

            MySqlCommand cmd = null;

            if (objEntrada.idColaborador != 0)
            {

                cmd = new MySqlCommand(@"
                 select Colaborador.idColaborador,
                        Colaborador.Nome,
                        Colaborador.Cpf,
                        Colaborador.idUnidade,
                        Colaborador.idUsuario,
                        Usuario.Nome
                   from Colaborador
                  inner join Usuario on Usuario.idUsuario = Colaborador.idUsuario
                  where Colaborador.idColaborador = @IdColaborador");

                cmd.Parameters.Add(new MySqlParameter("IdColaborador", objEntrada.idColaborador));

            }
            else
            {
                cmd = new MySqlCommand(@"select Colaborador.idColaborador,
                        Colaborador.Nome,
                        Colaborador.Cpf,
                        Colaborador.idUnidade,
                        Colaborador.idUsuario,
                        Usuario.Nome,
                        Unidade.nome
                   from Colaborador
                  inner join Usuario on Usuario.idUsuario = Colaborador.idUsuario
                  inner join Unidade on Unidade.idUnidade = Colaborador.idUnidade
                  order by idColaborador");
            }

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Colaborador> lstRetorno = new List<Colaborador>();

            while (reader.Read())
            {
                Colaborador colaborador = new Colaborador();

                colaborador.idColaborador = reader.GetInt32(0);
                colaborador.nome = reader.GetString(1);
                colaborador.cpf = reader.GetString(2);
                colaborador.idUnidade = reader.GetInt32(3);

                if (i == 1)
                    colaborador.nomeUnidade = reader.GetString(6);

                Usuario usuario = new Usuario();

                usuario.idUsuario = reader.GetInt32(4);
                usuario.Nome = reader.GetString(5);

                colaborador.usuario = usuario;

                lstRetorno.Add(colaborador);

            }

            c.Fechar();

            return lstRetorno;

        }

    }
}
