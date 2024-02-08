using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj_casa_dos_dados.EstruturaDadosCnpj
{
    public class CnpjDataResponse
    {
        public List<CnpjData> cnpj { get; set; }
        public int count { get; set; }
    }
}
