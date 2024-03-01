namespace Domain;

public class Result<T>
{
    public T Value { get; private set; }
    public bool IsSuccess { get; private set; }
    public string ErrorMessage { get; private set; }

    public Result(T value)
    {
        Value = value;
        IsSuccess = true;
    }

    public Result(string errorMessage)
    {
        ErrorMessage = errorMessage;
        IsSuccess = false;
    }
}
