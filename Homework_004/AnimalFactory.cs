namespace Homework_004
{
	public class AnimalFactory
	{
		private List<Animal> animalTypes = [];
		private Zoo zoo;

		public AnimalFactory(Zoo zoo, List<Animal> types)
		{
			this.animalTypes = types;
			this.zoo = zoo;
		}

		private Animal ProduceAnimal()
		{
			Animal animal = animalTypes[new Random().Next(animalTypes.Count)].Clone();
			double k = new Random().NextDouble() * (1 - 0.5) + 0.5; // min = 0.5, max = 1.0
			animal.Health = ((int)(k * animal.MaxHealth));
			return animal;
		}

		public void Work()
		{
			while (true)
			{
				zoo.RecivedAnimals.Add(this.ProduceAnimal());
				Thread.Sleep(new Random().Next(3, 5) * 1000);
			}
		}
	}
}
