namespace BlazorUtils.Interfaces.EventArgs
{
    public sealed class SelectionChangedEventArgs<T> : LMTEventArgs
    {
        public SelectionChangedEventArgs(int cur, int next, T data)
        {
            Cur = cur;
            Next = next;
            Data = data;
        }

        public int Cur { get; }
        public int Next { get; }
        public T Data { get; }
    }
}
