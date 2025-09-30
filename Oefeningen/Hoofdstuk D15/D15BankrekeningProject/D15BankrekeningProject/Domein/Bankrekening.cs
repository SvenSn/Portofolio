namespace D15BankrekeningProject.Domein
{
    public class Bankrekening
    {
		private decimal _saldo;

		public decimal Saldo
		{
			get { return _saldo; }
			set { _saldo = value; }
		}

		public void Storting(decimal bedrag)
		{
			Saldo = Saldo + bedrag;
		}
		
		public void Afhalen(decimal bedrag)
		{
			Saldo = Saldo - bedrag;
		}

		public void Overschrijven(decimal bedrag, Bankrekening doelBankrekening)
		{
			this.Afhalen(bedrag);
			doelBankrekening.Storting(bedrag);
		}
	}
}
