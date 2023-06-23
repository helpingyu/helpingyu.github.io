namespace RestApi.Models
{
    public class Clientes
    {
        public int Opcion { get; set; }
        public string CliNombre { get; set; }
        public int CliCedula { get; set; }
        public string CliCorreo { get; set; }

        public Clientes(int opcion, string nombre, int cedula, string correo) {
            Opcion = opcion;
            CliNombre = nombre;
            CliCedula = cedula;
            CliCorreo = correo;
        }
        public Clientes() {
            Opcion = 0;
            CliNombre = "";
            CliCedula = 0;
            CliCorreo = "";
        }

    }
}
