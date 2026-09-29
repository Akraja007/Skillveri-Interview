namespace Skillveri
{
    interface ISensor<T>
    {
        public bool TryDetect(out T result);
    }
}
