namespace Homework_004
{
	public class Tiger : Predator
	{
		public override int MaxHealth => 500;
		public override string Label => "Тигр";
		public override IEnumerable<string> Ration => ["обезъяна", "кролик"];

		public override Animal Clone()
		{
			return new Tiger();
		}
	}
}
