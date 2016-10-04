using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTemplate_new38
{
    public class MyTreeNodeConverter
    {
        public TreeNode ToTreeNode(string name, object obj)
        {
            if (obj is byte) return IsPrimitive(name, obj);
            if (obj is sbyte) return IsPrimitive(name, obj);
            if (obj is int) return IsPrimitive(name, obj);
            if (obj is uint) return IsPrimitive(name, obj);
            if (obj is short) return IsPrimitive(name, obj);
            if (obj is ushort) return IsPrimitive(name, obj);
            if (obj is long) return IsPrimitive(name, obj);
            if (obj is ulong) return IsPrimitive(name, obj);
            if (obj is float) return IsPrimitive(name, obj);
            if (obj is double) return IsPrimitive(name, obj);
            if (obj is char) return IsPrimitive(name, obj);
            if (obj is bool) return IsPrimitive(name, obj);
            if (obj is string) return IsPrimitive(name, obj);
            if (obj is decimal) return IsPrimitive(name, obj);
            if (obj is IEnumerable) return IsIEnumerable(name, obj);

            return Default(name, obj);
        }

        TreeNode IsPrimitive(string name, object obj)
        {
            return new TreeNode($"{name}: {obj}");
        }

        TreeNode IsIEnumerable(string name, object obj)
        {
            var node = new TreeNode(name);

            var index = 0;
            foreach (var item in obj as IEnumerable)
            {
                var child = ToTreeNode($"[{index}]", item);
                node.Nodes.Add(child);
                index++;
            }

            return node;
        }

        TreeNode Default(string name, object obj)
        {
            var node = new TreeNode(name);
            var type = obj.GetType();

            foreach (var item in type.GetProperties())
            {
                var val = item.GetValue(obj);
                if (val == null) continue;

                var child = ToTreeNode(item.Name, val);
                node.Nodes.Add(child);
            }

            return node;
        }
    }
}