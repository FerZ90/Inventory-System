using System;

public class ReactiveData<T>
{
    private T _value;
    private event Action<T> _observe;

    public T Value { get { return _value; } set { PostValue(value); } }

    public ReactiveData(T item = default(T))
    {
        _value = item; 
    }

    public ReactiveData<T> Observe(Action<T> action)
    {       
        action(_value);
        _observe += action;

        return this;
    }  

    private void PostValue(T value)
    {
        _value = value;
        _observe?.Invoke(_value);
    }

    public void StopObserving(Action<T> action)
    {
        _observe -= action;
    }   
    
}
