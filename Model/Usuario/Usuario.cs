using System;

namespace Client
{
    public class Usuario
    {
        Usuario() { }

        public Usuario(int id, string login, string nome, string cpfCnpj, string email, bool administrador, string token, string senha, EntesAutorizados[] entesAutorizados)
        {
            this.Id = id;
            this.Login = login ?? throw new ArgumentNullException(nameof(login));
            this.Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.CpfCnpj = cpfCnpj ?? throw new ArgumentNullException(nameof(cpfCnpj));
            this.Email = email ?? throw new ArgumentNullException(nameof(email));
            this.Administrador = administrador;
            this.Token = token ?? throw new ArgumentNullException(nameof(token));
            this.Senha = senha ?? throw new ArgumentNullException(nameof(senha));
            this.EntesAutorizados = entesAutorizados ?? throw new ArgumentNullException(nameof(entesAutorizados));
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public bool Administrador { get; set; }
        public string Token { get; set; }
        public string Senha { get; set; }
        public EntesAutorizados[] EntesAutorizados { get; set; }
    }

    public class EntesAutorizados
    {
        EntesAutorizados() { }

        public EntesAutorizados(int id, string cnpj, string razaoSocial)
        {
            Id = id;
            Cnpj = cnpj ?? throw new ArgumentNullException(nameof(cnpj));
            RazaoSocial = razaoSocial ?? throw new ArgumentNullException(nameof(razaoSocial));
        }

        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
    }
}