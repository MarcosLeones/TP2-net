using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Entities;

namespace UI.Consola
{
    public class Usuarios
    {
        private Business.Logic.UsuarioLogic _UsuarioNegocio;
        public Business.Logic.UsuarioLogic UsuarioNegocio { get; set; }

        public Usuarios()
        {
            UsuarioNegocio = new Business.Logic.UsuarioLogic();
        }

        public void Menu()
        {
            int op = 7;

            while (op != 6)
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1– Listado General\n" +
                    "2– Consulta\n" +
                    "3– Agregar\n" +
                    "4 - Modificar\n" +
                    "5 - Eliminar\n" +
                    "6 - Salir");
                Console.WriteLine("Elija una opción:");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1: ListadoGeneral();
                        break;

                    case 2: Consultar();
                        break;

                    case 3: Agregar();
                        break;
                    
                    case 4: Modificar();
                        break;

                    case 5: Eliminar();
                        break;
                    
                    default:
                        {
                            if (op != 6)
                            {
                                Console.WriteLine("Opción inválida.");
                            }
                        }
                        break;
                }
            }
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero.");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
            
        }

        public void Agregar()
        {
            Usuario usuario = new Usuario();

            Console.Clear();
            Console.WriteLine("Ingrese nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese clave: ");
            usuario.Clave = Console.ReadLine();
            Console.WriteLine("Ingrese e-mail: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese habilitación de usuario (1-SI/Otro-NO): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modifiacr: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.WriteLine("Ingrese nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese clave: ");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese e-mail: ");
                usuario.Email = Console.ReadLine();
                Console.WriteLine("Ingrese habilitación de usuario (1-SI/Otro-NO): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero.");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero.");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
        }
    }
}
