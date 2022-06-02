using Consultorio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consultorio.TL
{
    public class PacienteTL
    {
        // INSERTAR PACIENTE
        internal static int IUDPaciente(Paciente model)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionsql"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("IUDPaciente", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter("@Res", SqlDbType.Int);
                    paramId.Direction = ParameterDirection.Output;
                    command.Parameters.Add(paramId);

                    command.Parameters.AddWithValue("@prNombre", model.NOMBRE);
                    command.Parameters.AddWithValue("@prApPaterno", model.APPATERNO);
                    command.Parameters.AddWithValue("@prApMaterno", model.APMATERNO);
                    command.Parameters.AddWithValue("@prFechaNacimiento", model.FECHANAC);
                    command.Parameters.AddWithValue("@prLocalidad", model.LOCALIDAD);
                    command.Parameters.AddWithValue("@prTelefono", model.TELEFONO);
                    command.Parameters.AddWithValue("@prEmail", model.EMAIL);
                    command.Parameters.AddWithValue("@prMedio", model.MEDIO);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Convert.ToInt32(command.Parameters["@Res"].Value);
                    }
                    else
                        return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        // OBTENER PACIENTE
        internal static List<Paciente> getPacientes()
        {
            List<Paciente> pac = new List<Paciente>();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionsql"].ConnectionString))
                {
                    conn.Open();
                    using (var conm = conn.CreateCommand())
                    {
                        conm.CommandText = "getPacientes";
                        conm.CommandType = System.Data.CommandType.StoredProcedure;
                        using (var reader = conm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pac.Add(new Paciente()
                                {
                                    IDPACIENTE = reader["ID"].ToString(),
                                    NOMBRE = reader["nombre"].ToString(),
                                    APPATERNO = reader["apPaterno"].ToString(),
                                    APMATERNO = reader["apMaterno"].ToString(),
                                    FECHANAC = reader["fechaNacimiento"].ToString().Substring(0,10),
                                    LOCALIDAD = reader["localidad"].ToString(),
                                    TELEFONO = reader["telefono"].ToString(),
                                    EMAIL = reader["email"].ToString(),
                                    MEDIO = reader["medio"].ToString(),
                                    EDAD = Convert.ToInt32(reader["edad"].ToString())
                                });
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return pac;
        }

        // OBTENER LISTADO DE ID Y NOMBRE DE LOS PACIENTES
        internal static List<SelectListItem> getPaciente()
        {
            List<SelectListItem> paciente = new List<SelectListItem>();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionsql"].ConnectionString))
                {
                    conn.Open();
                    using (var conm = conn.CreateCommand())
                    {
                        conm.CommandText = "getPaciente";
                        conm.CommandType = System.Data.CommandType.StoredProcedure;
                        using (var reader = conm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                paciente.Add(new SelectListItem { Text = reader["NOMBRE"].ToString(), Value = reader["ID"].ToString() });
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return paciente;
        }
    }
}