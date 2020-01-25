using Registro_del_Personal.BLL;
using Registro_del_Personal.Entidades;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registro_del_Personal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IDText.Text = String.Empty;
            NombreText.Text = String.Empty;
            TelefonoText.Text = String.Empty;
            CedulaText.Text = String.Empty;
            DireccionText.Text = String.Empty;
            FechaText.Text = String.Empty;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            String Id = IDText.Text;
            int IdValue = Convert.ToInt32(Id);

            Persona persona = PersonasBLL.Buscar((int)IdValue.Value);
            return (persona != null);
        }

        private Persona llenaClase()
        {
            Persona persona = new Persona();
            persona.PersonaID = Convert.ToInt32(IDText.Value);
            persona.Nombre = NombreText.Text;
            persona.Cedula = CedulaText.Text;
            persona.Direccion = DireccionText.Text;
            persona.FechaNacimiento = FechaText.Text;

            return persona;
        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();
        }

        private void NuevoBoton(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarBoton(object sender, RoutedEventArgs e)
        {
            Persona persona;
            bool paso = false;

            if (!Validar())
                return;

            persona = llenaClase();

            if (IDText.Value == 0)
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se pudo modificar, ya existe");
                    return;
                }
                paso = PersonasBLL.Modificar(persona);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!!");
            }
            else
            {
                MessageBox.Show("No se guardo!!!");
            }
        }

        private void EliminarBoton(object sender, RoutedEventArgs e)
        {

        }
    }
}
