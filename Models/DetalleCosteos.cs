namespace RestApi.Models
{
    public class DetalleCosteos
    {
        public int sysdet_costeos_id { get; set; }
        public int sysdet_syscos_id { get; set; }
        public int sysdet_sysart_id { get; set; }
        public double sysdet_costo_articulo { get; set; }
        public double sysdet_porcion { get; set; }
        public double sysdet_sysart_tipo_unidad_id{ get; set; }
    }
}
