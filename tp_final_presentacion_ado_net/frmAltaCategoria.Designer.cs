namespace tp_final_presentacion_ado_net
{
    partial class frmAltaCategoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gboxNueva = new System.Windows.Forms.GroupBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtNuevaCategoria = new System.Windows.Forms.TextBox();
            this.gboxNueva.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(78, 121);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(171, 121);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gboxNueva
            // 
            this.gboxNueva.Controls.Add(this.lblCategoria);
            this.gboxNueva.Controls.Add(this.txtNuevaCategoria);
            this.gboxNueva.Location = new System.Drawing.Point(23, 24);
            this.gboxNueva.Name = "gboxNueva";
            this.gboxNueva.Size = new System.Drawing.Size(223, 78);
            this.gboxNueva.TabIndex = 15;
            this.gboxNueva.TabStop = false;
            this.gboxNueva.Text = "Nueva Categoria";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(25, 33);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(45, 13);
            this.lblCategoria.TabIndex = 0;
            this.lblCategoria.Text = "Ingrese:";
            // 
            // txtNuevaCategoria
            // 
            this.txtNuevaCategoria.Location = new System.Drawing.Point(76, 33);
            this.txtNuevaCategoria.Name = "txtNuevaCategoria";
            this.txtNuevaCategoria.Size = new System.Drawing.Size(100, 20);
            this.txtNuevaCategoria.TabIndex = 1;
            // 
            // frmAltaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 161);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gboxNueva);
            this.Name = "frmAltaCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta Categoria";
            this.Load += new System.EventHandler(this.frmAltaCategoria_Load);
            this.gboxNueva.ResumeLayout(false);
            this.gboxNueva.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gboxNueva;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtNuevaCategoria;
    }
}