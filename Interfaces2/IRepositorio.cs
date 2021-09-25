using System.Collections.Generic;

namespace cadastro.Interface2
{
    public interface IRepositorio<T>
    {
         List<T> Lista();

         T RetornaPorId(int id);
         void Insere(T entidade);
         void Excluir(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}