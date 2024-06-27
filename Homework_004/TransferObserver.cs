namespace Homework_004
{
	public class TransferObserver : ILabel
	{
		private Zoo zoo;
		public string Label => "Трансфер";

		public TransferObserver(Zoo zoo)
		{
			this.zoo = zoo;
		}

		public void Work()
		{
			while (true)
			{
				Thread.Sleep(30000);

				if (zoo.Animals.Count == zoo.MaxAnimalCount)
				{
					int min = zoo.Animals.Min(animal => animal.HealthStatus);
					Animal animalToTranser = zoo.Animals.FirstOrDefault(animal => animal.HealthStatus == min)!;
					if (animalToTranser != null)
					{
						Console.WriteLine();
						Console.WriteLine("{0, -20}: Найдено животное для трансфера - {1}", this.Label, animalToTranser);
						animalToTranser.InZoo = false;
						zoo.Animals.Remove(animalToTranser);
					}
				}
				else
				{
					Console.WriteLine();
					Console.WriteLine("{0, -20}: Нет животных для трансфера", this.Label);
				}
			}
		}
	}
}
