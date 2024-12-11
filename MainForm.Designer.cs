namespace Lab4_Max.View
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Елементи керування
        private System.Windows.Forms.ComboBox cmbCompanies;
        private System.Windows.Forms.Label lblCompanyInfo;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.Button btnCreateCompany;

        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button btnRemoveAccount;

        private System.Windows.Forms.Label lblCurrentTariff;
        private System.Windows.Forms.Label lblBalanceInfo;
        private System.Windows.Forms.TextBox txtBalanceAmount;
        private System.Windows.Forms.Button btnAddBalance;

        private System.Windows.Forms.ComboBox comboTariffs;
        private System.Windows.Forms.Button btnChangeTariff;

        private System.Windows.Forms.TextBox txtCallPhoneNumber;
        private System.Windows.Forms.TextBox txtCallMinutes;
        private System.Windows.Forms.RadioButton rbtnLocal;
        private System.Windows.Forms.RadioButton rbtnInternational;
        private System.Windows.Forms.CheckBox chkHideNumber;
        private System.Windows.Forms.Button btnMakeCall;

        private System.Windows.Forms.Button btnUseVPN;

        private System.Windows.Forms.Button btnSaveCompanyData;
        private System.Windows.Forms.Button btnLoadCompanyData;
        private System.Windows.Forms.Button btnSaveLogs;

        private System.Windows.Forms.Button btnShowTaxes;
        private System.Windows.Forms.DataGridView dgvTaxes;

        private System.Windows.Forms.DataGridView dgvLogs;

        private System.Windows.Forms.Button btnRemoveCompany;

        /// <summary>
        /// Обов'язковий метод для підтримки конструктора.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Ініціалізація елементів керування
            this.cmbCompanies = new System.Windows.Forms.ComboBox();
            this.lblCompanyInfo = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.btnCreateCompany = new System.Windows.Forms.Button();

            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.btnRemoveAccount = new System.Windows.Forms.Button();

            this.lblCurrentTariff = new System.Windows.Forms.Label();
            this.lblBalanceInfo = new System.Windows.Forms.Label();
            this.txtBalanceAmount = new System.Windows.Forms.TextBox();
            this.btnAddBalance = new System.Windows.Forms.Button();

            this.comboTariffs = new System.Windows.Forms.ComboBox();
            this.btnChangeTariff = new System.Windows.Forms.Button();

            this.txtCallPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtCallMinutes = new System.Windows.Forms.TextBox();
            this.rbtnLocal = new System.Windows.Forms.RadioButton();
            this.rbtnInternational = new System.Windows.Forms.RadioButton();
            this.chkHideNumber = new System.Windows.Forms.CheckBox();
            this.btnMakeCall = new System.Windows.Forms.Button();

            this.btnUseVPN = new System.Windows.Forms.Button();

            this.btnSaveCompanyData = new System.Windows.Forms.Button();
            this.btnLoadCompanyData = new System.Windows.Forms.Button();
            this.btnSaveLogs = new System.Windows.Forms.Button();

            this.btnShowTaxes = new System.Windows.Forms.Button();
            this.dgvTaxes = new System.Windows.Forms.DataGridView();

            this.dgvLogs = new System.Windows.Forms.DataGridView();

            this.btnRemoveCompany = new System.Windows.Forms.Button();

            // Налаштування елементів керування

            // cmbCompanies
            this.cmbCompanies.Location = new System.Drawing.Point(20, 20);
            this.cmbCompanies.Size = new System.Drawing.Size(200, 23);
            this.cmbCompanies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompanies.SelectedIndexChanged += new System.EventHandler(this.cmbCompanies_SelectedIndexChanged);

            // lblCompanyInfo
            this.lblCompanyInfo.Location = new System.Drawing.Point(240, 20);
            this.lblCompanyInfo.Size = new System.Drawing.Size(400, 20);
            this.lblCompanyInfo.Text = "Компанія: ";

            // txtCompanyName
            this.txtCompanyName.Location = new System.Drawing.Point(20, 50);
            this.txtCompanyName.Size = new System.Drawing.Size(200, 23);
            this.txtCompanyName.PlaceholderText = "Назва компанії";

            // txtCompanyCode
            this.txtCompanyCode.Location = new System.Drawing.Point(240, 50);
            this.txtCompanyCode.Size = new System.Drawing.Size(100, 23);
            this.txtCompanyCode.PlaceholderText = "Код ЄДРПОУ";

            // btnCreateCompany
            this.btnCreateCompany.Location = new System.Drawing.Point(360, 50);
            this.btnCreateCompany.Size = new System.Drawing.Size(150, 23);
            this.btnCreateCompany.Text = "Створити компанію";
            this.btnCreateCompany.Click += new System.EventHandler(this.btnCreateCompany_Click);

            // btnRemoveCompany
            this.btnRemoveCompany.Location = new System.Drawing.Point(520, 50);
            this.btnRemoveCompany.Size = new System.Drawing.Size(150, 23);
            this.btnRemoveCompany.Text = "Видалити компанію";
            this.btnRemoveCompany.Click += new System.EventHandler(this.btnRemoveCompany_Click);

            // cmbAccounts
            this.cmbAccounts.Location = new System.Drawing.Point(20, 90);
            this.cmbAccounts.Size = new System.Drawing.Size(200, 23);
            this.cmbAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);

            // txtPhoneNumber
            this.txtPhoneNumber.Location = new System.Drawing.Point(240, 90);
            this.txtPhoneNumber.Size = new System.Drawing.Size(150, 23);
            this.txtPhoneNumber.PlaceholderText = "Номер телефону";
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);

            // btnAddAccount
            this.btnAddAccount.Location = new System.Drawing.Point(400, 90);
            this.btnAddAccount.Size = new System.Drawing.Size(150, 23);
            this.btnAddAccount.Text = "Додати абонента";
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);

            // btnRemoveAccount
            this.btnRemoveAccount.Location = new System.Drawing.Point(560, 90);
            this.btnRemoveAccount.Size = new System.Drawing.Size(150, 23);
            this.btnRemoveAccount.Text = "Видалити абонента";
            this.btnRemoveAccount.Click += new System.EventHandler(this.btnRemoveAccount_Click);

            // lblCurrentTariff
            this.lblCurrentTariff.Location = new System.Drawing.Point(20, 130);
            this.lblCurrentTariff.Size = new System.Drawing.Size(400, 20);
            this.lblCurrentTariff.Text = "Тариф: ";

            // lblBalanceInfo
            this.lblBalanceInfo.Location = new System.Drawing.Point(20, 160);
            this.lblBalanceInfo.Size = new System.Drawing.Size(200, 20);
            this.lblBalanceInfo.Text = "Баланс: ";

            // txtBalanceAmount
            this.txtBalanceAmount.Location = new System.Drawing.Point(20, 190);
            this.txtBalanceAmount.Size = new System.Drawing.Size(100, 23);
            this.txtBalanceAmount.PlaceholderText = "Сума";

            // btnAddBalance
            this.btnAddBalance.Location = new System.Drawing.Point(130, 190);
            this.btnAddBalance.Size = new System.Drawing.Size(150, 23);
            this.btnAddBalance.Text = "Поповнити баланс";
            this.btnAddBalance.Click += new System.EventHandler(this.btnAddBalance_Click);

            // comboTariffs
            this.comboTariffs.Location = new System.Drawing.Point(20, 230);
            this.comboTariffs.Size = new System.Drawing.Size(200, 23);
            this.comboTariffs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnChangeTariff
            this.btnChangeTariff.Location = new System.Drawing.Point(240, 230);
            this.btnChangeTariff.Size = new System.Drawing.Size(150, 23);
            this.btnChangeTariff.Text = "Змінити тариф";
            this.btnChangeTariff.Click += new System.EventHandler(this.btnChangeTariff_Click);

            // txtCallPhoneNumber
            this.txtCallPhoneNumber.Location = new System.Drawing.Point(20, 270);
            this.txtCallPhoneNumber.Size = new System.Drawing.Size(200, 23);
            this.txtCallPhoneNumber.PlaceholderText = "Номер для дзвінка";

            // txtCallMinutes
            this.txtCallMinutes.Location = new System.Drawing.Point(240, 270);
            this.txtCallMinutes.Size = new System.Drawing.Size(100, 23);
            this.txtCallMinutes.PlaceholderText = "Хвилини";

            // rbtnLocal
            this.rbtnLocal.Location = new System.Drawing.Point(20, 300);
            this.rbtnLocal.Size = new System.Drawing.Size(100, 20);
            this.rbtnLocal.Text = "По Україні";
            this.rbtnLocal.Checked = true;

            // rbtnInternational
            this.rbtnInternational.Location = new System.Drawing.Point(130, 300);
            this.rbtnInternational.Size = new System.Drawing.Size(100, 20);
            this.rbtnInternational.Text = "За кордон";

            // chkHideNumber
            this.chkHideNumber.Location = new System.Drawing.Point(240, 300);
            this.chkHideNumber.Size = new System.Drawing.Size(150, 20);
            this.chkHideNumber.Text = "Приховати номер";
            this.chkHideNumber.Enabled = false;

            // btnMakeCall
            this.btnMakeCall.Location = new System.Drawing.Point(20, 330);
            this.btnMakeCall.Size = new System.Drawing.Size(150, 23);
            this.btnMakeCall.Text = "Здійснити дзвінок";
            this.btnMakeCall.Click += new System.EventHandler(this.btnMakeCall_Click);

            // btnUseVPN
            this.btnUseVPN.Location = new System.Drawing.Point(180, 330);
            this.btnUseVPN.Size = new System.Drawing.Size(150, 23);
            this.btnUseVPN.Text = "Використати VPN";
            this.btnUseVPN.Click += new System.EventHandler(this.btnUseVPN_Click);

            // btnSaveCompanyData
            this.btnSaveCompanyData.Location = new System.Drawing.Point(20, 370);
            this.btnSaveCompanyData.Size = new System.Drawing.Size(150, 23);
            this.btnSaveCompanyData.Text = "Зберегти дані компанії";
            this.btnSaveCompanyData.Click += new System.EventHandler(this.btnSaveCompanyData_Click);

            // btnLoadCompanyData
            this.btnLoadCompanyData.Location = new System.Drawing.Point(180, 370);
            this.btnLoadCompanyData.Size = new System.Drawing.Size(150, 23);
            this.btnLoadCompanyData.Text = "Завантажити дані компанії";
            this.btnLoadCompanyData.Click += new System.EventHandler(this.btnLoadCompanyData_Click);

            // btnSaveLogs
            this.btnSaveLogs.Location = new System.Drawing.Point(340, 370);
            this.btnSaveLogs.Size = new System.Drawing.Size(150, 23);
            this.btnSaveLogs.Text = "Зберегти логи";
            this.btnSaveLogs.Click += new System.EventHandler(this.btnSaveLogs_Click);

            // btnShowTaxes
            this.btnShowTaxes.Location = new System.Drawing.Point(500, 370);
            this.btnShowTaxes.Size = new System.Drawing.Size(150, 23);
            this.btnShowTaxes.Text = "Показати податки";
            this.btnShowTaxes.Click += new System.EventHandler(this.btnShowTaxes_Click);

            // dgvLogs
            this.dgvLogs.Location = new System.Drawing.Point(20, 410);
            this.dgvLogs.Size = new System.Drawing.Size(700, 150);
            this.dgvLogs.Columns.Add("Log", "Лог");
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.RowHeadersVisible = false;
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // dgvTaxes
            this.dgvTaxes.Location = new System.Drawing.Point(20, 570);
            this.dgvTaxes.Size = new System.Drawing.Size(700, 150);
            this.dgvTaxes.Columns.Add("Month", "Місяць");
            this.dgvTaxes.Columns.Add("Tax", "Податок (грн)");
            this.dgvTaxes.ReadOnly = true;
            this.dgvTaxes.AllowUserToAddRows = false;
            this.dgvTaxes.RowHeadersVisible = false;
            this.dgvTaxes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Додавання елементів на форму
            this.Controls.Add(this.cmbCompanies);
            this.Controls.Add(this.lblCompanyInfo);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.txtCompanyCode);
            this.Controls.Add(this.btnCreateCompany);
            this.Controls.Add(this.btnRemoveCompany);

            this.Controls.Add(this.cmbAccounts);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.btnRemoveAccount);

            this.Controls.Add(this.lblCurrentTariff);
            this.Controls.Add(this.lblBalanceInfo);
            this.Controls.Add(this.txtBalanceAmount);
            this.Controls.Add(this.btnAddBalance);

            this.Controls.Add(this.comboTariffs);
            this.Controls.Add(this.btnChangeTariff);

            this.Controls.Add(this.txtCallPhoneNumber);
            this.Controls.Add(this.txtCallMinutes);
            this.Controls.Add(this.rbtnLocal);
            this.Controls.Add(this.rbtnInternational);
            this.Controls.Add(this.chkHideNumber);
            this.Controls.Add(this.btnMakeCall);

            this.Controls.Add(this.btnUseVPN);

            this.Controls.Add(this.btnSaveCompanyData);
            this.Controls.Add(this.btnLoadCompanyData);
            this.Controls.Add(this.btnSaveLogs);
            this.Controls.Add(this.btnShowTaxes);

            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.dgvTaxes);

            // Налаштування форми
            this.Text = "Мобільний оператор";
            this.ClientSize = new System.Drawing.Size(750, 750);

            // Інші налаштування форми
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            txtCallPhoneNumber.KeyPress += txtCallPhoneNumber_KeyPress;
        }
    }
}
