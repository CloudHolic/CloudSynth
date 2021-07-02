using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace CloudSynth.Core.Utils
{
    public static class UiHelper
    {
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null)
                yield break;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is T foundChild)
                    yield return foundChild;

                foreach (var grandChild in FindVisualChildren<T>(child))
                    yield return grandChild;
            }
        }
    }
}
