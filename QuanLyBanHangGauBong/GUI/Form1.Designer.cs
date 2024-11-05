namespace GUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.productItem1 = new UC.ProductItem();
            this.SuspendLayout();
            // 
            // productItem1
            // 
            this.productItem1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.productItem1.Location = new System.Drawing.Point(0, 0);
            this.productItem1.Name = "productItem1";
            this.productItem1.ProductImage = ((System.Drawing.Image)(resources.GetObject("productItem1.ProductImage")));
            this.productItem1.ProductPrice = "275,000 đ";
            this.productItem1.Size = new System.Drawing.Size(255, 376);
            this.productItem1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1867, 886);
            this.Controls.Add(this.productItem1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UC.ProductItem productItem1;
    }
}

