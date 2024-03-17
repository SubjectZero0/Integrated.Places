namespace Common
{
    public static class ArrayEmpty<TClass> where TClass : class
    {
        public static readonly TClass[] Instance = [];
    }
}