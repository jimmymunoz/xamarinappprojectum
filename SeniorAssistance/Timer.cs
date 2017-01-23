namespace System.Threading
{
	class Timer
	{
		Func<object, object> p1;
		object p2;
		int totalMilliseconds;
		int v;

		public Timer(Func<object, object> p1, object p2, int v, int totalMilliseconds)
		{
			this.p1 = p1;
			this.p2 = p2;
			this.v = v;
			this.totalMilliseconds = totalMilliseconds;
		}
	}
}