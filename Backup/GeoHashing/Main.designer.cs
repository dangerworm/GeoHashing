namespace GeoHashing
{
    partial class Main
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
            this.Date = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.DOW = new System.Windows.Forms.TextBox();
            this.lblDOW = new System.Windows.Forms.Label();
            this.Code = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblMD5 = new System.Windows.Forms.Label();
            this.MD5 = new System.Windows.Forms.TextBox();
            this.CoordinatesN = new System.Windows.Forms.TextBox();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.CoordinatesW = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.LocationN = new System.Windows.Forms.TextBox();
            this.LocationW = new System.Windows.Forms.TextBox();
            this.ViewMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Date
            // 
            this.Date.Location = new System.Drawing.Point(98, 39);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(73, 20);
            this.Date.TabIndex = 2;
            this.Date.TextChanged += new System.EventHandler(this.Date_TextChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(59, 42);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date:";
            // 
            // DOW
            // 
            this.DOW.Location = new System.Drawing.Point(98, 65);
            this.DOW.Name = "DOW";
            this.DOW.Size = new System.Drawing.Size(73, 20);
            this.DOW.TabIndex = 3;
            this.DOW.TextChanged += new System.EventHandler(this.DOW_TextChanged);
            // 
            // lblDOW
            // 
            this.lblDOW.AutoSize = true;
            this.lblDOW.Location = new System.Drawing.Point(12, 68);
            this.lblDOW.Name = "lblDOW";
            this.lblDOW.Size = new System.Drawing.Size(80, 13);
            this.lblDOW.TabIndex = 3;
            this.lblDOW.Text = "DOW Opening:";
            // 
            // Code
            // 
            this.Code.Location = new System.Drawing.Point(98, 91);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(121, 20);
            this.Code.TabIndex = 6;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(57, 94);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(35, 13);
            this.lblCode.TabIndex = 5;
            this.lblCode.Text = "Code:";
            // 
            // lblMD5
            // 
            this.lblMD5.AutoSize = true;
            this.lblMD5.Location = new System.Drawing.Point(31, 120);
            this.lblMD5.Name = "lblMD5";
            this.lblMD5.Size = new System.Drawing.Size(61, 13);
            this.lblMD5.TabIndex = 7;
            this.lblMD5.Text = "MD5 Hash:";
            // 
            // MD5
            // 
            this.MD5.Location = new System.Drawing.Point(98, 117);
            this.MD5.Name = "MD5";
            this.MD5.Size = new System.Drawing.Size(217, 20);
            this.MD5.TabIndex = 7;
            // 
            // CoordinatesN
            // 
            this.CoordinatesN.Location = new System.Drawing.Point(98, 143);
            this.CoordinatesN.Name = "CoordinatesN";
            this.CoordinatesN.Size = new System.Drawing.Size(100, 20);
            this.CoordinatesN.TabIndex = 8;
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.AutoSize = true;
            this.lblCoordinates.Location = new System.Drawing.Point(26, 146);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(66, 13);
            this.lblCoordinates.TabIndex = 9;
            this.lblCoordinates.Text = "Coordinates:";
            // 
            // CoordinatesW
            // 
            this.CoordinatesW.Location = new System.Drawing.Point(215, 143);
            this.CoordinatesW.Name = "CoordinatesW";
            this.CoordinatesW.Size = new System.Drawing.Size(100, 20);
            this.CoordinatesW.TabIndex = 9;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(41, 15);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 11;
            this.lblLocation.Text = "Location:";
            // 
            // LocationN
            // 
            this.LocationN.Location = new System.Drawing.Point(98, 12);
            this.LocationN.Name = "LocationN";
            this.LocationN.Size = new System.Drawing.Size(99, 20);
            this.LocationN.TabIndex = 0;
            this.LocationN.Text = "53";
            this.LocationN.TextChanged += new System.EventHandler(this.LocationN_TextChanged);
            // 
            // LocationW
            // 
            this.LocationW.Location = new System.Drawing.Point(215, 12);
            this.LocationW.Name = "LocationW";
            this.LocationW.Size = new System.Drawing.Size(100, 20);
            this.LocationW.TabIndex = 1;
            this.LocationW.Text = "-1";
            this.LocationW.TextChanged += new System.EventHandler(this.LocationW_TextChanged);
            // 
            // ViewMap
            // 
            this.ViewMap.Location = new System.Drawing.Point(12, 176);
            this.ViewMap.Name = "ViewMap";
            this.ViewMap.Size = new System.Drawing.Size(303, 23);
            this.ViewMap.TabIndex = 10;
            this.ViewMap.Text = "View Map";
            this.ViewMap.UseVisualStyleBackColor = true;
            this.ViewMap.Click += new System.EventHandler(this.ViewMap_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 211);
            this.Controls.Add(this.ViewMap);
            this.Controls.Add(this.LocationW);
            this.Controls.Add(this.LocationN);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.CoordinatesW);
            this.Controls.Add(this.lblCoordinates);
            this.Controls.Add(this.CoordinatesN);
            this.Controls.Add(this.lblMD5);
            this.Controls.Add(this.MD5);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.Code);
            this.Controls.Add(this.lblDOW);
            this.Controls.Add(this.DOW);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.Date);
            this.Name = "Main";
            this.Text = "GeoHashing";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Date;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox DOW;
        private System.Windows.Forms.Label lblDOW;
        private System.Windows.Forms.TextBox Code;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblMD5;
        private System.Windows.Forms.TextBox MD5;
        private System.Windows.Forms.TextBox CoordinatesN;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.TextBox CoordinatesW;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox LocationN;
        private System.Windows.Forms.TextBox LocationW;
        private System.Windows.Forms.Button ViewMap;
    }
}

