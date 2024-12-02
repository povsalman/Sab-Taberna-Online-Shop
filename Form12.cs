using System;
using System.Drawing;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            
            AddCartTitle("Your Cart (3 items)");

            AddCartItem(@"C:\Users\HP\Desktop\images\watch.jpg", "Digital Wrist Watch", 125, 1);
            AddCartItem(@"C:\Users\HP\Desktop\images\controller.jfif", "Game Controller", 259, 1);
            AddCartItem(@"C:\Users\HP\Desktop\images\headphones.jfif", "Headphones", 175, 1);

            AddCartSummary(559, 50, 609); 
        }

        private void AddCartTitle(string title)
        {
            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Arial", 18, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 40
            };
            Controls.Add(titleLabel);
            titleLabel.BringToFront();
        }

        private void AddCartItem(string imagePath, string name, int price, int quantity)
        {
            Panel itemPanel = new Panel
            {
                Size = new Size(550, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            PictureBox itemImage = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(10, 10),
                Image = Image.FromFile(imagePath),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            Label itemName = new Label
            {
                Text = name,
                Location = new Point(100, 10),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label itemPrice = new Label
            {
                Text = $"Price: ${price}",
                Location = new Point(100, 40),
                AutoSize = true,
                ForeColor = Color.Green,
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            Label itemQuantity = new Label
            {
                Text = $"Quantity: {quantity}",
                Location = new Point(250, 10),
                AutoSize = true,
                Font = new Font("Arial", 9)
            };

            Label itemTotal = new Label
            {
                Text = $"Total: ${price * quantity}",
                Location = new Point(250, 40),
                AutoSize = true,
                Font = new Font("Arial", 9)
            };

            itemPanel.Controls.Add(itemImage);
            itemPanel.Controls.Add(itemName);
            itemPanel.Controls.Add(itemPrice);
            itemPanel.Controls.Add(itemQuantity);
            itemPanel.Controls.Add(itemTotal);

            
        }

        private void AddCartSummary(int subtotal, int tax, int total)
        {
            Panel summaryPanel = new Panel
            {
                Size = new Size(550, 80),
                Dock = DockStyle.Bottom
            };

            Label subtotalLabel = new Label
            {
                Text = $"Subtotal: ${subtotal}",
                AutoSize = true,
                Font = new Font("Arial", 10),
                Location = new Point(10, 10)
            };

            Label taxLabel = new Label
            {
                Text = $"Tax: ${tax}",
                AutoSize = true,
                Font = new Font("Arial", 10),
                Location = new Point(10, 30)
            };

            Label totalLabel = new Label
            {
                Text = $"Grand Total: ${total}",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Location = new Point(10, 50)
            };

            summaryPanel.Controls.Add(subtotalLabel);
            summaryPanel.Controls.Add(taxLabel);
            summaryPanel.Controls.Add(totalLabel);

            Controls.Add(summaryPanel);
            summaryPanel.BringToFront();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Checkout button clicked. Functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form10 customerForm = new Form10();
            customerForm.Show();
            this.Close();
        }
    }
}
