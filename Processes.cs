using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Uygulama
{
    internal class Processes
    {
        public static string con_str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Project.mdf;Integrated Security = True";

        public static SqlConnection _conn = new SqlConnection(Processes.con_str);

        public static string password = "bulent5100";

        public static string password2 = "furkan0066";
        public class AlimSatim
        {
            public int Id { get; set; }
            public string Isim { get; set; }
            public string Cins { get; set; }
            public string Tonaj { get; set; }
            public string Fiyat { get; set; }
            public string Tutar { get; set; }
            public string Tarih { get; set; }
        }
        public class BorcAlacak
        {
            public int Id { get; set; }
            public string Isim { get; set; }
            public string Tutar { get; set; }
            public string Tarih { get; set; }
        }
        public static void Connect()
        {
            try
            {
                _conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Veritabanı bağlantısında kritik bir hata oluştu." + e.Message);
            }

        }
        public static void Disconnect(SqlConnection conn)
        {
            try
            {
                conn.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show("Veritabanı bağlantısında kritik bir hata oluştu." + e.Message);
            }
        }
        public static List<AlimSatim> AlimRapor()
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandText = "SELECT * FROM ALIM";
                SqlDataReader reader = cmd.ExecuteReader();

                List<AlimSatim> list = new List<AlimSatim>();
                while (reader.Read())
                {
                    AlimSatim tbl = new AlimSatim();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Cins = reader["CINS"].ToString();
                    tbl.Tonaj = reader["TONAJ"].ToString();
                    tbl.Fiyat = reader["FIYAT"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }
        public static List<AlimSatim> SatisRapor()
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandText = "SELECT * FROM SATIS";
                SqlDataReader reader = cmd.ExecuteReader();

                List<AlimSatim> list = new List<AlimSatim>();
                while (reader.Read())
                {
                    AlimSatim tbl = new AlimSatim();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Cins = reader["CINS"].ToString();
                    tbl.Tonaj = reader["TONAJ"].ToString();
                    tbl.Fiyat = reader["FIYAT"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }
        public static List<BorcAlacak> BorcRapor()
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandText = "SELECT * FROM BORC";
                SqlDataReader reader = cmd.ExecuteReader();

                List<BorcAlacak> list = new List<BorcAlacak>();
                while (reader.Read())
                {
                    BorcAlacak tbl = new BorcAlacak();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }
        public static List<BorcAlacak> AlacakRapor()
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandText = "SELECT * FROM ALACAK";
                SqlDataReader reader = cmd.ExecuteReader();

                List<BorcAlacak> list = new List<BorcAlacak>();
                while (reader.Read())
                {
                    BorcAlacak tbl = new BorcAlacak();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }
        public static List<AlimSatim> AlimSahisCins(string isim, string cins)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@isim", isim);
                cmd.Parameters.AddWithValue("@cins", cins);
                cmd.CommandText = "SELECT * FROM ALIM WHERE ISIM = @isim AND CINS = @cins";
                SqlDataReader reader = cmd.ExecuteReader();

                List<AlimSatim> list = new List<AlimSatim>();
                while (reader.Read())
                {
                    AlimSatim tbl = new AlimSatim();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Cins = reader["CINS"].ToString();
                    tbl.Tonaj = reader["TONAJ"].ToString();
                    tbl.Fiyat = reader["FIYAT"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }
        public static List<AlimSatim> AlimSahis(string isim)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@isim", isim);
                cmd.CommandText = "SELECT * FROM ALIM WHERE ISIM = @isim";
                SqlDataReader reader = cmd.ExecuteReader();

                List<AlimSatim> list = new List<AlimSatim>();
                while (reader.Read())
                {
                    AlimSatim tbl = new AlimSatim();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Cins = reader["CINS"].ToString();
                    tbl.Tonaj = reader["TONAJ"].ToString();
                    tbl.Fiyat = reader["FIYAT"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }
        public static List<AlimSatim> AlimCins(string cins)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@cins", cins);
                cmd.CommandText = "SELECT * FROM ALIM WHERE CINS = @cins";
                SqlDataReader reader = cmd.ExecuteReader();

                List<AlimSatim> list = new List<AlimSatim>();
                while (reader.Read())
                {
                    AlimSatim tbl = new AlimSatim();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Cins = reader["CINS"].ToString();
                    tbl.Tonaj = reader["TONAJ"].ToString();
                    tbl.Fiyat = reader["FIYAT"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }
        public static List<AlimSatim> SatisSahisCins(string isim, string cins)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@isim", isim);
                cmd.Parameters.AddWithValue("@cins", cins);
                cmd.CommandText = "SELECT * FROM SATIS WHERE ISIM = @isim AND CINS = @cins";
                SqlDataReader reader = cmd.ExecuteReader();

                List<AlimSatim> list = new List<AlimSatim>();
                while (reader.Read())
                {
                    AlimSatim tbl = new AlimSatim();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Cins = reader["CINS"].ToString();
                    tbl.Tonaj = reader["TONAJ"].ToString();
                    tbl.Fiyat = reader["FIYAT"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }
        public static List<AlimSatim> SatisSahis(string isim)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@isim", isim);
                cmd.CommandText = "SELECT * FROM SATIS WHERE ISIM = @isim";
                SqlDataReader reader = cmd.ExecuteReader();

                List<AlimSatim> list = new List<AlimSatim>();
                while (reader.Read())
                {
                    AlimSatim tbl = new AlimSatim();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Cins = reader["CINS"].ToString();
                    tbl.Tonaj = reader["TONAJ"].ToString();
                    tbl.Fiyat = reader["FIYAT"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }
        public static List<AlimSatim> SatisCins(string cins)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@cins", cins);
                cmd.CommandText = "SELECT * FROM SATIS WHERE CINS = @cins";
                SqlDataReader reader = cmd.ExecuteReader();

                List<AlimSatim> list = new List<AlimSatim>();
                while (reader.Read())
                {
                    AlimSatim tbl = new AlimSatim();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Cins = reader["CINS"].ToString();
                    tbl.Tonaj = reader["TONAJ"].ToString();
                    tbl.Fiyat = reader["FIYAT"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }
        public static List<BorcAlacak> BorcSahis(string isim)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@isim", isim);
                cmd.CommandText = "SELECT * FROM BORC WHERE ISIM = @isim";
                SqlDataReader reader = cmd.ExecuteReader();

                List<BorcAlacak> list = new List<BorcAlacak>();
                while (reader.Read())
                {
                    BorcAlacak tbl = new BorcAlacak();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }
        public static List<BorcAlacak> AlacakSahis(string isim)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.Parameters.AddWithValue("@isim", isim);
                cmd.CommandText = "SELECT * FROM ALACAK WHERE ISIM = @isim";
                SqlDataReader reader = cmd.ExecuteReader();

                List<BorcAlacak> list = new List<BorcAlacak>();
                while (reader.Read())
                {
                    BorcAlacak tbl = new BorcAlacak();
                    tbl.Id = Convert.ToInt32(reader["ID"]);
                    tbl.Isim = reader["ISIM"].ToString();
                    tbl.Tutar = reader["TUTAR"].ToString();
                    tbl.Tarih = reader["TARIH"].ToString();
                    list.Add(tbl);
                }

                Disconnect(_conn);
                return list;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Disconnect(_conn);
                return null;
            }
        }

    }
}
