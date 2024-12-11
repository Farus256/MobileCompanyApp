using Lab4_Max.Model;
using System;

namespace Lab4_Max.Model
{
    // Клас для передачі даних про реєстрацію абонента
    public class AccountEventArgs : EventArgs
    {
        public string PhoneNumber { get; }

        public AccountEventArgs(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }

    // Клас для передачі даних про зміну тарифу
    public class TariffChangedEventArgs : EventArgs
    {
        public string PhoneNumber { get; }
        public Tariff OldTariff { get; }
        public Tariff NewTariff { get; }

        public TariffChangedEventArgs(string phoneNumber, Tariff oldTariff, Tariff newTariff)
        {
            PhoneNumber = phoneNumber;
            OldTariff = oldTariff;
            NewTariff = newTariff;
        }
    }

    // Клас для передачі даних про здійснений дзвінок
    public class CallEventArgs : EventArgs
    {
        public string FromPhoneNumber { get; }
        public string ToPhoneNumber { get; }
        public int DurationMinutes { get; }
        public decimal Cost { get; }
        public bool IsLocalCall { get; }
        public bool IsNumberHidden { get; }

        public CallEventArgs(string fromPhoneNumber, string toPhoneNumber, int durationMinutes, decimal cost, bool isLocalCall, bool isNumberHidden)
        {
            FromPhoneNumber = fromPhoneNumber;
            ToPhoneNumber = toPhoneNumber;
            DurationMinutes = durationMinutes;
            Cost = cost;
            IsLocalCall = isLocalCall;
            IsNumberHidden = isNumberHidden;
        }
    }

    // Клас для передачі даних про поповнення балансу
    public class BalanceEventArgs : EventArgs
    {
        public string PhoneNumber { get; }
        public decimal Amount { get; }

        public BalanceEventArgs(string phoneNumber, decimal amount)
        {
            PhoneNumber = phoneNumber;
            Amount = amount;
        }
    }

    // Клас для передачі даних про використання VPN
    public class VpnUsedEventArgs : EventArgs
    {
        public string PhoneNumber { get; }

        public VpnUsedEventArgs(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
