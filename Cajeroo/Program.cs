using Cajeroo.DAO;
using Cajeroo.Models;

namespace Cajeroo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CrudUsuario crudUsuarios = new CrudUsuario();
            Usuario usuario = new Usuario();
            Cuenta numCuenta = new Cuenta();
            Cuenta cuenta = new Cuenta();
            bool Continuar = true;
            while (Continuar)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("Pulse 1 para Crear una cuenta de ahorros");
                Console.WriteLine("Pulse 2 para Acceder a su cuenta");

                var Menu = Convert.ToInt32(Console.ReadLine());


                switch (Menu)
                {

                    case 1:
                        int bucle = 1;
                        while (bucle == 1)
                        {
                            
                            Console.WriteLine("Cree su password");
                            usuario.IdPassword = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese su nombre ");
                            usuario.Nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese su Apellido ");
                            usuario.Apellido = Console.ReadLine();
                            var codCuenta = crudUsuarios.numAleatorio();
                            crudUsuarios.AgregarUsuario(usuario,codCuenta);
                            
                            Console.WriteLine($"Su numero de cuenta generado es {codCuenta}");
                            Console.WriteLine("Su cuenta de ahorros se creo exitosamente");
                            Console.WriteLine("pulsa 0 para regresar al menu");
                            bucle = Convert.ToInt32(Console.ReadLine());


                        }
                        break;
                    case 2:
                        
                        Console.WriteLine("Ingrese el numero de targeta");
                        cuenta.NumCuenta = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese su password");
                        cuenta.IdPassword = Convert.ToInt32(Console.ReadLine());
                        var cuentaLog = crudUsuarios.accseo(cuenta);
                        if(cuentaLog != 0)
                        {
                            bool Siguiente = true;
                            while (Siguiente)
                            {
                                Console.WriteLine("\nMenu");
                                Console.WriteLine("Pulse 1 para ver su monto");
                                Console.WriteLine("Pulse 2 para hacer un deposito");
                                Console.WriteLine("Pulse 3 para hacer un retiro");
                                var Menu2 = Convert.ToInt32(Console.ReadLine());
                                switch (Menu2)
                                {
                                    case 1:
                                        Console.WriteLine($"El monto de su cuenta es {crudUsuarios.verMonto(cuentaLog)}");
                                        break;
                                    case 2:
                                        Console.WriteLine("Ingrese el monto a depositar");
                                        cuenta.Saldo = Convert.ToDecimal(Console.ReadLine());
                                        crudUsuarios.deposito(cuenta);
                                        break;
                                    case 3:
                                        Console.WriteLine("Ingrese el monto a retirar");
                                        cuenta.Saldo = Convert.ToDecimal(Console.ReadLine());
                                        crudUsuarios.retirar(cuenta);
                                        break;
                                }
                                Console.WriteLine("Ingrese 0 para salir");
                                int salir = Convert.ToInt32(Console.ReadLine());
                                if (salir != 0) { Siguiente = true; } else { Siguiente = false; }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cuenta invalida");
                        }
                        break;
                        

                }
            }
        }

    }
}