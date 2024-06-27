using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Xml.Serialization;

namespace Homework_004
{
	public class Zoo : ILabel
	{
		private static int animalNumber = 0;

		public readonly int MaxAnimalCount = 5;

		public ObservableCollection<Animal> RecivedAnimals = [];
		public ObservableCollection<Animal> Animals = [];

		public string Label => "Зоопарк";

		public void RecivedAnimals_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			Console.WriteLine();
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				Animal animal = (Animal)e.NewItems?[0]!;
				Console.WriteLine("{0, -20}: Доставлено новое животное - {1}", this.Label, animal);
			}
		}

		public void Animals_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				Animal animal = (Animal)e.NewItems?[0]!;
				ActivateAnimal(animal);
				Console.WriteLine("{0, -20}: Принято новое животное - {1}", this.Label, animal);
			}
			if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				Animal animal = (Animal)e.OldItems?[0]!;
				Console.WriteLine("{0, -20}: Животное передано в другой зоопарк - {1}", this.Label, animal);
			}
		}

		public void AcceptAnimalHandler(object? sender, EventArgs e)
		{
			if (Animals.Count < MaxAnimalCount)
			{
				Animals.Add(((VeterinaryClinicEventArgs)e).Animal);
			}
			else
			{
				Console.WriteLine("{0, -20}: К сожалению в зоопарке больше нет мест", this.Label);
				Console.WriteLine("{0, -20}: Животное возвращено поставщику - {1}", this.Label, ((VeterinaryClinicEventArgs)e).Animal);
			}
		}

		public void RejectAnimalHandler(object? sender, EventArgs e)
		{
			Console.WriteLine("{0, -20}: Животное возвращено поставщику - {1}", this.Label, ((VeterinaryClinicEventArgs)e).Animal);
		}

		private void ActivateAnimal(Animal animal)
		{
			animalNumber++;
			animal.Number = animalNumber;
			animal.InZoo = true;

			Thread animalThread = new Thread(animal.Live);
			animalThread.Start();
		}
	}
}
