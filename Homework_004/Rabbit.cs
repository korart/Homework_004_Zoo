namespace Homework_004
{
	public class Rabbit : Herbo
	{
		public override int MaxHealth => 50;
		public override string Label => "Кролик";
		public override int CuteLevel => 10;
		public override Animal Clone()
		{
			return new Rabbit();
		}

	}
}
