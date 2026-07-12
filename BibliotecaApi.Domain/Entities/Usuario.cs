namespace BibliotecaApi.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string nome, string cpf, string email, string telefone, DateOnly dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Bloqueado = false;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateOnly DataNascimento { get; private set; }
        public bool Bloqueado { get; private set; }

        public void Bloquear()
        {
            if (Bloqueado)
                throw new InvalidOperationException("O usuário está bloqueado!");
            Bloqueado = true;
        }

        public void Desbloquear()
        {
            if (!Bloqueado)
                throw new InvalidOperationException("O usuário não está bloqueado!");
            Bloqueado = false;
        }
    }
}
