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
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Business.Entities.Usuario UsuarioActual = new Business.Entities.Usuario();
        public UsuarioDesktop()
        {
            InitializeComponent();
        }
       
        public UsuarioDesktop(ModoForm modo) 
        {
            InitializeComponent();
            Modo = modo;
        }
        public UsuarioDesktop(int ID, ModoForm modo)  {
            InitializeComponent();
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            if(UsuarioActual != null)
            {
                if (modo == ModoForm.Baja)
                {
                    ul.Delete(ID);
                }
                else
                {
                    MapearDeDatos();
                    
                }
            }
                       
      
            
        }
        
        public override void MapearDeDatos() {

            this.txtID.Text = UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }


        }
        public override void MapearADatos() {
            switch (Modo)
            {
                case ModoForm.Alta:
                    Business.Entities.Usuario usr = new Business.Entities.Usuario();
                    UsuarioActual = usr;
                    //this.txtID.Text = this.UsuarioActual.ID.ToString();
                    this.UsuarioActual.Habilitado= true;
                    this.UsuarioActual.Nombre= this.txtNombre.Text;
                    this.UsuarioActual.Apellido= this.txtApellido.Text;
                    this.UsuarioActual.Clave= this.txtClave.Text;
                    this.UsuarioActual.Email= this.txtEmail.Text;
                    this.UsuarioActual.NombreUsuario= this.txtUsuario.Text;
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja:
                  
                    break;
                case ModoForm.Modificacion:
                    this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    this.UsuarioActual.Nombre = this.txtNombre.Text;
                    this.UsuarioActual.Apellido = this.txtApellido.Text;
                    this.UsuarioActual.Clave = this.txtClave.Text;
                    this.UsuarioActual.Email = this.txtEmail.Text;
                    this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                 
                    break;
                default:
                  
                    break;
            }
           

        }
        public override void GuardarCambios() {

            this.MapearADatos();
            Business.Logic.UsuarioLogic usrLog = new Business.Logic.UsuarioLogic();
            usrLog.Save(UsuarioActual);
        
        }
        public override bool Validar() { 
           
            if(txtApellido.Text == "" ||  txtClave.Text.Length < 8 || txtNombre.Text =="" || txtUsuario.Text =="" || txtEmail.Text =="" || txtClave.Text =="" || txtConfirmarClave.Text != txtClave.Text)
            {
                Notificar("Datos invalido","Revisar los datos del formulario",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
            
            
        }
        public  void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
      
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
