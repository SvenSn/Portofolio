using Domein;
using System.Collections.Generic;

namespace Persistentie
{
	public class BierRepository : IBierRepository
	{
		private BierMapper _bierMapper;

		public List<Bier> GeefBieren()
		{
			if (_bierMapper == null)
			{
				_bierMapper = new BierMapper();
			}
			return _bierMapper.GeefBieren();
		}

	}

}