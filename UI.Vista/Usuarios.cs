using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Vista
{
    public class Usuarios
    {
        private UsuarioLogic _usuarioNegocio;

        public UsuarioLogic UsuarioNegocio
        {
            get { return _usuarioNegocio; }
            set { _usuarioNegocio = value; }
        }

        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }
        public void Menu()
        {
            string opcion;
            Console.Clear();
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
              

                Console.WriteLine("--------------------------------- Elegir una opcion -------------------------------");
                Console.WriteLine("1– Listado Generalr");
                Console.WriteLine("2– Consulta ");
                Console.WriteLine("3– Agregar");
                Console.WriteLine("4- Modificar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("6- Salir");
              
                Console.ForegroundColor = ConsoleColor.White;
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        this.ListadoGeneral();
                        break;

                    case "2":
                        this.Consultar();
                        break;
                    case "3":
                        this.Agregar();
                        break;
                    case "4":
                        this.Modificar();
                        break;
                    case "5":
                        this.Delete();
                        break;
                    default:
                        break;
                }
            } while (opcion != "6");
           


        }

        private void Delete()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del susario a consular");
                int id = Convert.ToInt32(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(id));
                Console.WriteLine("Seguro quieres borrar el usuario ? 1-si/2-No");
                string confirm = Console.ReadLine();
                if (confirm.Equals("1"))
                {
                 
                    UsuarioNegocio.Delete(id);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Usuario borrado con exito!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
               


                //this.ListadoGeneral();
            }
            catch (FormatException fe)
            {
                Console.WriteLine("La id ingresdada debe ser un numero entero");
                Console.WriteLine(fe.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Precione una tecla para salir!!!");
                Console.ReadLine();
            }
        }

        private void Agregar()
        {
            Console.Clear();
            Usuario usuario = new Usuario();
            Console.Write("Ingresa el nombre : ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingresa el Apellido : ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingresa el Nombre de usuario : ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingresa el Email : ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingresa la Clave : ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingresa habilitación de usuario (1-si/otro-No)  : ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usuario creado con exito!!!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ID usuario nuevo {0}",usuario.ID);
            //this.ListadoGeneral();
        }

        public void ListadoGeneral()
        {
            
            foreach (Usuario usuario in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usuario);
            }
        }

        public void MostrarDatos(Usuario usuario)
        {
            Console.WriteLine("Usuario : {0}", usuario.ID);
            Console.WriteLine("Nombre : {0}", usuario.Nombre);
            Console.WriteLine("Apellido : {0}", usuario.Apellido);
            Console.WriteLine("Email : {0}", usuario.Email);
            Console.WriteLine("Clave : {0}", usuario.Clave);
            Console.WriteLine("Habilitado : {0}", usuario.Habilitado);
            Console.WriteLine("");
           
        }
        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del susario a consular");
                int id = Convert.ToInt32(Console.ReadLine());
                MostrarDatos(UsuarioNegocio.GetOne(id));
            }
            catch (FormatException fe)
            {
                Console.WriteLine("La id ingresdada debe ser un numero entero");
                Console.WriteLine(fe.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Precione una tecla para salir!!!");
                Console.ReadLine();
            }
           
           

        }
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del susario a consular");
                int id = Convert.ToInt32(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(id);
                Console.WriteLine("Datos del usuario actual : ");
                this.MostrarDatos(usuario);
                Console.Write("Ingresa el nombre : ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingresa el Apellido : ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingresa el Nombre de usuario : ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingresa el Email : ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingresa la Clave : ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingresa habilitación de usuario (1-si/otro-No)  : ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Usuario modificado con exito!!!");
                Console.ForegroundColor = ConsoleColor.White;
                //MostrarDatos(usuario);

            }
            catch (FormatException fe)
            {
                Console.WriteLine("La id ingresdada debe ser un numero entero");
                Console.WriteLine(fe.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Precione una tecla para salir!!!");
                Console.ReadLine();
            }
          
        }
    }
}
