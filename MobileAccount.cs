using System;

namespace Lab4_Max.Model
{
    public class MobileAccount
    {
        public string PhoneNumber { get; private set; }
        public Tariff CurrentTariff { get; set; }
        public decimal Balance { get; set; }
        public MobileOperatorCompany OperatorCompany { get; set; }

        // Подія при реєстрації нового клієнта
        public event EventHandler<AccountEventArgs> ClientRegistered;

        // Подія при здійсненні дзвінка
        public event EventHandler<CallEventArgs> CallMade;

        // Подія при зміні тарифу
        public event EventHandler<TariffChangedEventArgs> TariffChanged;

        // Подія при поповненні балансу
        public event EventHandler<BalanceEventArgs> BalanceToppedUp;

        // Подія при використанні VPN
        public event EventHandler<VpnUsedEventArgs> VpnUsed;

        public MobileAccount(string phoneNumber, Tariff initialTariff, MobileOperatorCompany operatorCompany)
        {
            PhoneNumber = phoneNumber;
            CurrentTariff = initialTariff;
            Balance = 0;
            OperatorCompany = operatorCompany;

            // Виклик події реєстрації нового клієнта
            OnClientRegistered();
        }

        // Метод для виклику події реєстрації нового клієнта
        protected virtual void OnClientRegistered()
        {
            ClientRegistered?.Invoke(this, new AccountEventArgs(PhoneNumber));
        }

        public void AddBalance(decimal amount)
        {
            Balance += amount;

            // Виклик події поповнення балансу
            OnBalanceToppedUp(amount);
        }

        // Метод для виклику події поповнення балансу
        protected virtual void OnBalanceToppedUp(decimal amount)
        {
            BalanceToppedUp?.Invoke(this, new BalanceEventArgs(PhoneNumber, amount));
        }

        public string ChangeTariff(Tariff newTariff)
        {
            if (Balance < newTariff.MonthlyFee)
                return "Недостатньо коштів для зміни тарифу!";

            Balance -= newTariff.MonthlyFee;
            OperatorCompany.AddMonthlyEarnings(DateTime.Now.Month, newTariff.MonthlyFee);

            var oldTariff = CurrentTariff;
            CurrentTariff = newTariff;

            // Виклик події зміни тарифу
            OnTariffChanged(oldTariff, newTariff);

            return $"Тариф змінено на {newTariff.Name}. Залишок на рахунку: {Balance:C}";
        }

        // Метод для виклику події зміни тарифу
        protected virtual void OnTariffChanged(Tariff oldTariff, Tariff newTariff)
        {
            TariffChanged?.Invoke(this, new TariffChangedEventArgs(PhoneNumber, oldTariff, newTariff));
        }

        public string MakeCall(int minutes, string phoneNumber, bool isLocalCall, bool hideNumber)
        {
            if (Balance <= 0)
                return "Недостатньо коштів на рахунку!";

            if (string.IsNullOrWhiteSpace(phoneNumber))
                return "Номер телефону не вказаний!";

            decimal cost = isLocalCall
                ? (CurrentTariff.DomesticRate == 0 ? 0 : minutes * CurrentTariff.DomesticRate)
                : minutes * CurrentTariff.RoamingRate;

            if (Balance < cost)
                return "Недостатньо коштів для дзвінка!";

            Balance -= cost;
            OperatorCompany.AddMonthlyEarnings(DateTime.Now.Month, cost);

            string hiddenNumberMessage = hideNumber ? " (номер приховано)" : "";

            // Виклик події здійснення дзвінка
            OnCallMade(minutes, phoneNumber, cost, isLocalCall, hideNumber);

            return $"Дзвінок на {phoneNumber} на {minutes} хвилин. Вартість: {cost:C}. Залишок: {Balance:C}{hiddenNumberMessage}";
        }

        // Метод для виклику події здійснення дзвінка
        protected virtual void OnCallMade(int minutes, string toPhoneNumber, decimal cost, bool isLocalCall, bool hideNumber)
        {
            CallMade?.Invoke(this, new CallEventArgs(PhoneNumber, toPhoneNumber, minutes, cost, isLocalCall, hideNumber));
        }

        public string UseVPN()
        {
            // Виклик події використання VPN
            OnVpnUsed();

            return CurrentTariff.FreeVPN
                ? "VPN використано безкоштовно."
                : "Ваш тариф не підтримує безкоштовний VPN. Використовуйте платний.";
        }

        // Метод для виклику події використання VPN
        protected virtual void OnVpnUsed()
        {
            VpnUsed?.Invoke(this, new VpnUsedEventArgs(PhoneNumber));
        }
    }
}
