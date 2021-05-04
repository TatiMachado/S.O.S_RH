using S.O.S_RH;
using System;
using System.Collections.Generic;
using System.Text;

namespace S.O.S_RH.Classes
{
    public class Vaga
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Salario { get; set; }
        public StatusVaga StatusVaga { get; set; }
        public Candidato Candidato { get; set; }
        public Empresa Empresa { get; set; }

        public Vaga(int id, string descricao, double salario, StatusVaga statusVaga, Candidato candidato, Empresa empresa)
        {
            Id = id;
            Descricao = descricao;
            Salario = salario;
            StatusVaga = statusVaga;
            Candidato = candidato;
            Empresa = empresa;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "ID..........: " + this.Id + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Salário..: " + this.Salario.ToString("F2") + Environment.NewLine;
            retorno += "Status...: " + this.StatusVaga + Environment.NewLine;
            return retorno;
        }

        public int RetornaId()
        {
            return this.Id;
        }

    }
}
