using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic; 

namespace UI.Desktop
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }
        public void Listar()
        {
            UsuarioLogic bl = new UsuarioLogic();
            this.dgvUsuarios.DataSource = bl.GetAll(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop usrDesk = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            usrDesk.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
         
            UsuarioDesktop usrDesk = new UsuarioDesktop(((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Modificacion);
            usrDesk.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            UsuarioDesktop usrDesk = new UsuarioDesktop(((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID, ApplicationForm.ModoForm.Baja);
            this.Listar();
        }
    }
}
