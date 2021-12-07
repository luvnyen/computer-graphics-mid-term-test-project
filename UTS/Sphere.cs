using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace UTS
{
    class Sphere : Mesh
    {
        public Sphere()
        {
        }

        public override void createvertices(float x, float y, float z, float lengthX, float lengthY, float lengthZ)
        {
            float _X = x;
            float _Y = y;
            float _Z = z;

            float _RadiusX = lengthX;
            float _RadiusY = lengthY;
            float _RadiusZ = lengthZ;
            Vector3 temp_vector = new Vector3();
            float _pi = 3.14159f;
            int count = 100;
            int temp_index = -1;
            float increament = 2 * _pi / count;
            for (float u = -_pi; u <= _pi + increament; u += increament)
            {
                for (float v = -_pi / 2; v <= _pi / 2 + increament; v += increament)
                {
                    temp_index++;
                    temp_vector.X = _X + _RadiusX * (float)Math.Cos(v) * (float)Math.Cos(u);
                    temp_vector.Y = _Y + _RadiusY * (float)Math.Cos(v) * (float)Math.Sin(u);
                    temp_vector.Z = _Z + _RadiusZ * (float)Math.Sin(v);
                    vertices.Add(temp_vector);
                    if (u != -_pi)
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
                if(u == -_pi)
                {
                    count = vertices.Count;
                    Console.WriteLine(count);
                }
            }        
        }
    }
}
