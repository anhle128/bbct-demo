using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.MMO.Concepts
{
    public struct Vector2D
    {
        //
        // Static Fields
        //
        public const float kEpsilon = 1E-05f;

        //
        // Fields
        //
        public float y;

        public float x;

        //
        // Static Properties
        //
        public static Vector2D one
        {
            get
            {
                return new Vector2D(1f, 1f);
            }
        }

        public static Vector2D right
        {
            get
            {
                return new Vector2D(1f, 0f);
            }
        }

        public static Vector2D up
        {
            get
            {
                return new Vector2D(0f, 1f);
            }
        }

        public static Vector2D zero
        {
            get
            {
                return new Vector2D(0f, 0f);
            }
        }

        //
        // Properties
        //
        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt(this.x * this.x + this.y * this.y);
            }
        }

        public Vector2D normalized
        {
            get
            {
                Vector2D result = new Vector2D(this.x, this.y);
                result.Normalize();
                return result;
            }
        }

        public float sqrMagnitude
        {
            get
            {
                return this.x * this.x + this.y * this.y;
            }
        }

        //
        // Constructors
        //
        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }


        public static Vector2D ClampMagnitude(Vector2D vector, float maxLength)
        {
            if (vector.sqrMagnitude > maxLength * maxLength)
            {
                return vector.normalized * maxLength;
            }
            return vector;
        }

        public static float Distance(Vector2D a, Vector2D b)
        {
            return (a - b).magnitude;
        }

        public static float Dot(Vector2D lhs, Vector2D rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y;
        }

        public static Vector2D Max(Vector2D lhs, Vector2D rhs)
        {
            return new Vector2D(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y));
        }

        public static Vector2D Min(Vector2D lhs, Vector2D rhs)
        {
            return new Vector2D(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y));
        }

        public static Vector2D MoveTowards(Vector2D current, Vector2D target, float maxDistanceDelta)
        {
            Vector2D a = target - current;
            float magnitude = a.magnitude;
            if (magnitude <= maxDistanceDelta || magnitude == 0f)
            {
                return target;
            }
            return current + a / magnitude * maxDistanceDelta;
        }

        public static Vector2D Scale(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.x * b.x, a.y * b.y);
        }

        public static float SqrMagnitude(Vector2D a)
        {
            return a.x * a.x + a.y * a.y;
        }

        //
        // Methods
        //
        public override bool Equals(object other)
        {
            if (!(other is Vector2D))
            {
                return false;
            }
            Vector2D vector = (Vector2D)other;
            return this.x.Equals(vector.x) && this.y.Equals(vector.y);
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode() << 2;
        }

        public void Normalize()
        {
            float magnitude = this.magnitude;
            if (magnitude > 1E-05f)
            {
                this /= magnitude;
            }
            else
            {
                this = Vector2D.zero;
            }
        }

        public void Scale(Vector2D scale)
        {
            this.x *= scale.x;
            this.y *= scale.y;
        }

        public void Set(float new_x, float new_y)
        {
            this.x = new_x;
            this.y = new_y;
        }

        public float SqrMagnitude()
        {
            return this.x * this.x + this.y * this.y;
        }

        public override string ToString()
        {
            return "{" + x + "," + y + "}";
        }

        //
        // Operators
        //
        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.x + b.x, a.y + b.y);
        }

        public static Vector2D operator /(Vector2D a, float d)
        {
            return new Vector2D(a.x / d, a.y / d);
        }

        public static bool operator ==(Vector2D lhs, Vector2D rhs)
        {
            return Vector2D.SqrMagnitude(lhs - rhs) < 9.99999944E-11f;
        }

        public static bool operator !=(Vector2D lhs, Vector2D rhs)
        {
            return Vector2D.SqrMagnitude(lhs - rhs) >= 9.99999944E-11f;
        }

        public static Vector2D operator *(Vector2D a, float d)
        {
            return new Vector2D(a.x * d, a.y * d);
        }

        public static Vector2D operator *(float d, Vector2D a)
        {
            return new Vector2D(a.x * d, a.y * d);
        }

        public static Vector2D operator -(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.x - b.x, a.y - b.y);
        }

        public static Vector2D operator -(Vector2D a)
        {
            return new Vector2D(-a.x, -a.y);
        }
    }
}
