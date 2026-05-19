using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EQUIPTRACK
{
    public partial class adminform : Form
    {
        private int selectedLabSlipId = 0;
        private int _adminId;
        private Chart chartMostBorrowed;
        private Chart chartBorrowingTrend;

        public adminform()
        {
            InitializeComponent();
            LoadEquipmentFilter();
            LoadSlipFilter();
            cmbSlipFilter.SelectedIndexChanged += cmbSlipFilter_SelectedIndexChanged;
            LoadCoursesIntoCombo();
            txtLabSlipSearch.TextChanged += txtLabSlipSearch_TextChanged;
            dgvLabSlips.SelectionChanged += dgvLabSlips_SelectionChanged;
            hamburgerpanel.Visible = false;
            addEquipmentPanel.Visible = false;
            addUserPanel.Visible = false;

            StyleDataGridView(dgvOverdue);
            StyleDataGridView(dgvBorrowed);
            StyleDataGridView(dgvReservations);
            StyleDataGridView(dataGridView1);
            StyleDataGridView(dgvUsers);
            StyleDataGridView(dgvborr);
            StyleDataGridView(dgvres);
            StyleDataGridView(returnedgv);
            StyleDataGridView(dgvLabSlips);
            StyleDataGridView(dgvLabSlipMembers);
            StyleDataGridView(dgvLabSlipItems);

            LoadLabBorrowSlips();
            LoadDashboard();
            LoadEquipment();
            LoadBorrowed();
            LoadReservations();
            LoadUsers();
            Loadreturn();

            LoadCourseAnalyticsFilter();
            CreateMostBorrowedChart();
            LoadMostBorrowedChart();
            CreateBorrowingTrendChart();
            LoadBorrowingTrendChart();
        }

        public adminform(int adminId) : this()
        {
            _adminId = adminId;
        }

        // ================= UI STYLE =================
        private void StyleDataGridView(DataGridView dgv)
        {
            Color brandingRed = Color.FromArgb(246, 43, 42);

            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = brandingRed;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersHeight = 45;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 230, 230);
            dgv.DefaultCellStyle.SelectionForeColor = brandingRed;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.GridColor = Color.FromArgb(240, 240, 240);
            dgv.ReadOnly = true;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
        }

        // ================= DASHBOARD =================
        private void LoadDashboard()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                (SELECT COUNT(*) FROM equipment) AS total,
                (SELECT COUNT(*) FROM equipment WHERE status='Available') AS available,
                (SELECT COUNT(*) FROM borrow_records WHERE status='Borrowed') AS borrowed,
                (SELECT COUNT(*) FROM borrow_records WHERE status='Overdue') AS overdue,
                (SELECT COUNT(*) FROM lab_borrow_slips WHERE status='Pending') AS lab_pending,
                (SELECT COUNT(*) FROM lab_borrow_slips WHERE status='Released') AS lab_released,
                (SELECT COUNT(*) FROM lab_borrow_slips WHERE status='Replacement Required') AS lab_replacement";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblTotal.Text = reader["total"].ToString();
                    lblAvailable.Text = reader["available"].ToString();
                    lblBorrowed.Text = reader["borrowed"].ToString();
                    lblOverdue.Text = reader["overdue"].ToString();
                    label15.Text = reader["total"].ToString();
                    label16.Text = reader["available"].ToString();

                    lblLabPending.Text = reader["lab_pending"].ToString();
                    lblLabReleased.Text = reader["lab_released"].ToString();
                    lblLabReplacement.Text = reader["lab_replacement"].ToString();
                }
            }
        }

        // ================= EQUIPMENT =================
        private void LoadEquipment()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = "SELECT equipment_id, name, category, quantity_total, quantity_available, status FROM equipment";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvOverdue.DataSource = table;
                dataGridView1.DataSource = table;
            }
        }

        // ================= BORROWED =================
        private void LoadBorrowed()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        b.borrow_id,
                        CONCAT(u.first_name, ' ', u.last_name) AS borrower,
                        e.name AS equipment,
                        b.quantity,
                        b.borrow_time,
                        b.return_time,
                        b.status
                    FROM borrow_records b
                    JOIN users u ON b.user_id = u.user_id
                    JOIN equipment e ON b.equipment_id = e.equipment_id
                    WHERE b.status IN ('Borrowed', 'Overdue')";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvBorrowed.DataSource = table;
                dgvborr.DataSource = table;
            }
        }

        private void Loadreturn()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        b.borrow_id,
                        b.user_id,
                        b.equipment_id,
                        CONCAT(u.first_name, ' ', u.last_name) AS borrower,
                        e.name AS equipment,
                        b.quantity,
                        b.borrow_time,
                        b.return_time,
                        b.status
                    FROM borrow_records b
                    JOIN users u ON b.user_id = u.user_id
                    JOIN equipment e ON b.equipment_id = e.equipment_id
                    WHERE b.status = 'Return Pending'";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                returnedgv.DataSource = table;
            }
        }

        // ================= RESERVATIONS =================
        private void LoadReservations()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                s.slip_id,
                s.slip_code,
                CONCAT(u.first_name, ' ', u.last_name) AS student,
                c.course_code AS course,
                s.group_name,
                s.subject_or_experiment,
                s.requested_at,
                s.expected_return_at,
                s.status
            FROM lab_borrow_slips s
            JOIN users u ON s.leader_user_id = u.user_id
            JOIN courses c ON s.course_id = c.course_id
            WHERE s.status = 'Pending'
            ORDER BY s.requested_at DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvReservations.DataSource = table;
                dgvres.DataSource = table;
            }
        }

        // ================= USERS =================
        private void LoadUsers()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = "SELECT user_id, first_name, last_name, mobile_no, address, role, username FROM users";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvUsers.DataSource = table;
            }
        }

        // ================= NAV =================
        private void dashboard_Click(object sender, EventArgs e) { tabcontrol1.SelectedIndex = 0; }
        private void equipment_click(object sender, EventArgs e) { tabcontrol1.SelectedIndex = 1; }
        private void user_Click(object sender, EventArgs e) { tabcontrol1.SelectedIndex = 2; }
        private void brrwdres_Click(object sender, EventArgs e) { tabcontrol1.SelectedIndex = 3; }
        private void return_Click(object sender, EventArgs e) { tabcontrol1.SelectedIndex = 4; }
        private void analytics_Click(object sender, EventArgs e) { tabcontrol1.SelectedIndex = 5; }
        private void btnLabSlips_Click(object sender, EventArgs e) { tabcontrol1.SelectedIndex = 6; }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void btnHamburger_Click(object sender, EventArgs e)
        {
            hamburgerpanel.Visible = !hamburgerpanel.Visible;
        }

        // ================= RETURN APPROVAL =================
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (returnedgv.CurrentRow == null)
            {
                MessageBox.Show("Please select a return record first.");
                return;
            }

            int borrowId = Convert.ToInt32(returnedgv.CurrentRow.Cells["borrow_id"].Value);
            int equipmentId = Convert.ToInt32(returnedgv.CurrentRow.Cells["equipment_id"].Value);
            int quantity = Convert.ToInt32(returnedgv.CurrentRow.Cells["quantity"].Value);

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string updateBorrowQuery = @"
                        UPDATE borrow_records
                        SET status = 'Returned', return_time = NOW()
                        WHERE borrow_id = @borrow_id";

                    using (MySqlCommand cmd = new MySqlCommand(updateBorrowQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@borrow_id", borrowId);
                        cmd.ExecuteNonQuery();
                    }

                    string updateEquipmentQuery = @"
                        UPDATE equipment
                        SET quantity_available = LEAST(quantity_available + @quantity, quantity_total),
                            status = CASE
                                WHEN LEAST(quantity_available + @quantity, quantity_total) > 0 THEN 'Available'
                                ELSE 'Unavailable'
                            END
                        WHERE equipment_id = @equipment_id";

                    using (MySqlCommand cmd = new MySqlCommand(updateEquipmentQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@equipment_id", equipmentId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Return approved successfully.");

                    LoadBorrowed();
                    Loadreturn();
                    LoadDashboard();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (returnedgv.CurrentRow == null)
            {
                MessageBox.Show("Please select a return record first.");
                return;
            }

            int borrowId = Convert.ToInt32(returnedgv.CurrentRow.Cells["borrow_id"].Value);

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                try
                {
                    string query = @"
                        UPDATE borrow_records
                        SET status = 'Borrowed'
                        WHERE borrow_id = @borrow_id AND status = 'Return Pending'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@borrow_id", borrowId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Return request declined.");
                    LoadBorrowed();
                    Loadreturn();
                    LoadDashboard();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // ================= RESERVATIONS APPROVAL =================
        private void btnApproveReservation_Click(object sender, EventArgs e)
        {
            // Pending slips show in the reservations grid now
            // so approving a reservation = approving the slip
            if (dgvReservations.CurrentRow == null)
            {
                MessageBox.Show("Please select a pending slip first.");
                return;
            }

            selectedLabSlipId = Convert.ToInt32(dgvReservations.CurrentRow.Cells["slip_id"].Value);
            btnApproveSlip_Click(sender, e);
            LoadReservations();
        }

        // ================= EQUIPMENT MANAGEMENT =================
        private void btnOpenAddPanel_Click(object sender, EventArgs e)
        {
            cmbEquipmentCourse.Items.Clear();
            cmbEquipmentCourse.Items.Add("CPE");
            cmbEquipmentCourse.Items.Add("EE");
            cmbEquipmentCourse.Items.Add("BSN");
            cmbEquipmentCourse.SelectedIndex = 0;

            addEquipmentPanel.Visible = true;
            addEquipmentPanel.BringToFront();
        }

        private void btnCancelEquipment_Click(object sender, EventArgs e)
        {
            ClearEquipmentFields();
            addEquipmentPanel.Visible = false;
        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) ||
                string.IsNullOrWhiteSpace(txtQuantityTotal.Text) ||
                string.IsNullOrWhiteSpace(txtQuantityAvailable.Text) ||
                string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!int.TryParse(txtQuantityTotal.Text.Trim(), out int quantityTotal))
            {
                MessageBox.Show("Quantity total must be a number.");
                txtQuantityTotal.Focus();
                return;
            }

            if (!int.TryParse(txtQuantityAvailable.Text.Trim(), out int quantityAvailable))
            {
                MessageBox.Show("Quantity available must be a number.");
                txtQuantityAvailable.Focus();
                return;
            }

            if (quantityAvailable > quantityTotal)
            {
                MessageBox.Show("Quantity available cannot be greater than quantity total.");
                return;
            }

            string courseCategory = cmbEquipmentCourse.SelectedItem?.ToString() ?? "CPE";

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string query = @"
                INSERT INTO equipment 
                    (name, description, category, quantity_total, quantity_available, 
                     status, slip_only, requires_slip, course_category)
                VALUES 
                    (@name, @description, @category, @quantity_total, @quantity_available, 
                     @status, 1, 1, @course_category)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@category", txtCategory.Text.Trim());
                        cmd.Parameters.AddWithValue("@quantity_total", quantityTotal);
                        cmd.Parameters.AddWithValue("@quantity_available", quantityAvailable);
                        cmd.Parameters.AddWithValue("@status", txtStatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@course_category", courseCategory);
                        cmd.ExecuteNonQuery();

                        // Get the new equipment id
                        int newEquipmentId = Convert.ToInt32(cmd.LastInsertedId);

                        // Insert course permission so students can see it immediately
                        string permQuery = @"
                    INSERT INTO course_equipment_permissions 
                        (course_id, equipment_id, is_allowed, created_at)
                    SELECT course_id, @equipment_id, 1, NOW()
                    FROM courses
                    WHERE course_code = @course_code";

                        using (MySqlCommand permCmd = new MySqlCommand(permQuery, conn, transaction))
                        {
                            permCmd.Parameters.AddWithValue("@equipment_id", newEquipmentId);
                            permCmd.Parameters.AddWithValue("@course_code", courseCategory);
                            permCmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Equipment added successfully.");
                    ClearEquipmentFields();
                    addEquipmentPanel.Visible = false;
                    LoadEquipment();
                    LoadDashboard();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error adding equipment: " + ex.Message);
                }
            }
        }

        private void ClearEquipmentFields()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtCategory.Clear();
            txtQuantityTotal.Clear();
            txtQuantityAvailable.Clear();
            txtStatus.Clear();
            cmbEquipmentCourse.SelectedIndex = 0;
        }
        private void btnDeleteEquipment_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select an equipment record first.");
                return;
            }

            int equipmentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["equipment_id"].Value);
            string equipmentName = dataGridView1.CurrentRow.Cells["name"].Value.ToString();

            DialogResult result = MessageBox.Show(
                "Delete equipment: " + equipmentName + "?",
                "Delete Equipment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string checkBorrowQuery = @"
                    SELECT COUNT(*) FROM borrow_records
                    WHERE equipment_id = @equipment_id
                      AND status IN ('Borrowed', 'Overdue', 'Return Pending')";

                using (MySqlCommand cmd = new MySqlCommand(checkBorrowQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@equipment_id", equipmentId);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("This equipment cannot be deleted because it is currently being used.");
                        return;
                    }
                }

                string checkReservationQuery = @"
                    SELECT COUNT(*) FROM reservations
                    WHERE equipment_id = @equipment_id AND status = 'pending'";

                using (MySqlCommand cmd = new MySqlCommand(checkReservationQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@equipment_id", equipmentId);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("This equipment cannot be deleted because it has pending reservations.");
                        return;
                    }
                }

                string deleteQuery = "DELETE FROM equipment WHERE equipment_id = @equipment_id";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@equipment_id", equipmentId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Equipment deleted successfully.");
            LoadEquipment();
            LoadDashboard();
            LoadMostBorrowedChart();
            LoadBorrowingTrendChart();
        }

        // ================= USER MANAGEMENT =================
        private void btnOpenUserPanel_Click(object sender, EventArgs e)
        {
            addUserPanel.Visible = true;
            addUserPanel.BringToFront();
        }

        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            ClearUserFields();
            addUserPanel.Visible = false;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtMobileNo.Text) ||
                string.IsNullOrWhiteSpace(txtRole.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            object courseId = DBNull.Value;
            if (cmbUserCourse.SelectedValue != null &&
                cmbUserCourse.SelectedValue != DBNull.Value &&
                cmbUserCourse.Text != "None")
            {
                courseId = Convert.ToInt32(cmbUserCourse.SelectedValue);
            }

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
            INSERT INTO users 
                (first_name, last_name, mobile_no, address, role, username, password, course_id)
            VALUES 
                (@first_name, @last_name, @mobile_no, @address, @role, @username, @password, @course_id)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@mobile_no", txtMobileNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", "");
                    cmd.Parameters.AddWithValue("@role", txtRole.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", "123456");
                    cmd.Parameters.AddWithValue("@course_id", courseId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("User added successfully. Default password is 123456.");
            ClearUserFields();
            addUserPanel.Visible = false;
            LoadUsers();
        }

        private void ClearUserFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMobileNo.Clear();
            txtRole.Clear();
            txtUsername.Clear();
            if (cmbUserCourse.Items.Count > 0)
                cmbUserCourse.SelectedIndex = 0;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["user_id"].Value);
            string fullName =
                dgvUsers.CurrentRow.Cells["first_name"].Value.ToString() + " " +
                dgvUsers.CurrentRow.Cells["last_name"].Value.ToString();

            DialogResult result = MessageBox.Show(
                "Delete user: " + fullName + "?",
                "Delete User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string checkBorrowQuery = @"
                    SELECT COUNT(*) FROM borrow_records
                    WHERE user_id = @user_id
                      AND status IN ('Borrowed', 'Overdue', 'Return Pending')";

                using (MySqlCommand cmd = new MySqlCommand(checkBorrowQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("This user cannot be deleted because they still have active borrowed items.");
                        return;
                    }
                }

                string checkReservationQuery = @"
                    SELECT COUNT(*) FROM reservations
                    WHERE user_id = @user_id AND status = 'pending'";

                using (MySqlCommand cmd = new MySqlCommand(checkReservationQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("This user cannot be deleted because they still have pending reservations.");
                        return;
                    }
                }

                string deleteQuery = "DELETE FROM users WHERE user_id = @user_id";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("User deleted successfully.");
            LoadUsers();
        }

        // ================= SEARCH =================
        private void txtBorrowedSearch_TextChanged(object sender, EventArgs e) { SearchBorrowed(txtBorrowedSearch.Text.Trim()); }
        private void txtReservationSearch_TextChanged(object sender, EventArgs e) { SearchReservations(txtReservationSearch.Text.Trim()); }
        private void txtReturnedSearch_TextChanged(object sender, EventArgs e) { SearchReturned(txtReturnedSearch.Text.Trim()); }
        private void txtUserSearch_TextChanged(object sender, EventArgs e) { SearchUsers(txtUserSearch.Text.Trim()); }
        private void txtEquipmentSearch_TextChanged(object sender, EventArgs e) { SearchEquipment(txtEquipmentSearch.Text.Trim()); }

        private void SearchBorrowed(string keyword)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT b.borrow_id, CONCAT(u.first_name, ' ', u.last_name) AS borrower,
                        e.name AS equipment, b.quantity, b.borrow_time, b.return_time, b.status
                    FROM borrow_records b
                    JOIN users u ON b.user_id = u.user_id
                    JOIN equipment e ON b.equipment_id = e.equipment_id
                    WHERE b.status IN ('Borrowed', 'Overdue')
                      AND (CONCAT(u.first_name, ' ', u.last_name) LIKE @keyword
                        OR e.name LIKE @keyword OR b.status LIKE @keyword)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvBorrowed.DataSource = table;
                    dgvborr.DataSource = table;
                }
            }
        }

        private void SearchReservations(string keyword)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT 
                s.slip_id,
                s.slip_code,
                CONCAT(u.first_name, ' ', u.last_name) AS student,
                c.course_code AS course,
                s.group_name,
                s.subject_or_experiment,
                s.requested_at,
                s.expected_return_at,
                s.status
            FROM lab_borrow_slips s
            JOIN users u ON s.leader_user_id = u.user_id
            JOIN courses c ON s.course_id = c.course_id
            WHERE s.status = 'Pending'
              AND (s.slip_code LIKE @keyword
                OR CONCAT(u.first_name, ' ', u.last_name) LIKE @keyword
                OR c.course_code LIKE @keyword
                OR s.group_name LIKE @keyword
                OR s.status LIKE @keyword)
            ORDER BY s.requested_at DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvReservations.DataSource = table;
                    dgvres.DataSource = table;
                }
            }
        }

        private void SearchReturned(string keyword)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT b.borrow_id, b.user_id, b.equipment_id,
                        CONCAT(u.first_name, ' ', u.last_name) AS borrower,
                        e.name AS equipment, b.quantity, b.borrow_time, b.return_time, b.status
                    FROM borrow_records b
                    JOIN users u ON b.user_id = u.user_id
                    JOIN equipment e ON b.equipment_id = e.equipment_id
                    WHERE b.status = 'Return Pending'
                      AND (CONCAT(u.first_name, ' ', u.last_name) LIKE @keyword
                        OR e.name LIKE @keyword OR b.status LIKE @keyword)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    returnedgv.DataSource = table;
                }
            }
        }

        private void SearchUsers(string keyword)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT user_id, first_name, last_name, mobile_no, address, role, username
                    FROM users
                    WHERE first_name LIKE @keyword OR last_name LIKE @keyword
                       OR mobile_no LIKE @keyword OR address LIKE @keyword
                       OR role LIKE @keyword OR username LIKE @keyword";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvUsers.DataSource = table;
                }
            }
        }

        private void SearchEquipment(string keyword)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT equipment_id, name, description, category, quantity_total, quantity_available, status
                    FROM equipment
                    WHERE name LIKE @keyword OR description LIKE @keyword
                       OR category LIKE @keyword OR status LIKE @keyword";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvOverdue.DataSource = table;
                    dataGridView1.DataSource = table;
                }
            }
        }

        // ================= CHARTS =================
        private void CreateMostBorrowedChart()
        {
            chartMostBorrowed = new Chart();
            chartMostBorrowed.Dock = DockStyle.Fill;
            chartMostBorrowed.BackColor = Color.White;

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.LabelStyle.Angle = -20;
            area.BackColor = Color.White;
            chartMostBorrowed.ChartAreas.Add(area);

            Legend legend = new Legend();
            legend.Enabled = false;
            chartMostBorrowed.Legends.Add(legend);

            Series series = new Series("Borrowed");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.Color = Color.FromArgb(246, 43, 42);
            chartMostBorrowed.Series.Add(series);

            Title title = new Title("Most Borrowed Equipment");
            title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            chartMostBorrowed.Titles.Add(title);

            panelAnalytics.Controls.Clear();
            panelAnalytics.Controls.Add(chartMostBorrowed);
        }

        private void LoadMostBorrowedChart(string courseFilter = "All Courses")
        {
            if (chartMostBorrowed == null) return;
            chartMostBorrowed.Series["Borrowed"].Points.Clear();

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query;

                if (courseFilter == "All Courses")
                {
                    query = @"
                SELECT e.name, SUM(b.quantity) AS total_borrowed
                FROM borrow_records b
                JOIN equipment e ON b.equipment_id = e.equipment_id
                GROUP BY e.equipment_id, e.name
                ORDER BY total_borrowed DESC LIMIT 5";
                }
                else
                {
                    query = @"
                SELECT e.name, SUM(b.quantity) AS total_borrowed
                FROM borrow_records b
                JOIN equipment e ON b.equipment_id = e.equipment_id
                JOIN course_equipment_permissions p ON e.equipment_id = p.equipment_id
                JOIN courses c ON p.course_id = c.course_id
                WHERE c.course_code = @course
                GROUP BY e.equipment_id, e.name
                ORDER BY total_borrowed DESC LIMIT 5";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (courseFilter != "All Courses")
                        cmd.Parameters.AddWithValue("@course", courseFilter);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            chartMostBorrowed.Series["Borrowed"].Points.AddXY(
                                reader["name"].ToString(),
                                Convert.ToInt32(reader["total_borrowed"]));
                    }
                }
            }
        }



        private void CreateBorrowingTrendChart()
        {
            chartBorrowingTrend = new Chart();
            chartBorrowingTrend.Dock = DockStyle.Fill;
            chartBorrowingTrend.BackColor = Color.White;

            ChartArea area = new ChartArea("TrendArea");
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.BackColor = Color.White;
            chartBorrowingTrend.ChartAreas.Add(area);

            Legend legend = new Legend();
            legend.Enabled = false;
            chartBorrowingTrend.Legends.Add(legend);

            Series series = new Series("Trend");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.Color = Color.FromArgb(246, 43, 42);
            series.IsValueShownAsLabel = true;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            series.MarkerColor = Color.FromArgb(246, 43, 42);
            chartBorrowingTrend.Series.Add(series);

            Title title = new Title("Borrowing Trend");
            title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            chartBorrowingTrend.Titles.Add(title);

            panelBorrowingTrend.Controls.Clear();
            panelBorrowingTrend.Controls.Add(chartBorrowingTrend);
        }

        private void LoadBorrowingTrendChart(string courseFilter = "All Courses")
        {
            if (chartBorrowingTrend == null) return;
            chartBorrowingTrend.Series["Trend"].Points.Clear();

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query;

                if (courseFilter == "All Courses")
                {
                    query = @"
                SELECT DATE(b.borrow_time) AS borrow_date, SUM(b.quantity) AS total_borrowed
                FROM borrow_records b
                GROUP BY DATE(b.borrow_time)
                ORDER BY borrow_date";
                }
                else
                {
                    query = @"
                SELECT DATE(b.borrow_time) AS borrow_date, SUM(b.quantity) AS total_borrowed
                FROM borrow_records b
                JOIN equipment e ON b.equipment_id = e.equipment_id
                JOIN course_equipment_permissions p ON e.equipment_id = p.equipment_id
                JOIN courses c ON p.course_id = c.course_id
                WHERE c.course_code = @course
                GROUP BY DATE(b.borrow_time)
                ORDER BY borrow_date";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (courseFilter != "All Courses")
                        cmd.Parameters.AddWithValue("@course", courseFilter);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            chartBorrowingTrend.Series["Trend"].Points.AddXY(
                                Convert.ToDateTime(reader["borrow_date"]).ToString("MMM dd"),
                                Convert.ToInt32(reader["total_borrowed"]));
                    }
                }
            }
        }

        // ================= LAB BORROW SLIPS =================
        private void LoadLabBorrowSlips()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT s.slip_id, s.slip_code,
                        CONCAT(u.first_name, ' ', u.last_name) AS leader,
                        c.course_code, s.group_name, s.subject_or_experiment,
                        s.faculty_name, s.requested_at, s.expected_return_at, s.status
                    FROM lab_borrow_slips s
                    JOIN users u ON s.leader_user_id = u.user_id
                    JOIN courses c ON s.course_id = c.course_id
                    ORDER BY s.requested_at DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvLabSlips.DataSource = table;
            }

            ClearLabSlipDetails();
        }

        private void LoadLabSlipMembers(int slipId)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT slip_member_id, member_name, member_role
                    FROM lab_borrow_slip_members
                    WHERE slip_id = @slip_id
                    ORDER BY slip_member_id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@slip_id", slipId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvLabSlipMembers.DataSource = table;
                }
            }
        }

        private void LoadLabSlipItems(int slipId)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT i.slip_item_id, e.name AS equipment,
                        i.quantity_requested, i.quantity_approved, i.quantity_released,
                        i.quantity_returned, i.item_status, i.return_condition, i.remarks
                    FROM lab_borrow_slip_items i
                    JOIN equipment e ON i.equipment_id = e.equipment_id
                    WHERE i.slip_id = @slip_id
                    ORDER BY i.slip_item_id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@slip_id", slipId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvLabSlipItems.DataSource = table;
                }
            }
        }

        private void ClearLabSlipDetails()
        {
            dgvLabSlipMembers.DataSource = null;
            dgvLabSlipItems.DataSource = null;
            selectedLabSlipId = 0;
        }

        private void SearchLabBorrowSlips(string keyword)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT s.slip_id, s.slip_code,
                        CONCAT(u.first_name, ' ', u.last_name) AS leader,
                        c.course_code, s.group_name, s.subject_or_experiment,
                        s.faculty_name, s.requested_at, s.expected_return_at, s.status
                    FROM lab_borrow_slips s
                    JOIN users u ON s.leader_user_id = u.user_id
                    JOIN courses c ON s.course_id = c.course_id
                    WHERE s.slip_code LIKE @keyword
                       OR CONCAT(u.first_name, ' ', u.last_name) LIKE @keyword
                       OR c.course_code LIKE @keyword
                       OR s.group_name LIKE @keyword
                       OR s.subject_or_experiment LIKE @keyword
                       OR s.faculty_name LIKE @keyword
                       OR s.status LIKE @keyword
                    ORDER BY s.requested_at DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvLabSlips.DataSource = table;
                }
            }

            ClearLabSlipDetails();
        }

        private void txtLabSlipSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLabSlipSearch.Text))
                LoadLabBorrowSlips();
            else
                SearchLabBorrowSlips(txtLabSlipSearch.Text.Trim());
        }

        private void dgvLabSlips_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLabSlips.CurrentRow == null ||
                dgvLabSlips.CurrentRow.Cells["slip_id"].Value == null)
            {
                ClearLabSlipDetails();
                return;
            }

            selectedLabSlipId = Convert.ToInt32(dgvLabSlips.CurrentRow.Cells["slip_id"].Value);
            LoadLabSlipMembers(selectedLabSlipId);
            LoadLabSlipItems(selectedLabSlipId);
        }

        private void btnApproveSlip_Click(object sender, EventArgs e)
        {
            if (selectedLabSlipId == 0) { MessageBox.Show("Please select a slip first."); return; }

            string currentStatus = dgvLabSlips.CurrentRow.Cells["status"].Value.ToString();
            if (currentStatus != "Pending") { MessageBox.Show("Only pending slips can be approved."); return; }

            if (MessageBox.Show("Approve this slip?", "Approve Slip", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE lab_borrow_slips
                    SET status = 'Approved', approved_by_user_id = @admin_id, approved_at = NOW()
                    WHERE slip_id = @slip_id AND status = 'Pending'";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@admin_id", _adminId);
                    cmd.Parameters.AddWithValue("@slip_id", selectedLabSlipId);
                    cmd.ExecuteNonQuery();
                }

                string updateItems = @"
                    UPDATE lab_borrow_slip_items
                    SET item_status = 'Approved', quantity_approved = quantity_requested
                    WHERE slip_id = @slip_id AND item_status = 'Requested'";

                using (MySqlCommand cmd = new MySqlCommand(updateItems, conn))
                {
                    cmd.Parameters.AddWithValue("@slip_id", selectedLabSlipId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Slip approved successfully.");
            LoadLabBorrowSlips();
        }

        private void btnReleaseItems_Click(object sender, EventArgs e)
        {
            if (selectedLabSlipId == 0) { MessageBox.Show("Please select a slip first."); return; }

            string currentStatus = dgvLabSlips.CurrentRow.Cells["status"].Value.ToString();
            if (currentStatus != "Approved") { MessageBox.Show("Only approved slips can have items released."); return; }

            if (MessageBox.Show("Release items? This will deduct from available equipment.", "Release Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Get slip leader user_id
                    int leaderUserId = 0;
                    string getLeader = "SELECT leader_user_id FROM lab_borrow_slips WHERE slip_id = @slip_id";
                    using (MySqlCommand cmd = new MySqlCommand(getLeader, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@slip_id", selectedLabSlipId);
                        leaderUserId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string getItems = @"
                SELECT slip_item_id, equipment_id, quantity_approved
                FROM lab_borrow_slip_items
                WHERE slip_id = @slip_id AND item_status = 'Approved'";

                    DataTable items = new DataTable();
                    using (MySqlCommand cmd = new MySqlCommand(getItems, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@slip_id", selectedLabSlipId);
                        new MySqlDataAdapter(cmd).Fill(items);
                    }

                    foreach (DataRow row in items.Rows)
                    {
                        int equipmentId = Convert.ToInt32(row["equipment_id"]);
                        int qtyApproved = Convert.ToInt32(row["quantity_approved"]);
                        int slipItemId = Convert.ToInt32(row["slip_item_id"]);

                        // Check available stock
                        int available = 0;
                        using (MySqlCommand cmd = new MySqlCommand(
                            "SELECT quantity_available FROM equipment WHERE equipment_id = @equipment_id",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@equipment_id", equipmentId);
                            available = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        if (qtyApproved > available)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Not enough stock for one of the items. Release cancelled.");
                            return;
                        }

                        // Deduct from equipment
                        string deductEquip = @"
                    UPDATE equipment
                    SET quantity_available = quantity_available - @qty,
                        status = CASE 
                            WHEN quantity_available - @qty <= 0 THEN 'Unavailable' 
                            ELSE 'Available' 
                        END
                    WHERE equipment_id = @equipment_id";

                        using (MySqlCommand cmd = new MySqlCommand(deductEquip, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@qty", qtyApproved);
                            cmd.Parameters.AddWithValue("@equipment_id", equipmentId);
                            cmd.ExecuteNonQuery();
                        }

                        // Update slip item status
                        string updateItem = @"
                    UPDATE lab_borrow_slip_items
                    SET item_status = 'Released', quantity_released = quantity_approved
                    WHERE slip_item_id = @slip_item_id";

                        using (MySqlCommand cmd = new MySqlCommand(updateItem, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@slip_item_id", slipItemId);
                            cmd.ExecuteNonQuery();
                        }

                        // CREATE BORROW RECORD so it shows in borrowed items tab
                        string insertBorrow = @"
                    INSERT INTO borrow_records 
                        (user_id, equipment_id, quantity, borrow_time, return_time, status)
                    VALUES 
                        (@user_id, @equipment_id, @quantity, NOW(), NULL, 'Borrowed')";

                        using (MySqlCommand cmd = new MySqlCommand(insertBorrow, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@user_id", leaderUserId);
                            cmd.Parameters.AddWithValue("@equipment_id", equipmentId);
                            cmd.Parameters.AddWithValue("@quantity", qtyApproved);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Update slip status to Released
                    string updateSlip = @"
                UPDATE lab_borrow_slips
                SET status = 'Released', released_by_user_id = @admin_id, released_at = NOW()
                WHERE slip_id = @slip_id";

                    using (MySqlCommand cmd = new MySqlCommand(updateSlip, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@admin_id", _adminId);
                        cmd.Parameters.AddWithValue("@slip_id", selectedLabSlipId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Items released successfully.");
                    LoadLabBorrowSlips();
                    LoadReservations();
                    LoadBorrowed();
                    LoadEquipment();
                    LoadDashboard();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error releasing items: " + ex.Message);
                }
            }
        }

        private void btnMarkReturned_Click(object sender, EventArgs e)
        {
            if (selectedLabSlipId == 0) { MessageBox.Show("Please select a slip first."); return; }

            string currentStatus = dgvLabSlips.CurrentRow.Cells["status"].Value.ToString();
            if (currentStatus != "Released") { MessageBox.Show("Only released slips can be marked as returned."); return; }

            if (MessageBox.Show("Mark all items as returned? This will restore equipment stock.", "Mark Returned", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Get leader INSIDE try so it's covered by rollback
                    int leaderUserId = 0;
                    string getLeader = "SELECT leader_user_id FROM lab_borrow_slips WHERE slip_id = @slip_id";
                    using (MySqlCommand cmd = new MySqlCommand(getLeader, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@slip_id", selectedLabSlipId);
                        leaderUserId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string getItems = @"
                SELECT slip_item_id, equipment_id, quantity_released
                FROM lab_borrow_slip_items
                WHERE slip_id = @slip_id AND item_status = 'Released'";

                    DataTable items = new DataTable();
                    using (MySqlCommand cmd = new MySqlCommand(getItems, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@slip_id", selectedLabSlipId);
                        new MySqlDataAdapter(cmd).Fill(items);
                    }

                    foreach (DataRow row in items.Rows)
                    {
                        int equipmentId = Convert.ToInt32(row["equipment_id"]);
                        int qtyReleased = Convert.ToInt32(row["quantity_released"]);
                        int slipItemId = Convert.ToInt32(row["slip_item_id"]);

                        // 1. Restore equipment stock
                        string restoreEquip = @"
                    UPDATE equipment
                    SET quantity_available = LEAST(quantity_available + @qty, quantity_total),
                        status = CASE 
                            WHEN LEAST(quantity_available + @qty, quantity_total) > 0 
                            THEN 'Available' ELSE 'Unavailable' 
                        END
                    WHERE equipment_id = @equipment_id";

                        using (MySqlCommand cmd = new MySqlCommand(restoreEquip, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@qty", qtyReleased);
                            cmd.Parameters.AddWithValue("@equipment_id", equipmentId);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Mark borrow record as Returned
                        string updateBorrowRecord = @"
                    UPDATE borrow_records
                    SET status = 'Returned', return_time = NOW()
                    WHERE equipment_id = @equipment_id
                      AND user_id = @leader_user_id
                      AND status IN ('Borrowed', 'Return Pending')";

                        using (MySqlCommand cmd = new MySqlCommand(updateBorrowRecord, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@equipment_id", equipmentId);
                            cmd.Parameters.AddWithValue("@leader_user_id", leaderUserId);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Mark slip item as Returned
                        string updateItem = @"
                    UPDATE lab_borrow_slip_items
                    SET item_status = 'Returned', quantity_returned = quantity_released, 
                        return_condition = 'Good'
                    WHERE slip_item_id = @slip_item_id";

                        using (MySqlCommand cmd = new MySqlCommand(updateItem, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@slip_item_id", slipItemId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 4. Mark the slip itself as Returned
                    string updateSlip = @"
                UPDATE lab_borrow_slips
                SET status = 'Returned', received_by_user_id = @admin_id, returned_at = NOW()
                WHERE slip_id = @slip_id";

                    using (MySqlCommand cmd = new MySqlCommand(updateSlip, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@admin_id", _adminId);
                        cmd.Parameters.AddWithValue("@slip_id", selectedLabSlipId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Slip marked as returned. Equipment stock restored.");
                    LoadLabBorrowSlips();
                    LoadBorrowed();
                    Loadreturn();
                    LoadEquipment();
                    LoadDashboard();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error marking returned: " + ex.Message);
                }
            }
        }
        private void btnDeclineSlip_Click(object sender, EventArgs e)
        {
            if (selectedLabSlipId == 0)
            {
                MessageBox.Show("Please select a slip first.");
                return;
            }

            string currentStatus = dgvLabSlips.CurrentRow.Cells["status"].Value.ToString();
            if (currentStatus != "Pending")
            {
                MessageBox.Show("Only pending slips can be declined.");
                return;
            }

            if (MessageBox.Show("Decline this slip?", "Decline Slip",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE lab_borrow_slips
                    SET status = 'Declined'
                    WHERE slip_id = @slip_id AND status = 'Pending'";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@slip_id", selectedLabSlipId);
                    cmd.ExecuteNonQuery();
                }

                string updateItems = @"
                    UPDATE lab_borrow_slip_items
                    SET item_status = 'Declined'
                    WHERE slip_id = @slip_id AND item_status = 'Requested'";

                using (MySqlCommand cmd = new MySqlCommand(updateItems, conn))
                {
                    cmd.Parameters.AddWithValue("@slip_id", selectedLabSlipId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Slip declined.");
            LoadLabBorrowSlips();
        }

        private void LoadCoursesIntoCombo()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                string query = "SELECT course_id, course_code FROM courses ORDER BY course_code";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                DataRow blankRow = table.NewRow();
                blankRow["course_id"] = DBNull.Value;
                blankRow["course_code"] = "None";
                table.Rows.InsertAt(blankRow, 0);

                cmbUserCourse.DisplayMember = "course_code";
                cmbUserCourse.ValueMember = "course_id";
                cmbUserCourse.DataSource = table;
            }
        }
        private void LoadEquipmentFilter()
        {
            cmbEquipmentFilter.Items.Clear();
            cmbEquipmentFilter.Items.Add("All");
            cmbEquipmentFilter.Items.Add("CPE");
            cmbEquipmentFilter.Items.Add("EE");
            cmbEquipmentFilter.Items.Add("BSN");
            cmbEquipmentFilter.SelectedIndex = 0;
            cmbEquipmentFilter.SelectedIndexChanged += cmbEquipmentFilter_SelectedIndexChanged;
        }

        private void cmbEquipmentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbEquipmentFilter.SelectedItem.ToString();

            if (selected == "All")
            {
                LoadEquipment();
                return;
            }

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT e.equipment_id, e.name, e.category, 
                   e.quantity_total, e.quantity_available, e.status
            FROM equipment e
            INNER JOIN course_equipment_permissions p ON e.equipment_id = p.equipment_id
            INNER JOIN courses c ON p.course_id = c.course_id
            WHERE c.course_code = @course_code
              AND p.is_allowed = 1
            ORDER BY e.name";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@course_code", selected);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvOverdue.DataSource = table;
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void LoadSlipFilter()
        {
            cmbSlipFilter.Items.Clear();
            cmbSlipFilter.Items.Add("All");
            cmbSlipFilter.Items.Add("Pending");
            cmbSlipFilter.Items.Add("Approved");
            cmbSlipFilter.Items.Add("Released");
            cmbSlipFilter.Items.Add("Partially Returned");
            cmbSlipFilter.Items.Add("Returned");
            cmbSlipFilter.Items.Add("Late Return");
            cmbSlipFilter.Items.Add("Declined");
            cmbSlipFilter.Items.Add("Replacement Required");
            cmbSlipFilter.Items.Add("Cancelled");
            cmbSlipFilter.SelectedIndex = 0;
        }

        private void cmbSlipFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbSlipFilter.SelectedItem.ToString();

            if (selected == "All")
            {
                LoadLabBorrowSlips();
                return;
            }

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT s.slip_id, s.slip_code,
                        CONCAT(u.first_name, ' ', u.last_name) AS leader,
                        c.course_code, s.group_name, s.subject_or_experiment,
                        s.faculty_name, s.requested_at, s.expected_return_at, s.status
                    FROM lab_borrow_slips s
                    JOIN users u ON s.leader_user_id = u.user_id
                    JOIN courses c ON s.course_id = c.course_id
                    WHERE s.status = @status
                    ORDER BY s.requested_at DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", selected);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvLabSlips.DataSource = table;
                }
            }

            ClearLabSlipDetails();
        }
        private void LoadCourseAnalyticsFilter()
        {
            // Find your analytics tab and add a ComboBox to it in the Designer
            // named cmbAnalyticsCourse, then wire it up here
            cmbAnalyticsCourse.Items.Clear();
            cmbAnalyticsCourse.Items.Add("All Courses");
            cmbAnalyticsCourse.Items.Add("CPE");
            cmbAnalyticsCourse.Items.Add("EE");
            cmbAnalyticsCourse.Items.Add("BSN");
            cmbAnalyticsCourse.SelectedIndex = 0;
            cmbAnalyticsCourse.SelectedIndexChanged += cmbAnalyticsCourse_SelectedIndexChanged;
        }
        private void cmbAnalyticsCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbAnalyticsCourse.SelectedItem.ToString();
            LoadMostBorrowedChart(selected);
            LoadBorrowingTrendChart(selected);
        }

        // ================= EMPTY HANDLERS =================
        private void button18_Click(object sender, EventArgs e) { }
        private void label25_Click(object sender, EventArgs e) { }
        private void txtRole_TextChanged(object sender, EventArgs e) { }
        private void tabPage4_Click(object sender, EventArgs e) { }
        private void label37_Click(object sender, EventArgs e) { }

        private void DASHBOARDtab_Click(object sender, EventArgs e)
        {

        }
    }
}