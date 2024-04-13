using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace CRUD
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {


            List<Clientes> clientes = new List <Clientes>();

            string connectionString = "Data Source=LAB1504-10\\SQLEXPRESS; Initial Catalog=neptuno2024; User Id=Myriamdb; password=123456";
            try { 

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("USP_ListarClientes", connection);


                MessageBox.Show("Conexion Correcta");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? null : reader.GetString(reader.GetOrdinal("idCliente"));
                    string NombreCompañia = reader.IsDBNull(reader.GetOrdinal("NombreCompañia")) ? null : reader.GetString(reader.GetOrdinal("NombreCompañia"));
                    string NombreContacto = reader.IsDBNull(reader.GetOrdinal("NombreContacto")) ? null : reader.GetString(reader.GetOrdinal("NombreContacto"));
                    string CargoContacto = reader.IsDBNull(reader.GetOrdinal("CargoContacto")) ? null : reader.GetString(reader.GetOrdinal("CargoContacto"));
                    string Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion"));
                    string Ciudad = reader.IsDBNull(reader.GetOrdinal("Ciudad")) ? null : reader.GetString(reader.GetOrdinal("Ciudad"));
                    string Region = reader.IsDBNull(reader.GetOrdinal("Region")) ? null : reader.GetString(reader.GetOrdinal("Region"));
                    string CodPostal = reader.IsDBNull(reader.GetOrdinal("CodPostal")) ? null : reader.GetString(reader.GetOrdinal("CodPostal"));
                    string Pais = reader.IsDBNull(reader.GetOrdinal("Pais")) ? null : reader.GetString(reader.GetOrdinal("Pais"));
                    string Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono"));
                    string Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) ? null : reader.GetString(reader.GetOrdinal("Fax"));

                    clientes.Add(new Clientes { IdCliente = IdCliente, NombreContacto = NombreContacto, NombreCompañia = NombreCompañia, CargoContacto = CargoContacto, Direccion = Direccion, Region = Region, CodPostal = CodPostal, Pais = Pais, Telefono = Telefono, Fax= Fax });
                }
                connection.Close();

                Demo.ItemsSource = clientes;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            agregar a = new agregar();
            a.ShowDialog(); 
        }

 

    }
}