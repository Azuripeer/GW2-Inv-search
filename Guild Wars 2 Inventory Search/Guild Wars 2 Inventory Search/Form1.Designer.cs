namespace Guild_Wars_2_Inventory_Search
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
            this.itemList = new System.Windows.Forms.ListView();
            this.item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.character = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.search = new System.Windows.Forms.TextBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.apiButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // itemList
            // 
            this.itemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.item,
            this.amount,
            this.character});
            this.itemList.Location = new System.Drawing.Point(12, 38);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(514, 262);
            this.itemList.TabIndex = 0;
            this.itemList.UseCompatibleStateImageBehavior = false;
            this.itemList.View = System.Windows.Forms.View.Details;
            // 
            // item
            // 
            this.item.Text = "Item";
            // 
            // amount
            // 
            this.amount.Text = "Amount";
            // 
            // character
            // 
            this.character.Text = "Character";
            // 
            // search
            // 
            this.search.Enabled = false;
            this.search.Location = new System.Drawing.Point(62, 12);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(269, 20);
            this.search.TabIndex = 1;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(337, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // apiButton
            // 
            this.apiButton.Location = new System.Drawing.Point(418, 10);
            this.apiButton.Name = "apiButton";
            this.apiButton.Size = new System.Drawing.Size(108, 23);
            this.apiButton.TabIndex = 3;
            this.apiButton.Text = "Change API key";
            this.apiButton.UseVisualStyleBackColor = true;
            this.apiButton.Click += new System.EventHandler(this.apiButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.label1.Location = new System.Drawing.Point(461, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 9);
            this.label1.TabIndex = 4;
            this.label1.Text = "Erin van der Veen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 314);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.apiButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.search);
            this.Controls.Add(this.itemList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Guild Wars 2 Inventory Search";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView itemList;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button apiButton;
        private System.Windows.Forms.ColumnHeader item;
        private System.Windows.Forms.ColumnHeader character;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

