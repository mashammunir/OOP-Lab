namespace Color_Changer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // textBox1
            this.textBox1.Location = new System.Drawing.Point(200, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 22);
            this.textBox1.TabIndex = 0;
            // nextButton
            this.nextButton.Location = new System.Drawing.Point(300, 200);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(100, 30);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // previousButton
            this.previousButton.Location = new System.Drawing.Point(150, 200);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(100, 30);
            this.previousButton.TabIndex = 2;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Color Changer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
    }
}