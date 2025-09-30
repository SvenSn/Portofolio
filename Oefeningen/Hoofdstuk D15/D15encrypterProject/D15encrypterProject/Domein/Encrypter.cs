namespace D15encrypterProject.Domein
{
    public class Encrypter
    {
        private string Codewiel = "0ab1cd2ef3gh4ij5kl6m n7op8qr9st.uv,wx!yz?";

		private int _offset;

		public int Offset
		{
			get { return _offset; }
			set { _offset = value; }
		}

        public Encrypter(int offset)
        {
            Offset = offset;
        }

        public string GetCodeFor(string tekst)
		{
			string result = "";
			foreach (char c in tekst)
			{
				int index = Codewiel.IndexOf(c);
				
				if (index == -1)
				{
					result += c;
				}
				else
				{
                    int newIndex = (index + Offset) % Codewiel.Length;
					if (newIndex < 0) newIndex += Codewiel.Length;
					result += Codewiel[newIndex];
                }
			}
			return result;
		}

	}
}
