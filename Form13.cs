using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void btnSubmitReview_Click(object sender, EventArgs e)
        {
            int rating = (int)numericUpDownRating.Value;
            string comment = txtReview.Text;

            string message = $"Rating: {rating}\nComment: {comment}";
            MessageBox.Show($"Thank you for your review!\n\n{message}", "Review Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.btnBack_Click(sender, e );
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
            Form10 customerDashboard = new Form10();
            customerDashboard.Show();
            this.Close();
        }
    }
}
