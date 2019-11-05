using Model;
using MySql.Data.MySqlClient;
using System;

namespace Controller
{
    public class UsuarioController
    {

        public void Cadastrar(Usuario objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Email))
                throw new ConsistenciaException("Por favor, preencha o campo cpf!");

            if (String.IsNullOrEmpty(objEntrada.Nome))
                throw new ConsistenciaException("Por favor, prencha o campo nome!");

            if (String.IsNullOrEmpty(objEntrada.Descricao))
                throw new ConsistenciaException("Por favor, prencha o campo descricão!");

            if (String.IsNullOrEmpty(objEntrada.Senha))
                throw new ConsistenciaException("Por favor, prencha o campo senha!");

            Conexao conx = new Conexao();

            conx.Abrir();
            MySqlCommand cmd1 = new MySqlCommand("select * from usuario where email = @email");

            cmd1.Parameters.Add(new MySqlParameter("email", objEntrada.Email));

            MySqlDataReader reader = conx.Pesquisar(cmd1);

            if (reader.HasRows)
            {
                throw new ConsistenciaException("E-mail já em uso, tente novamente com outro E-mail");
            }
            conx.Fechar();
            conx.Abrir();
            MySqlCommand cmd = new MySqlCommand(@"
                insert into usuario (nomeUsuario, email, descricao, senha) 
                values (@Nome, @Email, @Descricao, md5(@Senha))");

            

            cmd.Parameters.Add(new MySqlParameter("Nome", objEntrada.Nome));
            cmd.Parameters.Add(new MySqlParameter("Email", objEntrada.Email));
            cmd.Parameters.Add(new MySqlParameter("Descricao", objEntrada.Descricao));
            cmd.Parameters.Add(new MySqlParameter("Senha", objEntrada.Senha));

            conx.Executar(cmd);

            conx.Fechar();
        }

        public Usuario Logar(Usuario objEntrada)
        {

            if (String.IsNullOrEmpty(objEntrada.Email))
                throw new ConsistenciaException("Por favor, preencha o campo Email!");

            if (String.IsNullOrEmpty(objEntrada.Senha))
                throw new ConsistenciaException("Por favor, prencha o campo senha!");

            Conexao conx = new Conexao();

            MySqlCommand cmd = new MySqlCommand(@"
                select idUsuario,
                       nomeUsuario,
                       email,
                       senha,
                       descricao
                  from Usuario
                 where email = @email
                   and Senha = md5(@Senha)");

            conx.Abrir();

            cmd.Parameters.Add(new MySqlParameter("email", objEntrada.Email));
            cmd.Parameters.Add(new MySqlParameter("Senha", objEntrada.Senha));

            MySqlDataReader reader = conx.Pesquisar(cmd);

            if (!reader.Read())
            {
                conx.Fechar();
                throw new ConsistenciaException("Email ou senha inválido!");
            }

            Usuario us = new Usuario();

            us.idUsuario = reader.GetInt32(0);
            us.Nome = reader.GetString(1);
            us.Email = reader.GetString(2);
            us.Senha = reader.GetString(3);
            us.Descricao = reader.GetString(4);


            reader.Close();

            //cmd = new MySqlCommand(@"
            //    select distinct pagina.idPagina,
            //           pagina.url,
	           //        pagina.descricao,
            //           pagina.idPai
            //      from pagina
            //     inner join modulo_pagina on modulo_pagina.idPagina = pagina.idPagina
            //     inner join Modulo on modulo_pagina.idModulo = modulo.idModulo
            //     inner join usuario_modulo on modulo.idModulo = usuario_modulo.idModulo
            //     where usuario_modulo.idUsuario = @IdUsuario");

            //cmd.Parameters.Add(new MySqlParameter("IdUsuario", us.idUsuario));

            //reader = conx.Pesquisar(cmd);

            //while (reader.Read())
            //{

            //    Pagina p = new Pagina();

            //    p.idPagina = reader.GetInt32(0);

            //    if (reader["url"] != DBNull.Value)
            //        p.url = reader.GetString(1);

            //    p.descricao = reader.GetString(2);

            //    if (reader["idPai"] != DBNull.Value)
            //        p.idPai = reader.GetInt32(3);

            //    us.listaPaginaAcesso.Add(p);

            //}

            conx.Fechar();

            return us;

        }



    }
}
