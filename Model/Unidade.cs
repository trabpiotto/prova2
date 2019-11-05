using System;

namespace Model
{
    [Serializable]
    public class Unidade
    {

        public int idUnidade { get; set; }
        public String nome { get; set; }
        public String estado { get; set; }
        public Usuario usuario { get; set; }

    }
}
