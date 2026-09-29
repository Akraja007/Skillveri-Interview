namespace Skillveri
{
    public interface ISensor<T>
    {
        public bool TryDetect(out T result);
    }
}
