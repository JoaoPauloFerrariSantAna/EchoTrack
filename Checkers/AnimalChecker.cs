namespace EchoTrackV2.Checkers;

public static class AnimalChecker
{
    public static bool DoesItExists<TRepository>(TRepository repositoryToCheck)
    {
        return (repositoryToCheck != null);
    }
}
