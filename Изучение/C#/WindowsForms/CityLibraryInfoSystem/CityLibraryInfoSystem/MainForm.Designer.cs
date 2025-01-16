namespace CityLibraryInfoSystem
{
    partial class MainForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            comboBox_TablesName = new ComboBox();
            dataGridView_Table = new DataGridView();
            label_HelpText = new Label();
            btn_Database = new Button();
            btn_SendUpdatedData = new Button();
            btnManual = new Button();
            label_Manual = new Label();
            panel_Manual = new Panel();
            btn_LeaveManual = new Button();
            btn_ExportTable = new Button();
            btn_Import = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Table).BeginInit();
            SuspendLayout();
            // 
            // comboBox_TablesName
            // 
            comboBox_TablesName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TablesName.FormattingEnabled = true;
            comboBox_TablesName.Location = new Point(202, 0);
            comboBox_TablesName.Name = "comboBox_TablesName";
            comboBox_TablesName.Size = new Size(482, 39);
            comboBox_TablesName.TabIndex = 1;
            comboBox_TablesName.SelectedIndexChanged += comboBox_TablesName_SelectedIndexChanged;
            // 
            // dataGridView_Table
            // 
            dataGridView_Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView_Table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView_Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Table.Location = new Point(202, 45);
            dataGridView_Table.Name = "dataGridView_Table";
            dataGridView_Table.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView_Table.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_Table.Size = new Size(482, 420);
            dataGridView_Table.TabIndex = 2;
            // 
            // label_HelpText
            // 
            label_HelpText.AutoSize = true;
            label_HelpText.Font = new Font("Times New Roman", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_HelpText.Location = new Point(-1, 0);
            label_HelpText.Name = "label_HelpText";
            label_HelpText.Size = new Size(193, 40);
            label_HelpText.TabIndex = 3;
            label_HelpText.Text = "    МЕНЮ   \r\n";
            // 
            // btn_Database
            // 
            btn_Database.Location = new Point(-5, 45);
            btn_Database.Name = "btn_Database";
            btn_Database.Size = new Size(197, 39);
            btn_Database.TabIndex = 4;
            btn_Database.Text = "База данных";
            btn_Database.UseVisualStyleBackColor = true;
            btn_Database.Click += btn_Database_Click;
            // 
            // btn_SendUpdatedData
            // 
            btn_SendUpdatedData.Location = new Point(-5, 90);
            btn_SendUpdatedData.Name = "btn_SendUpdatedData";
            btn_SendUpdatedData.Size = new Size(197, 39);
            btn_SendUpdatedData.TabIndex = 5;
            btn_SendUpdatedData.Text = "Отправить";
            btn_SendUpdatedData.UseVisualStyleBackColor = true;
            btn_SendUpdatedData.Click += btn_SendUpdatedData_Click;
            // 
            // btnManual
            // 
            btnManual.Location = new Point(-5, 135);
            btnManual.Name = "btnManual";
            btnManual.Size = new Size(197, 39);
            btnManual.TabIndex = 6;
            btnManual.Text = "Руководство";
            btnManual.UseVisualStyleBackColor = true;
            btnManual.Click += btnManual_Click;
            // 
            // label_Manual
            // 
            label_Manual.AutoSize = true;
            label_Manual.Location = new Point(295, 0);
            label_Manual.Name = "label_Manual";
            label_Manual.Size = new Size(314, 31);
            label_Manual.TabIndex = 7;
            label_Manual.Text = "Руководство пользователя";
            label_Manual.Visible = false;
            // 
            // panel_Manual
            // 
            panel_Manual.AutoScroll = true;
            panel_Manual.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            panel_Manual.Location = new Point(202, 45);
            panel_Manual.Name = "panel_Manual";
            panel_Manual.Size = new Size(482, 420);
            panel_Manual.TabIndex = 9;
            panel_Manual.Visible = false;
            // 
            // btn_LeaveManual
            // 
            btn_LeaveManual.Location = new Point(-5, 426);
            btn_LeaveManual.Name = "btn_LeaveManual";
            btn_LeaveManual.Size = new Size(197, 39);
            btn_LeaveManual.TabIndex = 10;
            btn_LeaveManual.Text = "Назад";
            btn_LeaveManual.UseVisualStyleBackColor = true;
            btn_LeaveManual.Visible = false;
            btn_LeaveManual.Click += btn_LeaveManual_Click;
            // 
            // btn_ExportTable
            // 
            btn_ExportTable.Location = new Point(-1, 180);
            btn_ExportTable.Name = "btn_ExportTable";
            btn_ExportTable.Size = new Size(197, 39);
            btn_ExportTable.TabIndex = 11;
            btn_ExportTable.Text = "Экспорт";
            btn_ExportTable.UseVisualStyleBackColor = true;
            btn_ExportTable.Click += btn_ImportAndExportXML_Click;
            // 
            // btn_Import
            // 
            btn_Import.Location = new Point(-1, 225);
            btn_Import.Name = "btn_Import";
            btn_Import.Size = new Size(197, 39);
            btn_Import.TabIndex = 12;
            btn_Import.Text = "Импорт";
            btn_Import.UseVisualStyleBackColor = true;
            btn_Import.Click += btn_Import_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(15F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 465);
            Controls.Add(btn_Import);
            Controls.Add(btn_ExportTable);
            Controls.Add(btn_LeaveManual);
            Controls.Add(btnManual);
            Controls.Add(btn_SendUpdatedData);
            Controls.Add(btn_Database);
            Controls.Add(label_HelpText);
            Controls.Add(comboBox_TablesName);
            Controls.Add(label_Manual);
            Controls.Add(dataGridView_Table);
            Controls.Add(panel_Manual);
            Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(8, 7, 8, 7);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CityLibraryInfoSystem";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            Resize += MainForm_Resize_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView_Table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_TablesName;
        private DataGridView dataGridView_Table;
        private Label label_HelpText;
        private Button btn_Database;
        private Button btn_SendUpdatedData;
        private Button btnManual;
        private Label label_Manual;
        private Panel panel_Manual;
        private Button btn_LeaveManual;
        private Button btn_ExportTable;
        private Button btn_Import;
    }
}