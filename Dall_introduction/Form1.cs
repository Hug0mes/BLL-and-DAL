using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
namespace Dall_introduction
{
    public partial class Formm : Form
    {
       int id = 0;
        public Formm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                int x = BLL.Utilizadores.insertUtilizadores(textBox1.Text, textBox2.Text, textBox3.Text);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
              
            }
            catch (Exception ex) {
                MessageBox.Show("Erro:" + ex, "Dados Não Inseridos"); 
            }
           
            
        }

        private void Formm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.Utilizadores.Load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Tens certeza madje??", "?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                int x = BLL.Utilizadores.deleteUtilizadores(id);
                dataGridView1.DataSource = BLL.Utilizadores.Load();

            }
        }
    }
}
