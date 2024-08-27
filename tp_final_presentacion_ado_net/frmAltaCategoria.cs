using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using System.Text.RegularExpressions;

namespace tp_final_presentacion_ado_net
{
    public partial class frmAltaCategoria : Form
    {
        private List<Categoria> listaCategorias;
        private Categoria categoria = null;
        public frmAltaCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cargar()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                listaCategorias = negocio.Listar();
                dgvCategorias.DataSource = listaCategorias;
                ocultarColumnas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvCategorias.Columns["Id"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                }

                categoria.Descripcion = txtNuevaCategoria.Text;
                if (categoria.Descripcion != "")
                {
                    negocio.Agregar(categoria);
                    MessageBox.Show("Categoria agregada exitosamente");
                }
                cargar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void frmAltaCategoria_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
