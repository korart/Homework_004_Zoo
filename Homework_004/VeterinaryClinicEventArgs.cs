namespace Homework_004
{
	public class VeterinaryClinicEventArgs : EventArgs
	{
		public Animal Animal { get; }

		public VeterinaryClinicEventArgs(Animal animal)
		{
			Animal = animal;
		}
	}
}
