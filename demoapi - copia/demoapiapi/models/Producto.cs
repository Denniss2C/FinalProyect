using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoapi.models
{
    public class Producto
    {//replica las tbalas de la base de datos
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Categoria { get; set; }
        public String Stock { get; set; }
        public float Precio { get; set; }
        public String Descripcion { get; set; }
    }
}
