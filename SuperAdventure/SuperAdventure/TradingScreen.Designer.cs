namespace SuperAdventure
{
    partial class TradingScreen
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
            this.lblMyInventory = new System.Windows.Forms.Label();
            this.lblVendorInventory = new System.Windows.Forms.Label();
            this.dgvMyItems = new System.Windows.Forms.DataGridView();
            this.dgvVendorItems = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMyInventory
            // 
            this.lblMyInventory.AutoSize = true;
            this.lblMyInventory.Location = new System.Drawing.Point(99, 13);
            this.lblMyInventory.Name = "lblMyInventory";
            this.lblMyInventory.Size = new System.Drawing.Size(68, 13);
            this.lblMyInventory.TabIndex = 0;
            this.lblMyInventory.Text = "My Inventory";
            // 
            // lblVendorInventory
            // 
            this.lblVendorInventory.AutoSize = true;
            this.lblVendorInventory.Location = new System.Drawing.Point(349, 13);
            this.lblVendorInventory.Name = "lblVendorInventory";
            this.lblVendorInventory.Size = new System.Drawing.Size(95, 13);
            this.lblVendorInventory.TabIndex = 1;
            this.lblVendorInventory.Text = "Vendor\'s Inventory";
            // 
            // dgvMyItems
            // 
            this.dgvMyItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyItems.Location = new System.Drawing.Point(13, 43);
            this.dgvMyItems.Name = "dgvMyItems";
            this.dgvMyItems.Size = new System.Drawing.Size(240, 216);
            this.dgvMyItems.TabIndex = 2;
            // 
            // dgvVendorItems
            // 
            this.dgvVendorItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendorItems.Location = new System.Drawing.Point(276, 43);
            this.dgvVendorItems.Name = "dgvVendorItems";
            this.dgvVendorItems.Size = new System.Drawing.Size(240, 216);
            this.dgvVendorItems.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(441, 274);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TradingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 310);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvVendorItems);
            this.Controls.Add(this.dgvMyItems);
            this.Controls.Add(this.lblVendorInventory);
            this.Controls.Add(this.lblMyInventory);
            this.Name = "TradingScreen";
            this.Text = "Trader";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMyInventory;
        private System.Windows.Forms.Label lblVendorInventory;
        private System.Windows.Forms.DataGridView dgvMyItems;
        private System.Windows.Forms.DataGridView dgvVendorItems;
        private System.Windows.Forms.Button btnClose;
    }
}