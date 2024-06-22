namespace Homework_004
{
	public static class ConsoleFromatter
	{
		private static ConsoleColor fgColor = ConsoleColor.White;

		public static void SetColor(ConsoleColor color)
		{
			fgColor = Console.ForegroundColor;
			Console.ForegroundColor = color;
		}

		public static void ResetColor()
		{
			Console.ForegroundColor = fgColor;
		}
	}
}
