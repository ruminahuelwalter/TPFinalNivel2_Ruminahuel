using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_final_presentacion_ado_net
{
    public partial class frmAltaMarca : Form
    {
        private Marca marca= null;
        private List<Marca> listaMarcas;
        public frmAltaMarca()
        {
            InitializeComponent();
        }

        public frmAltaMarca(Marca marca)
        {
            InitializeComponent();
            this.marca = marca;
            Text = "Modificar marca";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            bool marcaExistente = false;
            try
            {
                if (marca == null)
                {
                    marca = new Marca();
                }

                marca.Descripcion = txtNuevaMarca.Text;
               
                listaMarcas = negocio.Listar();
                foreach (var item in listaMarcas)
                {
                    if (item.Descripcion.ToString().ToLower().Equals(marca.Descripcion.ToLower()))
                    {
                        marcaExistente = true;
                    }

                }

                if (marca.Id != 0 && marca.Descripcion != "")
                {
                    negocio.Modificar(marca);
                    
                    MessageBox.Show("La marca se modifico correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (marca.Id != 0 && marca.Descripcion == "")
                {
                    MessageBox.Show("Error al modificar, marca vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (marca.Descripcion != "" && !marcaExistente)
                {
                    negocio.Agregar(marca);
                    MessageBox.Show("La marca se agrego correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (marcaExistente)
                {
                    MessageBox.Show("Error al agregar, marca existente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmAltaMarca_Load(object sender, EventArgs e)
        {

            try
            {
                if (marca != null)
                {
                    txtNuevaMarca.Text = marca.Descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
