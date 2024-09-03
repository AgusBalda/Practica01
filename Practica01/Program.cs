// See https://aka.ms/new-console-template for more information

using Practica01.Domain;
using Practica01.Services;

FacturaManager manager = new FacturaManager();

//Create new product:
var oFactura = new Factura()
{
    Codigo = 0,
    Cliente = "FACTURA DE PRUEBA",
    Fecha = DateTime.Now,
    Activo = true,
    Id_Forma_Pago = 1,
};
if (manager.SaveFacturas(oFactura))
    Console.WriteLine("PRODUCTO CREADO EXISTOSAMENTE!");

//Get all facturas
List<Factura> lista = manager.GetFacturas();
if (lista.Count == 0)
{
    Console.WriteLine("Sin facturas");
}
else
{
    foreach (var oProduct in lista)
    {
        Console.WriteLine(oProduct);
    }
}

//dar de baja factura
if (manager.DeleteFactura(2))
    Console.WriteLine("PRODUCTO ACTUALIZADO CON DATOS DE BAJA!");

//Get all facturas
lista = manager.GetFacturas();
if (lista.Count == 0)
{
    Console.WriteLine("Sin facturas");
}
else
{
    foreach (var oProduct in lista)
    {
        Console.WriteLine(oProduct);
    }
}