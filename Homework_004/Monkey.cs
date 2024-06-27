namespace Homework_004
{
	public class Monkey : Herbo
	{
		public override int MaxHealth => 100;
		public override string Label => "Обезьянка";
		public override int CuteLevel => 7;
		public override Animal Clone()
		{
			return new Monkey();
		}
	}
}
