using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using System.Globalization;

namespace UTS
{
    class Mesh
    {
        //Vector 3 pastikan menggunakan OpenTK.Mathematics
        //tanpa protected otomatis komputer menganggap sebagai private
        protected List<Vector3d> vertices = new List<Vector3d>();
        protected List<Vector3d> textureVertices = new List<Vector3d>();
        protected List<Vector3d> normals = new List<Vector3d>();
        protected List<uint> vertexIndices = new List<uint>();
        protected int _vertexBufferObject;
        protected int _elementBufferObject;
        protected int _vertexArrayObject;
        protected Shader _shader;
        protected Matrix4 transform;
        protected int counter = 0;
        public List<Mesh> child = new List<Mesh>();
        protected Vector3 _Color;

        public Mesh() { }
        public void setupObject(string vert, string frag)
        {
            //inisialisasi Transformasi
            transform = Matrix4.Identity;
            //inisialisasi buffer
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            //parameter 2 yg kita panggil vertices.Count == array.length
            GL.BufferData<Vector3d>(BufferTarget.ArrayBuffer,
                vertices.Count * Vector3d.SizeInBytes,
                vertices.ToArray(),
                BufferUsageHint.StaticDraw);
            //inisialisasi array
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Double, false, 3 * sizeof(double), 0);
            GL.EnableVertexAttribArray(0);
            //inisialisasi index vertex
            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            //parameter 2 dan 3 perlu dirubah
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                vertexIndices.Count * sizeof(uint),
                vertexIndices.ToArray(), BufferUsageHint.StaticDraw);
            //inisialisasi shader
            _shader = new Shader(vert, frag);
            _shader.Use();
            // scale();
        }
        public virtual void createvertices(float x, float y, float z, float lengthX, float lengthY, float lengthZ) { }
        public virtual void createvertices(List<Vector3d> points)
        {

        }
        public virtual void render(Camera _cam)
        {
            //render itu akan selalu terpanggil setiap frame
            _shader.Use();

            _shader.SetVector3("Color", _Color);
            _shader.SetMatrix4("transform", transform);
            _shader.SetMatrix4("view", _cam.GetViewMatrix());
            _shader.SetMatrix4("projection", _cam.GetProjectionMatrix());
            _shader.SetMatrix4("transform", transform);

            GL.BindVertexArray(_vertexArrayObject);
            //perlu diganti di parameter 2
            GL.DrawElements(PrimitiveType.Triangles,
                vertexIndices.Count,
                DrawElementsType.UnsignedInt, 0);

            foreach (var meshobj in child)
            {
                meshobj.render(_cam);
            }
        }

        public virtual void render(PrimitiveType mode = PrimitiveType.TriangleFan)
        {
            //render itu akan selalu terpanggil setiap frame
            _shader.Use();


            _shader.SetMatrix4("transform", transform);
            GL.BindVertexArray(_vertexArrayObject);
            //perlu diganti di parameter 2
            GL.DrawElements(mode,
                vertexIndices.Count,
                DrawElementsType.UnsignedInt, 0);

            foreach (var meshobj in child)
            {
                meshobj.render(mode);
            }
        }

        public void setColor(float red = 0.0f, float green = 0.0f, float blue = 0.0f)
        {
            _Color = new Vector3(red, green, blue);
        }

        public void rotate(float x, float y, float z)
        {
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(y));
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(x));
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(z));
            foreach (var meshobj in child)
            {
                meshobj.rotate(x, y, z);
            }
        }
        public void scale(float a)
        {
            transform = transform * Matrix4.CreateScale(a);
        }
        public void translate(float x, float y, float z)
        {
            transform = transform * Matrix4.CreateTranslation(x, y, z);
        }
    }
}