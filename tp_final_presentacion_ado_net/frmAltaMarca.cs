using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace tp_final_presentacion_ado_net
{
    public partial class frmAltaMarca : Form
    {
        private List<Marca> listaMarcas;
        private Marca marca;
        public frmAltaMarca()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                listaMarcas = negocio.Listar();
                dgvMarcas.DataSource = listaMarcas;
                ocultarColumnas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void ocultarColumnas()
        {
            dgvMarcas.Columns["Id"].Visible = false;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                if (marca == null)
                {
                    marca = new Marca();
                }

                marca.Descripcion = txtNuevaMarca.Text;
                if (marca.Descripcion != "")
                {
                    negocio.Agregar(marca);
                }
                cargar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAltaMarca_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
