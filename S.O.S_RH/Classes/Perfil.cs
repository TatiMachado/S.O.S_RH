using S.O.S_RH;
using System;
using System.Collections.Generic;
using System.Text;

namespace S.O.S_RH.Classes
{
    public abstract class Perfil
    {
        public int Id { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Perfil(int id, string endereco, int numero, string bairro, string complemento, string cidade, string estado, string cEP, string email, string telefone)
        {
            Id = id;
            Endereco = endereco;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
            Email = email;
            Telefone = telefone;
        }

        Perfil()
        {
        }
    }
}
