namespace Homework_004
{
	public abstract class Thing : IInventory, ILabel
	{
		public abstract int Number { get; set; }
		public abstract string Label { get; }
	}
}
