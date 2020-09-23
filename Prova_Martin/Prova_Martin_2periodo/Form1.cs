using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prova_Martin_2periodo
{
    public partial class form1 : Form
    {
        List<Cliente> listaCliente = new List<Cliente>();

        public form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || maskedTextBox1.Text == "   ," || float.Parse(maskedTextBox1.Text) > 5)
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS COM SEU DEVIDO VALOR");
                return;
            }

            listaCliente.Add(new Cliente(textBox1.Text, dateTimePicker1.Value, float.Parse(maskedTextBox1.Text)));
            Atualizar();
            Limpar();
        }//adicionar a lista de clientes

        private void Atualizar()
        {
            richTextBox1.Clear();
            foreach (Cliente C in listaCliente)
            {
                richTextBox1.AppendText($"id:{listaCliente.IndexOf(C)}\nNome:{C.Nome}\nData:{C.Data.ToString("dd/MM/yyyy")}\nNota:{C.Nota}\n\n");
            }
            label8.Text = $"QUANTIDADE DE CLIENTES:{listaCliente.Count}";
        }//atualizar richtextbox e fazer a contagem de clientes

        private void Limpar()
        {
            textBox1.Clear();
            maskedTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxID.Text) || float.Parse(TextBoxID.Text) > listaCliente.Count - 1)
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS COM SEU DEVIDO VALOR");
                return;
            }

            maskedTextBox2.Visible = true;
            dateTimePicker3.Visible = true;
            textBox3.Visible = true;
            button3.Visible = true;
            button1.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;

            int index = Convert.ToInt32(TextBoxID.Text);
            textBox3.Text = listaCliente[index].Nome;
            dateTimePicker3.Value = listaCliente[index].Data;
            maskedTextBox2.Text = listaCliente[index].Nota.ToString();

        }//mostrar edição após ter verificado se já existem clientes registrados 

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) || maskedTextBox2.Text == "   ," || float.Parse(maskedTextBox2.Text) > 5)
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS COM SEU DEVIDO VALOR");
                return;
            }

            int index = Convert.ToInt32(TextBoxID.Text);
            listaCliente[index].Editar(textBox3.Text, dateTimePicker3.Value, float.Parse(maskedTextBox2.Text));
            Atualizar();
        }//editar o cliente a partir do ID

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("deseja mesmo excluir este registro", "confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = Convert.ToInt32(TextBoxID.Text);
                listaCliente.RemoveAt(index);
                Atualizar();
            }
            else
            {
                return;
            }
        }//excluir cliente junto com uma confirmação

        private void button4_Click(object sender, EventArgs e)
        {
            maskedTextBox2.Visible = false;
            dateTimePicker3.Visible = false;
            textBox3.Visible = false;
            button3.Visible = false;
            button1.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }//esconder edição
    }
}
