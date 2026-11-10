using AdotadosDAL;
using AdotadosDTO;

namespace AdotadosBLL
{
    public class AnimalBLL
    {
        AnimalDAL animalDAL = new AnimalDAL();

        public void CadastrarAnimal(AnimalDTO animal)
        {
            animalDAL.CadastrarAnimal(animal);
        }

        public void EditarAnimal(AnimalDTO animal)
        {
            animalDAL.Editar(animal);
        }

        public void ExcluirAnimal(int id)
        {
            animalDAL.Excluir(id);
        }

        public AnimalDTO SelecionarAnimal(int id)
        {
            return animalDAL.Selecionar(id);
        }

        public List<AnimalDTO> ListarAnimal()
        {
            return animalDAL.Listar();
        }
    }
}
