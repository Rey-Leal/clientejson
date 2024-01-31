using System;

namespace Client
{
    public class Logar
    {
        Logar() { }

        public Logar(string login, string senha)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Senha = senha ?? throw new ArgumentNullException(nameof(senha));
        }

        public string Login { get; set; }
        public string Senha { get; set; }
    }
}