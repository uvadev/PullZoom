using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace PullZoom.Api;

[PublicAPI]
public class ZoomApiException : Exception {
    public ZoomApiException() { }
    public ZoomApiException(string message) : base(message) { }
    public ZoomApiException(string message, Exception innerException) : base(message, innerException) { }
    protected ZoomApiException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context) { }
}
