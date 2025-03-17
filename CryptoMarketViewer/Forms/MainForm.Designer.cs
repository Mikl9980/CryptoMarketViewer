namespace CryptoMarketViewer.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxSymbol;
        private System.Windows.Forms.Button buttonGetPrices;
        private System.Windows.Forms.Label labelBinance;
        private System.Windows.Forms.Label labelBybit;
        private System.Windows.Forms.Label labelKucoin;
        private System.Windows.Forms.Label labelBitget;

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
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 256);
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }
    }
}