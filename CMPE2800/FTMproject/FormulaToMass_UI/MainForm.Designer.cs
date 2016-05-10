namespace FormulaToMass_UI
{
    partial class UI_F_FTM
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
            this.UI_DGV_Display = new System.Windows.Forms.DataGridView();
            this.UI_BT_SortName = new System.Windows.Forms.Button();
            this.UI_BT_SortSymbol = new System.Windows.Forms.Button();
            this.UI_BT_SortAtomic = new System.Windows.Forms.Button();
            this.UI_LB_Input = new System.Windows.Forms.Label();
            this.UI_TB_FormulaInput = new System.Windows.Forms.TextBox();
            this.UI_LB_MolarMass = new System.Windows.Forms.Label();
            this.UI_LBL_MolarOutput = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_Display)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_DGV_Display
            // 
            this.UI_DGV_Display.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_DGV_Display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DGV_Display.Location = new System.Drawing.Point(12, 12);
            this.UI_DGV_Display.Name = "UI_DGV_Display";
            this.UI_DGV_Display.Size = new System.Drawing.Size(678, 476);
            this.UI_DGV_Display.TabIndex = 0;
            // 
            // UI_BT_SortName
            // 
            this.UI_BT_SortName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BT_SortName.Location = new System.Drawing.Point(696, 12);
            this.UI_BT_SortName.Name = "UI_BT_SortName";
            this.UI_BT_SortName.Size = new System.Drawing.Size(141, 23);
            this.UI_BT_SortName.TabIndex = 1;
            this.UI_BT_SortName.Text = "Sort By Name";
            this.UI_BT_SortName.UseVisualStyleBackColor = true;
            this.UI_BT_SortName.Click += new System.EventHandler(this.UI_BT_SortName_Click);
            // 
            // UI_BT_SortSymbol
            // 
            this.UI_BT_SortSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BT_SortSymbol.Location = new System.Drawing.Point(696, 41);
            this.UI_BT_SortSymbol.Name = "UI_BT_SortSymbol";
            this.UI_BT_SortSymbol.Size = new System.Drawing.Size(141, 23);
            this.UI_BT_SortSymbol.TabIndex = 2;
            this.UI_BT_SortSymbol.Text = "Single Character Symbols";
            this.UI_BT_SortSymbol.UseVisualStyleBackColor = true;
            this.UI_BT_SortSymbol.Click += new System.EventHandler(this.UI_BT_SortSymbol_Click);
            // 
            // UI_BT_SortAtomic
            // 
            this.UI_BT_SortAtomic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_BT_SortAtomic.Location = new System.Drawing.Point(696, 70);
            this.UI_BT_SortAtomic.Name = "UI_BT_SortAtomic";
            this.UI_BT_SortAtomic.Size = new System.Drawing.Size(141, 23);
            this.UI_BT_SortAtomic.TabIndex = 3;
            this.UI_BT_SortAtomic.Text = "Sort By Atomic #";
            this.UI_BT_SortAtomic.UseVisualStyleBackColor = true;
            this.UI_BT_SortAtomic.Click += new System.EventHandler(this.UI_BT_SortAtomic_Click);
            // 
            // UI_LB_Input
            // 
            this.UI_LB_Input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LB_Input.AutoSize = true;
            this.UI_LB_Input.Location = new System.Drawing.Point(12, 495);
            this.UI_LB_Input.Name = "UI_LB_Input";
            this.UI_LB_Input.Size = new System.Drawing.Size(99, 13);
            this.UI_LB_Input.TabIndex = 4;
            this.UI_LB_Input.Text = "Chemical Formula : ";
            // 
            // UI_TB_FormulaInput
            // 
            this.UI_TB_FormulaInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_TB_FormulaInput.Location = new System.Drawing.Point(108, 492);
            this.UI_TB_FormulaInput.Name = "UI_TB_FormulaInput";
            this.UI_TB_FormulaInput.Size = new System.Drawing.Size(416, 20);
            this.UI_TB_FormulaInput.TabIndex = 5;
            this.UI_TB_FormulaInput.TextChanged += new System.EventHandler(this.UI_TB_FormulaInput_TextChanged);
            // 
            // UI_LB_MolarMass
            // 
            this.UI_LB_MolarMass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_LB_MolarMass.AutoSize = true;
            this.UI_LB_MolarMass.Location = new System.Drawing.Point(587, 495);
            this.UI_LB_MolarMass.Name = "UI_LB_MolarMass";
            this.UI_LB_MolarMass.Size = new System.Drawing.Size(103, 13);
            this.UI_LB_MolarMass.TabIndex = 6;
            this.UI_LB_MolarMass.Text = "Approx. Molar Mass:";
            // 
            // UI_LBL_MolarOutput
            // 
            this.UI_LBL_MolarOutput.AutoSize = true;
            this.UI_LBL_MolarOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UI_LBL_MolarOutput.Location = new System.Drawing.Point(696, 492);
            this.UI_LBL_MolarOutput.MaximumSize = new System.Drawing.Size(141, 20);
            this.UI_LBL_MolarOutput.MinimumSize = new System.Drawing.Size(141, 20);
            this.UI_LBL_MolarOutput.Name = "UI_LBL_MolarOutput";
            this.UI_LBL_MolarOutput.Size = new System.Drawing.Size(141, 20);
            this.UI_LBL_MolarOutput.TabIndex = 8;
            this.UI_LBL_MolarOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_F_FTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 522);
            this.Controls.Add(this.UI_LBL_MolarOutput);
            this.Controls.Add(this.UI_LB_MolarMass);
            this.Controls.Add(this.UI_TB_FormulaInput);
            this.Controls.Add(this.UI_LB_Input);
            this.Controls.Add(this.UI_BT_SortAtomic);
            this.Controls.Add(this.UI_BT_SortSymbol);
            this.Controls.Add(this.UI_BT_SortName);
            this.Controls.Add(this.UI_DGV_Display);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(865, 560);
            this.MinimumSize = new System.Drawing.Size(865, 560);
            this.Name = "UI_F_FTM";
            this.Text = "Formula To Mass Calculator V.6";
            this.Load += new System.EventHandler(this.UI_F_FTM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_Display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UI_DGV_Display;
        private System.Windows.Forms.Button UI_BT_SortName;
        private System.Windows.Forms.Button UI_BT_SortSymbol;
        private System.Windows.Forms.Button UI_BT_SortAtomic;
        private System.Windows.Forms.Label UI_LB_Input;
        private System.Windows.Forms.TextBox UI_TB_FormulaInput;
        private System.Windows.Forms.Label UI_LB_MolarMass;
        private System.Windows.Forms.Label UI_LBL_MolarOutput;
    }
}

