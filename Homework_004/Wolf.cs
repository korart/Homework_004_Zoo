namespace Homework_004
{
	public class Wolf : Predator
	{
		public override int MaxHealth => 250;

		public override string Label => "Волк";
		public override IEnumerable<string> Ration => ["кролик"];

		public override Animal Clone()
		{
			return new Wolf();
		}
	}
}
