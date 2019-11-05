using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Colaborador
    {

        public int idColaborador { get; set; }
        public String nome { get; set; }
        public String cpf { get; set; }
        public int idUnidade { get; set; }

        public String nomeUnidade { get; set; }
        public Usuario usuario { get; set; }

    }
}
