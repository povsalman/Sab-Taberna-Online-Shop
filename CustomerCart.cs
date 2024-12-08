using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class CustomerCart : Form
    {
        private List<Product> shoppingCart;

        public CustomerCart()
        {
            InitializeComponent();
            shoppingCart = SessionManager.ShoppingCart;
            DisplayCartItems();
        }


        private void Form12_Load(object sender, EventArgs e)
        {
            /*DisplayCartItems();*/
            LoadCartFromDatabase();
        }

        private void LoadCartFromDatabase()
        {
            shoppingCart.Clear();

            string query = @"
        SELECT C.ProductID, P.Name, P.Price, C.Quantity, P.ImageURL
        FROM CART C
        INNER JOIN ISPRODUCT P ON C.ProductID = P.ProductID
        WHERE C.UserID = @UserID";

            using (var conn = DBHandler.GetConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@UserID", SessionManager.UserID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shoppingCart.Add(new Product(
                            productID: Convert.ToInt32(reader["ProductID"]),
                            name: reader["Name"].ToString(),
                            price: reader["Price"].ToString(),
                            description: null,
                            stockLevel: 0,
                            imagePath: reader["ImageURL"].ToString(),
                            quantity: Convert.ToInt32(reader["Quantity"])
                        ));
                    }
                }
            }

            DisplayCartItems();
        }

        private void DisplayCartItems()
        {
            flowLayoutPanelCart.Controls.Clear();

            foreach (var product in shoppingCart) // shoppingCart is populated from the database
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

                Label lblQuantity = new Label
                {
                    Text = $"Quantity: {product.Quantity}",
                    Location = new Point(10, 310),
                    AutoSize = false,
                    Size = new Size(280, 30),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10, FontStyle.Regular)
                };

                Button btnCheckout = new Button
                {
                    Text = "Checkout",
                    Location = new Point(90, 360),
                    BackColor = Color.LightBlue,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(120, 40)
                };

                btnCheckout.Click += (s, e) => CheckoutProduct(product);

                Button btnRemove = new Button
                {
                    Text = "Remove",
                    Location = new Point(90, 410),
                    BackColor = Color.LightCoral,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(120, 40)
                };

                // Add event handler for remove button
                btnRemove.Click += (s, e) => RemoveFromCart(product);

                // Add controls to the product panel
                productPanel.Controls.Add(pictureBox);
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(lblPrice);
                productPanel.Controls.Add(lblQuantity);
                productPanel.Controls.Add(btnCheckout);
                productPanel.Controls.Add(btnRemove);

                flowLayoutPanelCart.Controls.Add(productPanel);
            }
        }







        /*  private void RemoveFromCart(Product product)
          {
              SessionManager.ShoppingCart.Remove(product);
              MessageBox.Show($"{product.Name} removed from cart.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
  */

        private void RemoveFromDatabaseCart(int productID)
        {
            string connectionString = @"Server=DESKTOP-36T2U50\SQLEXPRESS;Database=SABTaberna;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            string query = "DELETE FROM CART WHERE UserID = @UserID AND ProductID = @ProductID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", SessionManager.UserID);
                command.Parameters.AddWithValue("@ProductID", productID);
                command.ExecuteNonQuery();
            }
        }

        private void RemoveFromCart(Product product)
        {
            string query = "DELETE FROM CART WHERE UserID = @UserID AND ProductID = @ProductID";

            try
            {
                using (var conn = DBHandler.GetConnection())
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@UserID", SessionManager.UserID);
                    command.Parameters.AddWithValue("@ProductID", product.ProductID);
                    command.ExecuteNonQuery();
                }

                // Remove from in-memory cart
                shoppingCart.Remove(product);

                // Refresh the cart display
                DisplayCartItems();

                MessageBox.Show($"{product.Name} removed from the cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void CheckoutProduct(Product product)
        {
            int quantityToCheckout = product.Quantity;

            // Step 1: Prompt the user to select the quantity
            if (product.Quantity > 1)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"You have {product.Quantity} of {product.Name} in your cart. How many would you like to checkout?",
                    "Checkout Quantity",
                    product.Quantity.ToString()
                );

                if (!int.TryParse(input, out quantityToCheckout) || quantityToCheckout < 1 || quantityToCheckout > product.Quantity)
                {
                    MessageBox.Show("Invalid quantity entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Step 2: Prompt the user to select a shipping option
            string[] shippingOptions = { "Standard (5-7 days)", "Express (2-3 days)", "Overnight (Next day)" };
            string selectedShipping = shippingOptions[0]; // Default to the first option

            string shippingInput = Microsoft.VisualBasic.Interaction.InputBox(
                "Please choose a shipping option:\n1. Standard (5-7 days)\n2. Express (2-3 days)\n3. Overnight (Next day)",
                "Shipping Options",
                "1" // Default to option 1
            );

            if (shippingInput == "1") selectedShipping = "Standard (5-7 days)";
            else if (shippingInput == "2") selectedShipping = "Express (2-3 days)";
            else if (shippingInput == "3") selectedShipping = "Overnight (Next day)";
            else
            {
                MessageBox.Show("Invalid shipping option selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 3: Map selectedShipping to a valid ShippingStatus value
            string shippingStatus;
            switch (selectedShipping)
            {
                case "Standard (5-7 days)":
                    shippingStatus = "Pending";
                    break;
                case "Express (2-3 days)":
                    shippingStatus = "Pending";
                    break;
                case "Overnight (Next day)":
                    shippingStatus = "Shipped";
                    break;
                default:
                    shippingStatus = "Pending"; // Fallback
                    break;
            }

            // Step 4: Database logic

            using (var conn = DBHandler.GetConnection())
            {
                conn.Open();

                try
                {
                    // Insert into the order table
                    string insertOrderQuery = @"
                INSERT INTO ISORDER (CustomerID, OrderDate, ShippingStatus, TotalAmount, PaymentStatus)
                VALUES (@CustomerID, GETDATE(), @ShippingStatus, @TotalAmount, 'Pending');
                SELECT SCOPE_IDENTITY();";

                    SqlCommand orderCommand = new SqlCommand(insertOrderQuery, conn);
                    orderCommand.Parameters.AddWithValue("@CustomerID", SessionManager.UserID);
                    orderCommand.Parameters.AddWithValue("@ShippingStatus", shippingStatus);
                    orderCommand.Parameters.AddWithValue("@TotalAmount", Convert.ToDecimal(product.Price) * quantityToCheckout);

                    int orderId = Convert.ToInt32(orderCommand.ExecuteScalar());

                    // Insert into the order items table
                    string insertOrderItemQuery = @"
                INSERT INTO ORDER_ITEM (OrderID, ProductID, Quantity, Price)
                VALUES (@OrderID, @ProductID, @Quantity, @Price);";

                    SqlCommand itemCommand = new SqlCommand(insertOrderItemQuery, conn);
                    itemCommand.Parameters.AddWithValue("@OrderID", orderId);
                    itemCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                    itemCommand.Parameters.AddWithValue("@Quantity", quantityToCheckout);
                    itemCommand.Parameters.AddWithValue("@Price", product.Price);
                    itemCommand.ExecuteNonQuery();

                    // Update stock level in the database
                    string updateStockQuery = "UPDATE ISPRODUCT SET StockLevel = StockLevel - @Quantity WHERE ProductID = @ProductID;";
                    SqlCommand stockCommand = new SqlCommand(updateStockQuery, conn);
                    stockCommand.Parameters.AddWithValue("@Quantity", quantityToCheckout);
                    stockCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                    stockCommand.ExecuteNonQuery();

                    // Update cart in the database
                    int remainingQuantity = product.Quantity - quantityToCheckout;
                    if (remainingQuantity > 0)
                    {
                        string updateCartQuery = "UPDATE CART SET Quantity = @Quantity WHERE UserID = @UserID AND ProductID = @ProductID;";
                        SqlCommand updateCartCommand = new SqlCommand(updateCartQuery, conn);
                        updateCartCommand.Parameters.AddWithValue("@Quantity", remainingQuantity);
                        updateCartCommand.Parameters.AddWithValue("@UserID", SessionManager.UserID);
                        updateCartCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                        updateCartCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        string deleteCartQuery = "DELETE FROM CART WHERE UserID = @UserID AND ProductID = @ProductID;";
                        SqlCommand deleteCartCommand = new SqlCommand(deleteCartQuery, conn);
                        deleteCartCommand.Parameters.AddWithValue("@UserID", SessionManager.UserID);
                        deleteCartCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                        deleteCartCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show($"{quantityToCheckout} of {product.Name} successfully checked out with {selectedShipping} shipping!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during checkout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Update cart
            product.Quantity -= quantityToCheckout;
            if (product.Quantity == 0)
            {
                SessionManager.ShoppingCart.Remove(product);
            }

            // Refresh cart display
            DisplayCartItems();
        }



        /*private void btnCheckout_Click(object sender, EventArgs e)
        {
            foreach (var product in SessionManager.ShoppingCart.ToList()) // Use a copy to avoid modification issues
            {
                CheckoutProduct(product); // Checkout each product
            }
        }*/


        private void btnBack_Click(object sender, EventArgs e)
        {
            CustomerDashboard productForm = new CustomerDashboard();
            productForm.Show();
            this.Hide();
        }

    }
}
