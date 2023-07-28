using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuarioModelo
    {
        //Atributos do BD
        public int id;
        public string nome;
        public string senha;
        public string email;
        public string telefone;

        //Construtor da Classe
        public UsuarioModelo ()
        {
            nome = null;
            senha = null;
            email = null;
            telefone = null;

        }
    }
}
