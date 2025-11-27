using AlunosApi.Models;

namespace AlunosApi.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAllAlunos();
        Task<Aluno?> GetAlunoById(int id);
        Task<IEnumerable<Aluno>> GetAlunoByNome(string nome);
        Task CreateAluno(Aluno aluno);
        Task UpdateAluno(Aluno aluno);
        Task DeleteAluno(Aluno aluno);
    }
}
