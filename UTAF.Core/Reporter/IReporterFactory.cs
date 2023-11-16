namespace UTAF.Core.Reporter
{
    public interface IReporterFactory
    {
        IReporter Reporter { get; }
    }
}