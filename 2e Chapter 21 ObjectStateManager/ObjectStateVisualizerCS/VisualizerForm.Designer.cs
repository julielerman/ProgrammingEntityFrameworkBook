namespace EFExtensionMethods
{
  partial class VisualizerForm
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
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblType = new System.Windows.Forms.Label();
      this.lblState = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new System.Drawing.Point(12, 62);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.Size = new System.Drawing.Size(577, 383);
      this.dataGridView1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(23, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(82, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Object Type";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(23, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(126, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "Current Object State";
      // 
      // lblType
      // 
      this.lblType.AutoSize = true;
      this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblType.Location = new System.Drawing.Point(158, 13);
      this.lblType.Name = "lblType";
      this.lblType.Size = new System.Drawing.Size(51, 16);
      this.lblType.TabIndex = 3;
      this.lblType.Text = "label3";
      // 
      // lblState
      // 
      this.lblState.AutoSize = true;
      this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblState.Location = new System.Drawing.Point(158, 43);
      this.lblState.Name = "lblState";
      this.lblState.Size = new System.Drawing.Size(51, 16);
      this.lblState.TabIndex = 4;
      this.lblState.Text = "label4";
      // 
      // debuggerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(614, 457);
      this.Controls.Add(this.lblState);
      this.Controls.Add(this.lblType);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dataGridView1);
      this.Name = "DebuggerForm";
      this.Text = "Entity State Visualizer";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    internal System.Windows.Forms.DataGridView dataGridView1;
    internal System.Windows.Forms.Label lblType;
    internal System.Windows.Forms.Label lblState;
  }
}