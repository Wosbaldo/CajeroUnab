using Cajeroo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cajeroo.DAO
{
    public class CrudUsuario
    {
       
        public void AgregarUsuario(Usuario ParametroUsuario, int numCuenta)
        {
            using (BancoContext db = new BancoContext())
            {
                Usuario usuario = new Usuario();
                usuario.IdPassword = ParametroUsuario.IdPassword;
                usuario.Nombre = ParametroUsuario.Nombre;
                usuario.Apellido = ParametroUsuario.Apellido;
                db.Add(usuario);
                db.SaveChanges();
                agregarCuenta(ParametroUsuario, numCuenta);
            }
        }
        public void agregarCuenta(Usuario ParametroUsuario, int numCuenta)
        {
            using (BancoContext db = new BancoContext())
            {
                Cuenta cuenta = new Cuenta();
                
                cuenta.IdPassword = ParametroUsuario.IdPassword;
                cuenta.NumCuenta = numCuenta;
                cuenta.Saldo = 5000;
                db.Add(cuenta);
                db.SaveChanges();

            }
        }
        public int numAleatorio()
        {
            Random random = new Random();
            var numeros = "1234567890";
            var codigoCuenta = new string(Enumerable.Repeat(numeros, 9).Select(x => x[random.Next(x.Length)]).ToArray());
            return Convert.ToInt32(codigoCuenta);
        }

        public int accseo(Cuenta ParametroCuenta)
        {
            using (BancoContext db = new BancoContext())
            {
                var buscar = db.Cuentas.ToList();
                foreach (var item in buscar) {
                    if (ParametroCuenta.IdPassword == item.IdPassword && ParametroCuenta.NumCuenta == item.NumCuenta){

                        return item.IdPassword;
                    }

                }
                

            }
            return 0;

        }
        public double verMonto(int IdPassword)
        {
            using (BancoContext db = new BancoContext())
            {
                var buscar = db.Cuentas.FirstOrDefault(x => x.IdPassword == IdPassword);
                if(buscar != null)
                {
                    return Convert.ToDouble(buscar.Saldo);
                }

            }
            return 0.0;
        }
        public void deposito(Cuenta ParametroCuenta)
        {
            using (BancoContext db = new BancoContext())
            {
                var buscar2 = db.Cuentas.FirstOrDefault(x => x.IdPassword == ParametroCuenta.IdPassword);
                if (buscar2 != null)
                {
                    buscar2.Saldo = buscar2.Saldo + ParametroCuenta.Saldo;
                    db.Update(buscar2);
                    db.SaveChanges();
                    Console.WriteLine("Deposito realizado correctamente");
                }
            }
        }
        public void retirar(Cuenta ParametroCuenta)
        {
            using (BancoContext db = new BancoContext())
            {
                var buscar2 = db.Cuentas.FirstOrDefault(x => x.IdPassword == ParametroCuenta.IdPassword);
                if (buscar2 != null)
                {
                    buscar2.Saldo = buscar2.Saldo - ParametroCuenta.Saldo;
                    db.Update(buscar2);
                    db.SaveChanges();
                    Console.WriteLine("Monto retirado correctamente");
                }
            }
        }
    }
}
