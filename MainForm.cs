using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Lab4_Max.Model;

namespace Lab4_Max.View
{
    public partial class MainForm : Form
    {
        private List<MobileOperatorCompany> companies = new List<MobileOperatorCompany>();
        private MobileOperatorCompany currentCompany;
        private MobileAccount currentAccount;
        private List<Tariff> availableTariffs;

        public MainForm()
        {
            InitializeComponent();
            InitializeTariffs();
        }

        // Ініціалізація тарифів
        private void InitializeTariffs()
        {
            availableTariffs = new List<Tariff>
            {
                new Tariff("Стартовий", 100, 1.5m, 5m, 5, false, false, false),
                new Tariff("Максимальний", 200, 0m, 3m, 10, false, false, false),
                new Tariff("Професійний", 300, 0m, 2m, 0, true, true, true),
                new Tariff("Турбо", 500, 0m, 0m, 0, true, true, true)
            };

            comboTariffs.DataSource = availableTariffs;
            comboTariffs.DisplayMember = "Name";
        }

        // Обробник кнопки створення нової компанії
        private void btnCreateCompany_Click(object sender, EventArgs e)
        {
            string companyName = txtCompanyName.Text.Trim();
            string companyCode = txtCompanyCode.Text.Trim();

            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(companyCode))
            {
                MessageBox.Show("Введіть назву та код компанії.");
                return;
            }

            if (!Regex.IsMatch(companyName, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("Назва компанії може містити тільки букви, цифри та пробіли.");
                return;
            }

            if (!Regex.IsMatch(companyCode, @"^\d+$"))
            {
                MessageBox.Show("Код компанії повинен містити тільки цифри.");
                return;
            }

            if (companies.Any(c => c.CompanyName == companyName || c.CompanyCode == companyCode))
            {
                MessageBox.Show("Компанія з такою назвою або кодом вже існує.");
                return;
            }

            var newCompany = new MobileOperatorCompany(companyName, companyCode);
            companies.Add(newCompany);

            // Оновлюємо список компаній у ComboBox
            cmbCompanies.Items.Add(newCompany.CompanyName);
            cmbCompanies.SelectedItem = newCompany.CompanyName;

            currentCompany = newCompany;
            lblCompanyInfo.Text = $"Компанія: {currentCompany.CompanyName} (Код: {currentCompany.CompanyCode})";

            MessageBox.Show("Компанію створено.");
        }

        // Обробник зміни вибраної компанії
        private void cmbCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCompanyName = cmbCompanies.SelectedItem as string;

            // Відписуємось від події LogUpdated попередньої компанії
            if (currentCompany != null)
            {
                currentCompany.LogUpdated -= CurrentCompany_LogUpdated;
            }

            currentCompany = companies.FirstOrDefault(c => c.CompanyName == selectedCompanyName);

            if (currentCompany != null)
            {
                lblCompanyInfo.Text = $"Компанія: {currentCompany.CompanyName} (Код: {currentCompany.CompanyCode})";
                currentAccount = null;
                ClearAccountInfo();
                UpdateAccounts();

                // Підписуємось на подію LogUpdated нової компанії
                currentCompany.LogUpdated += CurrentCompany_LogUpdated;

                // Оновлюємо логи
                UpdateLogs();
            }
        }

        // Обробник події LogUpdated від компанії
        private void CurrentCompany_LogUpdated(object sender, EventArgs e)
        {
            // Оновлюємо логи в інтерфейсі
            Invoke(new Action(() => UpdateLogs()));
        }

        // Метод для оновлення логів в таблиці
        private void UpdateLogs()
        {
            dgvLogs.Rows.Clear();
            if (currentCompany != null)
            {
                foreach (var log in currentCompany.OperationLogs)
                {
                    dgvLogs.Rows.Add(log);
                }
            }
        }

        // Метод для оновлення списку абонентів
        private void UpdateAccounts()
        {
            cmbAccounts.Items.Clear();
            if (currentCompany != null)
            {
                foreach (var account in currentCompany.Accounts.Values)
                {
                    cmbAccounts.Items.Add(account.PhoneNumber);
                }
            }
        }

