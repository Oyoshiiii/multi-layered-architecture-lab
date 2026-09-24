namespace ViewWinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.prosthesesDataGridView = new System.Windows.Forms.DataGridView();
            this.GetByIDBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ChangeBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.GroupByBodyPart = new System.Windows.Forms.Button();
            this.FindByOriginBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descending = new System.Windows.Forms.RadioButton();
            this.ascending = new System.Windows.Forms.RadioButton();
            this.GetAllBtn = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BodyPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentOfSanityLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuffDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebuffDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.prosthesesDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.prosthesesDataGridView.Location = new System.Drawing.Point(202, 29);
            this.prosthesesDataGridView.MultiSelect = false;
            this.prosthesesDataGridView.Name = "prosthesesDataGridView";
            this.prosthesesDataGridView.RowHeadersVisible = false;
            this.prosthesesDataGridView.RowHeadersWidth = 53;
            this.prosthesesDataGridView.RowTemplate.Height = 24;
            this.prosthesesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.prosthesesDataGridView.Size = new System.Drawing.Size(1024, 556);
            this.prosthesesDataGridView.TabIndex = 0;
            // 
            // GetByIDBtn
            // 
            this.GetByIDBtn.Location = new System.Drawing.Point(24, 90);
            this.GetByIDBtn.Name = "GetByIDBtn";
            this.GetByIDBtn.Size = new System.Drawing.Size(156, 45);
            this.GetByIDBtn.TabIndex = 1;
            this.GetByIDBtn.Text = "Поиск по ID";
            this.GetByIDBtn.UseVisualStyleBackColor = true;
            this.GetByIDBtn.Click += new System.EventHandler(this.GetByIDBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(24, 154);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(156, 45);
            this.AddBtn.TabIndex = 2;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // ChangeBtn
            // 
            this.ChangeBtn.Location = new System.Drawing.Point(24, 219);
            this.ChangeBtn.Name = "ChangeBtn";
            this.ChangeBtn.Size = new System.Drawing.Size(156, 45);
            this.ChangeBtn.TabIndex = 3;
            this.ChangeBtn.Text = "Изменить";
            this.ChangeBtn.UseVisualStyleBackColor = true;
            this.ChangeBtn.Click += new System.EventHandler(this.ChangeBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(24, 284);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(156, 45);
            this.DeleteBtn.TabIndex = 4;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // GroupByBodyPart
            // 
            this.GroupByBodyPart.Location = new System.Drawing.Point(24, 366);
            this.GroupByBodyPart.Name = "GroupByBodyPart";
            this.GroupByBodyPart.Size = new System.Drawing.Size(156, 45);
            this.GroupByBodyPart.TabIndex = 5;
            this.GroupByBodyPart.Text = "Группировать по частям тела";
            this.GroupByBodyPart.UseVisualStyleBackColor = true;
            this.GroupByBodyPart.Click += new System.EventHandler(this.GroupByBodyPart_Click);
            // 
            // FindByOriginBtn
            // 
            this.FindByOriginBtn.Location = new System.Drawing.Point(24, 432);
            this.FindByOriginBtn.Name = "FindByOriginBtn";
            this.FindByOriginBtn.Size = new System.Drawing.Size(156, 45);
            this.FindByOriginBtn.TabIndex = 6;
            this.FindByOriginBtn.Text = "Поиск по месту нахождения";
            this.FindByOriginBtn.UseVisualStyleBackColor = true;
            this.FindByOriginBtn.Click += new System.EventHandler(this.FindByOriginBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descending);
            this.groupBox1.Controls.Add(this.ascending);
            this.groupBox1.Location = new System.Drawing.Point(30, 496);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 106);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сортировка по % потери рассудка";
            // 
            // descending
            // 
            this.descending.AutoSize = true;
            this.descending.Location = new System.Drawing.Point(7, 69);
            this.descending.Name = "descending";
            this.descending.Size = new System.Drawing.Size(114, 20);
            this.descending.TabIndex = 1;
            this.descending.TabStop = true;
            this.descending.Text = "по убыванию";
            this.descending.UseVisualStyleBackColor = true;
            this.descending.CheckedChanged += new System.EventHandler(this.descending_CheckedChanged);
            // 
            // ascending
            // 
            this.ascending.AutoSize = true;
            this.ascending.Location = new System.Drawing.Point(7, 43);
            this.ascending.Name = "ascending";
            this.ascending.Size = new System.Drawing.Size(135, 20);
            this.ascending.TabIndex = 0;
            this.ascending.TabStop = true;
            this.ascending.Text = "по возрастанию";
            this.ascending.UseVisualStyleBackColor = true;
            this.ascending.CheckedChanged += new System.EventHandler(this.ascending_CheckedChanged);
            // 
            // GetAllBtn
            // 
            this.GetAllBtn.Location = new System.Drawing.Point(24, 29);
            this.GetAllBtn.Name = "GetAllBtn";
            this.GetAllBtn.Size = new System.Drawing.Size(156, 45);
            this.GetAllBtn.TabIndex = 8;
            this.GetAllBtn.Text = "Вывести все";
            this.GetAllBtn.UseVisualStyleBackColor = true;
            this.GetAllBtn.Click += new System.EventHandler(this.GetAllBtn_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 621);
            this.Controls.Add(this.GetAllBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FindByOriginBtn);
            this.Controls.Add(this.GroupByBodyPart);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.ChangeBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.GetByIDBtn);
            this.Controls.Add(this.prosthesesDataGridView);
            this.MaximumSize = new System.Drawing.Size(1270, 669);
            this.MinimumSize = new System.Drawing.Size(1270, 669);
            this.Name = "MainForm";
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.prosthesesDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView prosthesesDataGridView;
        private System.Windows.Forms.Button GetByIDBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button ChangeBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button GroupByBodyPart;
        private System.Windows.Forms.Button FindByOriginBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton descending;
        private System.Windows.Forms.RadioButton ascending;
        private System.Windows.Forms.Button GetAllBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BodyPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentOfSanityLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuffDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebuffDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origin;
    }
}

