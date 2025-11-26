namespace EchoTrackV2.Checkers;

public static class ExistenseChecker
{
    public static bool DoesItExists<TRepository>(TRepository repositoryToCheck)
    {
        return (repositoryToCheck != null);
    }
}
