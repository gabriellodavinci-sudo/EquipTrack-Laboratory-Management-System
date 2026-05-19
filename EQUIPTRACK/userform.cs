using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EQUIPTRACK
{
    public partial class userform : Form
    {
        private int _userId;
        private int _userCourseId = 0;
        private int _selectedEquipmentId;
        private List<SlipMemberEntry> _slipMembers = new List<SlipMemberEntry>();
        private List<SlipItemEntry> _slipItems = new List<SlipItemEntry>();

        private class SlipMemberEntry
        {
            public string MemberName { get; set; }
            public string MemberRole { get; set; }
        }

        private class SlipItemEntry
        {
            public int EquipmentId { get; set; }
            public string EquipmentName { get; set; }
            public int QuantityRequested { get; set; }
        }

        public userform()
        {
            InitializeComponent();
            tab.TabPages.Remove(reserve);
            btnOpenReservePanel.Visible = false;
            LoadSlipFilter();
            cmbCourse.Enabled = false;
            cmbSlipFilter.SelectedIndexChanged += cmbSlipFilter_SelectedIndexChanged;

            panelSidebar.Visible = false;
            SetReserveControlsVisible(false);

            txtPassword.UseSystemPasswordChar = true;
            txtRole.ReadOnly = true;
            txtReserveEquipment.ReadOnly = true;

            btnOpenReservePanel.Click += btnOpenReservePanel_Click;
            btnReserve.Click += btnReserve_Click;
            btnCancelReserve.Click += btnCancelReserve_Click;
            btnRequestReturn.Click += btnRequestReturn_Click;
            btnSaveAccount.Click += btnSaveAccount_Click;
            txtEquipmentSearch.TextChanged += txtEquipmentSearch_TextChanged;
            txtBorrowedSearch.TextChanged += txtBorrowedSearch_TextChanged;
            txtReservationSearch.TextChanged += txtReservationSearch_TextChanged;
            textBox7.TextChanged += textBox7_TextChanged;
            textBox7.Text = "";
            StyleDataGridView(dataGridView3);
            StyleDataGridView(dgvEquipment);
            StyleDataGridView(dgvBorrowed);
            StyleDataGridView(dgvReservations);
            StyleDataGridView(dgvSlipMembers);
            StyleDataGridView(dgvSlipItems);
            StyleDataGridView(dgvMySlips);

            txtSlipQty.Enter += (s, e) => { if (txtSlipQty.Text == "qty") txtSlipQty.Clear(); };
            txtSlipQty.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSlipQty.Text)) txtSlipQty.Text = "qty"; };

            txtMemberName.Enter += (s, e) => { if (txtMemberName.Text == "please eneter member name") txtMemberName.Clear(); };
            txtMemberName.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtMemberName.Text)) txtMemberName.Text = "please eneter member name"; };
        }

        public userform(int userId) : this()
        {
            _userId = userId;
            LoadAccountDetails();
            LoadMyCourses();
            LoadMySlips();
            LoadUserDashboard();
            LoadAvailableEquipment();
            LoadMyBorrowed();
            LoadMyReservations();
        }

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
        private void LoadUserDashboard()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT
                (SELECT COUNT(*) FROM equipment e
                 INNER JOIN course_equipment_permissions p ON e.equipment_id = p.equipment_id
                 WHERE e.quantity_available > 0
                   AND p.course_id = @course_id
                   AND p.is_allowed = 1) AS available_equipment,
                (SELECT COUNT(*) FROM borrow_records WHERE user_id = @user_id AND status IN ('Borrowed', 'Overdue')) AS my_borrowed,
                (SELECT COUNT(*) FROM reservations WHERE user_id = @user_id AND status = 'pending') AS my_pending_reservations,
                (SELECT COUNT(*) FROM borrow_records WHERE user_id = @user_id AND status = 'Return Pending') AS my_return_pending";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    cmd.Parameters.AddWithValue("@course_id", _userCourseId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblAvailable.Text = reader["available_equipment"].ToString();
                            lblBorrowed.Text = reader["my_borrowed"].ToString();
                            lblPendingReservations.Text = reader["my_pending_reservations"].ToString();
                            lblReturnPending.Text = reader["my_return_pending"].ToString();
                        }
                    }
                }
            }
        }

        // ================= EQUIPMENT =================
        private void LoadAvailableEquipment()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query;
                string slipQuery;

                if (_userCourseId > 0)
                {
                    query = @"
                SELECT e.equipment_id, e.name, e.description, e.category,
                       e.quantity_available, e.status
                FROM equipment e
                INNER JOIN course_equipment_permissions p
                    ON e.equipment_id = p.equipment_id
                WHERE e.quantity_available > 0
                  AND p.course_id = @course_id
                  AND p.is_allowed = 1
                ORDER BY e.name";

                    slipQuery = @"
                SELECT e.name, e.category, 
                       e.quantity_available AS quantity, e.status
                FROM equipment e
                INNER JOIN course_equipment_permissions p
                    ON e.equipment_id = p.equipment_id
                WHERE e.quantity_available > 0
                  AND p.course_id = @course_id
                  AND p.is_allowed = 1
                ORDER BY e.name";
                }
                else
                {
                    query = @"
                SELECT equipment_id, name, description, category,
                       quantity_available, status
                FROM equipment
                WHERE quantity_available > 0
                ORDER BY name";

                    slipQuery = @"
                SELECT name, category,
                       quantity_available AS quantity, status
                FROM equipment
                WHERE quantity_available > 0
                ORDER BY name";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (_userCourseId > 0)
                        cmd.Parameters.AddWithValue("@course_id", _userCourseId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvEquipment.DataSource = table;
                    }
                }

                using (MySqlCommand cmd = new MySqlCommand(slipQuery, conn))
                {
                    if (_userCourseId > 0)
                        cmd.Parameters.AddWithValue("@course_id", _userCourseId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView3.DataSource = table;
                    }
                }
            }
        }

        // ================= BORROWED =================
        private void LoadMyBorrowed()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT b.borrow_id, b.equipment_id, e.name AS equipment,
                        b.quantity, b.borrow_time, b.return_time, b.status
                    FROM borrow_records b
                    JOIN equipment e ON b.equipment_id = e.equipment_id
                    WHERE b.user_id = @user_id
                      AND b.status IN ('Borrowed', 'Overdue', 'Return Pending')
                    ORDER BY b.borrow_time DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvBorrowed.DataSource = table;
                    }
                }
            }
        }

        // ================= RESERVATIONS =================
        private void LoadMyReservations()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT s.slip_id AS reservation_id, s.slip_code AS equipment,
                s.group_name, s.subject_or_experiment,
                s.requested_at AS scheduled_use, s.status
            FROM lab_borrow_slips s
            WHERE s.leader_user_id = @user_id 
              AND s.status = 'Pending'
            ORDER BY s.requested_at DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvReservations.DataSource = table;
                    }
                }
            }
        }

        // ================= ACCOUNT =================
        private void LoadAccountDetails()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT u.first_name, u.last_name, u.mobile_no, u.address,
                   u.role, u.username, u.password,
                   IFNULL(u.course_id, 0) AS course_id,
                   IFNULL(c.course_code, 'N/A') AS course_code
            FROM users u
            LEFT JOIN courses c ON u.course_id = c.course_id
            WHERE u.user_id = @user_id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFirstName.Text = reader["first_name"].ToString();
                            txtLastName.Text = reader["last_name"].ToString();
                            txtMobileNo.Text = reader["mobile_no"].ToString();
                            txtAddress.Text = reader["address"] == DBNull.Value ? "" : reader["address"].ToString();
                            txtRole.Text = reader["role"].ToString();
                            txtUsername.Text = reader["username"].ToString();
                            txtPassword.Text = reader["password"].ToString();
                            _userCourseId = Convert.ToInt32(reader["course_id"]);
                            txtCourse.Text = reader["course_code"].ToString();
                        }
                    }
                }
            }
        }

        // ================= SEARCH =================
        private void SearchEquipment(string keyword)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT equipment_id, name, description, category, quantity_available, status
                    FROM equipment
                    WHERE quantity_available > 0
                      AND (name LIKE @keyword OR description LIKE @keyword
                        OR category LIKE @keyword OR status LIKE @keyword)
                    ORDER BY name";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvEquipment.DataSource = table;
                    }
                }
            }
        }

        private void SearchMyBorrowed(string keyword)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT b.borrow_id, b.equipment_id, e.name AS equipment,
                        b.quantity, b.borrow_time, b.return_time, b.status
                    FROM borrow_records b
                    JOIN equipment e ON b.equipment_id = e.equipment_id
                    WHERE b.user_id = @user_id
                      AND b.status IN ('Borrowed', 'Overdue', 'Return Pending')
                      AND (e.name LIKE @keyword OR b.status LIKE @keyword)
                    ORDER BY b.borrow_time DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvBorrowed.DataSource = table;
                    }
                }
            }
        }

        private void SearchMyReservations(string keyword)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT s.slip_id AS reservation_id, s.slip_code AS equipment,
                s.group_name, s.subject_or_experiment,
                s.requested_at AS scheduled_use, s.status
            FROM lab_borrow_slips s
            WHERE s.leader_user_id = @user_id 
              AND s.status = 'Pending'
              AND (s.slip_code LIKE @keyword 
                OR s.group_name LIKE @keyword
                OR s.subject_or_experiment LIKE @keyword)
            ORDER BY s.requested_at DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvReservations.DataSource = table;
                    }
                }
            }
        }

        private bool UsernameExists(string username)
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT COUNT(*) FROM users
                    WHERE username = @username AND user_id <> @user_id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // ================= NAV =================
        private void btnreservations_Click(object sender, EventArgs e) { tab.SelectedIndex = 0; }
        private void btnborrowreserve_Click(object sender, EventArgs e) { tab.SelectedIndex = 6; }
        private void btnborrowedtab_Click(object sender, EventArgs e) { tab.SelectedIndex = 1; }
        private void btnOverdueTab_Click(object sender, EventArgs e) { tab.SelectedIndex = 2; }
        private void btnAccount_Click(object sender, EventArgs e) { tab.SelectedIndex = 3; }
        private void btnLabSlipsTab_Click(object sender, EventArgs e) { tab.SelectedIndex = 4; }
        private void btnMySlipsTab_Click(object sender, EventArgs e) { tab.SelectedIndex = 5; }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnHamburger_Click(object sender, EventArgs e)
        {
            panelSidebar.Visible = !panelSidebar.Visible;
        }

        // ================= RESERVE =================
        private void ClearReserveFields()
        {
            _selectedEquipmentId = 0;
            txtReserveEquipment.Clear();
            txtReserveQuantity.Clear();
            dtpScheduledPickup.Value = DateTime.Now;
        }

        private void SetReserveControlsVisible(bool visible)
        {
            panelReserve.Visible = visible;
            txtReserveEquipment.Visible = visible;
            txtReserveQuantity.Visible = visible;
            dtpScheduledPickup.Visible = visible;
            btnReserve.Visible = visible;
            btnCancelReserve.Visible = visible;
        }

        private void btnOpenReservePanel_Click(object sender, EventArgs e)
        {
            if (dgvEquipment.CurrentRow == null)
            {
                MessageBox.Show("Please select an equipment item first.");
                return;
            }

            _selectedEquipmentId = Convert.ToInt32(dgvEquipment.CurrentRow.Cells["equipment_id"].Value);
            txtReserveEquipment.Text = dgvEquipment.CurrentRow.Cells["name"].Value.ToString();
            txtReserveQuantity.Text = "1";
            dtpScheduledPickup.Value = DateTime.Now.AddHours(1);

            SetReserveControlsVisible(true);
            txtReserveEquipment.BringToFront();
        }

        private void btnCancelReserve_Click(object sender, EventArgs e)
        {
            ClearReserveFields();
            SetReserveControlsVisible(false);
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (_selectedEquipmentId == 0)
            {
                MessageBox.Show("Please select an equipment item first.");
                return;
            }

            if (!int.TryParse(txtReserveQuantity.Text.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Quantity must be a valid number.");
                txtReserveQuantity.Focus();
                return;
            }

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string checkQuery = "SELECT quantity_available FROM equipment WHERE equipment_id = @equipment_id";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@equipment_id", _selectedEquipmentId);
                    int availableQuantity = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (quantity > availableQuantity)
                    {
                        MessageBox.Show("Requested quantity is higher than available quantity.");
                        return;
                    }
                }

                // FIX BUG 3: Changed INSERT column names to match actual reservations table schema.
                // Original: quantity, scheduled_pickup_time
                // Correct:  quantity_reserved, scheduled_use
                string insertQuery = @"
                    INSERT INTO reservations (user_id, equipment_id, quantity_reserved, scheduled_use, status)
                    VALUES (@user_id, @equipment_id, @quantity_reserved, @scheduled_use, 'pending')";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    cmd.Parameters.AddWithValue("@equipment_id", _selectedEquipmentId);
                    cmd.Parameters.AddWithValue("@quantity_reserved", quantity);
                    cmd.Parameters.AddWithValue("@scheduled_use", dtpScheduledPickup.Value);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Reservation added successfully.");
            ClearReserveFields();
            SetReserveControlsVisible(false);
            LoadMyReservations();
            LoadUserDashboard();
        }

        private void btnRequestReturn_Click(object sender, EventArgs e)
        {
            if (dgvBorrowed.CurrentRow == null)
            {
                MessageBox.Show("Please select a borrowed item first.");
                return;
            }

            string currentStatus = dgvBorrowed.CurrentRow.Cells["status"].Value.ToString();
            if (currentStatus == "Return Pending")
            {
                MessageBox.Show("This item is already waiting for admin approval.");
                return;
            }

            int borrowId = Convert.ToInt32(dgvBorrowed.CurrentRow.Cells["borrow_id"].Value);

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE borrow_records
                    SET status = 'Return Pending'
                    WHERE borrow_id = @borrow_id AND user_id = @user_id
                      AND status IN ('Borrowed', 'Overdue')";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@borrow_id", borrowId);
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Return request sent successfully.");
            LoadMyBorrowed();
            LoadUserDashboard();
        }

        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtMobileNo.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all required account fields.");
                return;
            }

            if (UsernameExists(txtUsername.Text.Trim()))
            {
                MessageBox.Show("That username is already taken.");
                txtUsername.Focus();
                return;
            }

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE users
                    SET first_name = @first_name, last_name = @last_name,
                        mobile_no = @mobile_no, address = @address,
                        username = @username, `password` = @password
                    WHERE user_id = @user_id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@mobile_no", txtMobileNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Account details updated successfully.");
        }

        // ================= SEARCH EVENTS =================
        private void txtEquipmentSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEquipmentSearch.Text)) LoadAvailableEquipment();
            else SearchEquipment(txtEquipmentSearch.Text.Trim());
        }

        private void txtBorrowedSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBorrowedSearch.Text)) LoadMyBorrowed();
            else SearchMyBorrowed(txtBorrowedSearch.Text.Trim());
        }

        private void txtReservationSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReservationSearch.Text)) LoadMyReservations();
            else SearchMyReservations(txtReservationSearch.Text.Trim());
        }

        // ================= LAB BORROW SLIP =================
        private void LoadMyCourses()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                string query = "SELECT course_id, course_code FROM courses ORDER BY course_code";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                cmbCourse.DisplayMember = "course_code";
                cmbCourse.ValueMember = "course_id";
                cmbCourse.DataSource = table;
            }

            if (_userCourseId > 0)
            {
                foreach (DataRowView row in cmbCourse.Items)
                {
                    if (Convert.ToInt32(row["course_id"]) == _userCourseId)
                    {
                        cmbCourse.SelectedItem = row;
                        break;
                    }
                }
            }
        }

        private void LoadMySlips()
        {
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT s.slip_id, s.slip_code, s.group_name,
                        s.subject_or_experiment, s.faculty_name,
                        s.requested_at, s.expected_return_at, s.status
                    FROM lab_borrow_slips s
                    WHERE s.leader_user_id = @user_id
                    ORDER BY s.requested_at DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvMySlips.DataSource = table;
                }
            }
        }

        private void RefreshMembersGrid()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Member Name");
            table.Columns.Add("Role");
            foreach (var m in _slipMembers)
                table.Rows.Add(m.MemberName, m.MemberRole);
            dgvSlipMembers.DataSource = table;
        }

        private void RefreshItemsGrid()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Equipment");
            table.Columns.Add("Qty Requested");
            foreach (var item in _slipItems)
                table.Rows.Add(item.EquipmentName, item.QuantityRequested);
            dgvSlipItems.DataSource = table;
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            string name = txtMemberName.Text.Trim();
            string role = txtMemberRole.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a member name.");
                return;
            }

            _slipMembers.Add(new SlipMemberEntry { MemberName = name, MemberRole = role });
            RefreshMembersGrid();
            txtMemberName.Clear();
            txtMemberRole.Clear();
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            if (dgvSlipMembers.CurrentRow == null || dgvSlipMembers.CurrentRow.Index >= _slipMembers.Count)
                return;
            _slipMembers.RemoveAt(dgvSlipMembers.CurrentRow.Index);
            RefreshMembersGrid();
        }

        private void btnAddSlipItem_Click(object sender, EventArgs e)
        {
            if (txtSlipQty.Text.Trim() == "qty")
            {
                MessageBox.Show("Please enter a quantity.");
                return;
            }

            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Please select an equipment item from the list.");
                return;
            }

            if (!int.TryParse(txtSlipQty.Text.Trim(), out int qty) || qty <= 0)
            {
                MessageBox.Show("Enter a valid quantity.");
                return;
            }

            string selectedName = dataGridView3.CurrentRow.Cells["name"].Value.ToString();
            int available = Convert.ToInt32(dataGridView3.CurrentRow.Cells["quantity"].Value);

            if (qty > available)
            {
                MessageBox.Show($"Only {available} unit(s) available for {selectedName}.");
                return;
            }

            int equipId = 0;
            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                string query = "SELECT equipment_id FROM equipment WHERE name = @name LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", selectedName);
                    equipId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            if (equipId == 0)
            {
                MessageBox.Show("Could not find equipment. Please try again.");
                return;
            }

            if (_slipItems.Exists(i => i.EquipmentId == equipId))
            {
                MessageBox.Show("This equipment is already added. Remove it first to change quantity.");
                return;
            }

            _slipItems.Add(new SlipItemEntry
            {
                EquipmentId = equipId,
                EquipmentName = selectedName,
                QuantityRequested = qty
            });

            RefreshItemsGrid();
            txtSlipQty.Clear();
        }

        private void btnRemoveSlipItem_Click(object sender, EventArgs e)
        {
            if (dgvSlipItems.CurrentRow == null || dgvSlipItems.CurrentRow.Index >= _slipItems.Count)
                return;
            _slipItems.RemoveAt(dgvSlipItems.CurrentRow.Index);
            RefreshItemsGrid();
        }

        private void btnSubmitSlip_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGroupName.Text)) { MessageBox.Show("Enter group name."); return; }
            if (string.IsNullOrWhiteSpace(txtSectionName.Text)) { MessageBox.Show("Enter section name (e.g. CPE-2A)."); return; }
            if (string.IsNullOrWhiteSpace(txtSubjectOrExperiment.Text)) { MessageBox.Show("Enter subject or experiment."); return; }
            if (string.IsNullOrWhiteSpace(txtFacultyName.Text)) { MessageBox.Show("Enter faculty name."); return; }
            if (cmbCourse.SelectedValue == null) { MessageBox.Show("Select a course."); return; }
            if (_slipMembers.Count == 0) { MessageBox.Show("Add at least one member."); return; }
            if (_slipItems.Count == 0) { MessageBox.Show("Add at least one equipment item."); return; }

            int courseId = Convert.ToInt32(cmbCourse.SelectedValue);
            string slipCode = "LAB-" + DateTime.Now.Year + "-" + new Random().Next(1000, 9999).ToString();

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string insertSlip = @"
                        INSERT INTO lab_borrow_slips
                            (slip_code, leader_user_id, course_id, group_name,
                             section_name, subject_or_experiment, faculty_name,
                             requested_at, expected_return_at, status, remarks)
                        VALUES
                            (@slip_code, @leader_user_id, @course_id, @group_name,
                             @section_name, @subject_or_experiment, @faculty_name,
                             NOW(), @expected_return_at, 'Pending', NULL)";

                    int newSlipId;

                    using (MySqlCommand cmd = new MySqlCommand(insertSlip, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@slip_code", slipCode);
                        cmd.Parameters.AddWithValue("@leader_user_id", _userId);
                        cmd.Parameters.AddWithValue("@course_id", courseId);
                        cmd.Parameters.AddWithValue("@group_name", txtGroupName.Text.Trim());
                        cmd.Parameters.AddWithValue("@section_name", txtSectionName.Text.Trim());
                        cmd.Parameters.AddWithValue("@subject_or_experiment", txtSubjectOrExperiment.Text.Trim());
                        cmd.Parameters.AddWithValue("@faculty_name", txtFacultyName.Text.Trim());
                        cmd.Parameters.AddWithValue("@expected_return_at", dtpExpectedReturn.Value);
                        cmd.ExecuteNonQuery();
                        newSlipId = Convert.ToInt32(cmd.LastInsertedId);
                    }

                    // Insert leader automatically
                    string insertLeader = @"
                        INSERT INTO lab_borrow_slip_members
                            (slip_id, member_user_id, member_name, member_role)
                        VALUES (@slip_id, @member_user_id, @member_name, @member_role)";

                    using (MySqlCommand cmd = new MySqlCommand(insertLeader, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@slip_id", newSlipId);
                        cmd.Parameters.AddWithValue("@member_user_id", _userId);
                        cmd.Parameters.AddWithValue("@member_name",
                            txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@member_role", "Leader");
                        cmd.ExecuteNonQuery();
                    }

                    foreach (var member in _slipMembers)
                    {
                        string insertMember = @"
                            INSERT INTO lab_borrow_slip_members
                                (slip_id, member_user_id, member_name, member_role)
                            VALUES (@slip_id, @member_user_id, @member_name, @member_role)";

                        using (MySqlCommand cmd = new MySqlCommand(insertMember, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@slip_id", newSlipId);
                            cmd.Parameters.AddWithValue("@member_user_id", DBNull.Value);
                            cmd.Parameters.AddWithValue("@member_name", member.MemberName);
                            cmd.Parameters.AddWithValue("@member_role", member.MemberRole);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    foreach (var item in _slipItems)
                    {
                        string insertItem = @"
                            INSERT INTO lab_borrow_slip_items
                                (slip_id, equipment_id, quantity_requested, quantity_returned, item_status)
                            VALUES (@slip_id, @equipment_id, @quantity_requested, 0, 'Requested')";

                        using (MySqlCommand cmd = new MySqlCommand(insertItem, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@slip_id", newSlipId);
                            cmd.Parameters.AddWithValue("@equipment_id", item.EquipmentId);
                            cmd.Parameters.AddWithValue("@quantity_requested", item.QuantityRequested);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show($"Slip submitted!\nSlip Code: {slipCode}\n\nWaiting for admin approval.");
                    ClearSlipForm();
                    LoadMySlips();
                    LoadMyReservations();
                    LoadUserDashboard();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error submitting slip: " + ex.Message);
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
            cmbSlipFilter.Items.Add("Returned");
            cmbSlipFilter.Items.Add("Declined");
            cmbSlipFilter.Items.Add("Cancelled");
            cmbSlipFilter.SelectedIndex = 0;
        }

        private void cmbSlipFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbSlipFilter.SelectedItem.ToString();

            if (selected == "All")
            {
                LoadMySlips();
                return;
            }

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                // FIX BUG 4: Added WHERE leader_user_id = @user_id so the filter only shows
                // the current user's slips, not every slip in the system.
                string query = @"
                    SELECT s.slip_id, s.slip_code, s.group_name,
                        s.subject_or_experiment, s.faculty_name,
                        s.requested_at, s.expected_return_at, s.status
                    FROM lab_borrow_slips s
                    WHERE s.leader_user_id = @user_id
                      AND s.status = @status
                    ORDER BY s.requested_at DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    cmd.Parameters.AddWithValue("@status", selected);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvMySlips.DataSource = table;
                }
            }
        }

        private void btnCancelSlip_Click(object sender, EventArgs e)
        {
            if (dgvMySlips.CurrentRow == null)
            {
                MessageBox.Show("Please select a slip to cancel.");
                return;
            }

            string currentStatus = dgvMySlips.CurrentRow.Cells["status"].Value.ToString();
            if (currentStatus != "Pending")
            {
                MessageBox.Show("Only pending slips can be cancelled.");
                return;
            }

            int slipId = Convert.ToInt32(dgvMySlips.CurrentRow.Cells["slip_id"].Value);
            string slipCode = dgvMySlips.CurrentRow.Cells["slip_code"].Value.ToString();

            if (MessageBox.Show($"Cancel slip {slipCode}?", "Cancel Slip",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE lab_borrow_slips
                    SET status = 'Cancelled'
                    WHERE slip_id = @slip_id AND leader_user_id = @user_id AND status = 'Pending'";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@slip_id", slipId);
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    cmd.ExecuteNonQuery();
                }

                string cancelItems = @"
                    UPDATE lab_borrow_slip_items
                    SET item_status = 'Cancelled' WHERE slip_id = @slip_id";

                using (MySqlCommand cmd = new MySqlCommand(cancelItems, conn))
                {
                    cmd.Parameters.AddWithValue("@slip_id", slipId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Slip cancelled successfully.");
            LoadMySlips();
            LoadMyReservations(); // ADD THIS — removes it from reservations tab too
            LoadUserDashboard();  // ADD THIS — updates pending count
        }

        private void ClearSlipForm()
        {
            _slipMembers.Clear();
            _slipItems.Clear();
            RefreshMembersGrid();
            RefreshItemsGrid();
            txtGroupName.Clear();
            txtSectionName.Clear();
            txtSubjectOrExperiment.Clear();
            txtFacultyName.Clear();
            txtSlipQty.Clear();
            dtpExpectedReturn.Value = DateTime.Now.AddDays(1);
            if (cmbCourse.Items.Count > 0) cmbCourse.SelectedIndex = 0;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox7.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword) || keyword == "search")
            {
                LoadAvailableEquipment();
                return;
            }

            using (MySqlConnection conn = DATABASE.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT e.name, e.category,
                   e.quantity_available AS quantity, e.status
            FROM equipment e
            INNER JOIN course_equipment_permissions p
                ON e.equipment_id = p.equipment_id
            WHERE e.quantity_available > 0
              AND p.course_id = @course_id
              AND p.is_allowed = 1
              AND (e.name LIKE @keyword OR e.description LIKE @keyword
                OR e.category LIKE @keyword OR e.status LIKE @keyword)
            ORDER BY e.name";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@course_id", _userCourseId);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView3.DataSource = table;
                    }
                }
            }
        }

        // ================= EMPTY HANDLERS =================
        private void label1_Click(object sender, EventArgs e) { }
        private void dtpScheduledPickup_ValueChanged(object sender, EventArgs e) { }
        private void label27_Click(object sender, EventArgs e) { }
        private void label25_Click(object sender, EventArgs e) { }
        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label27_Click_1(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}