namespace Homework_004
{
	public abstract class Predator : Animal
	{
		public abstract IEnumerable<string> Ration { get; }
	}
}
