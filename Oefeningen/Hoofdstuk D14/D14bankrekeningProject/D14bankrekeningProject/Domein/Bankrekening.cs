namespace D14bankrekeningProject.Domein
{
    public class Bankrekening
    {
        private decimal _saldo;
        public void Stort(decimal bedrag)
        {
            _saldo = _saldo + bedrag;
        }
        public void HaalAf(decimal bedrag)
        {
            _saldo = _saldo - bedrag;
        }
        public decimal Saldo()
        {
            return _saldo;
        }


        public void SchrijOver(decimal bedrag,Bankrekening naarBankrekening)
        {
            this.HaalAf(bedrag);
            naarBankrekening.Stort(bedrag);
        }
    }
}
