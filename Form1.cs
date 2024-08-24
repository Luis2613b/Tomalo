using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsPyoyecend
{
    public partial class Form1 : Form
    {
        double precio = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Mostrar la fecha actual en el formato "d"
            label3.Text = DateTime.Now.ToString("D");
            lblPrecio.Text = label3.Text;
            lblPrecio.Text = (0).ToString();

        }
        private void CboProducto_Click(object sender, EventArgs e)
        {
            string producto = cboProductos.Text;

            if (producto.Equals("Colección Escolar")) precio = 250;
            if (producto.Equals("Colección PreUniversitaria")) precio = 150;
            if (producto.Equals("Colección Profesional")) precio = 350;

            lblPrecio.Text = precio.ToString("c");

        }
        private void BtnRegistrar_Click(object sender, EventArgs e)
       
        {
            //Validando
            if (cboProductos.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar un producto");
            else if (txtCantidad.Text == "")
                MessageBox.Show("Debe ingresar una Cantidad...!!!");
            if (cboTipo.SelectedIndex == -1)
                MessageBox.Show("Debe ingresar un producto...!!!");

            else
            {
                //Capturando datos
                string producto = cboProductos.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                string tipo = cboTipo.Text;

                //Procesar cálculos
                double subtotal = cantidad * precio;
                double descuento = 0, recargo = 0;
                if (tipo.Equals("Contado"))
                    descuento = 0.05 * subtotal;
                else
                    recargo = 0.1 * subtotal;
                double precioFinal = subtotal - descuento + recargo;

                //Impresión de resultados
                ListViewItem fila = new ListViewItem(producto);
                fila.SubItems.Add(cantidad.ToString());
                fila.SubItems.Add(precio.ToString());
                fila.SubItems.Add(tipo.ToString());
                fila.SubItems.Add(descuento.ToString());
                fila.SubItems.Add(recargo.ToString());
                fila.SubItems.Add(precioFinal.ToString());

                lvVenta.Items.Add(fila);

            }

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

         }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            BtnCancelar_Click(sender, e);
            Close();
        }

        private void LvVenta_SelectedIndexChanged(object sender, EventArgs e)
        { 
            cboProductos.Text = "(Seleccione producto)";
            cboTipo.Text = "(Seleccione tipo)";
            txtCantidad.Clear();
            lblPrecio.Text = (0).ToString("c");
            cboProductos.Focus();
        }
    }


}