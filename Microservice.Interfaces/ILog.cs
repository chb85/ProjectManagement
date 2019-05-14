using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Interfaces
{
    public interface ILog
    {
        ILog Configure(string configurationFile);

        void Debug<TYPE>(string message);

        void Error<TYPE>(string message);

        void Info<TYPE>(string message);

        void Fatal<TYPE>(string message);
    }
}
