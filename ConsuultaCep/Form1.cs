using ConsuultaCep.WSCorreios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsuultaCep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(mtbCep.Text)) 
            {
                using(var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(mtbCep.Text);

                        tbBairro.Text = endereco.bairro;
                        tbEstado.Text = endereco.cidade;
                        if(endereco.cidade == string.Empty)
                        {
                            tbRua.Enabled = true;
                        }
                        tbCidade.Text = endereco.cidade;
                        tbRua.Text = endereco.end;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Campo de cep vazio");
            }
        }
    }
}
