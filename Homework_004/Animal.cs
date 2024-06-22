namespace Homework_004
{
	public abstract class Animal : IAlive, IInventory, ILabel
	{
		private int health;

		public abstract string Label { get; }

		public abstract int MaxHealth { get; }

		public abstract Animal Clone();

		public event EventHandler? AnimalHungry;

		public int Health
		{
			get
			{
				return health;
			}
			set
			{
				if (value > MaxHealth)
				{
					health = MaxHealth;
				}
				else
				{
					health = value;
				}
			}
		}

		public int Number { get; set; }

		public int HealthStatus => (int)(Health * 100 / MaxHealth);

		public bool InZoo { get; set; } = false;

		public void Live()
		{
			while (InZoo)
			{
				Thread.Sleep(1000);
				Health -= MaxHealth / 10;

				if (Health < 0)
				{
					Console.WriteLine("{0, -20}: Животное голодное - {1}", this.Label, this);
					AnimalHungry?.Invoke(this, new EventArgs());
				}
			}
		}

		public override string ToString()
		{
			return String.Format("{0} (Здоровье: {1}%, No:{2})", Label, HealthStatus, Number == 0 ? "не задан" : Number);
		}
	}
}