        // Обробник зміни вибраного абонента
        private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPhoneNumber = cmbAccounts.SelectedItem as string;
            if (currentCompany != null && currentCompany.Accounts.ContainsKey(selectedPhoneNumber))
            {
                currentAccount = currentCompany.Accounts[selectedPhoneNumber];
                UpdateAccountInfo();
            }
        }

        // Обробник кнопки додавання абонента
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                MessageBox.Show("Виберіть компанію.");
                return;
            }

            string phoneNumber = txtPhoneNumber.Text.Trim();
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Введіть номер телефону.");
                return;
            }

            if (!Regex.IsMatch(phoneNumber, @"^\d{10}$"))
            {
                MessageBox.Show("Номер телефону повинен складатися з 10 цифр.");
                return;
            }

            if (currentCompany.Accounts.ContainsKey(phoneNumber))
            {
                MessageBox.Show("Абонент з таким номером вже існує.");
                return;
            }

            var selectedTariff = comboTariffs.SelectedItem as Tariff;
            if (selectedTariff == null)
            {
                MessageBox.Show("Оберіть тариф.");
                return;
            }

            var account = new MobileAccount(phoneNumber, selectedTariff, currentCompany);
            currentCompany.AddAccount(account);
            currentAccount = account;
            UpdateAccountInfo();
            MessageBox.Show("Абонента додано.");

            UpdateAccounts(); // Оновлюємо список абонентів
        }

        // Обробник кнопки видалення абонента
        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                MessageBox.Show("Виберіть компанію.");
                return;
            }

            string phoneNumber = txtPhoneNumber.Text.Trim();
            if (currentCompany.Accounts.ContainsKey(phoneNumber))
            {
                currentCompany.RemoveAccount(phoneNumber);
                if (currentAccount != null && currentAccount.PhoneNumber == phoneNumber)
                {
                    currentAccount = null;
                    ClearAccountInfo();
                }
                MessageBox.Show("Абонента видалено.");

                UpdateAccounts(); // Оновлюємо список абонентів
            }
            else
            {
                MessageBox.Show("Абонент не знайдений.");
            }
        }

        // Обробник кнопки поповнення балансу
        private void btnAddBalance_Click(object sender, EventArgs e)
        {
            if (currentAccount == null)
            {
                MessageBox.Show("Виберіть абонента.");
                return;
            }

            if (decimal.TryParse(txtBalanceAmount.Text, out decimal amount))
            {
                if (amount <= 0)
                {
                    MessageBox.Show("Сума повинна бути більше нуля.");
                    return;
                }

                currentAccount.AddBalance(amount);
                UpdateAccountInfo();
                MessageBox.Show("Баланс поповнено.");
            }
            else
            {
                MessageBox.Show("Некоректна сума.");
            }
        }

        // Обробник кнопки зміни тарифу
        private void btnChangeTariff_Click(object sender, EventArgs e)
        {
            if (currentAccount == null)
            {
                MessageBox.Show("Виберіть абонента.");
                return;
            }

            var selectedTariff = comboTariffs.SelectedItem as Tariff;
            if (selectedTariff == null)
            {
                MessageBox.Show("Оберіть тариф.");
                return;
            }

            string result = currentAccount.ChangeTariff(selectedTariff);
            UpdateAccountInfo();
            MessageBox.Show(result);
        }

        // Обробник кнопки здійснення дзвінка
        private void btnMakeCall_Click(object sender, EventArgs e)
        {
            if (currentAccount == null)
            {
                MessageBox.Show("Виберіть абонента.");
                return;
            }

            if (!int.TryParse(txtCallMinutes.Text, out int minutes) || minutes <= 0)
            {
                MessageBox.Show("Некоректна кількість хвилин.");
                return;
            }

            string callNumber = txtCallPhoneNumber.Text.Trim();

            if (!Regex.IsMatch(callNumber, @"^\d{10}$"))
            {
                MessageBox.Show("Номер для дзвінка повинен складатися з 10 цифр.");
                return;
            }

            bool isLocalCall = rbtnLocal.Checked;
            bool hideNumber = chkHideNumber.Checked;

            if (hideNumber && !currentAccount.CurrentTariff.CanHideNumber)
            {
                MessageBox.Show("Ваш тариф не підтримує приховування номера.");
                return;
            }

            string result = currentAccount.MakeCall(minutes, callNumber, isLocalCall, hideNumber);
            UpdateAccountInfo();
            MessageBox.Show(result);
        }
        private void txtCallPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка: только цифры и управляющие символы (например, Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Блокируем ввод
                return;
            }

            // Проверка: не больше 10 символов
            if (txtCallPhoneNumber.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Блокируем ввод, если уже 10 символов
            }
        }

        // Обробник кнопки використання VPN
        private void btnUseVPN_Click(object sender, EventArgs e)
        {
            if (currentAccount == null)
            {
                MessageBox.Show("Виберіть абонента.");
                return;
            }

            string result = currentAccount.UseVPN();
            MessageBox.Show(result);
        }

        // Обробник кнопки показу податків
        private void btnShowTaxes_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                MessageBox.Show("Виберіть компанію.");
                return;
            }

            var taxes = currentCompany.GetTaxReport();

            dgvTaxes.Rows.Clear();

            for (int month = 1; month <= 12; month++)
            {
                decimal tax = taxes[month - 1];
                dgvTaxes.Rows.Add(month, tax.ToString("C"));
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
                return;
            }

            if (txtPhoneNumber.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }


        private void btnRemoveCompany_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                MessageBox.Show("Оберіть компанію для видалення.");
                return;
            }


            var confirmResult = MessageBox.Show($"Ви дійсно бажаєте видалити компанію {currentCompany.CompanyName}?",
                                                "Підтвердження видалення",
                                                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                // Відписуємось від події LogUpdated
                currentCompany.LogUpdated -= CurrentCompany_LogUpdated;

                companies.Remove(currentCompany);
                cmbCompanies.Items.Remove(currentCompany.CompanyName);
                currentCompany = null;

                // Очищуємо інтерфейс
                lblCompanyInfo.Text = "Компанія:";
                cmbAccounts.Items.Clear();
                ClearAccountInfo();

                MessageBox.Show("Компанію успішно видалено.");
            }
        }

        // Оновлення інформації про абонента
        private void UpdateAccountInfo()
        {
            if (currentAccount != null)
            {
                lblBalanceInfo.Text = $"Баланс: {currentAccount.Balance:C}";
                lblCurrentTariff.Text = $"Тариф: {currentAccount.CurrentTariff.Name}";
                chkHideNumber.Enabled = currentAccount.CurrentTariff.CanHideNumber;
            }
            else
            {
                ClearAccountInfo();
            }
        }

        // Очищення інформації про абонента
        private void ClearAccountInfo()
        {
            lblBalanceInfo.Text = "Баланс: ";
            lblCurrentTariff.Text = "Тариф: ";
            chkHideNumber.Enabled = false;
        }

        // Обробник кнопки збереження даних компанії
        private void btnSaveCompanyData_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                MessageBox.Show("Виберіть компанію.");
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Зберегти дані компанії"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentCompany.SaveCompanyData(saveFileDialog.FileName);
                MessageBox.Show("Дані компанії збережено.");
            }
        }

        // Обробник кнопки завантаження даних компанії
        private void btnLoadCompanyData_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Завантажити дані компанії"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var newCompany = new MobileOperatorCompany("", "");
                try
                {
                    newCompany.LoadCompanyData(openFileDialog.FileName, availableTariffs);

                    if (companies.Any(c => c.CompanyName == newCompany.CompanyName || c.CompanyCode == newCompany.CompanyCode))
                    {
                        MessageBox.Show("Компанія з такою назвою або кодом вже існує.");
                        return;
                    }

                    companies.Add(newCompany);
                    cmbCompanies.Items.Add(newCompany.CompanyName);
                    cmbCompanies.SelectedItem = newCompany.CompanyName;
                    currentCompany = newCompany;

                    // Підписуємось на подію LogUpdated нової компанії
                    currentCompany.LogUpdated += CurrentCompany_LogUpdated;

                    MessageBox.Show("Дані компанії завантажено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}");
                }
            }
        }

        // Обробник кнопки збереження логів
        private void btnSaveLogs_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                MessageBox.Show("Виберіть компанію.");
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Зберегти логи операцій"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentCompany.SaveLogs(saveFileDialog.FileName);
                MessageBox.Show("Логи збережено.");
            }
        }

        // Відписуємось від події при закритті форми
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (currentCompany != null)
            {
                currentCompany.LogUpdated -= CurrentCompany_LogUpdated;
            }
            base.OnFormClosing(e);
        }
    }
}
