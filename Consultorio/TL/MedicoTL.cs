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
    public class MedicoTL
    {
        //OBTENER EL USUARIO QUE INTENTA LOGUEARSE EN CASO DE EXISTIR
        internal static Medico getLogin(Medico model)
        {
            Medico med = new Medico();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionsql"].ConnectionString))
                {
                    conn.Open();
                    using (var conm = conn.CreateCommand())
                    {
                        conm.CommandText = "getLogin";
                        conm.Parameters.AddWithValue("@prEmail", model.EMAIL);
                        conm.Parameters.AddWithValue("@prClave", model.PASSWORD);
                        conm.CommandType = System.Data.CommandType.StoredProcedure;
                        using (var reader = conm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                med.IDMEDICO = Convert.ToInt32(reader["ID"]);
                                med.EMAIL = reader["email"].ToString();
                                med.NOMBRE = reader["nombre"].ToString();
                                med.APPATERNO = reader["apPaterno"].ToString();
                                med.APMATERNO = reader["apMaterno"].ToString();
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return med;
        }

        // OBTENER LAS CITAS REGISTRADAS
        internal static List<Cita> getCitas()
        {
            List<Cita> cita = new List<Cita>();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionsql"].ConnectionString))
                {
                    conn.Open();
                    using (var conm = conn.CreateCommand())
                    {
                        conm.CommandText = "getCita";
                        conm.CommandType = System.Data.CommandType.StoredProcedure;
                        using (var reader = conm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cita.Add(new Cita()
                                {
                                    IDCITA = Convert.ToInt32(reader["ID"]),
                                    MEDICO = reader["medico"].ToString(),
                                    PACIENTE = reader["paciente"].ToString(),
                                    DIACITA = reader["diaCita"].ToString(),
                                    HORACITA = reader["horaCita"].ToString().Substring(0, 5),
                                    ESTUDIOS = reader["estudios"].ToString() is "1" ? "Si" : "No",
                                    OBSERVACIONES = reader["observaciones"].ToString(),
                                    EXPEDIENTE = reader["expediente"].ToString()

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
            return cita;
        }

        // INSERTAR UNA CITA
        internal static int IUDCita(Cita model)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionsql"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("IUDCita", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@prMedico", model.MEDICO);
                    command.Parameters.AddWithValue("@prPaciente", model.PACIENTE);
                    command.Parameters.AddWithValue("@prDiaCita", model.DIACITA);
                    command.Parameters.AddWithValue("@prHoraCita", model.HORACITA);
                    command.Parameters.AddWithValue("@prExpediente", model.EXPEDIENTE);
                    command.Parameters.AddWithValue("@prEstudios", model.ESTUDIOS);
                    command.Parameters.AddWithValue("@prObservaciones", model.OBSERVACIONES);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        // INSERTAR MEDICO
        internal static int IUDMedico(Medico model)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionsql"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("IUDMedico", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter("@Res", SqlDbType.Int);
                    paramId.Direction = ParameterDirection.Output;
                    command.Parameters.Add(paramId);

                    command.Parameters.AddWithValue("@prEmail", model.EMAIL);
                    command.Parameters.AddWithValue("@prClave", model.PASSWORD);
                    command.Parameters.AddWithValue("@prNombre", model.NOMBRE);
                    command.Parameters.AddWithValue("@prApPaterno", model.APPATERNO);
                    command.Parameters.AddWithValue("@prApMaterno", model.APMATERNO);

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

        // OBTENER LISTADO DE ID Y NOMBRE DE MEDICOS
        internal static List<SelectListItem> getMedico()
        {
            List<SelectListItem> paciente = new List<SelectListItem>();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionsql"].ConnectionString))
                {
                    conn.Open();
                    using (var conm = conn.CreateCommand())
                    {
                        conm.CommandText = "getMedico";
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