using System;

namespace Client
{
    public class Ata
    {
        Ata() { }

        public Ata(string numeroAtaRegistroPreco, int anoAta, DateTime dataAssinatura, DateTime dataVigenciaInicio, DateTime dataVigenciaFim)
        {
            NumeroAtaRegistroPreco = numeroAtaRegistroPreco ?? throw new ArgumentNullException(nameof(numeroAtaRegistroPreco));
            AnoAta = anoAta;
            DataAssinatura = dataAssinatura;
            DataVigenciaInicio = dataVigenciaInicio;
            DataVigenciaFim = dataVigenciaFim;
        }

        public string NumeroAtaRegistroPreco { get; set; }
        public int AnoAta { get; set; }
        public DateTime DataAssinatura { get; set; }
        public DateTime DataVigenciaInicio { get; set; }
        public DateTime DataVigenciaFim { get; set; }
    }
}