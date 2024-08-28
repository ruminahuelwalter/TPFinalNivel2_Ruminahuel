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
    public partial class frmAdministrarCategoria : Form
    {
        private List<Categoria> listaCategorias;
        
        public frmAdministrarCategoria()
        {
            InitializeComponent();
        }

        private void frmAltaCategoria_Load(object sender, EventArgs e)
        {
            cargar();
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
            frmAltaCategoria categoria = new frmAltaCategoria();
            categoria.ShowDialog();
            cargar();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Categoria seleccionado;
            seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            frmAltaCategoria categoria = new frmAltaCategoria(seleccionado);
            categoria.ShowDialog();
            cargar();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void eliminar()
        {

            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria seleccionado;
            seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿De verdad desea eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    negocio.Eliminar(seleccionado.Id);
                    MessageBox.Show("La categoría se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
