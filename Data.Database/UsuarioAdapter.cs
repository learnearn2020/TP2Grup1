using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.Email = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.Email = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<Usuario> GetAll()
        {
            //return new List<Usuario>(Usuarios);
            List<Usuario> usuarios = new List<Usuario>();
            this.OpenConnection();
            SqlCommand cmdUsuario = new SqlCommand("Select * from usuarios", SqlConn);
            SqlDataReader drUsuarios = cmdUsuario.ExecuteReader();
            while (drUsuarios.Read())
            {
                Usuario usr = new Usuario();
                usr.ID = (int)drUsuarios["id_usuario"];
                usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                usr.Clave = (string)drUsuarios["clave"];
                usr.Habilitado = (bool)drUsuarios["habilitado"];
                usr.Nombre = (string)drUsuarios["nombre"];
                usr.Apellido = (string)drUsuarios["apellido"];
                usr.Email = (string)drUsuarios["email"];
                usuarios.Add(usr);
            }
            //cerramos el dataReader 
            drUsuarios.Close();
            //cerramos la connexion
            this.CloseConnection();

            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {

            //return Usuarios.Find(delegate(Usuario u) { return u.ID == ID; });
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("select * from usuarios where id_usuario = @id",SqlConn);
                cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuario = cmdUsuario.ExecuteReader();
                if (drUsuario.Read())
                {
                    usr.ID = (int)drUsuario["id_usuario"];
                    usr.NombreUsuario = (string)drUsuario["nombre_usuario"];
                    usr.Clave = (string)drUsuario["clave"];
                    usr.Habilitado = (bool)drUsuario["habilitado"];
                    usr.Nombre = (string)drUsuario["nombre"];
                    usr.Apellido = (string)drUsuario["apellido"];
                    usr.Email = (string)drUsuario["email"];
                    
                }
                drUsuario.Close();
            }
            catch (Exception ex )
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos del usuario", ex); 

                throw ExcepcionManejada ;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr; 
        }

        public void Delete(int ID)
        {
            //Usuarios.Remove(this.GetOne(ID));
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete * from usuarios where id_usuario = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //ejecutamos la sentacia sql 
                cmdDelete.ExecuteNonQuery();

               
               
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el  usuario", ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario) {

            try 
            {

                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email)"+
                    "values (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email)" + 
                    "select @@identity",    //esta lanea es para recuperar el ID que asigna el sql automaticamente 
                    SqlConn);
                cmdSave.Parameters .Add( "@nombre_usuario", SqlDbType. VarChar, 50) . Value = usuario. NombreUsuario;
                cmdSave . Parameters. Add ( "@clave", SqlDbType. VarChar, 50) .Value = usuario. Clave;
                cmdSave . Parameters. Add ("@habilitado", SqlDbType.Bit) .Value = usuario. Habilitado;
                cmdSave. Parameters. Add ( "@nombre", SqlDbType. VarChar, 50) .Value = usuario. Nombre;
                cmdSave. Parameters. Add ("@apellido", SqlDbType.VarChar, 50) .Value = usuario. Apellido;
                cmdSave. Parameters. Add ("@email", SqlDbType.VarChar, 50) .Value = usuario.Email;
                usuario. ID = Decimal.ToInt32( (decimal)cmdSave.ExecuteScalar()); 
                //asi se obtiene el ID que asigna al BD automaticamente
            }
            catch (Exception Ex) {

                Exception Excepcionalejada = new Exception("Error al crear usuario", Ex); throw Excepcionalejada;
            }

            finally {

                this.CloseConnection();
            }

            }
        protected void Update(Usuario usuario)
        {

            try
            {

                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(

  "UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, " +
  "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email " +
  "WHERE id_usuario=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave; 
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido; 
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {

                Exception Excepcionalejada = new Exception("Error al actualizar el usuario", Ex); throw Excepcionalejada;
            }

            finally
            {

                this.CloseConnection();
            }

        }

        public void Save(Usuario usuario)
        {
            //if (usuario.State == BusinessEntity.States.New)
            //{
            //    int NextID = 0;
            //    foreach (Usuario usr in Usuarios)
            //    {
            //        if (usr.ID > NextID)
            //        {
            //            NextID = usr.ID;
            //        }
            //    }
            //    usuario.ID = NextID + 1;
            //    Usuarios.Add(usuario);
            //}
            //else if (usuario.State == BusinessEntity.States.Delete)
            //{
            //    this.Delete(usuario.ID);
            //}
            //else if (usuario.State == BusinessEntity.States.Modified)
            //{
            //    Usuarios[Usuarios.FindIndex(delegate(Usuario u) { return u.ID == usuario.ID; })]=usuario;
            //}
            //usuario.State = BusinessEntity.States.Unmodified;  

            if(usuario.State == BusinessEntity.States.Delete)
            {
                this.Delete(usuario.ID);

            }else if( usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);

            }else if( usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified; 

        }
    }
}
