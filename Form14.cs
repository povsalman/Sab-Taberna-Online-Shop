using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public class Review
    {
        public string Username { get; set; } // Username of the reviewer
        public int Rating { get; set; } // Rating between 1 and 5
        public string Comment { get; set; } // User's comment

        public Review(string username, int rating, string comment)
        {
            Username = username;
            Rating = rating;
            Comment = comment;
        }

        public override string ToString()
        {
            return $"{Username} - {Rating} stars\n{Comment}";
        }
    }
}
