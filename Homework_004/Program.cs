namespace Homework_004
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Zoo zoo = new Zoo();
			VeterinaryClinic clinic = new VeterinaryClinic(zoo);
			AnimalFactory factory = new(zoo, new List<Animal> { new Wolf(), new Monkey(), new Rabbit(), new Tiger() });
			TransferObserver transferObserver = new TransferObserver(zoo);
			Manager manager = new Manager(zoo);

			zoo.RecivedAnimals.CollectionChanged += zoo.RecivedAnimals_CollectionChanged;
			zoo.RecivedAnimals.CollectionChanged += clinic.CheckAnimalHealth;

			clinic.AcceptAnimalEvent += zoo.AcceptAnimalHandler;
			clinic.RejectAnimalEvent += zoo.RejectAnimalHandler;

			zoo.Animals.CollectionChanged += zoo.Animals_CollectionChanged;
			zoo.Animals.CollectionChanged += manager.AnimalSubscription;

			Thread factoryThread = new Thread(factory.Work);
			factoryThread.Start();

			Thread transferObserverThread = new Thread(transferObserver.Work);
			transferObserverThread.Start();
		}
	}
}
