using System.Linq;
using UnityEditor;
using UnityEngine;

namespace RelationsInspector.Backend
{
    public struct ColorLegendEntry
    {
        public string text;
        public Color color;
    }

    public static class ColorLegendBox
    {
        private static Vector2 padding = new(4, 4);

        public static Vector2 GetSize(string title, ColorLegendEntry[] entries)
        {
            return ColorLegend.GetSize(title, entries) + 2 * padding;   // padding is applied on both sides of the content
        }

        public static void Draw(Rect rect, string title, ColorLegendEntry[] entries)
        {
            GUI.Box(rect, GUIContent.none);
            var contentRect = new Rect(rect.x + padding.x, rect.y + padding.y, rect.width - 2 * padding.x, rect.height - 2 * padding.y);
            ColorLegend.Draw(contentRect, title, entries);
        }
    }

    internal static class ColorLegend
    {
        private static readonly GUIStyle titleStyle = EditorStyles.boldLabel;
        private static readonly GUIStyle entryLabelStyle = GUI.skin.label;

        public static Vector2 GetSize(string title, ColorLegendEntry[] entries)
        {
            Vector2 titleSize = titleStyle.CalcSize(new GUIContent(title));
            var entrySizes = entries.Select(x => entryLabelStyle.CalcSize(new GUIContent(x.text)));
            float maxWidth = Mathf.Max(titleSize.x, entrySizes.Max(s => s.x) + ColorRectWidget.GetSize().x);
            float height = titleSize.y + entrySizes.Sum(s => s.y);
            return new Vector2(maxWidth, height);
        }

        public static void Draw(Rect rect, string title, ColorLegendEntry[] entries)
        {
            var titleContent = new GUIContent(title);
            Vector2 titleSize = titleStyle.CalcSize(titleContent);
            var titleRect = new Rect(rect.x, rect.y, titleSize.x, titleSize.y);
            GUI.Label(titleRect, titleContent, titleStyle);

            var colorRectSize = ColorRectWidget.GetSize();

            for (int i = 0; i < entries.Length; i++)
            {
                var colorRectOrigin = new Vector2(rect.x, rect.y + titleSize.y + colorRectSize.y * i);
                var colorRect = new Rect(colorRectOrigin.x, colorRectOrigin.y, colorRectSize.x, colorRectSize.y);
                ColorRectWidget.Draw(colorRect, entries[i].color);

                var labelOrigin = new Vector2(rect.x + colorRectSize.x, rect.y + titleSize.y + colorRectSize.y * i);
                var labelContent = new GUIContent(entries[i].text);
                var labelSize = entryLabelStyle.CalcSize(labelContent);
                var labelRect = new Rect(labelOrigin.x, labelOrigin.y, labelSize.x, labelSize.y);
                GUI.Label(labelRect, labelContent, entryLabelStyle);
            }
        }
    }

    internal static class ColorRectWidget
    {
        private static Vector2 LayoutSize = new(16, 16);
        private static Vector2 InnerOffset = new(4, 4);
        private static Vector2 innerSize = new(8, 8);

        public static Vector2 GetSize()
        {
            return LayoutSize;
        }

        public static void Draw(Rect layoutSpace, Color color)
        {
            var colorRectOrigin = new Vector2(layoutSpace.x + InnerOffset.x, layoutSpace.y + InnerOffset.y);
            var outlineRectOrigin = new Vector2(colorRectOrigin.x - 1, colorRectOrigin.y - 1);
            EditorGUI.DrawRect(new Rect(outlineRectOrigin.x, outlineRectOrigin.y, innerSize.x + 2, innerSize.y + 2), Color.black);
            EditorGUI.DrawRect(new Rect(colorRectOrigin.x, colorRectOrigin.y, innerSize.x, innerSize.y), color);
        }
    }
}
