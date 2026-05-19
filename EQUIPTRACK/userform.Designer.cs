namespace EQUIPTRACK
{
    partial class userform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userform));
            btnHamburger = new Button();
            button1 = new Button();
            button3 = new Button();
            button5 = new Button();
            button4 = new Button();
            button8 = new Button();
            reservations = new TabPage();
            label23 = new Label();
            label10 = new Label();
            txtReservationSearch = new TextBox();
            dgvReservations = new DataGridView();
            tab = new TabControl();
            dashboard = new TabPage();
            label20 = new Label();
            label5 = new Label();
            label11 = new Label();
            panel1 = new Panel();
            lblAvailable = new Label();
            label6 = new Label();
            panel4 = new Panel();
            label9 = new Label();
            lblReturnPending = new Label();
            panel3 = new Panel();
            label7 = new Label();
            lblPendingReservations = new Label();
            panel2 = new Panel();
            label8 = new Label();
            lblBorrowed = new Label();
            borrowed = new TabPage();
            label22 = new Label();
            label4 = new Label();
            btnRequestReturn = new Button();
            txtBorrowedSearch = new TextBox();
            dgvBorrowed = new DataGridView();
            account = new TabPage();
            txtCourse = new TextBox();
            label39 = new Label();
            label24 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            txtAddress = new TextBox();
            btnSaveAccount = new Button();
            txtLastName = new TextBox();
            txtPassword = new TextBox();
            txtRole = new TextBox();
            txtUsername = new TextBox();
            txtMobileNo = new TextBox();
            txtFirstName = new TextBox();
            SLIPS = new TabPage();
            panel6 = new Panel();
            dataGridView3 = new DataGridView();
            textBox7 = new TextBox();
            label26 = new Label();
            button7 = new Button();
            panel10 = new Panel();
            button11 = new Button();
            label32 = new Label();
            label27 = new Label();
            button10 = new Button();
            dgvSlipItems = new DataGridView();
            txtSlipQty = new TextBox();
            label29 = new Label();
            panel9 = new Panel();
            button12 = new Button();
            txtMemberRole = new TextBox();
            label31 = new Label();
            label30 = new Label();
            button9 = new Button();
            dgvSlipMembers = new DataGridView();
            txtMemberName = new TextBox();
            label28 = new Label();
            panel7 = new Panel();
            label37 = new Label();
            txtFacultyName = new TextBox();
            label36 = new Label();
            label25 = new Label();
            label35 = new Label();
            label34 = new Label();
            label33 = new Label();
            txtGroupName = new TextBox();
            dtpExpectedReturn = new DateTimePicker();
            txtSectionName = new TextBox();
            txtSubjectOrExperiment = new TextBox();
            cmbCourse = new ComboBox();
            myslipstab = new TabPage();
            cmbSlipFilter = new ComboBox();
            button6 = new Button();
            label42 = new Label();
            label38 = new Label();
            dgvMySlips = new DataGridView();
            reserve = new TabPage();
            label21 = new Label();
            label1 = new Label();
            btnOpenReservePanel = new Button();
            txtEquipmentSearch = new TextBox();
            panelReserve = new Panel();
            label3 = new Label();
            label2 = new Label();
            btnCancelReserve = new Button();
            txtReserveEquipment = new TextBox();
            btnReserve = new Button();
            txtReserveQuantity = new TextBox();
            dtpScheduledPickup = new DateTimePicker();
            dgvEquipment = new DataGridView();
            panel5 = new Panel();
            panelSidebar = new Panel();
            button14 = new Button();
            button13 = new Button();
            reservations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            tab.SuspendLayout();
            dashboard.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            borrowed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBorrowed).BeginInit();
            account.SuspendLayout();
            SLIPS.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSlipItems).BeginInit();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSlipMembers).BeginInit();
            panel7.SuspendLayout();
            myslipstab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMySlips).BeginInit();
            reserve.SuspendLayout();
            panelReserve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).BeginInit();
            panel5.SuspendLayout();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // btnHamburger
            // 
            btnHamburger.BackColor = Color.Crimson;
            btnHamburger.FlatStyle = FlatStyle.Flat;
            btnHamburger.ForeColor = SystemColors.ControlLightLight;
            btnHamburger.Location = new Point(10, 28);
            btnHamburger.Name = "btnHamburger";
            btnHamburger.Size = new Size(51, 39);
            btnHamburger.TabIndex = 6;
            btnHamburger.Text = "☰";
            btnHamburger.UseVisualStyleBackColor = false;
            btnHamburger.Click += btnHamburger_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Crimson;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Franklin Gothic Medium Cond", 12F);
            button1.ForeColor = SystemColors.Window;
            button1.Location = new Point(3, 16);
            button1.Name = "button1";
            button1.Size = new Size(156, 55);
            button1.TabIndex = 1;
            button1.Text = "DASHBOARD";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnreservations_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Crimson;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Franklin Gothic Medium Cond", 12F);
            button3.ForeColor = SystemColors.Window;
            button3.Location = new Point(3, 77);
            button3.Name = "button3";
            button3.Size = new Size(156, 50);
            button3.TabIndex = 0;
            button3.Text = "BORROWED ITEMS";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnborrowedtab_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Crimson;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Franklin Gothic Medium Cond", 12F);
            button5.ForeColor = SystemColors.Window;
            button5.Location = new Point(4, 133);
            button5.Name = "button5";
            button5.Size = new Size(156, 50);
            button5.TabIndex = 2;
            button5.Text = "RESERVATIONS";
            button5.UseVisualStyleBackColor = false;
            button5.Click += btnOverdueTab_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Crimson;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Franklin Gothic Medium Cond", 12F);
            button4.ForeColor = SystemColors.Window;
            button4.Location = new Point(6, 190);
            button4.Name = "button4";
            button4.Size = new Size(156, 50);
            button4.TabIndex = 5;
            button4.Text = "ACCOUNT";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnAccount_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Crimson;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Franklin Gothic Medium Cond", 12F);
            button8.ForeColor = SystemColors.Window;
            button8.Location = new Point(3, 494);
            button8.Name = "button8";
            button8.Size = new Size(156, 50);
            button8.TabIndex = 3;
            button8.Text = "LOGOUT";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // reservations
            // 
            reservations.BackColor = SystemColors.Control;
            reservations.Controls.Add(label23);
            reservations.Controls.Add(label10);
            reservations.Controls.Add(txtReservationSearch);
            reservations.Controls.Add(dgvReservations);
            reservations.Location = new Point(4, 24);
            reservations.Name = "reservations";
            reservations.Padding = new Padding(3);
            reservations.Size = new Size(803, 531);
            reservations.TabIndex = 0;
            reservations.Text = "RESERVATIONS";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label23.ForeColor = SystemColors.ControlDarkDark;
            label23.Location = new Point(41, 82);
            label23.Name = "label23";
            label23.Size = new Size(461, 16);
            label23.TabIndex = 18;
            label23.Text = "Track your pending reservations and check their pickup schedule and status.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 20.25F);
            label10.ForeColor = SystemColors.ActiveCaptionText;
            label10.Location = new Point(41, 51);
            label10.Name = "label10";
            label10.Size = new Size(217, 31);
            label10.TabIndex = 13;
            label10.Text = "My Reservations";
            // 
            // txtReservationSearch
            // 
            txtReservationSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReservationSearch.Location = new Point(142, 172);
            txtReservationSearch.Name = "txtReservationSearch";
            txtReservationSearch.Size = new Size(491, 29);
            txtReservationSearch.TabIndex = 12;
            // 
            // dgvReservations
            // 
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservations.Dock = DockStyle.Bottom;
            dgvReservations.Location = new Point(3, 286);
            dgvReservations.Name = "dgvReservations";
            dgvReservations.Size = new Size(797, 242);
            dgvReservations.TabIndex = 0;
            // 
            // tab
            // 
            tab.Controls.Add(dashboard);
            tab.Controls.Add(borrowed);
            tab.Controls.Add(reservations);
            tab.Controls.Add(account);
            tab.Controls.Add(SLIPS);
            tab.Controls.Add(myslipstab);
            tab.Controls.Add(reserve);
            tab.Location = new Point(5, 44);
            tab.Name = "tab";
            tab.SelectedIndex = 0;
            tab.Size = new Size(811, 559);
            tab.TabIndex = 12;
            // 
            // dashboard
            // 
            dashboard.BackColor = SystemColors.Control;
            dashboard.Controls.Add(label20);
            dashboard.Controls.Add(label5);
            dashboard.Controls.Add(label11);
            dashboard.Controls.Add(panel1);
            dashboard.Controls.Add(panel4);
            dashboard.Controls.Add(panel3);
            dashboard.Controls.Add(panel2);
            dashboard.Location = new Point(4, 24);
            dashboard.Name = "dashboard";
            dashboard.Padding = new Padding(3);
            dashboard.Size = new Size(803, 531);
            dashboard.TabIndex = 3;
            dashboard.Text = "DASHBOARD";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.ForeColor = SystemColors.ControlDarkDark;
            label20.Location = new Point(54, 68);
            label20.Name = "label20";
            label20.Size = new Size(542, 16);
            label20.TabIndex = 15;
            label20.Text = "View your current equipment activity, pending reservations, and return requests at a glance.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 20.25F);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(52, 37);
            label5.Name = "label5";
            label5.Size = new Size(147, 31);
            label5.TabIndex = 7;
            label5.Text = "Dashboard";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(3, 3);
            label11.Name = "label11";
            label11.Size = new Size(0, 15);
            label11.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblAvailable);
            panel1.Controls.Add(label6);
            panel1.ForeColor = Color.Crimson;
            panel1.Location = new Point(54, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(316, 133);
            panel1.TabIndex = 12;
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Font = new Font("Microsoft Sans Serif", 20.25F);
            lblAvailable.ForeColor = Color.Crimson;
            lblAvailable.Location = new Point(135, 23);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(151, 31);
            lblAvailable.TabIndex = 3;
            lblAvailable.Text = "lblAvailable";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(82, 65);
            label6.Name = "label6";
            label6.Size = new Size(183, 24);
            label6.TabIndex = 8;
            label6.Text = "Available Equipment";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label9);
            panel4.Controls.Add(lblReturnPending);
            panel4.ForeColor = Color.Crimson;
            panel4.Location = new Point(450, 297);
            panel4.Name = "panel4";
            panel4.Size = new Size(291, 156);
            panel4.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ActiveCaptionText;
            label9.Location = new Point(72, 72);
            label9.Name = "label9";
            label9.Size = new Size(151, 24);
            label9.TabIndex = 11;
            label9.Text = "Pending Returns";
            // 
            // lblReturnPending
            // 
            lblReturnPending.AutoSize = true;
            lblReturnPending.Font = new Font("Microsoft Sans Serif", 20.25F);
            lblReturnPending.ForeColor = Color.Crimson;
            lblReturnPending.Location = new Point(121, 24);
            lblReturnPending.Name = "lblReturnPending";
            lblReturnPending.Size = new Size(222, 31);
            lblReturnPending.TabIndex = 6;
            lblReturnPending.Text = "lblReturnPending";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label7);
            panel3.Controls.Add(lblPendingReservations);
            panel3.ForeColor = Color.Crimson;
            panel3.Location = new Point(450, 133);
            panel3.Name = "panel3";
            panel3.Size = new Size(291, 133);
            panel3.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(60, 65);
            label7.Name = "label7";
            label7.Size = new Size(194, 24);
            label7.TabIndex = 9;
            label7.Text = "Pending Reservations";
            // 
            // lblPendingReservations
            // 
            lblPendingReservations.AutoSize = true;
            lblPendingReservations.Font = new Font("Microsoft Sans Serif", 20.25F);
            lblPendingReservations.ForeColor = Color.Crimson;
            lblPendingReservations.Location = new Point(121, 23);
            lblPendingReservations.Name = "lblPendingReservations";
            lblPendingReservations.Size = new Size(300, 31);
            lblPendingReservations.TabIndex = 4;
            lblPendingReservations.Text = "lblPendingReservations";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(lblBorrowed);
            panel2.ForeColor = Color.Crimson;
            panel2.Location = new Point(54, 297);
            panel2.Name = "panel2";
            panel2.Size = new Size(316, 156);
            panel2.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(81, 72);
            label8.Name = "label8";
            label8.Size = new Size(141, 24);
            label8.TabIndex = 10;
            label8.Text = "Borrowed Items";
            // 
            // lblBorrowed
            // 
            lblBorrowed.AutoSize = true;
            lblBorrowed.Font = new Font("Microsoft Sans Serif", 20.25F);
            lblBorrowed.ForeColor = Color.Crimson;
            lblBorrowed.Location = new Point(134, 24);
            lblBorrowed.Name = "lblBorrowed";
            lblBorrowed.Size = new Size(157, 31);
            lblBorrowed.TabIndex = 5;
            lblBorrowed.Text = "lblBorrowed";
            // 
            // borrowed
            // 
            borrowed.BackColor = SystemColors.Control;
            borrowed.Controls.Add(label22);
            borrowed.Controls.Add(label4);
            borrowed.Controls.Add(btnRequestReturn);
            borrowed.Controls.Add(txtBorrowedSearch);
            borrowed.Controls.Add(dgvBorrowed);
            borrowed.Location = new Point(4, 24);
            borrowed.Name = "borrowed";
            borrowed.Padding = new Padding(3);
            borrowed.Size = new Size(803, 531);
            borrowed.TabIndex = 4;
            borrowed.Text = "BORROWEDITEMS";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = SystemColors.ControlDarkDark;
            label22.Location = new Point(34, 68);
            label22.Name = "label22";
            label22.Size = new Size(541, 16);
            label22.TabIndex = 17;
            label22.Text = "See the equipment you currently borrowed and request a return when you are done using it.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 20.25F);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(34, 37);
            label4.Name = "label4";
            label4.Size = new Size(247, 31);
            label4.TabIndex = 12;
            label4.Text = "My Borrowed Items";
            // 
            // btnRequestReturn
            // 
            btnRequestReturn.BackColor = Color.Crimson;
            btnRequestReturn.ForeColor = SystemColors.ControlLightLight;
            btnRequestReturn.Location = new Point(586, 131);
            btnRequestReturn.Name = "btnRequestReturn";
            btnRequestReturn.Size = new Size(123, 42);
            btnRequestReturn.TabIndex = 11;
            btnRequestReturn.Text = "REQUEST RETURN";
            btnRequestReturn.UseVisualStyleBackColor = false;
            // 
            // txtBorrowedSearch
            // 
            txtBorrowedSearch.Location = new Point(34, 142);
            txtBorrowedSearch.Name = "txtBorrowedSearch";
            txtBorrowedSearch.Size = new Size(292, 23);
            txtBorrowedSearch.TabIndex = 10;
            // 
            // dgvBorrowed
            // 
            dgvBorrowed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBorrowed.Dock = DockStyle.Bottom;
            dgvBorrowed.Location = new Point(3, 242);
            dgvBorrowed.Name = "dgvBorrowed";
            dgvBorrowed.Size = new Size(797, 286);
            dgvBorrowed.TabIndex = 7;
            // 
            // account
            // 
            account.BackColor = SystemColors.Control;
            account.Controls.Add(txtCourse);
            account.Controls.Add(label39);
            account.Controls.Add(label24);
            account.Controls.Add(label19);
            account.Controls.Add(label18);
            account.Controls.Add(label17);
            account.Controls.Add(label16);
            account.Controls.Add(label15);
            account.Controls.Add(label14);
            account.Controls.Add(label13);
            account.Controls.Add(label12);
            account.Controls.Add(txtAddress);
            account.Controls.Add(btnSaveAccount);
            account.Controls.Add(txtLastName);
            account.Controls.Add(txtPassword);
            account.Controls.Add(txtRole);
            account.Controls.Add(txtUsername);
            account.Controls.Add(txtMobileNo);
            account.Controls.Add(txtFirstName);
            account.Location = new Point(4, 24);
            account.Name = "account";
            account.Padding = new Padding(3);
            account.Size = new Size(803, 531);
            account.TabIndex = 5;
            account.Text = "ACCOUNT";
            // 
            // txtCourse
            // 
            txtCourse.Location = new Point(386, 376);
            txtCourse.Name = "txtCourse";
            txtCourse.ReadOnly = true;
            txtCourse.Size = new Size(274, 23);
            txtCourse.TabIndex = 23;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label39.ForeColor = SystemColors.ActiveCaptionText;
            label39.Location = new Point(386, 353);
            label39.Name = "label39";
            label39.Size = new Size(60, 20);
            label39.TabIndex = 22;
            label39.Text = "Course";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label24.ForeColor = SystemColors.ControlDarkDark;
            label24.Location = new Point(62, 82);
            label24.Name = "label24";
            label24.Size = new Size(451, 16);
            label24.TabIndex = 21;
            label24.Text = "View and update your personal details, address, username, and password.";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.ActiveCaptionText;
            label19.Location = new Point(62, 353);
            label19.Name = "label19";
            label19.Size = new Size(42, 20);
            label19.TabIndex = 20;
            label19.Text = "Role";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.ForeColor = SystemColors.ActiveCaptionText;
            label18.Location = new Point(386, 284);
            label18.Name = "label18";
            label18.Size = new Size(83, 20);
            label18.TabIndex = 19;
            label18.Text = "Username";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ForeColor = SystemColors.ActiveCaptionText;
            label17.Location = new Point(386, 207);
            label17.Name = "label17";
            label17.Size = new Size(81, 20);
            label17.TabIndex = 18;
            label17.Text = "Mobile no.";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = SystemColors.ActiveCaptionText;
            label16.Location = new Point(386, 141);
            label16.Name = "label16";
            label16.Size = new Size(86, 20);
            label16.TabIndex = 17;
            label16.Text = "Last Name";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.ActiveCaptionText;
            label15.Location = new Point(62, 284);
            label15.Name = "label15";
            label15.Size = new Size(78, 20);
            label15.TabIndex = 16;
            label15.Text = "Password";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = SystemColors.ActiveCaptionText;
            label14.Location = new Point(62, 207);
            label14.Name = "label14";
            label14.Size = new Size(68, 20);
            label14.TabIndex = 15;
            label14.Text = "Address";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = SystemColors.ActiveCaptionText;
            label13.Location = new Point(62, 141);
            label13.Name = "label13";
            label13.Size = new Size(86, 20);
            label13.TabIndex = 14;
            label13.Text = "First Name";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 20.25F);
            label12.ForeColor = SystemColors.ActiveCaptionText;
            label12.Location = new Point(62, 51);
            label12.Name = "label12";
            label12.Size = new Size(113, 31);
            label12.TabIndex = 13;
            label12.Text = "Account";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(62, 230);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(268, 23);
            txtAddress.TabIndex = 8;
            // 
            // btnSaveAccount
            // 
            btnSaveAccount.BackColor = Color.Crimson;
            btnSaveAccount.ForeColor = SystemColors.ControlLightLight;
            btnSaveAccount.Location = new Point(625, 445);
            btnSaveAccount.Name = "btnSaveAccount";
            btnSaveAccount.Size = new Size(136, 55);
            btnSaveAccount.TabIndex = 7;
            btnSaveAccount.Text = "SAVE";
            btnSaveAccount.UseVisualStyleBackColor = false;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(386, 164);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(274, 23);
            txtLastName.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(62, 307);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(268, 23);
            txtPassword.TabIndex = 5;
            // 
            // txtRole
            // 
            txtRole.Location = new Point(70, 376);
            txtRole.Name = "txtRole";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(78, 23);
            txtRole.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(386, 307);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(274, 23);
            txtUsername.TabIndex = 2;
            // 
            // txtMobileNo
            // 
            txtMobileNo.Location = new Point(386, 230);
            txtMobileNo.Name = "txtMobileNo";
            txtMobileNo.Size = new Size(274, 23);
            txtMobileNo.TabIndex = 1;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(62, 164);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(268, 23);
            txtFirstName.TabIndex = 0;
            // 
            // SLIPS
            // 
            SLIPS.BackColor = SystemColors.Control;
            SLIPS.Controls.Add(panel6);
            SLIPS.Controls.Add(button7);
            SLIPS.Controls.Add(panel10);
            SLIPS.Controls.Add(panel9);
            SLIPS.Controls.Add(panel7);
            SLIPS.Location = new Point(4, 24);
            SLIPS.Name = "SLIPS";
            SLIPS.Padding = new Padding(3);
            SLIPS.Size = new Size(803, 531);
            SLIPS.TabIndex = 6;
            SLIPS.Text = "SLIPS";
            // 
            // panel6
            // 
            panel6.Controls.Add(dataGridView3);
            panel6.Controls.Add(textBox7);
            panel6.Controls.Add(label26);
            panel6.Location = new Point(467, 108);
            panel6.Name = "panel6";
            panel6.Size = new Size(316, 359);
            panel6.TabIndex = 21;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(6, 63);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(304, 292);
            dataGridView3.TabIndex = 20;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(5, 34);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(210, 23);
            textBox7.TabIndex = 19;
            textBox7.Text = "search";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label26.ForeColor = SystemColors.ActiveCaptionText;
            label26.Location = new Point(5, 5);
            label26.Name = "label26";
            label26.Size = new Size(196, 20);
            label26.TabIndex = 16;
            label26.Text = "AVAILABLE EQUIPMENT";
            // 
            // button7
            // 
            button7.BackColor = Color.Crimson;
            button7.ForeColor = SystemColors.ControlLightLight;
            button7.Location = new Point(629, 469);
            button7.Name = "button7";
            button7.Size = new Size(136, 55);
            button7.TabIndex = 9;
            button7.Text = "SAVE";
            button7.UseVisualStyleBackColor = false;
            button7.Click += btnSubmitSlip_Click;
            // 
            // panel10
            // 
            panel10.Controls.Add(button11);
            panel10.Controls.Add(label32);
            panel10.Controls.Add(label27);
            panel10.Controls.Add(button10);
            panel10.Controls.Add(dgvSlipItems);
            panel10.Controls.Add(txtSlipQty);
            panel10.Controls.Add(label29);
            panel10.Location = new Point(20, 108);
            panel10.Name = "panel10";
            panel10.Size = new Size(431, 196);
            panel10.TabIndex = 4;
            // 
            // button11
            // 
            button11.BackColor = Color.Crimson;
            button11.ForeColor = SystemColors.ControlLightLight;
            button11.Location = new Point(367, 48);
            button11.Name = "button11";
            button11.Size = new Size(55, 23);
            button11.TabIndex = 26;
            button11.Text = "remove";
            button11.UseVisualStyleBackColor = false;
            button11.Click += btnRemoveSlipItem_Click;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label32.ForeColor = SystemColors.ActiveCaptionText;
            label32.Location = new Point(225, 27);
            label32.Name = "label32";
            label32.Size = new Size(53, 16);
            label32.TabIndex = 25;
            label32.Text = "quantity";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label27.ForeColor = SystemColors.ActiveCaptionText;
            label27.Location = new Point(6, 51);
            label27.Name = "label27";
            label27.Size = new Size(207, 16);
            label27.TabIndex = 24;
            label27.Text = "Click a row from the list on the right";
            label27.Click += label27_Click_1;
            // 
            // button10
            // 
            button10.BackColor = Color.Crimson;
            button10.ForeColor = SystemColors.ControlLightLight;
            button10.Location = new Point(306, 48);
            button10.Name = "button10";
            button10.Size = new Size(55, 23);
            button10.TabIndex = 23;
            button10.Text = "add";
            button10.UseVisualStyleBackColor = false;
            button10.Click += btnAddSlipItem_Click;
            // 
            // dgvSlipItems
            // 
            dgvSlipItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSlipItems.Location = new Point(6, 73);
            dgvSlipItems.Name = "dgvSlipItems";
            dgvSlipItems.Size = new Size(422, 120);
            dgvSlipItems.TabIndex = 21;
            // 
            // txtSlipQty
            // 
            txtSlipQty.Location = new Point(219, 46);
            txtSlipQty.Name = "txtSlipQty";
            txtSlipQty.Size = new Size(81, 23);
            txtSlipQty.TabIndex = 23;
            txtSlipQty.Text = "qty";
            txtSlipQty.TextAlign = HorizontalAlignment.Center;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label29.ForeColor = SystemColors.ActiveCaptionText;
            label29.Location = new Point(3, 5);
            label29.Name = "label29";
            label29.Size = new Size(206, 20);
            label29.TabIndex = 17;
            label29.Text = "EQUIPMENT TO BORROW";
            // 
            // panel9
            // 
            panel9.Controls.Add(button12);
            panel9.Controls.Add(txtMemberRole);
            panel9.Controls.Add(label31);
            panel9.Controls.Add(label30);
            panel9.Controls.Add(button9);
            panel9.Controls.Add(dgvSlipMembers);
            panel9.Controls.Add(txtMemberName);
            panel9.Controls.Add(label28);
            panel9.Location = new Point(20, 310);
            panel9.Name = "panel9";
            panel9.Size = new Size(431, 218);
            panel9.TabIndex = 3;
            // 
            // button12
            // 
            button12.BackColor = Color.Crimson;
            button12.ForeColor = SystemColors.ControlLightLight;
            button12.Location = new Point(370, 55);
            button12.Name = "button12";
            button12.Size = new Size(55, 23);
            button12.TabIndex = 28;
            button12.Text = "remove";
            button12.UseVisualStyleBackColor = false;
            button12.Click += btnRemoveMember_Click;
            // 
            // txtMemberRole
            // 
            txtMemberRole.Location = new Point(218, 56);
            txtMemberRole.Name = "txtMemberRole";
            txtMemberRole.Size = new Size(81, 23);
            txtMemberRole.TabIndex = 27;
            txtMemberRole.Text = "member";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label31.ForeColor = SystemColors.ActiveCaptionText;
            label31.Location = new Point(222, 37);
            label31.Name = "label31";
            label31.Size = new Size(30, 16);
            label31.TabIndex = 26;
            label31.Text = "role";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label30.ForeColor = SystemColors.ActiveCaptionText;
            label30.Location = new Point(3, 37);
            label30.Name = "label30";
            label30.Size = new Size(94, 16);
            label30.TabIndex = 25;
            label30.Text = "member name";
            // 
            // button9
            // 
            button9.BackColor = Color.Crimson;
            button9.ForeColor = SystemColors.ControlLightLight;
            button9.Location = new Point(309, 56);
            button9.Name = "button9";
            button9.Size = new Size(55, 23);
            button9.TabIndex = 22;
            button9.Text = "add";
            button9.UseVisualStyleBackColor = false;
            button9.Click += btnAddMember_Click;
            // 
            // dgvSlipMembers
            // 
            dgvSlipMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSlipMembers.Location = new Point(0, 85);
            dgvSlipMembers.Name = "dgvSlipMembers";
            dgvSlipMembers.Size = new Size(431, 129);
            dgvSlipMembers.TabIndex = 20;
            // 
            // txtMemberName
            // 
            txtMemberName.Location = new Point(3, 56);
            txtMemberName.Name = "txtMemberName";
            txtMemberName.Size = new Size(209, 23);
            txtMemberName.TabIndex = 19;
            txtMemberName.Text = "please eneter member name";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label28.ForeColor = SystemColors.ActiveCaptionText;
            label28.Location = new Point(9, 16);
            label28.Name = "label28";
            label28.Size = new Size(154, 20);
            label28.TabIndex = 16;
            label28.Text = "GROUP MEMBERS";
            // 
            // panel7
            // 
            panel7.Controls.Add(label37);
            panel7.Controls.Add(txtFacultyName);
            panel7.Controls.Add(label36);
            panel7.Controls.Add(label25);
            panel7.Controls.Add(label35);
            panel7.Controls.Add(label34);
            panel7.Controls.Add(label33);
            panel7.Controls.Add(txtGroupName);
            panel7.Controls.Add(dtpExpectedReturn);
            panel7.Controls.Add(txtSectionName);
            panel7.Controls.Add(txtSubjectOrExperiment);
            panel7.Controls.Add(cmbCourse);
            panel7.Location = new Point(20, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(763, 102);
            panel7.TabIndex = 2;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label37.ForeColor = SystemColors.ActiveCaptionText;
            label37.Location = new Point(453, 8);
            label37.Name = "label37";
            label37.Size = new Size(58, 16);
            label37.TabIndex = 31;
            label37.Text = "Teacher";
            // 
            // txtFacultyName
            // 
            txtFacultyName.Location = new Point(453, 25);
            txtFacultyName.Name = "txtFacultyName";
            txtFacultyName.Size = new Size(184, 23);
            txtFacultyName.TabIndex = 30;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label36.ForeColor = SystemColors.ActiveCaptionText;
            label36.Location = new Point(453, 52);
            label36.Name = "label36";
            label36.Size = new Size(184, 16);
            label36.TabIndex = 29;
            label36.Text = "Expected return date and time";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label25.ForeColor = SystemColors.ActiveCaptionText;
            label25.Location = new Point(238, 3);
            label25.Name = "label25";
            label25.Size = new Size(95, 16);
            label25.TabIndex = 28;
            label25.Text = "Experiment no.";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label35.ForeColor = SystemColors.ActiveCaptionText;
            label35.Location = new Point(238, 52);
            label35.Name = "label35";
            label35.Size = new Size(52, 16);
            label35.TabIndex = 27;
            label35.Text = "Section";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label34.ForeColor = SystemColors.ActiveCaptionText;
            label34.Location = new Point(6, 50);
            label34.Name = "label34";
            label34.Size = new Size(84, 16);
            label34.TabIndex = 26;
            label34.Text = "Group Name";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label33.ForeColor = SystemColors.ActiveCaptionText;
            label33.Location = new Point(3, 3);
            label33.Name = "label33";
            label33.Size = new Size(50, 16);
            label33.TabIndex = 25;
            label33.Text = "Course";
            // 
            // txtGroupName
            // 
            txtGroupName.Location = new Point(3, 69);
            txtGroupName.Name = "txtGroupName";
            txtGroupName.Size = new Size(176, 23);
            txtGroupName.TabIndex = 24;
            // 
            // dtpExpectedReturn
            // 
            dtpExpectedReturn.Location = new Point(453, 71);
            dtpExpectedReturn.Name = "dtpExpectedReturn";
            dtpExpectedReturn.Size = new Size(200, 23);
            dtpExpectedReturn.TabIndex = 23;
            // 
            // txtSectionName
            // 
            txtSectionName.Location = new Point(238, 71);
            txtSectionName.Name = "txtSectionName";
            txtSectionName.Size = new Size(100, 23);
            txtSectionName.TabIndex = 20;
            // 
            // txtSubjectOrExperiment
            // 
            txtSubjectOrExperiment.Location = new Point(238, 25);
            txtSubjectOrExperiment.Name = "txtSubjectOrExperiment";
            txtSubjectOrExperiment.Size = new Size(100, 23);
            txtSubjectOrExperiment.TabIndex = 21;
            // 
            // cmbCourse
            // 
            cmbCourse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Location = new Point(3, 20);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(103, 29);
            cmbCourse.TabIndex = 18;
            cmbCourse.SelectedIndexChanged += cmbCourse_SelectedIndexChanged;
            // 
            // myslipstab
            // 
            myslipstab.BackColor = SystemColors.Control;
            myslipstab.Controls.Add(cmbSlipFilter);
            myslipstab.Controls.Add(button6);
            myslipstab.Controls.Add(label42);
            myslipstab.Controls.Add(label38);
            myslipstab.Controls.Add(dgvMySlips);
            myslipstab.Location = new Point(4, 24);
            myslipstab.Name = "myslipstab";
            myslipstab.Padding = new Padding(3);
            myslipstab.Size = new Size(803, 531);
            myslipstab.TabIndex = 7;
            myslipstab.Text = "MYSLIPS";
            // 
            // cmbSlipFilter
            // 
            cmbSlipFilter.FormattingEnabled = true;
            cmbSlipFilter.Location = new Point(503, 80);
            cmbSlipFilter.Name = "cmbSlipFilter";
            cmbSlipFilter.Size = new Size(121, 23);
            cmbSlipFilter.TabIndex = 45;
            // 
            // button6
            // 
            button6.BackColor = Color.Crimson;
            button6.ForeColor = SystemColors.ControlLightLight;
            button6.Location = new Point(643, 48);
            button6.Name = "button6";
            button6.Size = new Size(136, 55);
            button6.TabIndex = 8;
            button6.Text = "CANCEL";
            button6.UseVisualStyleBackColor = false;
            button6.Click += btnCancelSlip_Click;
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label42.Location = new Point(452, 83);
            label42.Name = "label42";
            label42.Size = new Size(45, 20);
            label42.TabIndex = 44;
            label42.Text = "Filter:";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Font = new Font("Microsoft Sans Serif", 20.25F);
            label38.ForeColor = SystemColors.ActiveCaptionText;
            label38.Location = new Point(27, 31);
            label38.Name = "label38";
            label38.Size = new Size(138, 31);
            label38.TabIndex = 14;
            label38.Text = "MY SLIPS";
            // 
            // dgvMySlips
            // 
            dgvMySlips.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMySlips.Location = new Point(15, 113);
            dgvMySlips.Name = "dgvMySlips";
            dgvMySlips.Size = new Size(764, 422);
            dgvMySlips.TabIndex = 0;
            // 
            // reserve
            // 
            reserve.BackColor = SystemColors.Control;
            reserve.Controls.Add(label21);
            reserve.Controls.Add(label1);
            reserve.Controls.Add(btnOpenReservePanel);
            reserve.Controls.Add(txtEquipmentSearch);
            reserve.Controls.Add(panelReserve);
            reserve.Controls.Add(dgvEquipment);
            reserve.Location = new Point(4, 24);
            reserve.Name = "reserve";
            reserve.Padding = new Padding(3);
            reserve.Size = new Size(803, 531);
            reserve.TabIndex = 2;
            reserve.Text = "RESERVE";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.ForeColor = SystemColors.ControlDarkDark;
            label21.Location = new Point(33, 66);
            label21.Name = "label21";
            label21.Size = new Size(632, 16);
            label21.TabIndex = 16;
            label21.Text = "Browse available equipment and submit a reservation by selecting an item, quantity, and pickup schedule.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20.25F);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(33, 32);
            label1.Name = "label1";
            label1.Size = new Size(252, 31);
            label1.TabIndex = 11;
            label1.Text = "Reserve Equipment";
            // 
            // btnOpenReservePanel
            // 
            btnOpenReservePanel.BackColor = Color.Crimson;
            btnOpenReservePanel.ForeColor = SystemColors.ControlLightLight;
            btnOpenReservePanel.Location = new Point(564, 111);
            btnOpenReservePanel.Name = "btnOpenReservePanel";
            btnOpenReservePanel.Size = new Size(74, 34);
            btnOpenReservePanel.TabIndex = 9;
            btnOpenReservePanel.Text = "RESERVE";
            btnOpenReservePanel.UseVisualStyleBackColor = false;
            // 
            // txtEquipmentSearch
            // 
            txtEquipmentSearch.Location = new Point(33, 118);
            txtEquipmentSearch.Name = "txtEquipmentSearch";
            txtEquipmentSearch.Size = new Size(451, 23);
            txtEquipmentSearch.TabIndex = 7;
            // 
            // panelReserve
            // 
            panelReserve.Controls.Add(label3);
            panelReserve.Controls.Add(label2);
            panelReserve.Controls.Add(btnCancelReserve);
            panelReserve.Controls.Add(txtReserveEquipment);
            panelReserve.Controls.Add(btnReserve);
            panelReserve.Controls.Add(txtReserveQuantity);
            panelReserve.Controls.Add(dtpScheduledPickup);
            panelReserve.Location = new Point(157, 151);
            panelReserve.Name = "panelReserve";
            panelReserve.Size = new Size(463, 100);
            panelReserve.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(141, 19);
            label3.Name = "label3";
            label3.Size = new Size(55, 16);
            label3.TabIndex = 15;
            label3.Text = "Quantity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(9, 19);
            label2.Name = "label2";
            label2.Size = new Size(126, 16);
            label2.TabIndex = 12;
            label2.Text = "Reserve Equipment";
            // 
            // btnCancelReserve
            // 
            btnCancelReserve.BackColor = Color.Crimson;
            btnCancelReserve.ForeColor = Color.Beige;
            btnCancelReserve.Location = new Point(358, 67);
            btnCancelReserve.Name = "btnCancelReserve";
            btnCancelReserve.Size = new Size(77, 30);
            btnCancelReserve.TabIndex = 14;
            btnCancelReserve.Text = "CANCEL";
            btnCancelReserve.UseVisualStyleBackColor = false;
            // 
            // txtReserveEquipment
            // 
            txtReserveEquipment.Location = new Point(9, 38);
            txtReserveEquipment.Name = "txtReserveEquipment";
            txtReserveEquipment.Size = new Size(126, 23);
            txtReserveEquipment.TabIndex = 11;
            // 
            // btnReserve
            // 
            btnReserve.BackColor = Color.Crimson;
            btnReserve.ForeColor = Color.Beige;
            btnReserve.Location = new Point(259, 65);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new Size(93, 32);
            btnReserve.TabIndex = 13;
            btnReserve.Text = "RESERVE";
            btnReserve.UseVisualStyleBackColor = false;
            // 
            // txtReserveQuantity
            // 
            txtReserveQuantity.Location = new Point(141, 38);
            txtReserveQuantity.Name = "txtReserveQuantity";
            txtReserveQuantity.Size = new Size(100, 23);
            txtReserveQuantity.TabIndex = 8;
            // 
            // dtpScheduledPickup
            // 
            dtpScheduledPickup.Location = new Point(247, 38);
            dtpScheduledPickup.Name = "dtpScheduledPickup";
            dtpScheduledPickup.Size = new Size(207, 23);
            dtpScheduledPickup.TabIndex = 12;
            dtpScheduledPickup.ValueChanged += dtpScheduledPickup_ValueChanged;
            // 
            // dgvEquipment
            // 
            dgvEquipment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipment.Dock = DockStyle.Bottom;
            dgvEquipment.Location = new Point(3, 200);
            dgvEquipment.Name = "dgvEquipment";
            dgvEquipment.Size = new Size(797, 328);
            dgvEquipment.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BackgroundImage = (Image)resources.GetObject("panel5.BackgroundImage");
            panel5.Controls.Add(btnHamburger);
            panel5.Location = new Point(1, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(818, 73);
            panel5.TabIndex = 13;
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.Crimson;
            panelSidebar.Controls.Add(button14);
            panelSidebar.Controls.Add(button13);
            panelSidebar.Controls.Add(button8);
            panelSidebar.Controls.Add(button4);
            panelSidebar.Controls.Add(button5);
            panelSidebar.Controls.Add(button3);
            panelSidebar.Controls.Add(button1);
            panelSidebar.Location = new Point(1, 59);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(165, 711);
            panelSidebar.TabIndex = 7;
            // 
            // button14
            // 
            button14.BackColor = Color.Crimson;
            button14.FlatStyle = FlatStyle.Flat;
            button14.Font = new Font("Franklin Gothic Medium Cond", 12F);
            button14.ForeColor = SystemColors.Window;
            button14.Location = new Point(6, 302);
            button14.Name = "button14";
            button14.Size = new Size(156, 50);
            button14.TabIndex = 7;
            button14.Text = "MY SLIPS";
            button14.UseVisualStyleBackColor = false;
            button14.Click += btnMySlipsTab_Click;
            // 
            // button13
            // 
            button13.BackColor = Color.Crimson;
            button13.FlatStyle = FlatStyle.Flat;
            button13.Font = new Font("Franklin Gothic Medium Cond", 12F);
            button13.ForeColor = SystemColors.Window;
            button13.Location = new Point(6, 246);
            button13.Name = "button13";
            button13.Size = new Size(156, 50);
            button13.TabIndex = 6;
            button13.Text = "BORROW SLIP";
            button13.UseVisualStyleBackColor = false;
            button13.Click += btnLabSlipsTab_Click;
            // 
            // userform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 605);
            Controls.Add(panel5);
            Controls.Add(panelSidebar);
            Controls.Add(tab);
            Name = "userform";
            Text = "userform";
            reservations.ResumeLayout(false);
            reservations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            tab.ResumeLayout(false);
            dashboard.ResumeLayout(false);
            dashboard.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            borrowed.ResumeLayout(false);
            borrowed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBorrowed).EndInit();
            account.ResumeLayout(false);
            account.PerformLayout();
            SLIPS.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSlipItems).EndInit();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSlipMembers).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            myslipstab.ResumeLayout(false);
            myslipstab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMySlips).EndInit();
            reserve.ResumeLayout(false);
            reserve.PerformLayout();
            panelReserve.ResumeLayout(false);
            panelReserve.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).EndInit();
            panel5.ResumeLayout(false);
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnHamburger;
        private Button button3;
        private Button button1;
        private Button button5;
        private Button button8;
        private TabPage reservations;
        private Button button10;
        private DataGridView dgvReservations;
        private TabControl tab;
        private TabPage borrowed;
        private DataGridView dgvBorrowed;
        private TabPage account;
        private Button btnRequestReturn;
        private TextBox txtBorrowedSearch;
        private Button btnSaveAccount;
        private TextBox txtLastName;
        private TextBox txtPassword;
        private TextBox txtRole;
        private TextBox txtUsername;
        private TextBox txtMobileNo;
        private TextBox txtFirstName;
        private TextBox txtReservationSearch;
        private TextBox txtAddress;
        private Button button4;
        private TabPage dashboard;
        private Label label5;
        private Label lblPendingReservations;
        private Label label11;
        private Panel panel1;
        private Label lblAvailable;
        private Label label6;
        private Panel panel4;
        private Label label9;
        private Label lblReturnPending;
        private Panel panel3;
        private Label label7;
        private Panel panel2;
        private Label label8;
        private Label lblBorrowed;
        private Label label10;
        private Label label4;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label23;
        private Label label22;
        private Label label24;
        private Panel panel5;
        private Panel panelSidebar;
        private TabPage SLIPS;
        private Button button6;
        private Panel panel10;
        private Panel panel9;
        private Panel panel7;
        private Button button7;
        private Label label29;
        private Label label28;
        private ComboBox cmbCourse;
        private DataGridView dgvSlipItems;
        private TextBox txtSlipQty;
        private DataGridView dgvSlipMembers;
        private TextBox txtMemberName;
        private TextBox txtSubjectOrExperiment;
        private TextBox txtSectionName;
        private DateTimePicker dtpExpectedReturn;
        private TextBox txtGroupName;
        private Panel panel6;
        private DataGridView dataGridView3;
        private TextBox textBox7;
        private Label label26;
        private Button button9;
        private Label label27;
        private Label label31;
        private Label label30;
        private Label label32;
        private Label label37;
        private TextBox txtFacultyName;
        private Label label36;
        private Label label25;
        private Label label35;
        private Label label34;
        private Label label33;
        private TextBox txtMemberRole;
        private TabPage myslipstab;
        private Label label38;
        private DataGridView dgvMySlips;
        private Button button11;
        private Button button12;
        private Button button14;
        private Button button13;
        private TextBox txtCourse;
        private Label label39;
        private ComboBox cmbSlipFilter;
        private Label label42;
        private TabPage reserve;
        private Label label21;
        private Label label1;
        private Button btnOpenReservePanel;
        private TextBox txtEquipmentSearch;
        private Panel panelReserve;
        private Label label3;
        private Label label2;
        private Button btnCancelReserve;
        private TextBox txtReserveEquipment;
        private Button btnReserve;
        private TextBox txtReserveQuantity;
        private DateTimePicker dtpScheduledPickup;
        private DataGridView dgvEquipment;
    }
}