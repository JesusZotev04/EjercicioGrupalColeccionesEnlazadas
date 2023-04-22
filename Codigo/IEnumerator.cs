public interface IEnumerator {
    object Current { get; }
    void Reset();
    bool MoveNext();
}

public interface IEnumerator<T> : IDisposable, IEnumerator {
    T Current { get; }
}