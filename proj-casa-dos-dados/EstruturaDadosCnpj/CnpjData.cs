using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;

namespace proj_casa_dos_dados.EstruturaDadosCnpj
{
    public class CnpjData
    {
        public string cnpj { get; set; }
        public string cnpj_raiz { get; set; }
        public int filial_numero { get; set; }
        public string razao_social { get; set; }
        public string nome_fantasia { get; set; }
        public DateTime data_abertura { get; set; }
        public string situacao_cadastral { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string municipio { get; set; }
        public string uf { get; set; }
        public CnpjDataAtividadePrincipal atividade_principal { get; set; }
        public bool cnpj_mei { get; set; }
        public string versao { get; set; }
    }
}
