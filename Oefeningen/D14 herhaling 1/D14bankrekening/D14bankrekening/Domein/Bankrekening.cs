namespace D14bankrekening.Domein
{
    internal class Bankrekening
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

        public void SchrijfOver(decimal bedrag, Bankrekening doelrekening)
        {
            this.HaalAf(bedrag);
            doelrekening.Stort(bedrag);
        }
    }
}
