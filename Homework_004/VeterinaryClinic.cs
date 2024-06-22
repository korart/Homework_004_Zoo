using System.Collections.Specialized;

namespace Homework_004
{
	public class VeterinaryClinic : ILabel
	{
		private Zoo zoo;

		public string Label => "Ветеринарная клиника";

		public event EventHandler? RejectAnimalEvent;
		public event EventHandler? AcceptAnimalEvent;

		public void CheckAnimalHealth(object? sender, NotifyCollectionChangedEventArgs e)
		{
			Animal animal = (Animal)e.NewItems?[0]!;
			if (animal.Health >= 0.75 * animal.MaxHealth)
			{
				Console.WriteLine("{0, -20}: Состояние здоровья хорошее, рекомендуется к приему.", this.Label);
				AcceptAnimalEvent?.Invoke(this, new VeterinaryClinicEventArgs(animal));
			}
			else
			{
				Console.WriteLine("{0, -20}: Состояние здоровья плохое, рекомендуется к возврату", this.Label);
				RejectAnimalEvent?.Invoke(this, new VeterinaryClinicEventArgs(animal));
			}
		}

		public VeterinaryClinic(Zoo zoo)
		{
			this.zoo = zoo;
		}
	}
}
