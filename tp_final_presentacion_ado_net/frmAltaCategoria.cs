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
    public partial class frmAltaCategoria : Form
    {
        private Categoria categoria = null;
        public frmAltaCategoria()
        {
            InitializeComponent();
        }
        public frmAltaCategoria(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
            Text = "Modificar Categoria";
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                }

                categoria.Descripcion = txtNuevaCategoria.Text;
                //if (categoria.Descripcion != "")
                //{
                 //   negocio.Agregar(categoria);
                 //   MessageBox.Show("Categoria agregada exitosamente");
                //}

                if (categoria.Id != 0)
                {
                    negocio.Modificar(categoria);
                    MessageBox.Show("La categoria se modifico correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (categoria.Descripcion != "") 
                {
                    negocio.Agregar(categoria);
                    MessageBox.Show("La categoria se agregó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Close();
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

        private void frmAltaCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                if (categoria != null)
                {
                    txtNuevaCategoria.Text = categoria.Descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }
    }
}
