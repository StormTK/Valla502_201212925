namespace Valla502_201212925
{
    partial class Form_Analizador
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Analizador));
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.MenuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuArchivo_NuevaPestaña = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuArchivo_Abrir = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuArchivo_Guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuArchivo_Salir = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCompilar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCompilar_Analizar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCompilar_Valla = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCompilar_Salida = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAyuda_Usuario = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAyuda_Tecnico = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAyuda_Acercade = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPestana = new System.Windows.Forms.TabControl();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            resources.ApplyResources(this.Menu, "Menu");
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuArchivo,
            this.MenuCompilar,
            this.MenuAyuda});
            this.Menu.Name = "Menu";
            // 
            // MenuArchivo
            // 
            resources.ApplyResources(this.MenuArchivo, "MenuArchivo");
            this.MenuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuArchivo_NuevaPestaña,
            this.toolStripSeparator2,
            this.MenuArchivo_Abrir,
            this.MenuArchivo_Guardar,
            this.toolStripSeparator1,
            this.MenuArchivo_Salir});
            this.MenuArchivo.Name = "MenuArchivo";
            // 
            // MenuArchivo_NuevaPestaña
            // 
            resources.ApplyResources(this.MenuArchivo_NuevaPestaña, "MenuArchivo_NuevaPestaña");
            this.MenuArchivo_NuevaPestaña.Name = "MenuArchivo_NuevaPestaña";
            this.MenuArchivo_NuevaPestaña.Click += new System.EventHandler(this.MenuArchivo_NuevaPestaña_Click);
            // 
            // MenuArchivo_Abrir
            // 
            resources.ApplyResources(this.MenuArchivo_Abrir, "MenuArchivo_Abrir");
            this.MenuArchivo_Abrir.Name = "MenuArchivo_Abrir";
            this.MenuArchivo_Abrir.Click += new System.EventHandler(this.MenuArchivo_Abrir_Click);
            // 
            // MenuArchivo_Guardar
            // 
            resources.ApplyResources(this.MenuArchivo_Guardar, "MenuArchivo_Guardar");
            this.MenuArchivo_Guardar.Name = "MenuArchivo_Guardar";
            this.MenuArchivo_Guardar.Click += new System.EventHandler(this.MenuArchivo_Guardar_Click);
            // 
            // MenuArchivo_Salir
            // 
            resources.ApplyResources(this.MenuArchivo_Salir, "MenuArchivo_Salir");
            this.MenuArchivo_Salir.Name = "MenuArchivo_Salir";
            this.MenuArchivo_Salir.Click += new System.EventHandler(this.MenuArchivo_Salir_Click);
            // 
            // MenuCompilar
            // 
            resources.ApplyResources(this.MenuCompilar, "MenuCompilar");
            this.MenuCompilar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCompilar_Analizar,
            this.MenuCompilar_Valla,
            this.MenuCompilar_Salida});
            this.MenuCompilar.Name = "MenuCompilar";
            // 
            // MenuCompilar_Analizar
            // 
            resources.ApplyResources(this.MenuCompilar_Analizar, "MenuCompilar_Analizar");
            this.MenuCompilar_Analizar.Name = "MenuCompilar_Analizar";
            this.MenuCompilar_Analizar.Click += new System.EventHandler(this.MenuCompilar_Analizar_Click);
            // 
            // MenuCompilar_Valla
            // 
            resources.ApplyResources(this.MenuCompilar_Valla, "MenuCompilar_Valla");
            this.MenuCompilar_Valla.Name = "MenuCompilar_Valla";
            this.MenuCompilar_Valla.Click += new System.EventHandler(this.MenuCompilar_Valla_Click);
            // 
            // MenuCompilar_Salida
            // 
            resources.ApplyResources(this.MenuCompilar_Salida, "MenuCompilar_Salida");
            this.MenuCompilar_Salida.Name = "MenuCompilar_Salida";
            this.MenuCompilar_Salida.Click += new System.EventHandler(this.MenuCompilar_Salida_Click);
            // 
            // MenuAyuda
            // 
            resources.ApplyResources(this.MenuAyuda, "MenuAyuda");
            this.MenuAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAyuda_Usuario,
            this.MenuAyuda_Tecnico,
            this.MenuAyuda_Acercade});
            this.MenuAyuda.Name = "MenuAyuda";
            // 
            // MenuAyuda_Usuario
            // 
            resources.ApplyResources(this.MenuAyuda_Usuario, "MenuAyuda_Usuario");
            this.MenuAyuda_Usuario.Name = "MenuAyuda_Usuario";
            this.MenuAyuda_Usuario.Click += new System.EventHandler(this.MenuAyuda_Usuario_Click);
            // 
            // MenuAyuda_Tecnico
            // 
            resources.ApplyResources(this.MenuAyuda_Tecnico, "MenuAyuda_Tecnico");
            this.MenuAyuda_Tecnico.Name = "MenuAyuda_Tecnico";
            this.MenuAyuda_Tecnico.Click += new System.EventHandler(this.MenuAyuda_Tecnico_Click);
            // 
            // MenuAyuda_Acercade
            // 
            resources.ApplyResources(this.MenuAyuda_Acercade, "MenuAyuda_Acercade");
            this.MenuAyuda_Acercade.Name = "MenuAyuda_Acercade";
            this.MenuAyuda_Acercade.Click += new System.EventHandler(this.MenuAyuda_Acercade_Click);
            // 
            // TabPestana
            // 
            resources.ApplyResources(this.TabPestana, "TabPestana");
            this.TabPestana.Name = "TabPestana";
            this.TabPestana.SelectedIndex = 0;
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // Form_Analizador
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabPestana);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "Form_Analizador";
            this.Load += new System.EventHandler(this.Analizador_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuArchivo;
        private System.Windows.Forms.ToolStripMenuItem MenuArchivo_NuevaPestaña;
        private System.Windows.Forms.ToolStripMenuItem MenuArchivo_Abrir;
        private System.Windows.Forms.ToolStripMenuItem MenuArchivo_Guardar;
        private System.Windows.Forms.ToolStripMenuItem MenuArchivo_Salir;
        private System.Windows.Forms.ToolStripMenuItem MenuCompilar;
        private System.Windows.Forms.ToolStripMenuItem MenuCompilar_Analizar;
        private System.Windows.Forms.ToolStripMenuItem MenuCompilar_Valla;
        private System.Windows.Forms.ToolStripMenuItem MenuCompilar_Salida;
        private System.Windows.Forms.ToolStripMenuItem MenuAyuda;
        private System.Windows.Forms.ToolStripMenuItem MenuAyuda_Usuario;
        private System.Windows.Forms.ToolStripMenuItem MenuAyuda_Tecnico;
        private System.Windows.Forms.ToolStripMenuItem MenuAyuda_Acercade;
        private System.Windows.Forms.TabControl TabPestana;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

