using AlunosApi.Context;
using AlunosApi.Interfaces;
using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly AppDbContext _context;

        public AlunoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aluno>> GetAllAlunos()
        {
            try
            {
                return await _context.Alunos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Aluno>> GetAlunoByNome(string nome)
        {
            IEnumerable<Aluno> alunos;
            if(!string.IsNullOrWhiteSpace(nome))
            {
                alunos = await _context.Alunos
                    .Where(a => a.Nome != null && a.Nome.Contains(nome))
                    .ToListAsync();
            }
            else
            {
                alunos = await GetAllAlunos();
            }
            return alunos;
        }

        public async Task<Aluno?> GetAlunoById(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            return aluno;
        }

        public async Task CreateAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAluno(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
