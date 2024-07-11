using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client
{
    class Program
    {
        static HttpClient cliente = new HttpClient();
        static HttpResponseMessage response = new HttpResponseMessage();

        //Mostra usuario em tela
        static void MostraUsuario(Usuario usuario)
        {
            Console.WriteLine($"id: {usuario.Id}\tnome: {usuario.Nome}");
        }

        static async Task<Usuario> Get(string path)
        {
            Usuario usuario = null;
            response = await cliente.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                usuario = await response.Content.ReadAsAsync<Usuario>();
            }
            return usuario;
        }
        static async Task<Uri> Post(Usuario usuario)
        {
            response = await cliente.PostAsJsonAsync("api/usuario", usuario);
            response.EnsureSuccessStatusCode();

            //Retorna URI criado
            return response.Headers.Location;
        }

        static async Task<Usuario> Put(Usuario usuario)
        {
            response = await cliente.PutAsJsonAsync($"api/usuario/{usuario.Id}", usuario);
            response.EnsureSuccessStatusCode();

            //Deserializa objeto
            usuario = await response.Content.ReadAsAsync<Usuario>();
            return usuario;
        }

        static async Task<HttpStatusCode> Delete(int id)
        {
            response = await cliente.DeleteAsync($"api/usuario/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            ExecucaoAssincrona().GetAwaiter().GetResult();
        }

        static async Task ExecucaoAssincrona()
        {
            string jsonString;
            string arquivo = "Arquivo.json";
            string entrada = "";

            //Gera cadastros aleatorios
            Random random = new Random();
            string[] login = { "Carolina", "Natacha", "Eli", "Silvestre", "Isabelly", "Luci" };
            string[] nome = { "Carolina Adelia da Silva Soares", "Natacha Resende", "Elielthon Pereira de Araujo", "Silvestre Nunes de Jesus Silva", "Isabelly Santos Assunção", "Lucilene Beltrão Castro" };
            string[] cpfCnpj = { "08930229697", "05092615664", "05471641655", "02064837671", "06740401632", "85844560663" };
            string[] email = { "carolina@gmail.com", "nat@gmail.com", "eli@gmail.com", "princess@gmail.com", "isa@gmail.com", "luci@gmail.com" };
            string[] token = { "4gs6d4g6fsd", "16as1f9af", "41v9r4a", "87e9sa7f9sa7", "321da3d46", "j9k8g4hjn6." };
            string[] senha = { "71nr6ad17r", "574m156e54", "i.g61i749", "9y871sr", "6c52.v", ".et8mam8s" };
            string[] cnpj = { "20516886000138", "21347679000160", "18781070000190", "09166603000132", "23441261000142", "21161690000130" };
            string[] razaoSocial = { "SAAE DE CORREGO FUNDO", "SAAE DE GUANHAES", "CAMARA PASSOS", "CISAB SUL - BOA ESPERANCA", "CISAB VICOSA", "DEMSUR MURIAE" };

            //Sorteia index
            int index = random.Next(login.Length);

            //Conexao Localhost
            cliente.BaseAddress = new Uri("http://localhost:64195/");
            //Conexao Web
            //cliente.BaseAddress = new Uri("https://pncp.gov.br/api/pncp/v1/usuarios/");

            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                //Cria um novo usuario
                Console.WriteLine("Criando usuario...");
                Usuario usuario = new Usuario(1, login[index], nome[index], cpfCnpj[index], email[index], true, token[index], senha[index],
                    new EntesAutorizados[] { new EntesAutorizados(1, cnpj[index], razaoSocial[index]) });

                //Salva usuario
                Console.WriteLine("Salvando usuario...");
                var url = await Post(usuario);
                Console.WriteLine($"{url}");

                //Pega o usuario
                usuario = await Get(url.PathAndQuery);
                MostraUsuario(usuario);
                Console.WriteLine("Usuario salvo...\n");

                //Atualiza usuario
                //Console.WriteLine("Atualizando usuario...");
                //usuario.Nome = "João da Silva Santos";
                //await Put(usuario);

                //Busca usuario atualizado
                //Console.WriteLine("Pegando usuario...");
                //usuario = await Get(url.PathAndQuery);
                //MostraUsuario(usuario);

                //Deleta usuario
                //Console.WriteLine("Deletando usuario...");
                //var statusCode = await Delete(usuario.Id);
                //Console.WriteLine($"Deletado (HTTP Status = {(int)statusCode})");

                //Lista todos usuarios                
                Console.WriteLine("Lista de usuários: ");
                int ultimoUsuario = usuario.Id;
                for (int i = 1; i <= ultimoUsuario; i++)
                {
                    usuario = await Get("/api/usuario/" + i);
                    MostraUsuario(usuario);
                }

                //Busca determinado usuario                                
                Console.Write("\nSelecione o id de um usuário ou 'x' para abortar: ");
                while (entrada != "x")
                {
                    entrada = Console.ReadLine();
                    if (entrada != "x")
                    {
                        int idUsuario = Convert.ToInt32(entrada);
                        usuario = await Get("/api/usuario/" + idUsuario);
                        MostraUsuario(usuario);
                        //Salva em arquivo                
                        jsonString = JsonConvert.SerializeObject(usuario);
                        File.AppendAllText(arquivo, jsonString);
                    }
                }

                //Mostra arquivo
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