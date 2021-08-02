using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALUS.REGCOVID.Common.BE
{
    public class Precio
    {
        public int id { get; set; }
        public string organizationId { get; set; }
        public string Empresa { get; set; }
        public string locationId { get; set; }
        public string sede { get; set; }
        public string tipoPrueba { get; set; }
        public string Prueba { get; set; }
        public int lugarTomaID { get; set; }
        public string lugarToma { get; set; }
        public decimal precio { get; set; }
        public bool isDeleted { get; set; }
        public int insertUser { get; set; }
        public DateTime insertDate { get; set; }
        public int updateUser { get; set; }
        public DateTime updateDate { get; set; }
        public int deleteUser { get; set; }
        public DateTime deleteDate { get; set; }
    }
}
