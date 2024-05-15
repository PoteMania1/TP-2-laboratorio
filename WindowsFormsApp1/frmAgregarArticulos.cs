using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using negocio;

namespace WindowsFormsApp1
{
    public partial class frmAgregarArticulos : Form
    {
        private Articulo articulo = null;
        public frmAgregarArticulos()
        {
            InitializeComponent();
        }
        public frmAgregarArticulos(Articulo art)
        {
            InitializeComponent();
            this.articulo = art;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo art= new Articulo();
            UrlImagen img= new UrlImagen();
            NegocioArticulo neg = new NegocioArticulo();
            NegocioUrlImagen negImg = new NegocioUrlImagen();
            try
            {
                art.Id = int.Parse(tbId.Text);
                img.IdArticulo = int.Parse(tbId.Text);
                art.Codigo = tbCodigo.Text;
                art.Nombre = tbNombre.Text;
                art.Descripcion = tbDescripcion.Text;
                art.IdMarca = int.Parse(tbIdMarca.Text);
                art.IdCategoria = int.Parse(tbIdCategoria.Text);
                img.Url = tbUrlImagen.Text;
                art.Precio = decimal.Parse(tbPrecio.Text);

                neg.Agregar(art);
                negImg.Agregar(img);

                MessageBox.Show("Agregado Exitosamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAgregarArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                if(articulo != null)
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
