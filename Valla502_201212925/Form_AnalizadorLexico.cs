using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valla502_201212925
{
    public partial class Form_Analizador : Form
    {
        //------------------------------------------Control de Pestañas----------------------------------------------
        List<Tuple<String, RichTextBox, String>> Indice = new List<Tuple<String, RichTextBox, String>>();//NombreTab + RichTextBox
        int ContarPestañaNueva = 1; //Contador de Pestañas
        //----------------------------------------Instrucciones del Analizador---------------------------------------
        AnalizadorLexico AnalizarTexto = new AnalizadorLexico();
        String NombreGrafico = "";
        Boolean Analisis = false;
        List<Tuple<int, int, int>> Pixeles = new List<Tuple<int, int, int>>();
        List<Tuple<int, String, int, int, int, String>> Tokens = new List<Tuple<int, String, int, int, int, String>>();
        List<Tuple<int, int, int, String>> Errores = new List<Tuple<int, int, int, String>>();
        public Form_Analizador()
        {
            InitializeComponent();
        }
        private void Analizador_Load(object sender, EventArgs e)
        {
            CrearPestaña();
        }
        private void MenuArchivo_NuevaPestaña_Click(object sender, EventArgs e)
        {
            CrearPestaña();
        }
        private void MenuArchivo_Abrir_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog AbrirArchivo = new OpenFileDialog();
                AbrirArchivo.Filter = "Archivo Valla502|*.vp502";
                AbrirArchivo.Title = "Abrir Archivo de Valla Publicitaria";
                if (AbrirArchivo.ShowDialog() == DialogResult.OK)
                {
                    String Ruta = AbrirArchivo.FileName;
                    RichTextBox PestañaActual = new RichTextBox();
                    StreamReader CargarFile = new StreamReader(Ruta);
                    String Temp = "";
                    foreach (var busqueda in Indice)
                    {
                        if (busqueda.Item1.Equals(TabPestana.SelectedTab.Text.ToString()))
                        {
                            Temp = busqueda.Item1;
                            PestañaActual = busqueda.Item2;
                            busqueda.Item2.Text = CargarFile.ReadToEnd();
                            CargarFile.Close();
                        }
                    }
                    Indice.RemoveAll(item => item.Item1 == Temp);
                    String TituloPestaña = Path.GetFileNameWithoutExtension(Ruta) + Path.GetExtension(Ruta);
                    TabPestana.SelectedTab.Text = TituloPestaña;
                    Indice.Add(new Tuple<String, RichTextBox, String>(TituloPestaña, PestañaActual, Ruta));
                }
            }
            catch (Exception)
            {

            }
        }
        private void MenuArchivo_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog GuardarArchivo = new SaveFileDialog();
                GuardarArchivo.Filter = "Archivo Valla502|*.vp502";
                GuardarArchivo.Title = "Guardar Archivo - Valla502";
                GuardarArchivo.DefaultExt = "vp502";
                GuardarArchivo.AddExtension = true;
                if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    String Temp = "";
                    String Ruta = GuardarArchivo.FileName;
                    RichTextBox PestañaActual = new RichTextBox();
                    foreach (var busqueda in Indice)
                    {
                        if (busqueda.Item1.Equals(TabPestana.SelectedTab.Text.ToString()))
                        {
                            Temp = busqueda.Item1;
                            PestañaActual = busqueda.Item2;
                            StreamWriter Guardar = new StreamWriter(Ruta);
                            foreach (object line in busqueda.Item2.Lines)
                            {
                                Guardar.WriteLine(line);
                            }
                            Guardar.Close();
                        }
                    }
                    Indice.RemoveAll(item => item.Item1 == Temp);
                    String TituloPestaña = Path.GetFileNameWithoutExtension(Ruta) + Path.GetExtension(Ruta);
                    TabPestana.SelectedTab.Text = TituloPestaña;
                    Indice.Add(new Tuple<String, RichTextBox, String>(TituloPestaña, PestañaActual, Ruta));
                }
            }
            catch (Exception)
            {

            }
        }
        private void MenuArchivo_Salir_Click(object sender, EventArgs e)
        {
            foreach (var busqueda in Indice)
            {
                if (busqueda.Item3.Equals("SinRuta"))
                {
                    DialogResult dialogResult = MessageBox.Show("Cerrará el Programa sin Guardar algunos Archivos. \n\r ¿Desea guardar con el Archivo " + busqueda.Item1 + "?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveFileDialog GuardarArchivo = new SaveFileDialog();
                        GuardarArchivo.Filter = "Archivo Valla502|*.vp502";
                        GuardarArchivo.Title = "Guardar Archivo - Valla502";
                        GuardarArchivo.DefaultExt = "vp502";
                        GuardarArchivo.AddExtension = true;
                        if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                        {
                            String Ruta = GuardarArchivo.FileName;
                            StreamWriter Guardar = new StreamWriter(Ruta);
                            foreach (object line in busqueda.Item2.Lines)
                            {
                                Guardar.WriteLine(line);
                            }
                            Guardar.Close();
                        }
                    }
                }
            }
            this.Close();
        }
        private void MenuCompilar_Analizar_Click(object sender, EventArgs e)
        {
            if (Analisis)
            {
                DialogResult dialogResult = MessageBox.Show("Ya realizo un Analisis Léxico. \n\r Si desea realizar otro perdera los datos del anterior Analisis Léxico. \n\r ¿Desea continuar con el Analisis Léxico?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    Analizar();
                }
            }
            else
            {
                Analizar();
            }

        }
        private void MenuCompilar_Valla_Click(object sender, EventArgs e)
        {
            Form VallaPublicitaria = new Form();
            VallaPublicitaria.Size = new Size(AnalizarTexto.getTamañoFondoX() + 34, AnalizarTexto.getTamañoFondoY() + 53);
            VallaPublicitaria.Text = "Grafica - " + Path.GetFileNameWithoutExtension(NombreGrafico);
            VallaPublicitaria.StartPosition = FormStartPosition.CenterScreen;
            switch (AnalizarTexto.getColorFondo())
            {
                case 0:
                    {
                        VallaPublicitaria.BackColor = Color.Black;
                        break;
                    }
                case 1:
                    {
                        VallaPublicitaria.BackColor = Color.Yellow;
                        break;
                    }
                case 2:
                    {
                        VallaPublicitaria.BackColor = Color.Blue;
                        break;
                    }
                case 3:
                    {
                        VallaPublicitaria.BackColor = Color.Red;
                        break;
                    }
                case 4:
                    {
                        VallaPublicitaria.BackColor = Color.Green;
                        break;
                    }
            }
            VallaPublicitaria.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            Pixeles = AnalizarTexto.getLista();
            foreach (var pixel in Pixeles)
            {
                Panel Contenedor = new Panel();
                Contenedor.Size = new Size(20, 20);
                switch (pixel.Item3)
                {
                    case 1:
                        {
                            Contenedor.BackColor = Color.Yellow;
                            break;
                        }
                    case 2:
                        {
                            Contenedor.BackColor = Color.Blue;
                            break;
                        }
                    case 3:
                        {
                            Contenedor.BackColor = Color.Red;
                            break;
                        }
                    case 4:
                        {
                            Contenedor.BackColor = Color.Green;
                            break;
                        }
                }
                Contenedor.Location = new Point(pixel.Item1 * 20, pixel.Item2 * 20);
                VallaPublicitaria.Controls.Add(Contenedor);
            }

            VallaPublicitaria.ShowDialog();
        }
        private void MenuCompilar_Salida_Click(object sender, EventArgs e)
        {
            GuardarToken();
            if (AnalizarTexto.getCantidadErrores() > 0)
            {
                GuardarError();
            }

        }
        private void MenuAyuda_Usuario_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "ManualUsuario_201212925.pdf";
            proc.Start();
        }
        private void MenuAyuda_Tecnico_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "ManualTecnico_201212925.pdf";
            proc.Start();
        }
        private void MenuAyuda_Acercade_Click(object sender, EventArgs e)
        {
            FormEstudiante Mostrar = new FormEstudiante();
            Mostrar.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Mostrar.Show();
        }
        private void CrearPestaña()
        {
            String Titulo = "Sin título-" + ContarPestañaNueva + ".*";//Creamos un Titulo para la Pestaña
            TabPage NuevaPestaña = new TabPage(Titulo); // Creamos una nueva pestaña
            TabPestana.TabPages.Add(NuevaPestaña);//Añadimos la Pestaña
            TabPestana.SelectedTab = NuevaPestaña;//Seleccionamos la Pestaña
            TabPestana.Font = new Font("Arial", 11, FontStyle.Regular);//De formato de letra

            RichTextBox NuevaPublicidad = new RichTextBox();//Creamos un RichTextBox
            NuevaPublicidad.Dock = DockStyle.Fill;//Que llene todo el Tab
            NuevaPublicidad.Multiline = true;//Que sea multilinea
            NuevaPublicidad.AcceptsTab = true;//Que Acepte Tabulacion
            NuevaPublicidad.Font = new Font("Arial", 12, FontStyle.Regular);//De formato de letra
            TabPestana.SelectedTab.Controls.Add(NuevaPublicidad); //Agregar el RichTextBox al Tab

            Indice.Add(new Tuple<String, RichTextBox, String>(Titulo, NuevaPublicidad, "SinRuta"));// Agregar a la Lista
            ContarPestañaNueva++;//Aumentar el Contador de Pestaña Nueva
        }
        private void GuardarToken()
        {
            try
            {
                SaveFileDialog GuardarArchivo = new SaveFileDialog();
                GuardarArchivo.Filter = "HTML|*.html";
                GuardarArchivo.Title = "Guardar Reporting Service Token";
                GuardarArchivo.DefaultExt = "html";
                GuardarArchivo.AddExtension = true;
                if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    String Ruta = GuardarArchivo.FileName;
                    StreamWriter Guardar = new StreamWriter(Ruta);
                    Guardar.WriteLine("<html !DOCTYPE> <head><title>Reporting Service - Tokens</title> <style type=\"text/css\"> body {width: 100%; background: #004d4d; font-family: Calibri;} h1{font-size: 30px;text-align: center;color: #fff;font-weight: bold;}table { border-collapse: collapse;margin: 0 auto;}table, th, td {text-align: center;padding: 10px 20px;}th, td {border-bottom: 1px solid #ddd;}th{ background-color: #006767; color: white;padding: 10px;font - size: 20px;font-weight: bold;}tr{background: #fff;}tr:nth-child(even) { background-color: #e5f2f2}tr:hover {background: #4ca6a6; font-weight: bold;}</style></head> <body><h1>Reporting Service - Tokens</h1> <table><tr><th><strong> No. </strong></th><th><strong> Lexema </strong></th><th><strong> Fila </strong></th><th><strong>Columna</strong></th><th><strong>IdToken</strong></th><th><strong>Token</strong></th></th> ");
                    Tokens = AnalizarTexto.getHTMLToken();
                    foreach (var html in Tokens)
                    {
                        Guardar.WriteLine("<tr><td>" + html.Item1 + "</td><td>" + html.Item2 + "</td><td>" + html.Item3 + "</td><td>" + html.Item4 + "</td><td>" + html.Item5 + "</td><td>" + html.Item6 + "</td></tr>");
                    }
                    Guardar.WriteLine("</table></body></html>");
                    Guardar.Close();
                }
            }
            catch
            {

            }
        }
        private void GuardarError()
        {
            try
            {
                SaveFileDialog GuardarArchivo = new SaveFileDialog();
                GuardarArchivo.Filter = "HTML|*.html";
                GuardarArchivo.Title = "Guardar Reporting Service Errores";
                GuardarArchivo.DefaultExt = "html";
                GuardarArchivo.AddExtension = true;
                if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    String Ruta = GuardarArchivo.FileName;
                    StreamWriter Guardar = new StreamWriter(Ruta);
                    Guardar.WriteLine("<html !DOCTYPE> <head><title>Reporting Service - Errores</title> <style type=\"text/css\"> body {width: 100%; background: #004d4d; font-family: Calibri;} h1{font-size: 30px;text-align: center;color: #fff;font-weight: bold;}table { border-collapse: collapse;margin: 0 auto;}table, th, td {text-align: center;padding: 10px 20px;}th, td {border-bottom: 1px solid #ddd;}th{ background-color: #006767; color: white;padding: 10px;font - size: 20px;font-weight: bold;}tr{background: #fff;}tr:nth-child(even) { background-color: #e5f2f2}tr:hover {background: #4ca6a6; font-weight: bold;}</style></head> <body><h1>Reporting Service - Tokens</h1> <table><tr><th><strong> No. </strong></th><th><strong> Fila </strong></th><th><strong>Columna</strong></th><th><strong>Caracter</strong></th><th><strong>Descripcion</strong></th></tr> ");
                    Errores = AnalizarTexto.getHTMLError();
                    foreach (var html in Errores)
                    {
                        Guardar.WriteLine("<tr><td>" + html.Item1 + "</td><td>" + html.Item2 + "</td><td>" + html.Item3 + "</td><td>" + html.Item4 + "</td><td>" + "Desconocido</td></tr>");
                    }
                    Guardar.WriteLine("</table></body></html>");
                    Guardar.Close();
                }
            }
            catch
            {

            }
        }
        private void Analizar()
        {
            foreach (var busqueda in Indice)
            {
                if (busqueda.Item1.Equals(TabPestana.SelectedTab.Text.ToString()))
                {
                    if (busqueda.Item2.Text.Equals(""))
                    {
                        MessageBox.Show("No hay Texto para Analizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Analisis = true;
                        try
                        {
                            NombreGrafico = busqueda.Item1.ToString();
                            AnalizarTexto.AnalizarTexto(busqueda.Item2.Text);
                            MenuCompilar_Valla.Enabled = true;
                            MenuCompilar_Salida.Enabled = true;
                            MessageBox.Show("Se ha realizado el analisis lexico exitosamente.", "Analisis Léxico Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ha ocurrido un error durante  el Analisis Lexico. Intentalo Nuevamente");
                        }
                    }
                }
            }
        }
    }
}
