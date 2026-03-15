namespace PKHeX.WinForms
{
    partial class SAV_Find
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
            if (disposing && (components is not null))
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
            TB_Name = new System.Windows.Forms.TextBox();
            LB_Results = new System.Windows.Forms.ListBox();
            B_Find = new System.Windows.Forms.Button();
            L_Name = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // TB_Name
            // 
            TB_Name.Location = new System.Drawing.Point(12, 25);
            TB_Name.Name = "TB_Name";
            TB_Name.Size = new System.Drawing.Size(200, 23);
            TB_Name.TabIndex = 0;
            // 
            // LB_Results
            // 
            LB_Results.FormattingEnabled = true;
            LB_Results.Location = new System.Drawing.Point(12, 54);
            LB_Results.Name = "LB_Results";
            LB_Results.Size = new System.Drawing.Size(200, 95);
            LB_Results.TabIndex = 1;
            // 
            // B_Find
            // 
            B_Find.Location = new System.Drawing.Point(12, 155);
            B_Find.Name = "B_Find";
            B_Find.Size = new System.Drawing.Size(75, 23);
            B_Find.TabIndex = 2;
            B_Find.Text = "Find";
            B_Find.UseVisualStyleBackColor = true;
            B_Find.Click += B_Find_Click;
            // 
            // L_Name
            // 
            L_Name.AutoSize = true;
            L_Name.Location = new System.Drawing.Point(12, 9);
            L_Name.Name = "L_Name";
            L_Name.Size = new System.Drawing.Size(41, 13);
            L_Name.TabIndex = 3;
            L_Name.Text = "Name:";
            // 
            // SAV_Find
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(224, 190);
            Controls.Add(L_Name);
            Controls.Add(B_Find);
            Controls.Add(LB_Results);
            Controls.Add(TB_Name);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SAV_Find";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Find Pokémon";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.ListBox LB_Results;
        private System.Windows.Forms.Button B_Find;
        private System.Windows.Forms.Label L_Name;
        #endregion
    }
}