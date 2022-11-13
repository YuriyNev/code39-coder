namespace Aspose.Coder39.Services;

public class InvalidTextBarException : Exception
{
}

public class EncodeBarException : Exception
{
    public EncodeBarException(string message) : base(message)
    {
    }
}

public class DecodeBarException : Exception
{
    public DecodeBarException(string message) : base(message)
    {
    }
}