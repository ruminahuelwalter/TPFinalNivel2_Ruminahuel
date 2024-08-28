using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace tp_final_presentacion_ado_net
{
    public partial class frmArticulos : Form
    {
        private List<Articulo> listaArticulos;
        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            Cargar();
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.ImagenUrl);
            }
        }

        private void Cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.Listar();
                dgvArticulos.DataSource = listaArticulos;
                OcultarColumnas();
                cargarImagen(listaArticulos[0].ImagenUrl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception )
            {

                pbxArticulo.Load("https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg");
            }
        }

        private void OcultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            Cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            //seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            try
            {
                //if (dgvArticulos.CurrentRow == null)
                //{
                //    MessageBox.Show("No hay ningun articulo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                //if (!(dgvArticulos.CurrentRow.DataBoundItem is Articulo seleccionado))
                //{
                //    MessageBox.Show("El artículo seleccionado es inválido o no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (validarSeleccionDataGridView())
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
                    modificar.ShowDialog();

                }


            
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccione un elemento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void eliminar()
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿De verdad desea eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes && validarSeleccionDataGridView())
                {

                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.Eliminar(seleccionado.Id);
                    Cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool validarSeleccionDataGridView()
        {
            try
            {
                if (dgvArticulos.CurrentRow == null)
                {
                    MessageBox.Show("No hay ningun articulo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!(dgvArticulos.CurrentRow.DataBoundItem is Articulo seleccionado))
                {
                    MessageBox.Show("El artículo seleccionado es inválido o no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccione un elemento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministrarMarca altaMarca = new frmAdministrarMarca();
            altaMarca.ShowDialog();
         
        }

        private void agregarModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministrarCategoria altaCategoria = new frmAdministrarCategoria();
            altaCategoria.ShowDialog();
            
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            try
            {
                //if (dgvArticulos.CurrentRow == null)
                //{
                //    MessageBox.Show("No hay ningun articulo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                //if (!(dgvArticulos.CurrentRow.DataBoundItem is Articulo seleccionado))
                //{
                //    MessageBox.Show("El artículo seleccionado es inválido o no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (validarSeleccionDataGridView())
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    frmDetalleArticulo ver = new frmDetalleArticulo(seleccionado);
                    ver.ShowDialog();
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccione un elemento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            Cargar();
        }

        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                {
                    return;
                }

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        private void txtFiltroAvanzado_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltroAvanzado.Text;

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            OcultarColumnas();

        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar.");
                return true;
            }

            if (cboCriterio.SelectedIndex < 0)
            {
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Debes cargar el filtro para númericos");
                    return true;
                }
                if (!soloNumeros(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Solo nros para filtrar por campo númerico");
                    return true;
                }
            }

            return false;

        }

        private bool soloNumeros(string cadena)
        {
            var cultureInfo = new CultureInfo("es-AR");
            //cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
            //cultureInfo.NumberFormat.NumberGroupSeparator = ".";
            decimal valorDecimal;

            if (Decimal.TryParse(cadena,NumberStyles.Number, cultureInfo, out valorDecimal))
            {

                return true;
            }
            else 
            {
                return false;
            }
           
        }

    }
}
