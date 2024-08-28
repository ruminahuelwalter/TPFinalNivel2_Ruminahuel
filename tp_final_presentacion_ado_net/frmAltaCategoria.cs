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
        private List<Categoria> listaCategorias;
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
            bool categoriaExistente = false;
            try
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                }

                categoria.Descripcion = txtNuevaCategoria.Text;

                listaCategorias = negocio.Listar();
                foreach (var item in listaCategorias)
                {
                    if (item.Descripcion.ToString().ToLower().Equals(categoria.Descripcion.ToLower()))
                    {
                        categoriaExistente = true;
                    }
                    
                }

                if (categoria.Id != 0 && categoria.Descripcion != "")
                {
                    negocio.Modificar(categoria);
                    MessageBox.Show("La categoria se modifico correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (categoria.Id != 0 && categoria.Descripcion == "")
                {
                    MessageBox.Show("Error al agregar, categoria vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (categoria.Descripcion != "" && !categoriaExistente)
                {
                    negocio.Agregar(categoria);
                    MessageBox.Show("La categoria se agregó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (categoriaExistente)
                {
                    MessageBox.Show( "Error al agregar, categoria existente","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
