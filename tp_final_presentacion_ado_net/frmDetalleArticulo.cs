using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_final_presentacion_ado_net
{
    public partial class frmDetalleArticulo : Form
    {
        private Articulo articulo = null;
        public frmDetalleArticulo( Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDetalleArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                
                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    richTextBoxDescripcion.Text = articulo.Descripcion;
                   
                    cargarImagen(articulo.ImagenUrl);

                    decimal valorDecimal = articulo.Precio;
                    txtPrecio.Text = valorDecimal.ToString(); 

                    txtMarca.Text = articulo.Marca.Descripcion.ToString();
                    txtCategoria.Text = articulo.Categoria.Descripcion.ToString();

                }


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
            catch (Exception)
            {
                pbxArticulo.Load("https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg");
            }
        }
    }
}
