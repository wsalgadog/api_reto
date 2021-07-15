using api_reto.Entitites;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace api_reto.Repository
{
    public class cliente_repository
    {

        string cadena = "Server=dbapintpboe.ck3as5z68fkx.us-east-1.rds.amazonaws.com;Port=3306;Database=bdoeschle;user=admin;password=JusticeX09A;Pooling=false";
        public List<Cliente> SearchById(int id_cliente)
        {
            MySqlConnection conn = new MySqlConnection(cadena);
            List<Cliente> result = new List<Cliente>();

            try
            {
                conn.Open();

                string rtn = "select id, nombres, apellidos, fnacimiento, TIMESTAMPDIFF(YEAR,fnacimiento,CURDATE()) edad from Cliente where id = " + id_cliente;
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var item = new Cliente();
                        if (!reader.IsDBNull(0)) { item.id = Convert.ToInt32(reader[0]); }
                        if (!reader.IsDBNull(1)) { item.nombres = Convert.ToString(reader[1]); }
                        if (!reader.IsDBNull(2)) { item.apellidos = Convert.ToString(reader[2]); }
                        if (!reader.IsDBNull(3)) { item.fnacimiento = Convert.ToDateTime(reader[3]); }
                        if (!reader.IsDBNull(4)) { item.edad = Convert.ToInt32(reader[4]); }
                        result.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public List<Cliente> Search()
        {
            MySqlConnection conn = new MySqlConnection(cadena);
            List<Cliente> result = new List<Cliente>();

            try
            {
                conn.Open();

                string rtn = "select id, nombres, apellidos, fnacimiento, TIMESTAMPDIFF(YEAR,fnacimiento,CURDATE()) edad from Cliente";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var item = new Cliente();
                        if (!reader.IsDBNull(0)) { item.id = Convert.ToInt32(reader[0]); }
                        if (!reader.IsDBNull(1)) { item.nombres = Convert.ToString(reader[1]); }
                        if (!reader.IsDBNull(2)) { item.apellidos = Convert.ToString(reader[2]); }
                        if (!reader.IsDBNull(3)) { item.fnacimiento = Convert.ToDateTime(reader[3]); }
                        if (!reader.IsDBNull(4)) { item.edad = Convert.ToInt32(reader[4]); }
                        result.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public bool Insert(Cliente cliente)
        {
            MySqlConnection conn = new MySqlConnection(cadena);
            int id= GetId();

            try
            {
                conn.Open();

                string rtn = "insert into Cliente (id, nombres, apellidos, fnacimiento) " +
                    "values (" + id.ToString() +", '" + cliente.nombres + "', '" + cliente.apellidos + "', '" + cliente.fnacimiento.ToString("yyyy-MM-dd") + "')";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.Text;
                var resp = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }


        public int GetId()
        {
            MySqlConnection conn = new MySqlConnection(cadena);
            int id = 0;

            try
            {
                conn.Open();

                string rtn = "select (case when isnull(max(id)) = 1 then 0 else max(id) end)+1 from Cliente";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader[0]);
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return id;
        }

    }
}
