using System;

namespace Client
{
    public class Contrato
    {
        Contrato() { }

        public Contrato(string cnpjCompra, int anoCompra, int sequencialCompra, int tipoContratoId, string numeroContratoEmpenho, int anoContrato, string processo, int categoriaProcessoId, string niFornecedor, string tipoPessoaFornecedor, string nomeRazaoSocialFornecedor, bool receita, string codigoUnidade, string objetoContrato, decimal valorInicial, int numeroParcelas, decimal valorParcela, decimal valorGlobal, DateTime dataAssinatura, DateTime dataVigenciaInicio, DateTime dataVigenciaFim, decimal valorAcumulado, string niFornecedorSubContratado, string tipoPessoaFornecedorSubContratado, string nomeRazaoSocialFornecedorSubContratado, string informacaoComplementar, string urlCipi, string identificadorCipi)
        {
            CnpjCompra = cnpjCompra ?? throw new ArgumentNullException(nameof(cnpjCompra));
            AnoCompra = anoCompra;
            SequencialCompra = sequencialCompra;
            TipoContratoId = tipoContratoId;
            NumeroContratoEmpenho = numeroContratoEmpenho ?? throw new ArgumentNullException(nameof(numeroContratoEmpenho));
            AnoContrato = anoContrato;
            Processo = processo ?? throw new ArgumentNullException(nameof(processo));
            CategoriaProcessoId = categoriaProcessoId;
            NiFornecedor = niFornecedor ?? throw new ArgumentNullException(nameof(niFornecedor));
            TipoPessoaFornecedor = tipoPessoaFornecedor ?? throw new ArgumentNullException(nameof(tipoPessoaFornecedor));
            NomeRazaoSocialFornecedor = nomeRazaoSocialFornecedor ?? throw new ArgumentNullException(nameof(nomeRazaoSocialFornecedor));
            Receita = receita;
            CodigoUnidade = codigoUnidade ?? throw new ArgumentNullException(nameof(codigoUnidade));
            ObjetoContrato = objetoContrato ?? throw new ArgumentNullException(nameof(objetoContrato));
            ValorInicial = valorInicial;
            NumeroParcelas = numeroParcelas;
            ValorParcela = valorParcela;
            ValorGlobal = valorGlobal;
            DataAssinatura = dataAssinatura;
            DataVigenciaInicio = dataVigenciaInicio;
            DataVigenciaFim = dataVigenciaFim;
            ValorAcumulado = valorAcumulado;
            NiFornecedorSubContratado = niFornecedorSubContratado ?? throw new ArgumentNullException(nameof(niFornecedorSubContratado));
            TipoPessoaFornecedorSubContratado = tipoPessoaFornecedorSubContratado ?? throw new ArgumentNullException(nameof(tipoPessoaFornecedorSubContratado));
            NomeRazaoSocialFornecedorSubContratado = nomeRazaoSocialFornecedorSubContratado ?? throw new ArgumentNullException(nameof(nomeRazaoSocialFornecedorSubContratado));
            InformacaoComplementar = informacaoComplementar ?? throw new ArgumentNullException(nameof(informacaoComplementar));
            UrlCipi = urlCipi ?? throw new ArgumentNullException(nameof(urlCipi));
            IdentificadorCipi = identificadorCipi ?? throw new ArgumentNullException(nameof(identificadorCipi));
        }

        public string CnpjCompra { get; set; }
        public int AnoCompra { get; set; }
        public int SequencialCompra { get; set; }
        public int TipoContratoId { get; set; }
        public string NumeroContratoEmpenho { get; set; }
        public int AnoContrato { get; set; }
        public string Processo { get; set; }
        public int CategoriaProcessoId { get; set; }
        public string NiFornecedor { get; set; }
        public string TipoPessoaFornecedor { get; set; }
        public string NomeRazaoSocialFornecedor { get; set; }
        public bool Receita { get; set; }
        public string CodigoUnidade { get; set; }
        public string ObjetoContrato { get; set; }
        public decimal ValorInicial { get; set; }
        public int NumeroParcelas { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorGlobal { get; set; }
        public DateTime DataAssinatura { get; set; }
        public DateTime DataVigenciaInicio { get; set; }
        public DateTime DataVigenciaFim { get; set; }
        public decimal ValorAcumulado { get; set; }
        public string NiFornecedorSubContratado { get; set; }
        public string TipoPessoaFornecedorSubContratado { get; set; }
        public string NomeRazaoSocialFornecedorSubContratado { get; set; }
        public string InformacaoComplementar { get; set; }
        public string UrlCipi { get; set; }
        public string IdentificadorCipi { get; set; }
    }
}