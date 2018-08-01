using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace MgWheels
{
    public interface IPrimitiveBatcher
    {
        void DrawLine(Vector2 p1, Vector2 p2, Color color, float lineWidth);

        void DrawLineStrip(IEnumerable<Vector2> points, Color color, float lineWidth);

        void DrawRect(Rectangle rect, Color color, float lineWidth);

        void DrawRoundedRect(Rectangle rectangle, float radius, int segments, Color color, int lineWidth);

        void DrawRoundedRect(Rectangle rectangle,
                             float radiusTl, int segmentsTl,
                             float radiusTr, int segmentsTr,
                             float radiusBr, int segmentsBr,
                             float radiusBl, int segmentsBl,
                             Color color, int lineWidth = 1);

        void FillRect(Rectangle rect, Color c);

        void FillRoundedRect(Rectangle rectangle, float radius, int segments, Color color);

        void DrawCircle(Vector2 center, float radius, Color color, int sides, float lineWidth);

        void DrawCircleSegment(Vector2 center, float radius, float start, float end, Color color, int sides, float lineWidth);

        void FillCircle(Vector2 center, float radius, Color color, int sides);

        void FillCircleSegment(Vector2 center, float radius, float start, float end, Color color, int sides);

        void Clear();

        void Flush();
    }
}