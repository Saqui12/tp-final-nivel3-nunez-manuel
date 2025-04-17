using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NegocioUsuario
    {

        public int insertarUsuario(Usuario nuevo)
        {
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearProcedimiento("insertarNuevo");
				datos.setearParametro("@email", nuevo.Email);
				datos.setearParametro("@pass", nuevo.Pass);
				return datos.ejecutarAccionScalar();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }

		public bool Login(Usuario user)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsulta("Select id, email, pass, admin, urlimagenPerfil, nombre, apellido from USERS Where email = @email And pass = @pass");
				datos.setearParametro("@email",user.Email);
				datos.setearParametro("@pass",user.Pass);
				datos.ejecutarLectura();
				if (datos.Lector.Read())
				{
					user.Id = (int)datos.Lector["id"];
					user.Admin = (bool)datos.Lector["admin"];
					return true;
				}

				return false;
			}
			catch (Exception ex)
			{

				throw ex ;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
        public bool ExisteEmail(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select id, email, pass, admin, urlimagenPerfil, nombre, apellido from USERS Where email = @email ");
                datos.setearParametro("@email", user.Email);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["id"];
                    user.Admin = (bool)datos.Lector["admin"];
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void actualizar(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set UrlImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido Where Id = @id");
                datos.setearParametro("@imagen", (object)user.ImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@id", user.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void actualizarPass(Usuario user, string pass)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set Pass=@Pass where Id = @Id ");
                datos.setearParametro("@Id", user.Id);
                datos.setearParametro("@Pass", pass);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public object listar(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select UrlImagenPerfil,Nombre,Apellido,Id,admin from USERS where email = @email And pass = @pass");
                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@pass", user.Pass);
                datos.ejecutarLectura();
                Usuario aux = new Usuario();

                while (datos.Lector.Read()) {
                    if(!(datos.Lector["UrlImagenPerfil"] is DBNull))
                     aux.ImagenPerfil = (string)datos.Lector["UrlImagenPerfil"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Admin = (bool)datos.Lector["admin"];
                }

                aux.Email = user.Email;
                aux.Pass = user.Pass;
                return aux;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
