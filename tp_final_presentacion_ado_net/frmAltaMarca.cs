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
    public partial class frmAltaMarca : Form
    {
        private Marca marca;
        public frmAltaMarca()
        {
            InitializeComponent();
        }

        public frmAltaMarca(Marca marca)
        {
            this.marca = marca;
            Text = "Modificar marca";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                if (marca == null)
                {
                    marca = new Marca();
                }

                marca.Descripcion = txtNuevaMarca.Text;
               
                if (marca.Id != 0)
                {
                    negocio.Modificar(marca);
                    
                    MessageBox.Show("La marca se modifico correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (marca.Descripcion != "")
                {
                    negocio.Agregar(marca);
                    MessageBox.Show("La marca se agrego correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
