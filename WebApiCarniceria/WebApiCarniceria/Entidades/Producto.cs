namespace WebApiCarniceria.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }  

        public int TipoProductoId { get; set; }
        public TipoProducto TipoProducto { get; set; }
    }
}
