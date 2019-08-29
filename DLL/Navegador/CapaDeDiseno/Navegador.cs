using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace CapaDeDiseno
{
    public partial class Navegador : UserControl
    {
        logica logic = new logica();
        string tabla = "Asientos";
        int pos = 8;
        int noCampos = 1;
        int x = 30;
        int y = 30;
        string[] tipoCampo = new string[30];
        public Navegador()
        {
            InitializeComponent();
           
        }

        private void Navegador_Load(object sender, EventArgs e)
        {
            DataTable dt = logic.consultaLogica(tabla);
            dataGridView1.DataSource = dt;
            CreaComponentes();
            
        }

        public void asignarTabla(string table)
        {
            tabla = table;
        }

        void CreaComponentes()
        {
            string[] Campos =logic.campos(tabla);
            string[] Tipos = logic.tipos(tabla);
            int i = 0;
            int fin = Campos.Length;
            while (i < fin)
            {
                if (noCampos == 6 || noCampos == 11 || noCampos == 16 || noCampos == 21) { pos = 8; }
                if (noCampos >= 6 && noCampos < 10) { x = 300; }
                if (noCampos >= 11 && noCampos < 15) { x = 600; }
                if (noCampos >= 16 && noCampos < 20) { x = 900; }
                if (noCampos >= 21 && noCampos < 25) { x = 900; }
                Label lb = new Label();

                lb.Text = Campos[i];

                Point p = new Point(x + pos, y * pos);
                lb.Location = p;
                lb.Name = "lb_" +Campos[i];
                this.Controls.Add(lb);

       
                switch (Tipos[i])
                {
                    case "int":
                        tipoCampo[noCampos - 1] = "Num";
                        crearTextBox(Campos[i]);
                        break;
                    case "varchar":
                        tipoCampo[noCampos - 1] = "Text";
                        crearTextBox(Campos[i]);
                        break;
                    case "date":
                        tipoCampo[noCampos - 1] = "Text";
                        crearDateTimePicker(Campos[i]);
                        break;
                    case "text":
                        tipoCampo[noCampos - 1] = "Text";
                        crearTextBox(Campos[i]);
                        break;
                }
                noCampos++;

                i++;
            }
        }

        void crearTextBox(String nom)
        {
            TextBox tb = new TextBox();
            Point p = new Point(x + 125 + pos, y * pos);
            tb.Location = p;
            tb.Name = nom;
            this.Controls.Add(tb);
            pos++;
        }
        void crearComboBox(String nom)
        {
            ComboBox cb = new ComboBox();
            Point p = new Point(x + 125 + pos, y * pos);
            cb.Location = p;
            cb.Name = nom;
            this.Controls.Add(cb);
            pos++;
        }
        void crearDateTimePicker(String nom)
        {
            DateTimePicker dtp = new DateTimePicker();
            Point p = new Point(x + 125 + pos, y * pos);
            dtp.Location = p;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy-MM-dd";
            dtp.Name = nom;
            this.Controls.Add(dtp);
            pos++;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            btn_Guardar.Enabled = false;

            logic.nuevoQuery(crearInsert());
            DataTable dt = logic.consultaLogica(tabla);
            dataGridView1.DataSource = dt;

        }

        string crearInsert()// crea el query de insert
        {
            string query = "INSERT INTO " + tabla + " VALUES (";
            int posCampo = 0;
            string campos = "";
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker)
                {

                    switch (tipoCampo[posCampo])
                    {
                        case "Text":
                            campos += "'" + componente.Text + "' , ";
                            break;
                        case "Num":
                            campos += componente.Text + " , ";
                            break;
                    }
                    posCampo++;

                }

            }
            campos = campos.TrimEnd(' ');
            campos = campos.TrimEnd(',');
            query += campos + ");";
            return query;
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            btn_Guardar.Enabled = false;
            logic.nuevoQuery( crearUpdate());
            DataTable dt = logic.consultaLogica(tabla);
            dataGridView1.DataSource = dt;

            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker)
                {
                    componente.Enabled = true;
                    componente.Text = "";

                }

            }

        }

       string crearUpdate()// crea el query de update
        {
            string query = "UPDATE " + tabla + " SET ";
            string whereQuery = " WHERE  ";
            int posCampo = 0;
            string campos = "";
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker)
                {

                    if (posCampo > 0)
                    {
                        switch (tipoCampo[posCampo])
                        {
                            case "Text":
                                campos += componente.Name + " = '" + componente.Text + "' , ";
                                break;
                            case "Num":
                                campos += componente.Name + " = " + componente.Text + " , ";
                                break;
                        }
                    }
                    else
                    {
                        switch (tipoCampo[posCampo])
                        {
                            case "Text":
                                whereQuery += componente.Name + " = '" + componente.Text;
                                break;
                            case "Num":
                                whereQuery += componente.Name + " = " + componente.Text;
                                break;
                        }

                    }
                    posCampo++;

                }

            }
            campos = campos.TrimEnd(' ');
            campos = campos.TrimEnd(',');
            query += campos + whereQuery + ";";
            //contenido.Text = query;
            return query;
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            btn_Guardar.Enabled = true;
            int posCampo = 0;
            foreach (Control componente in Controls)
            {
                if (componente is TextBox || componente is DateTimePicker)
                {
                    
                    componente.Text = dataGridView1.CurrentRow.Cells[posCampo].Value.ToString();
                    if (posCampo == 0)
                    {
                        componente.Enabled = false;
                    }
                    posCampo++;

                }

            }
        }
    }
}
