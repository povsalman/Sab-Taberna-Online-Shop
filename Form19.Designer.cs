namespace DB_Proj_00
{
    partial class Form19
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView Acc;
        private Button App;
        private Button Rej;
        private Button View;
        private Button btnBack;

       
        private void InitializeComponent()
        {
            Acc = new DataGridView();
            App = new Button();
            Rej = new Button();
            View = new Button();
            btnBack = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)Acc).BeginInit();
            SuspendLayout();
            
            Acc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Acc.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            Acc.Location = new Point(20, 20);
            Acc.Name = "Acc";
            Acc.RowHeadersWidth = 62;
            Acc.Size = new Size(663, 300);
            Acc.TabIndex = 0;
            
            App.Location = new Point(20, 340);
            App.Name = "App";
            App.Size = new Size(150, 30);
            App.TabIndex = 1;
            App.Text = "Approve Seller";
            App.Click += App_Click;
            
            Rej.Location = new Point(200, 340);
            Rej.Name = "Rej";
            Rej.Size = new Size(150, 30);
            Rej.TabIndex = 2;
            Rej.Text = "Reject Seller";
            Rej.Click += Rej_Click;
            
            View.Location = new Point(380, 340);
            View.Name = "View";
            View.Size = new Size(200, 30);
            View.TabIndex = 3;
            View.Text = "View Suspicious Activity";
            View.Click += View_Click;
            
            btnBack.Location = new Point(20, 400);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            
            dataGridViewTextBoxColumn1.HeaderText = "Account Type";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 150;
            
            dataGridViewTextBoxColumn2.HeaderText = "Name";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 150;
             
            dataGridViewTextBoxColumn3.HeaderText = "Email";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 150;
            
            dataGridViewTextBoxColumn4.HeaderText = "Status";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 150;
            
            ClientSize = new Size(760, 450);
            Controls.Add(Acc);
            Controls.Add(App);
            Controls.Add(Rej);
            Controls.Add(View);
            Controls.Add(btnBack);
            Name = "Form19";
            Text = "Admin - User and Seller Management";
            ((System.ComponentModel.ISupportInitialize)Acc).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
