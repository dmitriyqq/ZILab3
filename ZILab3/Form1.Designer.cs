
namespace ZILab3
{
    partial class Form1
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
            this.encodeButton = new System.Windows.Forms.Button();
            this.decodeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.encodeFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.decodeFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.keyBox1 = new System.Windows.Forms.TextBox();
            this.keyBox2 = new System.Windows.Forms.TextBox();
            this.keyBox3 = new System.Windows.Forms.TextBox();
            this.keyBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // encodeButton
            // 
            this.encodeButton.Location = new System.Drawing.Point(511, 63);
            this.encodeButton.Margin = new System.Windows.Forms.Padding(4);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(100, 28);
            this.encodeButton.TabIndex = 2;
            this.encodeButton.Text = "Encode File";
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.encodeButton_Click);
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(511, 27);
            this.decodeButton.Margin = new System.Windows.Forms.Padding(4);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(100, 28);
            this.decodeButton.TabIndex = 3;
            this.decodeButton.Text = "Decode File";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key:";
            // 
            // encodeFileDialog
            // 
            this.encodeFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.encodeFileDialog_FileOk);
            // 
            // decodeFileDialog
            // 
            this.decodeFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.decodeFileDialog_FileOk);
            // 
            // keyBox1
            // 
            this.keyBox1.Location = new System.Drawing.Point(12, 49);
            this.keyBox1.Name = "keyBox1";
            this.keyBox1.Size = new System.Drawing.Size(118, 22);
            this.keyBox1.TabIndex = 6;
            this.keyBox1.Text = "99999";
            // 
            // keyBox2
            // 
            this.keyBox2.Location = new System.Drawing.Point(136, 49);
            this.keyBox2.Name = "keyBox2";
            this.keyBox2.Size = new System.Drawing.Size(121, 22);
            this.keyBox2.TabIndex = 7;
            this.keyBox2.Text = "88888";
            // 
            // keyBox3
            // 
            this.keyBox3.Location = new System.Drawing.Point(263, 49);
            this.keyBox3.Name = "keyBox3";
            this.keyBox3.Size = new System.Drawing.Size(119, 22);
            this.keyBox3.TabIndex = 8;
            this.keyBox3.Text = "77777";
            // 
            // keyBox4
            // 
            this.keyBox4.Location = new System.Drawing.Point(388, 49);
            this.keyBox4.Name = "keyBox4";
            this.keyBox4.Size = new System.Drawing.Size(116, 22);
            this.keyBox4.TabIndex = 9;
            this.keyBox4.Text = "66666";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 108);
            this.Controls.Add(this.keyBox4);
            this.Controls.Add(this.keyBox3);
            this.Controls.Add(this.keyBox2);
            this.Controls.Add(this.keyBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.encodeButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "ZILab3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog encodeFileDialog;
        private System.Windows.Forms.OpenFileDialog decodeFileDialog;
        private System.Windows.Forms.TextBox keyBox1;
        private System.Windows.Forms.TextBox keyBox2;
        private System.Windows.Forms.TextBox keyBox3;
        private System.Windows.Forms.TextBox keyBox4;
    }
}

