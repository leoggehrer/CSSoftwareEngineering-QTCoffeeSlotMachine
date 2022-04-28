namespace QTCoffeeSlotMachine.Logic.Controllers
{
    public class CoffeeMachineController
    {
		private int Id { get; set; }
		public int Price { get; set; } = 50;
		private int[] Coins { get; set; }
		private int[] DepotCoins { get; set; }
		private int[] InsertCoins { get; set; }
		private int[] EjectionCoins { get; set; }

		private string[] Products { get; set; }
		private int[] ProductCounters { get; set; }

		public bool CanSelect => SumCoinValues(Coins, InsertCoins) >= Price;
		public int CoinsInDepot
		{
			get
			{
				return SumArrayValues(DepotCoins);
			}
		}
		public int ProductsAvailable
		{
			get
			{
				return Products.Length;
			}
		}
		public string[] ProductNames
		{
			get
			{
				string[] result = new string[Products.Length];

				for (int i = 0; i < Products.Length; i++)
				{
					result[i] = Products[i];
				}
				return result;
			}
		}
		public CoffeeMachineController()
		{
			Coins = new int[] { 5, 10, 20, 50, 100, 200 };
			InsertCoins = new int[] { 0, 0, 0, 0, 0, 0 };
			EjectionCoins = new int[] { 0, 0, 0, 0, 0, 0 };
			DepotCoins = new int[] { 3, 3, 3, 3, 3, 3 };

			Products = new string[] { "Cappuccino", "Mocca", "Kakao" };
			ProductCounters = new int[] { 0, 0, 0 };
		}

		public CoffeeMachineController(int[] coinsInDepot, string[] productNames)
			: this()
		{
			if (coinsInDepot == null)
				throw new ArgumentNullException(nameof(coinsInDepot));

			if (coinsInDepot.Length != Coins.Length)
				throw new ArgumentException("Invalid count of coins");

			if (productNames == null)
				throw new ArgumentNullException(nameof(productNames));

			for (int i = 0; i < coinsInDepot.Length; i++)
			{
				if (coinsInDepot[i] >= 0)
				{
					DepotCoins[i] = coinsInDepot[i];
				}
			}
			Products = new string[productNames.Length];
			ProductCounters = new int[productNames.Length];

			for (int i = 0; i < productNames.Length; i++)
			{
				Products[i] = productNames[i];
				ProductCounters[i] = 0;
			}
		}

		public CoffeeMachineController(string location)
			: this()
        {
			Task.Run(async () => await LoadDataAsync(location)).Wait();
        }
		private async Task LoadDataAsync(string location)
        {
			using var smCtrl = new Logic.Controllers.SlotMachinesController();
			var entities = await smCtrl.EntitySet.Where(e => e.Location == location)
												 .Include(e => e.Products)
												 .ToArrayAsync()
												 .ConfigureAwait(false);

			if (entities.Any())
			{
				var entity = entities[0];

				CopyDataFromEntity(entity);
			}
		}
		private async Task SaveDataAsync(int id)
		{
			using var smCtrl = new Logic.Controllers.SlotMachinesController();
			var entities = await smCtrl.EntitySet.Where(e => e.Id == id)
												 .Include(e => e.Products)
												 .ToArrayAsync()
												 .ConfigureAwait(false);
			var entity = entities.FirstOrDefault();

			if (entity != null)
			{
				CopyDataToEntity(entity);

				var saveItem = await smCtrl.UpdateAsync(entity).ConfigureAwait(false);

				await smCtrl.SaveChangesAsync().ConfigureAwait(false);

				CopyDataFromEntity(saveItem);
			}
		}

		private void CopyDataFromEntity(Entities.SlotMachine slotMachine)
        {
			Id = slotMachine.Id;
			Location = slotMachine.Location;
			Address = slotMachine.Address;
			Price = slotMachine.Price;
			DepotCoins[0] = slotMachine.DepoteCoin5;
			DepotCoins[1] = slotMachine.DepoteCoin10;
			DepotCoins[2] = slotMachine.DepoteCoin20;
			DepotCoins[3] = slotMachine.DepoteCoin50;
			DepotCoins[4] = slotMachine.DepoteCoin100;
			DepotCoins[5] = slotMachine.DepoteCoin200;
			Products = slotMachine.Products.Select(e => e.Name).ToArray();
			ProductCounters = new int[Products.Length];

            for (int i = 0; i < slotMachine.Products.Count; i++)
            {
				ProductCounters[i] = slotMachine.Products[i].Count;
            }
		}
		private void CopyDataToEntity(Entities.SlotMachine slotMachine)
		{
			slotMachine.Location = Location;
			slotMachine.Address = Address;
			slotMachine.Price = Price;
			slotMachine.DepoteCoin5 = DepotCoins[0];
			slotMachine.DepoteCoin10 = DepotCoins[1];
			slotMachine.DepoteCoin20 = DepotCoins[2];
			slotMachine.DepoteCoin50 = DepotCoins[3];
			slotMachine.DepoteCoin100 = DepotCoins[4];
			slotMachine.DepoteCoin200 = DepotCoins[5];

            for (int i = 0; i < ProductCounters.Length; i++)
            {
				if (i < slotMachine.Products.Count)
                {
					slotMachine.Products[i].Count = ProductCounters[i];
                }
            }
		}
		public string Location { get; private set; } = string.Empty;
		public string Address { get; private set; } = string.Empty;
		public bool InsertCoin(int coin)
		{
			bool result = false;
			int coinIdx = GetIndexOf(Coins, coin);

			if (coinIdx > -1)
			{
				result = true;
				InsertCoins[coinIdx]++;
			}
			return result;
		}
		public bool SelectProduct(string product, out int donation)
		{
			bool result = false;
			int restValue = SumCoinValues(Coins, InsertCoins) - Price;
			int productIdx = GetIndexOf(Products, product);

			donation = 0;
			if (productIdx >= 0 && restValue >= 0)
			{
				result = true;
				donation = restValue;
				ProductCounters[productIdx]++;
				DepotCoins = AddArrays(DepotCoins, InsertCoins);
				EmptyArray(InsertCoins);

				int coinIdx = Coins.Length - 1;

				while (coinIdx >= 0 && donation > 0)
				{
					if (DepotCoins[coinIdx] > 0 && Coins[coinIdx] <= donation)
					{
						EjectionCoins[coinIdx]++;
						DepotCoins[coinIdx]--;
						donation -= Coins[coinIdx];
					}
					else
					{
						coinIdx--;
					}
				}
			}
			Task.Run(async () => await SaveDataAsync(Id)).Wait();
			return result;
		}

		public void CancelOrder()
		{
			EjectionCoins = AddArrays(EjectionCoins, InsertCoins);
			EmptyArray(InsertCoins);
		}

		public int[] EmptyDepot(out int sum)
		{
			int[] result = CopyArray(DepotCoins);
			sum = SumCoinValues(Coins, DepotCoins);

			EmptyArray(DepotCoins);
			return result;
		}
		public int[] EmptyEjection(out int sum)
		{
			int[] result = CopyArray(EjectionCoins);
			sum = SumCoinValues(Coins, EjectionCoins);

			EmptyArray(EjectionCoins);
			return result;
		}

		public bool GetCounterForProduct(string product, out int counter)
		{
			bool result = false;
			int productIdx = GetIndexOf(Products, product);

			counter = 0;
			if (productIdx >= 0)
			{
				result = true;
				counter = ProductCounters[productIdx];
			}
			return result;
		}
		public bool GetCounterForDepot(int coin, out int counter)
		{
			bool result = false;
			int coinIdx = GetIndexOf(Coins, coin);

			counter = 0;
			if (coinIdx >= 0)
			{
				result = true;
				counter = DepotCoins[coinIdx];
			}
			return result;
		}
		public bool GetCounterForInsert(int coin, out int counter)
		{
			bool result = false;
			int coinIdx = GetIndexOf(Coins, coin);

			counter = 0;
			if (coinIdx >= 0)
			{
				result = true;
				counter = InsertCoins[coinIdx];
			}
			return result;
		}
		public bool GetCounterForEjection(int coin, out int counter)
		{
			bool result = false;
			int coinIdx = GetIndexOf(Coins, coin);

			counter = 0;
			if (coinIdx >= 0)
			{
				result = true;
				counter = EjectionCoins[coinIdx];
			}
			return result;
		}

		#region Helpers
		private static void EmptyArray(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0;
			}
		}
		private static int[] CopyArray(int[] array)
		{
			int[] result = new int[array.Length];

			for (int i = 0; i < array.Length; i++)
			{
				result[i] = array[i];
			}
			return result;
		}
		private static int[] AddArrays(int[] left, int[] right)
		{
			int[] result = new int[left.Length];

			for (int i = 0; i < left.Length && i < right.Length; i++)
			{
				result[i] = left[i] + right[i];
			}
			return result;
		}
		private static int SumArrayValues(int[] array)
		{
			int result = 0;

			for (int i = 0; i < array.Length; i++)
			{
				result += array[i];
			}
			return result;
		}
		private static int SumCoinValues(int[] coins, int[] array)
		{
			int result = 0;

			for (int i = 0; i < coins.Length && i < array.Length; i++)
			{
				result += coins[i] * array[i];
			}
			return result;
		}
		private static int GetIndexOf(int[] array, int elem)
		{
			int result = -1;

			for (int i = 0; i < array.Length && result == -1; i++)
			{
				if (array[i] == elem)
				{
					result = i;
				}
			}
			return result;
		}
		private static int GetIndexOf(string[] array, string elem)
		{
			int result = -1;

			for (int i = 0; i < array.Length && result == -1; i++)
			{
				if (array[i].Equals(elem))
				{
					result = i;
				}
			}
			return result;
		}
		#endregion Helpers
	}
}
