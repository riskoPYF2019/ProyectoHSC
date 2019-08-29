using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAVE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            navegador1.asignarTabla("Peliculas");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Navegador1_Load(object sender, EventArgs e)
        {

        }
    }
}
