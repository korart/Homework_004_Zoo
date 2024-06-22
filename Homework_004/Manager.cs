using System.Collections.Specialized;

namespace Homework_004
{
	public class Manager : ILabel
	{
		private Zoo zoo;
		public string Label => "Менеджер";

		public Manager(Zoo zoo)
		{
			this.zoo = zoo;
		}

		public void Feed(object? sender, EventArgs e)
		{
			Animal animal = (Animal)sender!;
			animal.Health = animal.MaxHealth;
			Console.WriteLine("{0, -20}: Животное накормлено - {1}", this.Label, animal);
		}

		public void AnimalSubscription(object? sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				Animal animal = (Animal)e.NewItems?[0]!;
				animal.AnimalHungry += Feed;
				Console.WriteLine("{0, -20}: Животное под наблюдением - {1}", this.Label, animal);
			}
			if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				Animal animal = (Animal)e.OldItems?[0]!;
				animal.AnimalHungry -= Feed;
				Console.WriteLine("{0, -20}: Животное снято с наблюдения - {1}", this.Label, animal);
			}
		}
	}
}
