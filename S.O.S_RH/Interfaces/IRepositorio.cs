using System;
using System.Collections.Generic;
using System.Text;

namespace S.O.S_RH.Interfaces
{
    public interface IRepositorio<T>
    {
        void Insere(T entidade);
        void Atualiza(int id, T entidade);
        int ProximoId();
        T RetornaVagaPorId(int id);
        List<T> ListarVagasPorCandidato(string cpf);
        List<T> ListarVagasPorEmpresa(string cnpj);
        List<T> ListarTodasVagas();
    }
}
