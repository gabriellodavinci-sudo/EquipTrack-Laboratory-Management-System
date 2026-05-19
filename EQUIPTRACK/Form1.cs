
using MySql.Data.MySqlClient;
namespace EQUIPTRACK

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            if (DATABASE.TestConnection())
            {
                MessageBox.Show("Connected successfully!");
            }
            else
            {
                MessageBox.Show("Connection failed!");
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            int userId = 0;
            string role = "";

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = "SELECT user_id, role FROM users WHERE username = @username AND password = @password";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = Convert.ToInt32(reader["user_id"]);
                            role = reader["role"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                            return;
                        }
                    }
                }
            }

            MessageBox.Show("Login successful!");

            if (role == "Admin" || role == "admin")
            {
                adminform admin = new adminform(userId);
                admin.Show();
            }
            else
            {
                userform frm = new userform(userId);
                frm.Show();
            }

            this.Hide();
        }

    }
}
