using UnityEngine;

namespace HelperFuncRepository
{
    public class HelperFunc : MonoBehaviour
    {
        public static Vector2 FirstBezier( Vector2 p0, Vector2 p1, float t )
        {
            return Vector3.Lerp( p0, p1, t );
        }
        public static Vector2 SecondBezier( Vector2 p0, Vector2 p1, Vector2 p2, float t )
        {
            Vector2 m0 = FirstBezier( p0, p1, t );
            Vector2 m1 = FirstBezier( p1, p2, t );
            return FirstBezier( m0, m1, t );
        }
    }
}