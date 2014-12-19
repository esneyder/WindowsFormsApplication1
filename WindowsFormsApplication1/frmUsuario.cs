using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using databaseConnection;


namespace WindowsFormsApplication1
{
    public partial class frmUsuario : Form
    {
        DbConnection db = new DbConnection("Parametros.xml");
        public frmUsuario()
        {
            InitializeComponent();

        }




        private void button1_Click(object sender, EventArgs e)
        {

            if (!db.OpenConnection())
            {
                db.CloseConnection();
                MessageBox.Show("Error" + db.Error);
            }
            else
            {
                string[] parametros = { "@operacion",
                                      "@nombre", 
                                      "@apellido", 
                                      "@genero", 
                                      "@usuario",
                                      "@clave" };

                db.ExecuteProcedures("spUsuarioIA",
                      parametros, "I", txtnombre.Text,
                                      txtapellido.Text,
                                      txtgenero.Text,
                                      txtusuario.Text,
                                      txtclave.Text);
                MessageBox.Show("Registro ingresado");
            }

        }




        private void frmUsuario_Load(object sender, EventArgs e)
        {

        }
        public DataTable Persona()
        {

            String[] parametros = { "@operacion", "@usuarioId" };
            return db.GetData("spUsuarioSE", parametros, "T", 0);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!db.OpenConnection())
            {
                db.CloseConnection();
                MessageBox.Show("Error" + db.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                string[] parametros = { "@operacion", "@usuarioId" };
                dt = db.GetData("spUsuarioSE", parametros, "S",7);
                foreach (DataRow fila in dt.Rows)
                {
                    txtnombre.Text = fila["nombre"].ToString();
                    txtapellido.Text = fila["apellido"].ToString();
                    txtgenero.Text = fila["genero"].ToString();
                    txtusuario.Text = fila["usuario"].ToString();
                    txtclave.Text = fila["clave"].ToString();


                }
                db.CloseConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!db.OpenConnection())
            {
                db.CloseConnection();
                MessageBox.Show("Error" + db.Error);
            }
            else
            {
                string[] parametros = { "@operacion",
                                      "@nombre", 
                                      "@apellido", 
                                      "@genero", 
                                      "@usuario",
                                      "@clave" };

                db.ExecuteProcedures("spUsuarioIA",
                      parametros, "A", txtnombre.Text,
                                      txtapellido.Text,
                                      txtgenero.Text,
                                      txtusuario.Text,
                                      txtclave.Text);
                MessageBox.Show("Registro Actualizado");
                db.CloseConnection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!db.OpenConnection())
            {
                db.CloseConnection();
                MessageBox.Show("Error" + db.Error);
            }
            else
            {
                string[] parametros = { "@operacion",
                                      "@usuarioId", 
                                       };

                db.ExecuteProcedures("spUsuarioSE",
                      parametros, "E", 5);
                MessageBox.Show("Registro eliminado");
                db.CloseConnection();
            }
        }
    }
}
