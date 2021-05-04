using S.O.S_RH;
using System;
using System.Collections.Generic;
using System.Text;

namespace S.O.S_RH.Classes
{
    public class Empresa : Perfil
    {
        
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }

        //TATI ver p colocar tudo do construtor base
        public Empresa(int id, string endereco, int numero, string bairro, string complemento, string cidade, string estado, string CEP, string email, string telefone, string cnpj, string razaoSocial) :base(id, endereco, numero, bairro, complemento, cidade, estado, CEP, email, telefone)
        {
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "ID..........: " + this.Id + Environment.NewLine;
            retorno += "CNPJ........: " + this.CNPJ + Environment.NewLine;
            retorno += "Razão Social: " + this.RazaoSocial + Environment.NewLine;
            retorno += "Endereco....: " + this.Endereco + Environment.NewLine;
            retorno += "Numero......: " + this.Numero + Environment.NewLine;
            retorno += "Bairro......: " + this.Bairro + Environment.NewLine;
            retorno += "Complemento.: " + this.Complemento + Environment.NewLine;
            retorno += "Cidade......: " + this.Cidade + Environment.NewLine;
            retorno += "Estado......: " + this.Estado + Environment.NewLine;
            retorno += "CEP.........: " + this.CEP + Environment.NewLine;
            retorno += "Email.......: " + this.Email + Environment.NewLine;
            retorno += "Telefone....: " + this.Estado + Environment.NewLine;
            return retorno;
        }
    }
}
