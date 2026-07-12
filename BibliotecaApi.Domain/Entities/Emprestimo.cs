using BibliotecaApi.Domain.Enums;

namespace BibliotecaApi.Domain.Entities
{
    public class Emprestimo
    {
        public Emprestimo(int usuarioId, int livroId)
        {
            UsuarioId = usuarioId;
            LivroId = livroId;
            DataEmprestimo = DateTime.UtcNow;
            DataPrevistaDevolucao = DateTime.UtcNow.AddDays(7);
            Status = StatusEmprestimo.Ativo;
        }

        public int Id { get; private set; }
        public int UsuarioId { get; private set; }
        public int LivroId { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataPrevistaDevolucao { get; private set; }
        public DateTime? DataDevolucaoReal { get; private set; }
        public StatusEmprestimo Status { get; private set; }

        public void Devolver()
        {
            if (Status == StatusEmprestimo.Devolvido)
                throw new InvalidOperationException("Este empréstimo já foi devolvido.");

            DataDevolucaoReal = DateTime.UtcNow;
            Status = StatusEmprestimo.Devolvido;
        }

        public void VerificarAtraso()
        {
            if (Status != StatusEmprestimo.Ativo)
                return;

            if (DateTime.UtcNow > DataPrevistaDevolucao)
            {
                Status = StatusEmprestimo.Atrasado;
            }
        }
    }
}