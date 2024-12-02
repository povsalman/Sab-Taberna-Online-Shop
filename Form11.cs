using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form11 : Form
    {
        private List<Product> P = new List<Product>();
        private List<Product> filteredProducts = new List<Product>();
        private List<Product> shoppingCart; 
        private List<Product> wishlist = new List<Product>();
        private Dictionary<Product, List<Review>> productReviews; 
        public Form11(List<Product> cart, Dictionary<Product, List<Review>> reviews) 
        {
            InitializeComponent();
            shoppingCart = cart; 
            productReviews = reviews; 
        }


        private void Form11_Load(object sender, EventArgs e)
        {
            
            InitializeProducts();
            DisplayProducts(P);
        }

        private void InitializeProducts()
        {
            P.Add(new Product("Digital Wrist Watch", @"C:\Users\HP\Desktop\images\watch.jpg", "$125", "Gadget, Wearable", 5, "Electronics", "Standard"));
            P.Add(new Product("Game Controller", @"C:\Users\HP\Desktop\images\controller.jfif", "$259", "Gaming", 4, "Gaming", "Express"));
            P.Add(new Product("Digital VR", @"C:\Users\HP\Desktop\images\vr.jpg", "$175", "Virtual Reality", 4, "Electronics", "Standard"));
            P.Add(new Product("Headphones Set", @"C:\Users\HP\Desktop\images\headphones.jfif", "$259", "Audio", 5, "Electronics", "Express"));
            P.Add(new Product("Earphones", @"C:\Users\HP\Desktop\images\earphones.jfif", "$179", "Audio", 4, "Accessories", "Standard"));
            P.Add(new Product("Jogging Shoes", @"C:\Users\HP\Desktop\images\shoes.jpg", "$159", "Sportswear", 3, "Clothing", "Standard"));
            P.Add(new Product("Water Bottle", @"C:\Users\HP\Desktop\images\water_bottle.jpg", "$59", "Sports", 5, "Accessories", "Standard"));
            P.Add(new Product("Face Mask", @"C:\Users\HP\Desktop\images\mask.jpg", "$25", "Health", 4, "Accessories", "Standard"));
            
        }

        private void DisplayProducts(List<Product> products)
        {
            flowLayoutPanelProducts.Controls.Clear();

            foreach (var product in products)
            {
              
                Panel productPanel = new Panel
                {
                    Size = new Size(200, 350),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                // To add Image
                PictureBox productImage = new PictureBox
                {
                    Size = new Size(200, 150),
                    Image = Image.FromFile(product.ImagePath),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                //This is to add nanme
                Label productName = new Label
                {
                    Text = product.Name,
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Top,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                };

                // This is for price
                Label productPrice = new Label
                {
                    Text = product.Price,
                    AutoSize = true,
                    ForeColor = Color.Green,
                    Location = new Point(10, 160)
                };

                // This is add to cart button
                Button addToCartButton = new Button
                {
                    Text = "Add to Cart",
                    Size = new Size(120, 30),
                    Location = new Point(40, 200),
                    BackColor = Color.LightGreen,
                    FlatStyle = FlatStyle.Flat
                };
                addToCartButton.Click += (s, e) =>
                {
                    MessageBox.Show($"{product.Name} added to Cart!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                productPanel.Controls.Add(productImage);
                productPanel.Controls.Add(productName);
                productPanel.Controls.Add(productPrice);
                productPanel.Controls.Add(addToCartButton);

                flowLayoutPanelProducts.Controls.Add(productPanel);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();
            string category = cmbCategory.SelectedItem?.ToString();
            string priceRange = cmbPriceRange.SelectedItem?.ToString();
            string rating = cmbRating.SelectedItem?.ToString();
            string shipping = cmbShipping.SelectedItem?.ToString();

            filteredProducts = P
                .Where(p =>
                    (string.IsNullOrEmpty(keyword) || p.Name.ToLower().Contains(keyword)) &&
                    (string.IsNullOrEmpty(category) || p.Category == category) &&
                    (string.IsNullOrEmpty(priceRange) || p.Price == priceRange) &&
                    (string.IsNullOrEmpty(rating) || p.Rating.ToString() == rating) &&
                    (string.IsNullOrEmpty(shipping) || p.Shipping == shipping))
                .ToList();

            DisplayProducts(filteredProducts);
        }




        
    }

    public class Product
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Price { get; set; }
        public string Tags { get; set; }
        public int Rating { get; set; }
        public string Category { get; set; }
        public string Shipping { get; set; }

        public Product(string name, string imagePath, string price, string tags, int rating, string category, string shipping)
        {
            Name = name;
            ImagePath = imagePath;
            Price = price;
            Tags = tags;
            Rating = rating;
            Category = category;
            Shipping = shipping;
        }
    }
}
