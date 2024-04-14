using System;
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

namespace CRUD
{
    /// <summary>
    /// Lógica de interacción para agregar.xaml
    /// </summary>
    public partial class agregar : Window
    {
        public agregar()
        {
            InitializeComponent();
        }

        public buttonCLick_insertar()
        {
            
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("NombreProcedimientoInsertar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@parametro1", valor1);
                command.Parameters.AddWithValue("@parametro2", valor2);
                // Agrega los parámetros restantes según tu procedimiento almacenado
            
                command.ExecuteNonQuery();
                MessageBox.Show("Registro agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
                RefreshData();
            }

        }
    }
}
