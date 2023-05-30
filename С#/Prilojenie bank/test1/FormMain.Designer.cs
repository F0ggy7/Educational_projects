
namespace test1
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonGrid = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.test0DataSet = new test1.test0DataSet();
            this.allClientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.allClientTableAdapter = new test1.test0DataSetTableAdapters.AllClientTableAdapter();
            this.allClientBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.test0DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.allClientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.allClientsTableAdapter = new test1.test0DataSetTableAdapters.AllClientsTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Refresh = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TableslistView = new System.Windows.Forms.ListView();
            this.ReadBT = new System.Windows.Forms.Button();
            this.ScriptTB = new System.Windows.Forms.TextBox();
            this.ReadUni = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test0DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allClientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allClientBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test0DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allClientsBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(1328, 266);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // ButtonGrid
            // 
            this.ButtonGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonGrid.Enabled = false;
            this.ButtonGrid.Location = new System.Drawing.Point(129, 401);
            this.ButtonGrid.Name = "ButtonGrid";
            this.ButtonGrid.Size = new System.Drawing.Size(113, 38);
            this.ButtonGrid.TabIndex = 2;
            this.ButtonGrid.Text = "Выполнить Sql запрос";
            this.ButtonGrid.UseVisualStyleBackColor = true;
            this.ButtonGrid.Click += new System.EventHandler(this.ButtonGrid_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(10, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Загрузка данных из БД в xml файл";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // test0DataSet
            // 
            this.test0DataSet.DataSetName = "test0DataSet";
            this.test0DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // allClientBindingSource
            // 
            this.allClientBindingSource.DataMember = "AllClient";
            this.allClientBindingSource.DataSource = this.test0DataSet;
            // 
            // allClientTableAdapter
            // 
            this.allClientTableAdapter.ClearBeforeFill = true;
            // 
            // allClientBindingSource1
            // 
            this.allClientBindingSource1.DataMember = "AllClient";
            this.allClientBindingSource1.DataSource = this.test0DataSet;
            // 
            // test0DataSetBindingSource
            // 
            this.test0DataSetBindingSource.DataSource = this.test0DataSet;
            this.test0DataSetBindingSource.Position = 0;
            // 
            // allClientsBindingSource
            // 
            this.allClientsBindingSource.DataMember = "AllClients";
            this.allClientsBindingSource.DataSource = this.test0DataSetBindingSource;
            // 
            // allClientsTableAdapter
            // 
            this.allClientsTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.Refresh);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.TableslistView);
            this.panel2.Location = new System.Drawing.Point(1108, 284);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 155);
            this.panel2.TabIndex = 1;
            // 
            // Refresh
            // 
            this.Refresh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Refresh.Location = new System.Drawing.Point(200, 3);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(29, 33);
            this.Refresh.TabIndex = 8;
            this.Refresh.Text = "R";
            this.Refresh.UseVisualStyleBackColor = false;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(196, 33);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Список таблиц test0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TableslistView
            // 
            this.TableslistView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableslistView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TableslistView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TableslistView.HideSelection = false;
            this.TableslistView.Location = new System.Drawing.Point(3, 36);
            this.TableslistView.Name = "TableslistView";
            this.TableslistView.Size = new System.Drawing.Size(226, 116);
            this.TableslistView.TabIndex = 6;
            this.TableslistView.UseCompatibleStateImageBehavior = false;
            this.TableslistView.View = System.Windows.Forms.View.List;
            this.TableslistView.SelectedIndexChanged += new System.EventHandler(this.TableslistView_SelectedIndexChanged);
            // 
            // ReadBT
            // 
            this.ReadBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReadBT.Location = new System.Drawing.Point(248, 401);
            this.ReadBT.Name = "ReadBT";
            this.ReadBT.Size = new System.Drawing.Size(113, 38);
            this.ReadBT.TabIndex = 6;
            this.ReadBT.Text = "Read XML file";
            this.ReadBT.UseVisualStyleBackColor = true;
            this.ReadBT.Click += new System.EventHandler(this.ReadBT_Click);
            // 
            // ScriptTB
            // 
            this.ScriptTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ScriptTB.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScriptTB.Location = new System.Drawing.Point(9, 284);
            this.ScriptTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ScriptTB.Multiline = true;
            this.ScriptTB.Name = "ScriptTB";
            this.ScriptTB.Size = new System.Drawing.Size(1094, 94);
            this.ScriptTB.TabIndex = 0;
            this.ScriptTB.Text = "Введите Sql запрос";
            this.ScriptTB.TextChanged += new System.EventHandler(this.ScriptTB_TextChanged);
            this.ScriptTB.Enter += new System.EventHandler(this.ScriptTB_Enter);
            this.ScriptTB.Leave += new System.EventHandler(this.ScriptTB_Leave);
            // 
            // ReadUni
            // 
            this.ReadUni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReadUni.Location = new System.Drawing.Point(367, 401);
            this.ReadUni.Name = "ReadUni";
            this.ReadUni.Size = new System.Drawing.Size(113, 38);
            this.ReadUni.TabIndex = 7;
            this.ReadUni.Text = "Универсальное чтение xml";
            this.ReadUni.UseVisualStyleBackColor = true;
            this.ReadUni.Click += new System.EventHandler(this.ReadUni_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 450);
            this.Controls.Add(this.ReadUni);
            this.Controls.Add(this.ScriptTB);
            this.Controls.Add(this.ReadBT);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ButtonGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MinimumSize = new System.Drawing.Size(1364, 489);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test0DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allClientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allClientBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test0DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allClientsBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonGrid;
        private System.Windows.Forms.Button button1;
        private test0DataSet test0DataSet;
        private System.Windows.Forms.BindingSource allClientBindingSource;
        private test0DataSetTableAdapters.AllClientTableAdapter allClientTableAdapter;
        private System.Windows.Forms.BindingSource test0DataSetBindingSource;
        private System.Windows.Forms.BindingSource allClientBindingSource1;
        private System.Windows.Forms.BindingSource allClientsBindingSource;
        private test0DataSetTableAdapters.AllClientsTableAdapter allClientsTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView TableslistView;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button ReadBT;
        private System.Windows.Forms.TextBox ScriptTB;
        private System.Windows.Forms.Button ReadUni;
    }
}