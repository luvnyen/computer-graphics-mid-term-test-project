using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Common;
using LearnOpenTK.Common;
using OpenTK.Mathematics;

namespace UTS
{
    class Curve : Mesh
    {
        List<Vector3d> temporary_bezier = new List<Vector3d>();

        public Curve()
        {
        }
        private double Comb(int n, int r)
        {
            double nfact = 1.0;
            double rfact = 1.0;
            double nrfact = 1.0;

            for (int i = 1; i <= n; i++)
            {
                nfact *= i;
            }
            for (int i = 1; i <= r; i++)
            {
                rfact *= i;
            }
            for (int i = 1; i <= (n - r); i++)
            {
                nrfact *= i;
            }
            return nfact / (rfact * nrfact);
        }
        Vector3d setBezier(List<Vector3d> p, int count, float t)
        {
            Vector3d result;
            double[] coef = new double[count];
            for (int i = 0; i < count; i++)
            {
                coef[i] = Comb(count - 1, i) * (float)Math.Pow((1 - t), count - i - 1) * (float)Math.Pow(t, i);
            }
            result.X = 0.0;
            result.Y = 0.0;
            result.Z = 0.0;
            for (int i = 0; i < count; i++)
            {
                result.X += coef[i] * p[i].X;
                result.Y += coef[i] * p[i].Y;
                result.Y += coef[i] * p[i].Z;
            }
            return result;
        }
        public override void createvertices(List<Vector3d> points)
        {
            temporary_bezier = points;

            vertices.Add(points[0]);

            for (float t = 0.0f; t <= 1.0f; t += 0.01f)
            {
                Vector3d P = setBezier(temporary_bezier, temporary_bezier.Count, t);
                vertices.Add(P);
            }
        }

        public void render(Camera _cam, PrimitiveType mode = PrimitiveType.TriangleFan)
        {
            _shader.Use();
            _shader.SetVector3("Color", _Color);
            _shader.SetMatrix4("transform", transform);
            _shader.SetMatrix4("view", _cam.GetViewMatrix());
            _shader.SetMatrix4("projection", _cam.GetProjectionMatrix());

            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawArrays(PrimitiveType.LineStrip, 0, vertices.Count);

            foreach (var meshobj in child)
            {
                meshobj.render(mode);
            }
        }
    }
}