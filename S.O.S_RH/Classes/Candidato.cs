using S.O.S_RH;
using System;
using System.Collections.Generic;
using System.Text;

namespace S.O.S_RH.Classes
{
    public class Candidato : Perfil
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        

        //TATIver p colocar tudo do construtor base
        public Candidato(int id, string endereco, int numero, string bairro, string complemento, string cidade, string estado, string CEP, string email, string telefone, string cpf, string nome, DateTime dataNasc) :base(id, endereco, numero, bairro, complemento, cidade, estado, CEP, email, telefone)
        {
            Id = id;
            CPF = cpf;
            Nome = nome;
            DataNasc = dataNasc;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "ID..........: " + this.Id + Environment.NewLine;
            retorno += "CPF.........: " + this.CPF + Environment.NewLine;
            retorno += "Nome........: " + this.Nome + Environment.NewLine;
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
