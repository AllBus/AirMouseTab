namespace AirMouseTab
{
    partial class AirMouseTabForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AirMouseTabForm));
            this.editPIN = new System.Windows.Forms.TextBox();
            this.labelIp = new System.Windows.Forms.Label();
            this.labelPIN = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.listIp = new System.Windows.Forms.ListBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.buttonGeneratePIN = new System.Windows.Forms.Button();
            this.labelPort = new System.Windows.Forms.Label();
            this.editPort = new System.Windows.Forms.TextBox();
            this.buttonDefaultPort = new System.Windows.Forms.Button();
            this.labelIPInfo = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editPIN
            // 
            resources.ApplyResources(this.editPIN, "editPIN");
            this.editPIN.Name = "editPIN";
            this.editPIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editPort_KeyPress_1);
            // 
            // labelIp
            // 
            resources.ApplyResources(this.labelIp, "labelIp");
            this.labelIp.Name = "labelIp";
            // 
            // labelPIN
            // 
            resources.ApplyResources(this.labelPIN, "labelPIN");
            this.labelPIN.Name = "labelPIN";
            // 
            // buttonConnect
            // 
            resources.ApplyResources(this.buttonConnect, "buttonConnect");
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // listIp
            // 
            resources.ApplyResources(this.listIp, "listIp");
            this.listIp.FormattingEnabled = true;
            this.listIp.Name = "listIp";
            // 
            // labelHeader
            // 
            resources.ApplyResources(this.labelHeader, "labelHeader");
            this.tableLayoutPanel1.SetColumnSpan(this.labelHeader, 3);
            this.labelHeader.Name = "labelHeader";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.labelVersion, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonConnect, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.listIp, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPIN, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelIp, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.editPIN, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonGeneratePIN, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelPort, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.editPort, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDefaultPort, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelIPInfo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxLanguage, 0, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // labelVersion
            // 
            resources.ApplyResources(this.labelVersion, "labelVersion");
            this.labelVersion.Name = "labelVersion";
            // 
            // buttonGeneratePIN
            // 
            resources.ApplyResources(this.buttonGeneratePIN, "buttonGeneratePIN");
            this.buttonGeneratePIN.Name = "buttonGeneratePIN";
            this.buttonGeneratePIN.UseVisualStyleBackColor = true;
            this.buttonGeneratePIN.Click += new System.EventHandler(this.buttonGeneratePIN_Click);
            // 
            // labelPort
            // 
            resources.ApplyResources(this.labelPort, "labelPort");
            this.labelPort.Name = "labelPort";
            // 
            // editPort
            // 
            resources.ApplyResources(this.editPort, "editPort");
            this.editPort.Name = "editPort";
            this.editPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editPort_KeyPress_1);
            // 
            // buttonDefaultPort
            // 
            resources.ApplyResources(this.buttonDefaultPort, "buttonDefaultPort");
            this.buttonDefaultPort.Name = "buttonDefaultPort";
            this.buttonDefaultPort.UseVisualStyleBackColor = true;
            this.buttonDefaultPort.Click += new System.EventHandler(this.buttonDefaultPort_Click);
            // 
            // labelIPInfo
            // 
            resources.ApplyResources(this.labelIPInfo, "labelIPInfo");
            this.labelIPInfo.Name = "labelIPInfo";
            // 
            // comboBoxLanguage
            // 
            resources.ApplyResources(this.comboBoxLanguage, "comboBoxLanguage");
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            resources.GetString("comboBoxLanguage.Items"),
            resources.GetString("comboBoxLanguage.Items1")});
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // AirMouseTabForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "AirMouseTabForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox editPIN;
        private System.Windows.Forms.Label labelIp;
        private System.Windows.Forms.Label labelPIN;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ListBox listIp;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonGeneratePIN;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox editPort;
        private System.Windows.Forms.Button buttonDefaultPort;
        private System.Windows.Forms.Label labelIPInfo;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
    }
}

