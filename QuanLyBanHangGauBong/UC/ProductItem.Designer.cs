namespace UC
{
    partial class ProductItem
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productImage = new System.Windows.Forms.PictureBox();
            this.productName = new System.Windows.Forms.Label();
            this.productPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).BeginInit();
            this.SuspendLayout();
            // 
            // productImage
            // 
            this.productImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.productImage.Image = global::UC.Properties.Resources.Gau_Bong_Capybara_Cosplay_Ca_Map_3_300x300_transformed;
            this.productImage.Location = new System.Drawing.Point(0, 0);
            this.productImage.Name = "productImage";
            this.productImage.Size = new System.Drawing.Size(255, 255);
            this.productImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.productImage.TabIndex = 0;
            this.productImage.TabStop = false;
            // 
            // productName
            // 
            this.productName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.productName.AutoSize = true;
            this.productName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productName.Location = new System.Drawing.Point(0, 258);
            this.productName.MaximumSize = new System.Drawing.Size(255, 0);
            this.productName.MinimumSize = new System.Drawing.Size(255, 0);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(255, 46);
            this.productName.TabIndex = 1;
            this.productName.Text = "Gấu Bông Capybara Cosplay Cá Mập";
            this.productName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // productPrice
            // 
            this.productPrice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.productPrice.AutoSize = true;
            this.productPrice.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(131)))));
            this.productPrice.Location = new System.Drawing.Point(0, 318);
            this.productPrice.MaximumSize = new System.Drawing.Size(255, 0);
            this.productPrice.MinimumSize = new System.Drawing.Size(255, 0);
            this.productPrice.Name = "productPrice";
            this.productPrice.Size = new System.Drawing.Size(255, 23);
            this.productPrice.TabIndex = 1;
            this.productPrice.Text = "275,000 đ";
            this.productPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.productPrice);
            this.Controls.Add(this.productName);
            this.Controls.Add(this.productImage);
            this.Name = "ProductItem";
            this.Size = new System.Drawing.Size(255, 376);
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox productImage;
        private System.Windows.Forms.Label productName;
        private System.Windows.Forms.Label productPrice;
    }
}
