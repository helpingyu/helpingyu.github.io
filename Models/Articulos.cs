using Microsoft.Extensions.Options;

namespace RestApi.Models
{
    public class Articulos
    {
        public int Art_id { get; set; }
        public string Art_nombre { get; set; }
        public int Tipou_id { get; set; }
        public string Art_cabys { get; set; }
        public string Art_codigobarras { get; set; }
        public double Art_precio { get; set; }

        public dynamic Tipou_nombre { get; set; }

        public Articulos() {
            Art_id = 0;
            Art_nombre = string.Empty;
            Tipou_id = 0;
            Art_cabys = string.Empty;
            Art_codigobarras = string.Empty;
            Art_precio = 0.00;
            Tipou_nombre = string.Empty;
        }
        public Articulos(int art_id, string art_nombre, int tipou_id, string art_cabys,
            string art_codigobarras, double art_precio, dynamic tipou_nombre)
        {
            Art_id = art_id;
            Art_nombre = art_nombre;
            Tipou_id = tipou_id;
            Art_cabys = art_cabys;
            Art_codigobarras = art_codigobarras;
            Art_precio = art_precio;  
            Tipou_nombre = tipou_nombre;
        }
    }
}
