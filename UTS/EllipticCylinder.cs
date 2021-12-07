using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace UTS
{
    class EllipticCylinder : Mesh
    {
        public EllipticCylinder()
        {
        }

        public override void createvertices(float x, float y, float z, float length,float tinggi,float tinggi2)
        {
            float _X = x;
            float _Y = y;
            float _Z = z;
            float height = tinggi;
            float _Radius = length;
            Vector3 temp_vector = new Vector3();
            float _pi = 3.14159f;

            int count = 500; 
            int temp_index = -1;
            float increament = _pi / count;


            for (float u = 0; u <= 2 * _pi + increament; u += increament)
            {
                for (float v = 0; v <= height + increament; v += increament)
                {
                    temp_index++;
                    temp_vector.X = _X + _Radius * (float)Math.Cos(u);
                    temp_vector.Y = _Y + _Radius * (float)Math.Sin(u);
                    temp_vector.Z = _Z + _Radius * v;
                    vertices.Add(temp_vector);
                    if (u != 0)
                    {
                        if ((temp_index % count) + 1 < count)
                        {
                            vertexIndices.Add(Convert.ToUInt32(temp_index));
                            vertexIndices.Add(Convert.ToUInt32(temp_index - count));
                            vertexIndices.Add(Convert.ToUInt32(temp_index - count + 1));
                        }
                        if (temp_index % count > 0)
                        {
                            vertexIndices.Add(Convert.ToUInt32(temp_index));
                            vertexIndices.Add(Convert.ToUInt32(temp_index - count));
                            vertexIndices.Add(Convert.ToUInt32(temp_index - 1));
                        }
                    }
                }
                if (u == 0)
                {
                    count = vertices.Count;
                }
            }
        }
    }
}

