﻿namespace UTAF.Core.Logger
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogError(string message);
    }
}
