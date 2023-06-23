namespace RestApi.Models
{
    public class GruposEmp
    {
        public int Grupo_emp_id { get; set; }
        public string Grupo_emp_nombre { get; set; }

        public GruposEmp()
        {
            Grupo_emp_id = 0;
            Grupo_emp_nombre = string.Empty;
        }

        public GruposEmp(int grupo_emp_id, string grupo_emp_nombre)
        {
            Grupo_emp_id = grupo_emp_id;
            Grupo_emp_nombre = grupo_emp_nombre;
        }
    }
}
