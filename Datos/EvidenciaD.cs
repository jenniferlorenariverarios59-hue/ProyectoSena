using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ProyectoSena.Datos
{
    public class EvidenciaD
    {

        public List<Evidencia> MtObtenerEvidencia()
        {
            List<Evidencia> listarEvidencia = new List<Evidencia>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {

                cn.Open();

                string consulta = $@"Select * from Evidencia e inner join Aprendiz a on e.IdAprendiz = a.Id Where e.IdAprendiz = a.Id";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {

                    cmd.CommandType = CommandType.Text;

                    DataTable cd = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(cd);


                    foreach (DataRow item in cd.Rows) 
                    {
                        Evidencia oEvidencia = new Evidencia();
                        oEvidencia.Id = Convert.ToInt32(item["Id"]);

                        listarEvidencia.Add(oEvidencia);
                    }

                }



            }

            return listarEvidencia;


        }
        public int MtRegistrarEvidencia(Evidencia oEvidencia )
        {
            int Verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn .Open();

                string consulta = $@"Sp_RegistrarEvidencia";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd .CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Archivo", oEvidencia.Archivo);
                    Verificacion = cmd.ExecuteNonQuery();
                }


            }return Verificacion;
        }
    }
}