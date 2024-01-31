using System;

namespace Client
{
    public class Orgao
    {
        Orgao() { }

        public Orgao(string cnpj, string razaoSocial, string poderId, string esferaId)
        {
            Cnpj = cnpj ?? throw new ArgumentNullException(nameof(cnpj));
            RazaoSocial = razaoSocial ?? throw new ArgumentNullException(nameof(razaoSocial));
            PoderId = poderId ?? throw new ArgumentNullException(nameof(poderId));
            EsferaId = esferaId ?? throw new ArgumentNullException(nameof(esferaId));
        }

        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string PoderId { get; set; }
        public string EsferaId { get; set; }
    }
}