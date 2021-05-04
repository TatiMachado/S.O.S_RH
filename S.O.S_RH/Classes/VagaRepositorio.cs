using S.O.S_RH.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace S.O.S_RH.Classes
{
    public class VagaRepositorio : IRepositorio<Vaga>
    {
        private List<Vaga> listaVagas = new List<Vaga>();

        public void Atualiza(int id, Vaga vaga)
        {
            listaVagas[id] = vaga;
        }

        public void Insere(Vaga vaga)
        {
            listaVagas.Add(vaga);
        }

        public List<Vaga> ListarTodasVagas()
        {
            return listaVagas;
        }

        public int ProximoId()
        {
            return listaVagas.Count;
        }

        public Vaga RetornaVagaPorId(int id)
        {
            Vaga v = listaVagas.Find(v => v.Id == id);
            return v;
        }

        public List<Vaga> ListarVagasPorCandidato(string cpf)
        {
            return listaVagas.FindAll(v => v.Candidato.CPF == cpf);
        }

        public List<Vaga> ListarVagasPorEmpresa(string cnpj)
        {
            return listaVagas.FindAll(v => v.Empresa.CNPJ == cnpj);
        }
    }
}
