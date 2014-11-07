using System;
using System.Runtime.Serialization;

namespace NPlant.Core
{
    [Serializable]
    public class JavaNotFoundException : NPlantException
    {
        public JavaNotFoundException()
        {
        }

        public JavaNotFoundException(string message) : base(message)
        {
        }

        public JavaNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected JavaNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}