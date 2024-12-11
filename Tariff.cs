namespace Lab4_Max.Model
{
    public class Tariff
    {
        public string Name { get; set; }
        public decimal MonthlyFee { get; set; }
        public decimal DomesticRate { get; set; }
        public decimal RoamingRate { get; set; }
        public int InternetGB { get; set; }
        public bool UnlimitedInternet { get; set; }
        public bool FreeVPN { get; set; }
        public bool CanHideNumber { get; set; }

        public Tariff(string name, decimal monthlyFee, decimal domesticRate, decimal roamingRate, int internetGB, bool unlimitedInternet, bool freeVPN, bool canHideNumber)
        {
            Name = name;
            MonthlyFee = monthlyFee;
            DomesticRate = domesticRate;
            RoamingRate = roamingRate;
            InternetGB = internetGB;
            UnlimitedInternet = unlimitedInternet;
            FreeVPN = freeVPN;
            CanHideNumber = canHideNumber;
        }

        public override string ToString()
        {
            return $"{Name} (Ціна: {MonthlyFee} грн/міс)";
        }
    }
}
