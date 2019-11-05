using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class UnidadeController
    {

        public void Incluir(Unidade objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome da unidade.");
            }

            if (String.IsNullOrEmpty(objEntrada.estado))
            {
                throw new ConsistenciaException("Por favor, informe o estado da unidade.");
            }

            MySqlCommand cmd = new MySqlCommand(@"insert into Unidade values(
                 default,
                 @Nome,
                 @Estado,
                 @idUsuario)");



            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.nome));
            cmd.Parameters.Add(new MySqlParameter("Estado", objEntrada.estado));
            cmd.Parameters.Add(new MySqlParameter("idUsuario", objEntrada.usuario.idUsuario));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Atualizar(Unidade objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.nome))
            {
                throw new ConsistenciaException("Por favor, digite o nome da unidade.");
            }

            if (String.IsNullOrEmpty(objEntrada.estado))
            {
                throw new ConsistenciaException("Por favor, informe o estado da unidade.");
            }

            MySqlCommand cmd = new MySqlCommand(@"update Unidade
                 set Nome = @Nome,
                     Estado = @Estado,
                     idUsuario = @idUsuario
               where idUnidade = @idUnidade
             ");

            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.nome));
            cmd.Parameters.Add(new MySqlParameter("Estado", objEntrada.estado));
            cmd.Parameters.Add(new MySqlParameter("idUsuario", objEntrada.usuario.idUsuario));
            cmd.Parameters.Add(new MySqlParameter("idUnidade", objEntrada.idUnidade));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public void Excluir(Unidade objEntrada)
        {

            MySqlCommand cmd = new MySqlCommand("delete from Unidade where idUnidade = @idUnidade");

            cmd.Parameters.Add(new MySqlParameter("idUnidade", objEntrada.idUnidade));

            Conexao c = new Conexao();
            c.Abrir();
            c.Executar(cmd);
            c.Fechar();

        }

        public List<Unidade> Listar(Unidade objEntrada)
        {

            MySqlCommand cmd = null;

            if (objEntrada.idUnidade != 0)
            {

                cmd = new MySqlCommand(@"
                 select Unidade.idUnidade,
                        Unidade.Nome,
                        Unidade.Estado,
                        Unidade.idUsuario,
                        Usuario.Nome
                   from Unidade
                  inner join Usuario on Usuario.idUsuario = Unidade.idUsuario
                  where Unidade.idUnidade = @Idunidade");

                cmd.Parameters.Add(new MySqlParameter("Idunidade", objEntrada.idUnidade));

            }
            else
            {
                cmd = new MySqlCommand(@"
                 select Unidade.idUnidade,
                        Unidade.Nome,
                        Unidade.Estado,
                        Unidade.idUsuario,
                        Usuario.Nome
                   from Unidade
                  inner join Usuario on Usuario.idUsuario = Unidade.idUsuario");
            }

            Conexao c = new Conexao();

            c.Abrir();

            MySqlDataReader reader = c.Pesquisar(cmd);

            List<Unidade> lstRetorno = new List<Unidade>();

            while (reader.Read())
            {
                Unidade unidade = new Unidade();

                unidade.idUnidade = reader.GetInt32(0);
                unidade.nome = reader.GetString(1);
                unidade.estado = reader.GetString(2);

                Usuario usuario = new Usuario();

                usuario.idUsuario = reader.GetInt32(3);
                usuario.Nome = reader.GetString(4);

                unidade.usuario = usuario;

                lstRetorno.Add(unidade);

            }

            c.Fechar();

            return lstRetorno;

        }

    }
}
