using System.Collections.Generic;
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

            var propertyValue = property.GetValue(this);
            var propertyValueType = propertyValue?.GetType();
            string propertyValueStr;

            if (propertyValue == null) {
                propertyValueStr = "null";
            } else if (typeof(IEnumerable<object>).IsAssignableFrom(propertyValueType)) {
                var list = (IEnumerable<object>) propertyValue;
                propertyValueStr = "[" + string.Join(", ", list) + "]";
            } else {
                propertyValueStr = propertyValue.ToString();
            }
            
            sb.Append("\n")
              .Append($"{property.Name}: {propertyValueStr}".Indent(4));
        }

        sb.Append("\n}");

        return sb.ToString();
    }
}
