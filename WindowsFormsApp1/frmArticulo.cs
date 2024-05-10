using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using Dominio;

namespace WindowsFormsApp1
{
    public partial class Catalogo : Form
    {
        private List<Articulo> listaArticulos = new List<Articulo>();
        private List<Marca> listaMarcas = new List<Marca>();
        private List<Categoria> listaCategorias = new List<Categoria>();
        private Articulo seleccionado = new Articulo();
        public Catalogo()
        {
            InitializeComponent();
            dgv_articulo.SelectionChanged += dgv_articulo_SelectionChanged;
        }

        private void Catalogo_Load(object sender, EventArgs e)
        {
            NegocioMarca negocioMarca = new NegocioMarca();
            NegocioArticulo negocioArticulo = new NegocioArticulo();
            NegocioCategoria negocioCategoria = new NegocioCategoria();
            listaArticulos = negocioArticulo.Listar();
            listaMarcas = negocioMarca.Listar(); 
            listaCategorias = negocioCategoria.Listar();
            dgv_articulo.DataSource = listaArticulos;
            dgv_articulo.Rows[0].Selected = true;
            LlenarComboBox();
            SeleccionAutomatica();
            
        }

        private void SeleccionAutomatica()
        {
            //dgv_articulo.DataSource = listaArticulos;
            //dgv_articulo.Rows[0].Selected = true;
            //dataGridView1_SelectionChanged(dgv_articulo, EventArgs.Empty);
            if (dgv_articulo.SelectedRows.Count > 0)
            {
                int idMarcaSeleccionada = Convert.ToInt32(dgv_articulo.SelectedRows[0].Cells["IdMarca"].Value);
                int idCategoriaSeleccionada = Convert.ToInt32(dgv_articulo.SelectedRows[0].Cells["IdCategoria"].Value);
                string descripcionMarca = listaMarcas.FirstOrDefault(m => m.Id == idMarcaSeleccionada)?.Descripcion;
                string descripcionCategoria = listaCategorias.FirstOrDefault(m => m.Id == idCategoriaSeleccionada)?.Descripcion;

                // Si se encontró la descripción de la marca, selecciónala en el ComboBox
                if (descripcionMarca != null)
                {
                    for (int i = 0; i < cmbMarca.Items.Count; i++)
                    {
                        if (cmbMarca.Items[i].ToString() == descripcionMarca)
                        {
                            cmbMarca.SelectedIndex = i;
                            break;
                        }
                    }
                }
                if (descripcionCategoria != null)
                {
                    for (int i = 0; i < cmbCategoria.Items.Count; i++)
                    {
                        if (cmbCategoria.Items[i].ToString() == descripcionCategoria)
                        {
                            cmbCategoria.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarArticulos ventana = new frmAgregarArticulos();
            ventana.ShowDialog();
        }


        private void dgv_articulo_SelectionChanged(object sender, EventArgs e)
        {
            SeleccionAutomatica();
        }


        private void LlenarComboBox()
        {
            // Limpia los elementos existentes del ComboBox
            cmbMarca.Items.Clear();
            cmbCategoria.Items.Clear();

            // Agrega todas las descripciones de las marcas al ComboBox
            foreach (var marca in listaMarcas)
            {
                cmbMarca.Items.Add(marca.Descripcion);
            }
            foreach (var categoria in listaCategorias)
            {
                cmbCategoria.Items.Add(categoria.Descripcion);
            }

        }
     }
}

