﻿namespace DB_Proj_00
{
    partial class Customer_Feedback_and_Product_Rating_Analysis_Report
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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(153, 30);
            label1.Name = "label1";
            label1.Size = new Size(401, 25);
            label1.TabIndex = 0;
            label1.Text = "Customer_Feedback_and_Product_rating_Analysis";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(262, 108);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(553, 388);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(12, 108);
            button1.Name = "button1";
            button1.Size = new Size(132, 86);
            button1.TabIndex = 2;
            button1.Text = "Average Ratings by Product";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 243);
            button2.Name = "button2";
            button2.Size = new Size(132, 90);
            button2.TabIndex = 3;
            button2.Text = "Product Sentiment Analysis";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 375);
            button3.Name = "button3";
            button3.Size = new Size(132, 92);
            button3.TabIndex = 4;
            button3.Text = "Top Rated Products";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Customer_Feedback_and_Product_Rating_Analysis_Report
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 605);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "Customer_Feedback_and_Product_Rating_Analysis_Report";
            Text = "Customer_Feedback_and_Product_Rating_Analysis_Report";
            Load += Customer_Feedback_and_Product_Rating_Analysis_Report_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}