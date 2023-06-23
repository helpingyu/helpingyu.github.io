namespace RestApi.Models
{
    public class TipoUnidades
    {
        public int Tipou_id { get; set; }
        public string Tipou_nombre { get; set; }

        // En caso de existir, pues también se llamaría al peso
        public int Peso_id { get; set; }

        //En caso de no ser un envase que tenga un peso, podrá tener un peso determinado, por ejemplo es un kilo de algo xdxd  
        public double Cantidad { get; set; }


        public TipoUnidades(int tipou_id, string tipou_nombre, int peso_id, double cantidad)
        {
            Tipou_id = tipou_id;
            Tipou_nombre = tipou_nombre;
            Peso_id = peso_id;
            Cantidad = cantidad;
        }

        public TipoUnidades() { 
            Tipou_id = 0;
            Tipou_nombre = string.Empty;
            Peso_id = 0;
            Cantidad = 0.0;
        }



    }
}
