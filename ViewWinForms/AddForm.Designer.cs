namespace ViewWinForms
{
    partial class AddForm
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
            this.lblModelName = new System.Windows.Forms.Label();
            this.TxtModelName = new System.Windows.Forms.TextBox();
            this.lblBodyPart = new System.Windows.Forms.Label();
            this.CmbBodyPart = new System.Windows.Forms.ComboBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.NumPercentOfSanityLoss = new System.Windows.Forms.NumericUpDown();
            this.lblBuff = new System.Windows.Forms.Label();
            this.TxtBuffDescript = new System.Windows.Forms.TextBox();
            this.lblDebuff = new System.Windows.Forms.Label();
            this.TxtDebuffDescript = new System.Windows.Forms.TextBox();
            this.lblOrigin = new System.Windows.Forms.Label();
            this.CmbOrigin = new System.Windows.Forms.ComboBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumPercentOfSanityLoss)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Location = new System.Drawing.Point(13, 67);
            this.lblModelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(60, 16);
            this.lblModelName.TabIndex = 2;
            this.lblModelName.Text = "Модель:";
            // 
            // TxtModelName
            // 
            this.TxtModelName.Location = new System.Drawing.Point(213, 64);
            this.TxtModelName.Margin = new System.Windows.Forms.Padding(4);
            this.TxtModelName.Name = "TxtModelName";
            this.TxtModelName.Size = new System.Drawing.Size(399, 22);
            this.TxtModelName.TabIndex = 3;
            // 
            // lblBodyPart
            // 
            this.lblBodyPart.AutoSize = true;
            this.lblBodyPart.Location = new System.Drawing.Point(13, 104);
            this.lblBodyPart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBodyPart.Name = "lblBodyPart";
            this.lblBodyPart.Size = new System.Drawing.Size(82, 16);
            this.lblBodyPart.TabIndex = 4;
            this.lblBodyPart.Text = "Часть тела:";
            // 
            // CmbBodyPart
            // 
            this.CmbBodyPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBodyPart.FormattingEnabled = true;
            this.CmbBodyPart.Location = new System.Drawing.Point(213, 101);
            this.CmbBodyPart.Margin = new System.Windows.Forms.Padding(4);
            this.CmbBodyPart.Name = "CmbBodyPart";
            this.CmbBodyPart.Size = new System.Drawing.Size(160, 24);
            this.CmbBodyPart.TabIndex = 5;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(13, 141);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(136, 16);
            this.lblPercent.TabIndex = 6;
            this.lblPercent.Text = "% потери рассудка:";
            // 
            // NumPercentOfSanityLoss
            // 
            this.NumPercentOfSanityLoss.Location = new System.Drawing.Point(213, 139);
            this.NumPercentOfSanityLoss.Margin = new System.Windows.Forms.Padding(4);
            this.NumPercentOfSanityLoss.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NumPercentOfSanityLoss.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumPercentOfSanityLoss.Name = "NumPercentOfSanityLoss";
            this.NumPercentOfSanityLoss.Size = new System.Drawing.Size(107, 22);
            this.NumPercentOfSanityLoss.TabIndex = 7;
            this.NumPercentOfSanityLoss.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblBuff
            // 
            this.lblBuff.AutoSize = true;
            this.lblBuff.Location = new System.Drawing.Point(13, 177);
            this.lblBuff.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuff.Name = "lblBuff";
            this.lblBuff.Size = new System.Drawing.Size(49, 16);
            this.lblBuff.TabIndex = 8;
            this.lblBuff.Text = "Бафф:";
            // 
            // TxtBuffDescript
            // 
            this.TxtBuffDescript.Location = new System.Drawing.Point(213, 175);
            this.TxtBuffDescript.Margin = new System.Windows.Forms.Padding(4);
            this.TxtBuffDescript.Multiline = true;
            this.TxtBuffDescript.Name = "TxtBuffDescript";
            this.TxtBuffDescript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtBuffDescript.Size = new System.Drawing.Size(399, 73);
            this.TxtBuffDescript.TabIndex = 9;
            // 
            // lblDebuff
            // 
            this.lblDebuff.AutoSize = true;
            this.lblDebuff.Location = new System.Drawing.Point(13, 264);
            this.lblDebuff.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDebuff.Name = "lblDebuff";
            this.lblDebuff.Size = new System.Drawing.Size(65, 16);
            this.lblDebuff.TabIndex = 10;
            this.lblDebuff.Text = "Дебафф:";
            // 
            // TxtDebuffDescript
            // 
            this.TxtDebuffDescript.Location = new System.Drawing.Point(213, 261);
            this.TxtDebuffDescript.Margin = new System.Windows.Forms.Padding(4);
            this.TxtDebuffDescript.Multiline = true;
            this.TxtDebuffDescript.Name = "TxtDebuffDescript";
            this.TxtDebuffDescript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDebuffDescript.Size = new System.Drawing.Size(399, 73);
            this.TxtDebuffDescript.TabIndex = 11;
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.Location = new System.Drawing.Point(13, 350);
            this.lblOrigin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(189, 16);
            this.lblOrigin.TabIndex = 12;
            this.lblOrigin.Text = "Локация/место нахождения:";
            // 
            // CmbOrigin
            // 
            this.CmbOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOrigin.FormattingEnabled = true;
            this.CmbOrigin.Location = new System.Drawing.Point(213, 347);
            this.CmbOrigin.Margin = new System.Windows.Forms.Padding(4);
            this.CmbOrigin.Name = "CmbOrigin";
            this.CmbOrigin.Size = new System.Drawing.Size(399, 24);
            this.CmbOrigin.TabIndex = 13;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(333, 394);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(160, 37);
            this.SaveBtn.TabIndex = 14;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 468);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CmbOrigin);
            this.Controls.Add(this.lblOrigin);
            this.Controls.Add(this.TxtDebuffDescript);
            this.Controls.Add(this.lblDebuff);
            this.Controls.Add(this.TxtBuffDescript);
            this.Controls.Add(this.lblBuff);
            this.Controls.Add(this.NumPercentOfSanityLoss);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.CmbBodyPart);
            this.Controls.Add(this.lblBodyPart);
            this.Controls.Add(this.TxtModelName);
            this.Controls.Add(this.lblModelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(685, 516);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(685, 516);
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Form";
            ((System.ComponentModel.ISupportInitialize)(this.NumPercentOfSanityLoss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.TextBox TxtModelName;
        private System.Windows.Forms.Label lblBodyPart;
        private System.Windows.Forms.ComboBox CmbBodyPart;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.NumericUpDown NumPercentOfSanityLoss;
        private System.Windows.Forms.Label lblBuff;
        private System.Windows.Forms.TextBox TxtBuffDescript;
        private System.Windows.Forms.Label lblDebuff;
        private System.Windows.Forms.TextBox TxtDebuffDescript;
        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.ComboBox CmbOrigin;
        private System.Windows.Forms.Button SaveBtn;
    }
}