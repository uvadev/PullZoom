using System.ComponentModel;
using System.Text;
using PullZoom.Util;

namespace PullZoom.Structures;

public abstract class ZoomStructure {
    public override string ToString() {
        var properties = TypeDescriptor.GetProperties(this);
        var className = GetType().Name;
        
        var sb = new StringBuilder($"{className} {{");

        for (var i = 0; i < properties.Count; i++) {
            var property = properties[i];
            
            if (i > 0) {
                sb.Append(",");
            }
            
            sb.Append("\n")
              .Append($"{property.Name}: {property.GetValue(this)?.ToString() ?? "null"}".Indent(4));
        }

        sb.Append("\n}");

        return sb.ToString();
    }
}
