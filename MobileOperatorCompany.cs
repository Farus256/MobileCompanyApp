using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4_Max.Model
{
    public class MobileOperatorCompany
    {
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public Dictionary<string, MobileAccount> Accounts { get; private set; } = new Dictionary<string, MobileAccount>();

        // Використовуємо List<string> для збереження порядку логів
        public List<string> OperationLogs { get; private set; } = new List<string>();
        public List<decimal> MonthlyEarnings { get; private set; } = Enumerable.Repeat(0m, 12).ToList();

        // Подія, що виникає при оновленні логів
        public event EventHandler LogUpdated;

        public MobileOperatorCompany(string companyName, string companyCode)
        {
            CompanyName = companyName;
            CompanyCode = companyCode;
        }

        public void AddAccount(MobileAccount account)
        {
            if (!Accounts.ContainsKey(account.PhoneNumber))
            {
                Accounts[account.PhoneNumber] = account;

                // Підписка на події від абонента
                account.ClientRegistered += Account_ClientRegistered;
                account.CallMade += Account_CallMade;
                account.TariffChanged += Account_TariffChanged;
                account.BalanceToppedUp += Account_BalanceToppedUp;
                account.VpnUsed += Account_VpnUsed;

                // Логування додавання абонента
                LogOperation($"Абонент {account.PhoneNumber} доданий.");
            }
        }

        public void RemoveAccount(string phoneNumber)
        {
            if (Accounts.TryGetValue(phoneNumber, out var account))
            {
                // Відписка від подій абонента
                account.ClientRegistered -= Account_ClientRegistered;
                account.CallMade -= Account_CallMade;
                account.TariffChanged -= Account_TariffChanged;
                account.BalanceToppedUp -= Account_BalanceToppedUp;
                account.VpnUsed -= Account_VpnUsed;

                Accounts.Remove(phoneNumber);

                // Логування видалення абонента
                LogOperation($"Абонент {phoneNumber} видалений.");
            }
            else
            {
                throw new Exception("Абонент не знайдений.");
            }
        }

        // Обробник події реєстрації нового клієнта
        private void Account_ClientRegistered(object sender, AccountEventArgs e)
        {
            LogOperation($"Абонент {e.PhoneNumber} зареєстрований.");
        }

        // Обробник події здійснення дзвінка
        private void Account_CallMade(object sender, CallEventArgs e)
        {
            LogOperation($"Абонент {e.FromPhoneNumber} здійснив дзвінок на {e.ToPhoneNumber} тривалістю {e.DurationMinutes} хвилин, вартістю {e.Cost:C}.");
        }

        // Обробник події зміни тарифу
        private void Account_TariffChanged(object sender, TariffChangedEventArgs e)
        {
            LogOperation($"Абонент {e.PhoneNumber} змінив тариф з {e.OldTariff.Name} на {e.NewTariff.Name}.");
        }

        // Обробник події поповнення балансу
        private void Account_BalanceToppedUp(object sender, BalanceEventArgs e)
        {
            LogOperation($"Абонент {e.PhoneNumber} поповнив баланс на {e.Amount:C}.");
        }

        // Обробник події використання VPN
        private void Account_VpnUsed(object sender, VpnUsedEventArgs e)
        {
            LogOperation($"Абонент {e.PhoneNumber} використав VPN.");
        }

        public void AddMonthlyEarnings(int month, decimal amount)
        {
            if (month < 1 || month > 12) throw new ArgumentOutOfRangeException(nameof(month));
            MonthlyEarnings[month - 1] += amount;
        }

        public decimal[] GetTaxReport()
        {
            return MonthlyEarnings.Select(e => e * 0.15m).ToArray();
        }

        public void SaveCompanyData(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Компанія: {CompanyName}");
                writer.WriteLine($"Код ЄДРПОУ: {CompanyCode}");
                writer.WriteLine($"Кількість клієнтів: {Accounts.Count}");
                writer.WriteLine("Клієнти:");
                foreach (var account in Accounts.Values)
                {
                    writer.WriteLine($"{account.PhoneNumber},{account.Balance},{account.CurrentTariff.Name}");
                }
            }
        }

        public void LoadCompanyData(string filePath, List<Tariff> tariffs)
        {
            using (var reader = new StreamReader(filePath))
            {
                CompanyName = reader.ReadLine()?.Split(new[] { ": " }, StringSplitOptions.None)[1];
                CompanyCode = reader.ReadLine()?.Split(new[] { ": " }, StringSplitOptions.None)[1];
                int accountCount = int.Parse(reader.ReadLine()?.Split(new[] { ": " }, StringSplitOptions.None)[1]);

                reader.ReadLine(); // Пропускаємо "Клієнти:"

                for (int i = 0; i < accountCount; i++)
                {
                    var line = reader.ReadLine().Split(',');
                    var number = line[0];
                    var balance = decimal.Parse(line[1]);
                    var tariffName = line[2];

                    var tariff = tariffs.FirstOrDefault(t => t.Name == tariffName);
                    if (tariff == null)
                        throw new Exception($"Тариф {tariffName} не знайдено.");

                    var account = new MobileAccount(number, tariff, this) { Balance = balance };
                    AddAccount(account);
                }
            }
        }

        public void SaveLogs(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var log in OperationLogs)
                {
                    writer.WriteLine(log);
                }
            }
        }

        public void LogOperation(string message)
        {
            string logEntry = $"{DateTime.Now}: {message}";
            OperationLogs.Add(logEntry);

            // Викликаємо подію LogUpdated після додавання нового лога
            OnLogUpdated();
        }

        // Метод для виклику події LogUpdated
        protected virtual void OnLogUpdated()
        {
            LogUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
