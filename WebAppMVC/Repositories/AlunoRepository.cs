using WebAppMVC.ViewModels;

namespace WebAppMVC.Repositories
{
    public static class AlunoRepository
    {
        private static List<AlunoViewModel> alunosList = new List<AlunoViewModel>();

        public static List<AlunoViewModel> GetAll()
        {
            return alunosList;
        }

        public static AlunoViewModel GetById(int id)
        {
            AlunoViewModel? retorno = null;

            if (id != 0)
            {
                retorno = alunosList.FirstOrDefault(p => p.Id == id);
            }

            if (retorno == null) retorno = new AlunoViewModel();

            return retorno;
        }

        public static List<AlunoViewModel> GetBySearch(string searchString)
        {
            List<AlunoViewModel>? retorno = null;

            if (!String.IsNullOrEmpty(searchString))
            {
                retorno = alunosList.Where(p => p.Nome.Contains(searchString)).ToList();
            }

            if (retorno == null) retorno = new List<AlunoViewModel>();

            return retorno;
        }

        public static void Create(AlunoViewModel aluno)
        {
            alunosList.Add(aluno);
        }

        public static void Update(AlunoViewModel aluno)
        {
            AlunoViewModel? retorno = null;

            if (aluno.Id != 0)
            {
                retorno = alunosList.FirstOrDefault(p => p.Id == aluno.Id);

                if (retorno != null)
                {
                    retorno.Nome = aluno.Nome;
                    retorno.SobreNome = aluno.SobreNome;
                    retorno.DataNascimento = aluno.DataNascimento;
                }
            }
        }

        public static void Delete(int id)
        {
            AlunoViewModel? retorno = null;

            if (id != 0) retorno = alunosList.FirstOrDefault(p => p.Id == id);
            if (retorno != null) alunosList.Remove(retorno);
        }
    }
}
