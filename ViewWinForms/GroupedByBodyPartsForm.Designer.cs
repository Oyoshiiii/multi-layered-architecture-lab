namespace ViewWinForms
{
    partial class GroupedByBodyPartsForm
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
            this.prosthesesDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BodyPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentOfSanityLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuffDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebuffDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.prosthesesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // prosthesesDataGridView
            // 
            this.prosthesesDataGridView.AllowUserToAddRows = false;
            this.prosthesesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prosthesesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ModelName,
            this.BodyPart,
            this.PercentOfSanityLoss,
            this.BuffDescription,
            this.DebuffDescription,
            this.Origin});
            this.prosthesesDataGridView.Location = new System.Drawing.Point(26, 21);
            this.prosthesesDataGridView.MultiSelect = false;
            this.prosthesesDataGridView.Name = "prosthesesDataGridView";
            this.prosthesesDataGridView.RowHeadersVisible = false;
            this.prosthesesDataGridView.RowHeadersWidth = 53;
            this.prosthesesDataGridView.RowTemplate.Height = 24;
            this.prosthesesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.prosthesesDataGridView.Size = new System.Drawing.Size(1024, 548);
            this.prosthesesDataGridView.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.MinimumWidth = 7;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Id.Width = 30;
            // 
            // ModelName
            // 
            this.ModelName.HeaderText = "Модель";
            this.ModelName.MinimumWidth = 7;
            this.ModelName.Name = "ModelName";
            this.ModelName.ReadOnly = true;
            this.ModelName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ModelName.Width = 130;
            // 
            // BodyPart
            // 
            this.BodyPart.HeaderText = "Часть тела";
            this.BodyPart.MinimumWidth = 7;
            this.BodyPart.Name = "BodyPart";
            this.BodyPart.ReadOnly = true;
            this.BodyPart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BodyPart.Width = 70;
            // 
            // PercentOfSanityLoss
            // 
            this.PercentOfSanityLoss.HeaderText = "Потеря рассудка";
            this.PercentOfSanityLoss.MinimumWidth = 7;
            this.PercentOfSanityLoss.Name = "PercentOfSanityLoss";
            this.PercentOfSanityLoss.ReadOnly = true;
            this.PercentOfSanityLoss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PercentOfSanityLoss.Width = 70;
            // 
            // BuffDescription
            // 
            this.BuffDescription.HeaderText = "Баффы";
            this.BuffDescription.MinimumWidth = 7;
            this.BuffDescription.Name = "BuffDescription";
            this.BuffDescription.ReadOnly = true;
            this.BuffDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BuffDescription.Width = 167;
            // 
            // DebuffDescription
            // 
            this.DebuffDescription.HeaderText = "Дебаффы";
            this.DebuffDescription.MinimumWidth = 7;
            this.DebuffDescription.Name = "DebuffDescription";
            this.DebuffDescription.ReadOnly = true;
            this.DebuffDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DebuffDescription.Width = 167;
            // 
            // Origin
            // 
            this.Origin.HeaderText = "Локация/место нахождения";
            this.Origin.MinimumWidth = 7;
            this.Origin.Name = "Origin";
            this.Origin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Origin.Width = 129;
            // 
            // GroupedByBodyPartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 591);
            this.Controls.Add(this.prosthesesDataGridView);
            this.MaximumSize = new System.Drawing.Size(1086, 639);
            this.MinimumSize = new System.Drawing.Size(1086, 639);
            this.Name = "GroupedByBodyPartsForm";
            this.Text = "GroupedByBodyPartsForm";
            ((System.ComponentModel.ISupportInitialize)(this.prosthesesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView prosthesesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BodyPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentOfSanityLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuffDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebuffDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origin;
    }
}