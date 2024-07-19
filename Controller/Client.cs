using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static HttpResponseMessage response = new HttpResponseMessage();

        //-------------------------------------------------------------------
        //Usuario
        //-------------------------------------------------------------------
        static void MostraUsuario(Usuario usuario)
        {
            Console.WriteLine($"id: {usuario.Id}\tnome: {usuario.Nome}");
        }
        static async Task<Usuario> GetUsuario(string path)
        {
            Usuario usuario = null;
            response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                usuario = await response.Content.ReadAsAsync<Usuario>();
            }
            return usuario;
        }
        static async Task<List<Usuario>> GetUsuarios(string path)
        {
            List<Usuario> usuarios = new List<Usuario>();
            response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                usuarios = await response.Content.ReadAsAsync<List<Usuario>>();
            }
            return usuarios;
        }
        static async Task<Uri> PostUsuario(Usuario usuario)
        {
            response = await client.PostAsJsonAsync("api/usuario", usuario);
            response.EnsureSuccessStatusCode();

            //Retorna URI criado
            return response.Headers.Location;
        }
        static async Task<Usuario> PutUsuario(Usuario usuario)
        {
            response = await client.PutAsJsonAsync($"api/usuario/{usuario.Id}", usuario);
            response.EnsureSuccessStatusCode();

            //Deserializa objeto
            usuario = await response.Content.ReadAsAsync<Usuario>();
            return usuario;
        }
        static async Task<HttpStatusCode> DeleteUsuario(int id)
        {
            response = await client.DeleteAsync($"api/usuario/{id}");
            return response.StatusCode;
        }
        //-------------------------------------------------------------------
        //Produto
        //-------------------------------------------------------------------
        static void MostraProduto(Produto produto)
        {
            Console.WriteLine($"id: {produto.Id}\tnome: {produto.Nome}\tcategoria: {produto.Categoria}");
        }
        static async Task<Produto> GetProduto(string path)
        {
            Produto produto = null;
            response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                produto = await response.Content.ReadAsAsync<Produto>();
            }
            return produto;
        }
        static async Task<List<Produto>> GetProdutos(string path)
        {
            List<Produto> produtos = new List<Produto>();
            response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                produtos = await response.Content.ReadAsAsync<List<Produto>>();
            }
            return produtos;
        }
        //-------------------------------------------------------------------        

        static void Main()
        {
            ExecucaoAssincrona().GetAwaiter().GetResult();
        }

        static async Task ExecucaoAssincrona()
        {
            try
            {
                string jsonString;
                string arquivo = "Arquivo.json";
                string entrada = "";

                //Cadastros de usuarios aleatorios            
                string[] login = { "Carolina", "Natacha", "Eli", "Silvestre", "Isabelly", "Luci" };
                string[] nome = { "Carolina Adelia da Silva Soares", "Natacha Resende", "Elielthon Pereira de Araujo", "Silvestre Nunes de Jesus Silva", "Isabelly Santos Assunção", "Lucilene Beltrão Castro" };
                string[] cpfCnpj = { "08930229697", "05092615664", "05471641655", "02064837671", "06740401632", "85844560663" };
                string[] email = { "carolina@gmail.com", "nat@gmail.com", "eli@gmail.com", "princess@gmail.com", "isa@gmail.com", "luci@gmail.com" };
                string[] token = { "4gs6d4g6fsd", "16as1f9af", "41v9r4a", "87e9sa7f9sa7", "321da3d46", "j9k8g4hjn6." };
                string[] senha = { "71nr6ad17r", "574m156e54", "i.g61i749", "9y871sr", "6c52.v", ".et8mam8s" };
                string[] cnpj = { "20516886000138", "21347679000160", "18781070000190", "09166603000132", "23441261000142", "21161690000130" };
                string[] razaoSocial = { "SAAE DE CORREGO FUNDO", "SAAE DE GUANHAES", "CAMARA PASSOS", "CISAB SUL - BOA ESPERANCA", "CISAB VICOSA", "DEMSUR MURIAE" };

                //Sorteia index aleatorio
                Random random = new Random();
                int index = random.Next(login.Length);

                //Conexao Localhost
                client.BaseAddress = new Uri("http://localhost:64195/");
                //Conexao Web
                //cliente.BaseAddress = new Uri("https://pncp.gov.br/api/pncp/v1/usuarios/");
                //Declara headers json
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Cria um novo usuario
                Console.WriteLine("Criando usuario...");
                Usuario usuario = new Usuario(1, login[index], nome[index], cpfCnpj[index], email[index], true, token[index], senha[index],
                    new EntesAutorizados[] { new EntesAutorizados(1, cnpj[index], razaoSocial[index]) });

                //Salva usuario
                Console.WriteLine("Salvando usuario...");
                var url = await PostUsuario(usuario);
                Console.WriteLine($"{url}");

                //Pega o usuario
                usuario = await GetUsuario(url.PathAndQuery);
                MostraUsuario(usuario);
                Console.WriteLine("Usuario salvo...\n");

                //Atualiza usuario
                //Console.WriteLine("Atualizando usuario...");
                //usuario.Nome = "João da Silva Santos";
                //await PutUsuario(usuario);

                //Busca usuario atualizado
                //Console.WriteLine("Buscando usuario...");
                //usuario = await GetUsuario(url.PathAndQuery);
                //MostraUsuario(usuario);

                //Deleta usuario
                //Console.WriteLine("Deletando usuario...");
                //var statusCode = await DeleteUsuario(usuario.Id);
                //Console.WriteLine($"Deletado (HTTP Status = {(int)statusCode})");

                //Lista todos usuarios                
                Console.WriteLine("Lista de usuários: ");
                List<Usuario> usuarios = await GetUsuarios("/api/usuario/");
                foreach (var item in usuarios)
                {
                    MostraUsuario(item);
                }
                Console.WriteLine("\n");

                //Lista todos produtos                
                Console.WriteLine("Lista de produtos: ");
                List<Produto> produtos = await GetProdutos("/api/produto/");
                foreach (var item in produtos)
                {
                    MostraProduto(item);
                }
                Console.WriteLine("\n");

                //Busca usuario especifico
                Console.Write("Selecione o id de um usuário ou 'x' para abortar: ");
                while (entrada != "x")
                {
                    entrada = Console.ReadLine();
                    if (entrada != "x")
                    {
                        int idUsuario = Convert.ToInt32(entrada);
                        usuario = await GetUsuario("/api/usuario/" + idUsuario);
                        MostraUsuario(usuario);
                        //Salva em arquivo                
                        jsonString = JsonConvert.SerializeObject(usuario);
                        File.AppendAllText(arquivo, jsonString);
                    }
                }

                //Mostra arquivo JSON completo
                Console.WriteLine(File.ReadAllText(arquivo));
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" +
                    response.ToString() + "\n" +
                    response.Headers.Location);
            }

            Console.WriteLine("Pressione 'ENTER' para encerrar...");
            Console.ReadLine();
        }
    }
}