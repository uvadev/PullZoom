using System;

namespace PullZoom.Util;

[AttributeUsage(AttributeTargets.Field)]
internal sealed class ZoomApiRepresentationAttribute : Attribute {
    internal string Representation { get; }

    public ZoomApiRepresentationAttribute(string representation) {
        Representation = representation;
    }
}
