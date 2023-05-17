﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Changepwd.xaml
    /// </summary>
    public partial class Changepwd : Window
    {
        public Changepwd()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            string Password = pwdbox.Password.ToString();
           
            

            string serverIp = "localhost";
            string username = "root";
            string password = "root";
            string databaseName = "hospital";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            MySqlConnection conn = new MySqlConnection(dbConnectionString);
            MySqlCommand cmd;

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                int Drid = Convert.ToInt32(idtxt.Text.ToString());
                cmd.CommandText = "update doctor set Password=@Password where Drid=" + Drid;
                cmd.Parameters.AddWithValue("@Password", Password.ToString());





                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Successfully updated!!!", "Info");
                
                else
                { MessageBox.Show("Error in updating"); }




            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
