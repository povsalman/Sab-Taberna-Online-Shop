using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class CustomerProduct : Form
    {
        private List<Product> shoppingCart;
        private Dictionary<Product, List<Review>> productReviews;

        public CustomerProduct()
        {
            InitializeComponent();
            shoppingCart = new List<Product>();
            productReviews = new Dictionary<Product, List<Review>>();
        }

        public CustomerProduct(List<Product> cart)
        {
            InitializeComponent();
            shoppingCart = cart ?? new List<Product>();
            productReviews = new Dictionary<Product, List<Review>>();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadProductsFromDatabase();
        }

        private void LoadProductsFromDatabase()
        {
            string query = "SELECT TOP 16 ProductID, Name, Price, Description, StockLevel, ImageURL FROM ISPRODUCT ORDER BY StockLevel DESC";

            List<Product> productsFromDB = new List<Product>();

            using (var conn = DBHandler.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productsFromDB.Add(new Product(
                                    productID: Convert.ToInt32(reader["ProductID"]),
                                    name: reader["Name"]?.ToString() ?? "Unnamed Product",
                                    price: reader["Price"]?.ToString() ?? "0.00",
                                    description: reader["Description"]?.ToString() ?? "No description available",
                                    stockLevel: reader["StockLevel"] != DBNull.Value ? Convert.ToInt32(reader["StockLevel"]) : 0,
                                    imagePath: reader["ImageURL"]?.ToString()
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DisplayProducts(productsFromDB);
        }

        private void DisplayProducts(List<Product> products)
        {
            flowLayoutPanelProducts.Controls.Clear();
            flowLayoutPanelProducts.Padding = new Padding(0, 110, 0, 20); 
            flowLayoutPanelProducts.Dock = DockStyle.Fill;

            flowLayoutPanelProducts.Dock = DockStyle.Fill;

            flowLayoutPanelProducts.WrapContents = true; 
            flowLayoutPanelProducts.FlowDirection = FlowDirection.LeftToRight; 

            foreach (var product in products)
            {
                Panel productPanel = new Panel
                {
                    Size = new Size(300, 500), 
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(15),
                    BackColor = Color.FromArgb(180, 255, 255, 255)
                };

                PictureBox pictureBox = new PictureBox
                {
                    ImageLocation = product.ImagePath,
                    Size = new Size(280, 200), 
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                Label lblName = new Label
                {
                    Text = product.Name,
                    Location = new Point(10, 220),
                    AutoSize = false,
                    Size = new Size(280, 40),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };

                Label lblPrice = new Label
                {
                    Text = $"Price: {product.Price}",
                    Location = new Point(10, 270),
                    AutoSize = false,
                    Size = new Size(280, 30),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10, FontStyle.Regular)
                };

                Button btnAddToCart = new Button
                {
                    Text = "Add to Cart",
                    Location = new Point(90, 320), // Center the button
                    BackColor = Color.LightGreen,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(120, 40)
                };
                btnAddToCart.Click += (s, e) => AddToCart(product);

                productPanel.Controls.Add(pictureBox);
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(lblPrice);
                productPanel.Controls.Add(btnAddToCart);

                flowLayoutPanelProducts.Controls.Add(productPanel);
            }
        }






        /*private void AddToCart(Product product)
        {
            string connectionString = @"Server=DESKTOP-36T2U50\SQLEXPRESS;Database=SABTaberna;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the product is already in the cart
                var existingProduct = SessionManager.ShoppingCart.FirstOrDefault(p => p.ProductID == product.ProductID);

                if (existingProduct != null)
                {
                    if (existingProduct.Quantity + 1 > product.StockLevel)
                    {
                        MessageBox.Show("Cannot add more items. Stock limit reached.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    existingProduct.Quantity++;
                }
                else
                {
                    if (product.StockLevel < 1)
                    {
                        MessageBox.Show("Out of stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newProduct = new Product(
                        productID: product.ProductID,
                        name: product.Name,
                        price: product.Price,
                        description: product.Description,
                        stockLevel: product.StockLevel,
                        imagePath: product.ImagePath,
                        quantity: 1
                    );

                    SessionManager.ShoppingCart.Add(newProduct);
                }
            }

            MessageBox.Show($"{product.Name} added to cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }*/
        private void AddToCart(Product product)
        {

            using (var conn = DBHandler.GetConnection())
            {
                conn.Open();

                // Check if the product is already in the cart
                string checkCartQuery = "SELECT Quantity FROM CART WHERE UserID = @UserID AND ProductID = @ProductID";
                SqlCommand checkCommand = new SqlCommand(checkCartQuery, conn);
                checkCommand.Parameters.AddWithValue("@UserID", SessionManager.UserID);
                checkCommand.Parameters.AddWithValue("@ProductID", product.ProductID);

                object result = checkCommand.ExecuteScalar();

                if (result != null) // Update quantity
                {
                    int newQuantity = Convert.ToInt32(result) + 1;

                    if (newQuantity > product.StockLevel)
                    {
                        MessageBox.Show("Cannot add more items. Stock limit reached.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string updateQuery = "UPDATE CART SET Quantity = @Quantity WHERE UserID = @UserID AND ProductID = @ProductID";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
                    updateCommand.Parameters.AddWithValue("@Quantity", newQuantity);
                    updateCommand.Parameters.AddWithValue("@UserID", SessionManager.UserID);
                    updateCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                    updateCommand.ExecuteNonQuery();
                }
                else 
                {
                    if (product.StockLevel < 1)
                    {
                        MessageBox.Show("Out of stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string insertQuery = "INSERT INTO CART (UserID, ProductID, Quantity) VALUES (@UserID, @ProductID, 1)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
                    insertCommand.Parameters.AddWithValue("@UserID", SessionManager.UserID);
                    insertCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                    insertCommand.ExecuteNonQuery();
                }
            }

            MessageBox.Show($"{product.Name} added to cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            string category = cbCategory.SelectedItem?.ToString() == "All Categories" ? null : cbCategory.SelectedItem?.ToString();
            string brand = cbBrand.SelectedItem?.ToString() == "All Brands" ? null : cbBrand.SelectedItem?.ToString();
            decimal? minPrice = string.IsNullOrWhiteSpace(txtMinPrice.Text) ? (decimal?)null : Convert.ToDecimal(txtMinPrice.Text);
            decimal? maxPrice = string.IsNullOrWhiteSpace(txtMaxPrice.Text) ? (decimal?)null : Convert.ToDecimal(txtMaxPrice.Text);

            try
            {
                string query = @"
            SELECT P.ProductID, P.Name, P.Price, P.Description, P.StockLevel, P.ImageURL
            FROM ISPRODUCT P
            INNER JOIN CATEGORY C ON P.CategoryID = C.CategoryID
            INNER JOIN SELLER S ON P.SellerID = S.SellerID
            WHERE (@Category IS NULL OR C.CategoryName = @Category)
              AND (@Brand IS NULL OR S.StoreName = @Brand)
              AND (@MinPrice IS NULL OR P.Price >= @MinPrice)
              AND (@MaxPrice IS NULL OR P.Price <= @MaxPrice)
            ORDER BY P.Name";

                List<Product> filteredProducts = new List<Product>();

                using (var conn = DBHandler.GetConnection())
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@Category", (object)category ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Brand", (object)brand ?? DBNull.Value);
                    command.Parameters.AddWithValue("@MinPrice", (object)minPrice ?? DBNull.Value);
                    command.Parameters.AddWithValue("@MaxPrice", (object)maxPrice ?? DBNull.Value);

                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            filteredProducts.Add(new Product(
                                productID: Convert.ToInt32(reader["ProductID"]),
                                name: reader["Name"].ToString(),
                                price: reader["Price"].ToString(),
                                description: reader["Description"].ToString(),
                                stockLevel: Convert.ToInt32(reader["StockLevel"]),
                                imagePath: reader["ImageURL"].ToString()
                            ));
                        }
                    }
                }

                DisplayProducts(filteredProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during search: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCart_Click(object sender, EventArgs e)
        {
            CustomerCart cartForm = new CustomerCart();
            cartForm.Show();
            this.Hide();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Close();
        }

        private void txtMinPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbRating_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMaxPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelProducts_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public int StockLevel { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }
        public bool Selected { get; set; }

        public Product(int productID, string name, string price, string description, int stockLevel, string imagePath, int quantity = 0)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            Description = description;
            StockLevel = stockLevel;
            ImagePath = imagePath;
            Quantity = quantity;
            Selected = false;
        }
    }
}
