namespace frmGetUUIDfromXML
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
      this.btnGo = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtPath = new System.Windows.Forms.TextBox();
      this.lblMessage = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.btnCopyFilesByList = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnGo
      // 
      this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
      this.btnGo.Location = new System.Drawing.Point(50, 31);
      this.btnGo.Name = "btnGo";
      this.btnGo.Size = new System.Drawing.Size(157, 186);
      this.btnGo.TabIndex = 0;
      this.btnGo.Text = "GO!";
      this.btnGo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.btnGo.UseVisualStyleBackColor = true;
      this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(33, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Ruta:";
      // 
      // txtPath
      // 
      this.txtPath.Location = new System.Drawing.Point(47, 5);
      this.txtPath.Name = "txtPath";
      this.txtPath.Size = new System.Drawing.Size(305, 20);
      this.txtPath.TabIndex = 2;
      // 
      // lblMessage
      // 
      this.lblMessage.AutoSize = true;
      this.lblMessage.Location = new System.Drawing.Point(12, 101);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(32, 13);
      this.lblMessage.TabIndex = 3;
      this.lblMessage.Text = "Listo!";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(277, 31);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 4;
      this.button1.Text = "Retenciones";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // btnCopyFilesByList
      // 
      this.btnCopyFilesByList.Location = new System.Drawing.Point(47, 336);
      this.btnCopyFilesByList.Name = "btnCopyFilesByList";
      this.btnCopyFilesByList.Size = new System.Drawing.Size(160, 23);
      this.btnCopyFilesByList.TabIndex = 5;
      this.btnCopyFilesByList.Text = "copy files by list";
      this.btnCopyFilesByList.UseVisualStyleBackColor = true;
      this.btnCopyFilesByList.Click += new System.EventHandler(this.btnCopyFilesByList_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(370, 371);
      this.Controls.Add(this.btnCopyFilesByList);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.lblMessage);
      this.Controls.Add(this.txtPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnGo);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnGo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtPath;
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button btnCopyFilesByList;
  }
}

