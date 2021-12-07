using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace UTS
{
    class Window : GameWindow
    {
        protected List<Vector3d> p1 = new List<Vector3d>();
        protected List<Vector3d> p2 = new List<Vector3d>();
        protected List<Vector3d> coord = new List<Vector3d>();
        protected List<Vector3d> c1 = new List<Vector3d>();
        protected List<Vector3d> c2 = new List<Vector3d>();

        string shader_vert = "../../../Shaders/shader.vert";
        string shader_frag = "../../../Shaders/shader.frag";

        Camera _camera;
        bool _firstMove = true;
        Vector2 _lastPos;
        private float scale = 1.0f;

        List<Mesh> calvert = new List<Mesh>();
        List<Mesh> alas = new List<Mesh>();
        List<Mesh> jovian = new List<Mesh>();
        List<Mesh> liauw = new List<Mesh>();
        List<Mesh> atas = new List<Mesh>();
        List<Mesh> t = new List<Mesh>();

        // List<Vector3d> positions = new List<Vector3d>();
        List<Curve> liauw_curve = new List<Curve>();
        List<Curve> calvert_curve = new List<Curve>();
        List<Curve> jovian_curve = new List<Curve>();

        Mesh temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, temp13, temp14, temp15, temp16;
        Mesh temp17, temp18, temp19, temp20, temp21, temp22, temp23, temp24, temp25, temp26, temp27, temp28, temp29, temp30, temp31;
        Mesh temp;
        Mesh r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16;
        Mesh lantai;
        Mesh t1, t2, t3, t4, t5, t6, t7, t8;
        Mesh wall1, wall2, wall3, wall4, wall5, wall6, wall7, wall8, wall9;
        Mesh tetes;
        Mesh cloud1, cloud2, cloud3, cloud4, cloud5, cloud6, cloud7, cloud8, cloud9, cloud10, cloud11, cloud12;

        float x = 4, y = -2;
        private int count = 0;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings) { }

        protected override void OnLoad()
        {
            _camera = new Camera(Vector3.UnitZ * 3, Size.X / (float)Size.Y);
            CursorGrabbed = true;

            GL.ClearColor(0.968f, 0.913f, 0.580f, 0);
            {
                //    positions.Add(new Vector3d(0.35, -0.2, 0.0));
                //    positions.Add(new Vector3d(0.2, 0.05, 0.0));
                //    positions.Add(new Vector3d(0.0, 0.4, 0.0));
                //    positions.Add(new Vector3d(-0.2, 0.05, 0.0));
                //    positions.Add(new Vector3d(-0.35, -0.2, 0.0));

                //    float recolor = 0;
                //    float move = 0;
                //    for (int i = 0; i < 20; i++)
                //    {

                //        Curve Kurva = new Curve();
                //        Kurva.createvertices(positions);
                //        Kurva.setupObject(shader_vert, shader_frag);
                //        Kurva.rotate(0.0f, 0.0f, 0.0f);
                //        if (i < 5)
                //            Kurva.setColor(1.0f - recolor, 0.0f + recolor, 0.0f);
                //        else
                //        {
                //            if (i == 6)
                //                Kurva.setColor(0.0f, 1.0f - recolor, 0.0f + recolor);
                //            else if (i == 7)
                //                Kurva.setColor(0.5f, 0.0f, 0.5f + recolor);
                //            else
                //                Kurva.setColor(0.5f, 0.5f, 0.5f);
                //        }
                //        Kurva.translate(-2.9f, 0.0f + move, -2.3f);
                //        move += 0.005f;
                //        recolor += 0.25f;
                //        Indikator.Add(Kurva);
                //    }

                tetes = new Ellipsoid();
                tetes.createvertices(-0.8f + y, 0.25f, 0.0f, 0.03f, 0.1f, 0.03f);
                tetes.setupObject(shader_vert, shader_frag);
                tetes.setColor(1f, 1f, 1f);
                t.Add(tetes);
                tetes = new Ellipsoid();
                tetes.createvertices(-0.95f + y, 0.15f, 0.0f, 0.03f, 0.1f, 0.03f);
                tetes.setupObject(shader_vert, shader_frag);
                tetes.setColor(1f, 1f, 1f);
                t.Add(tetes);
                tetes = new Ellipsoid();
                tetes.createvertices(-1.25f + y, 0.25f, 0.0f, 0.03f, 0.1f, 0.03f);
                tetes.setupObject(shader_vert, shader_frag);
                tetes.setColor(1f, 1f, 1f);
                t.Add(tetes);
                tetes = new Ellipsoid();
                tetes.createvertices(-1.1f + y, 0.15f, 0.0f, 0.03f, 0.1f, 0.03f);
                tetes.setupObject(shader_vert, shader_frag);
                tetes.setColor(1f, 1f, 1f);
                t.Add(tetes);
            }
            {
                //rumput
                r12 = new Cone();
                r12.createvertices(9f, 1f, 0f, 0.5f, 0.3f, 1f);
                r12.setupObject(shader_vert, shader_frag);
                r12.setColor(0.129f, 0.709f, 0.137f);
                r12.rotate(90f, 0f, 0f);
                alas.Add(r12);
                r9 = new Cone();
                r9.createvertices(7.5f, 1.5f, 0f, 0.5f, 0.3f, 1f);
                r9.setupObject(shader_vert, shader_frag);
                r9.setColor(0.129f, 0.709f, 0.137f);
                r9.rotate(90f, 0f, 0f);
                alas.Add(r9);
                r8 = new Cone();
                r8.createvertices(6f, 2f, 0f, 0.5f, 0.3f, 1f);
                r8.setupObject(shader_vert, shader_frag);
                r8.setColor(0.129f, 0.709f, 0.137f);
                r8.rotate(90f, 0f, 0f);
                alas.Add(r8);
                r7 = new Cone();
                r7.createvertices(4.5f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r7.setupObject(shader_vert, shader_frag);
                r7.setColor(0.129f, 0.709f, 0.137f);
                r7.rotate(90f, 0f, 0f);
                alas.Add(r7);
                r6 = new Cone();
                r6.createvertices(3f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r6.setupObject(shader_vert, shader_frag);
                r6.setColor(0.129f, 0.709f, 0.137f);
                r6.rotate(90f, 0f, 0f);
                alas.Add(r6);
                r5 = new Cone();
                r5.createvertices(1.5f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r5.setupObject(shader_vert, shader_frag);
                r5.setColor(0.129f, 0.709f, 0.137f);
                r5.rotate(90f, 0f, 0f);
                alas.Add(r5);
                r4 = new Cone();
                r4.createvertices(0f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r4.setupObject(shader_vert, shader_frag);
                r4.setColor(0.129f, 0.709f, 0.137f);
                r4.rotate(90f, 0f, 0f);
                alas.Add(r4);
                r1 = new Cone();
                r1.createvertices(-1.5f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r1.setupObject(shader_vert, shader_frag);
                r1.setColor(0.129f, 0.709f, 0.137f);
                r1.rotate(90f, 0f, 0f);
                alas.Add(r1);
                r2 = new Cone();
                r2.createvertices(-3f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r2.setupObject(shader_vert, shader_frag);
                r2.setColor(0.129f, 0.709f, 0.137f);
                r2.rotate(90f, 0f, 0f);
                alas.Add(r2);
                r3 = new Cone();
                r3.createvertices(-4.5f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r3.setupObject(shader_vert, shader_frag);
                r3.setColor(0.129f, 0.709f, 0.137f);
                r3.rotate(90f, 0f, 0f);
                alas.Add(r3);
                r10 = new Cone();
                r10.createvertices(-6f, 2f, 0f, 0.5f, 0.3f, 1f);
                r10.setupObject(shader_vert, shader_frag);
                r10.setColor(0.129f, 0.709f, 0.137f);
                r10.rotate(90f, 0f, 0f);
                alas.Add(r10);
                r11 = new Cone();
                r11.createvertices(-7.5f, 1.5f, 0f, 0.5f, 0.3f, 1f);
                r11.setupObject(shader_vert, shader_frag);
                r11.setColor(0.129f, 0.709f, 0.137f);
                r11.rotate(90f, 0f, 0f);
                alas.Add(r11);
                r13 = new Cone();
                r13.createvertices(-7.5f, 1.5f, 0f, 0.5f, 0.3f, 1f);
                r13.setupObject(shader_vert, shader_frag);
                r13.setColor(0.129f, 0.709f, 0.137f);
                r13.rotate(90f, 0f, 0f);
                alas.Add(r13);
                r14 = new Cone();
                r14.createvertices(-9f, 1f, 0f, 0.5f, 0.3f, 1f);
                r14.setupObject(shader_vert, shader_frag);
                r14.setColor(0.129f, 0.709f, 0.137f);
                r14.rotate(90f, 0f, 0f);
                alas.Add(r14);

                t1 = new EllipticCylinder();
                t1.createvertices(9.1f, -0.3f, -1.5f, 0.5f, 3f, 1f);
                t1.setupObject(shader_vert, shader_frag);
                t1.setColor(0.741f, 0.4f, 0.141f);
                t1.rotate(90f, 0f, 0f);
                alas.Add(t1);
                t2 = new Cone();
                t2.createvertices(9.1f, -0.3f, 1.3f, 1.5f, 1.5f, 1f);
                t2.setupObject(shader_vert, shader_frag);
                t2.setColor(0.054f, 0.529f, 0.062f);
                t2.rotate(90f, 0f, 0f);
                alas.Add(t2);
                t3 = new Cone();
                t3.createvertices(9.1f, -0.3f, 2.3f, 1.3f, 1f, 1f);
                t3.setupObject(shader_vert, shader_frag);
                t3.setColor(0.054f, 0.529f, 0.062f);
                t3.rotate(90f, 0f, 0f);
                alas.Add(t3);
                t4 = new Cone();
                t4.createvertices(9.1f, -0.3f, 3.3f, 0.7f, 0.7f, 0.9f);
                t4.setupObject(shader_vert, shader_frag);
                t4.setColor(0.054f, 0.529f, 0.062f);
                t4.rotate(90f, 0f, 0f);
                alas.Add(t4);

                t5 = new EllipticCylinder();
                t5.createvertices(-9.1f, -0.3f, -1.5f, 0.5f, 3f, 1f);
                t5.setupObject(shader_vert, shader_frag);
                t5.setColor(0.741f, 0.4f, 0.141f);
                t5.rotate(90f, 0f, 0f);
                alas.Add(t5);
                t6 = new Cone();
                t6.createvertices(-9.1f, -0.3f, 1.3f, 1.5f, 1.5f, 1f);
                t6.setupObject(shader_vert, shader_frag);
                t6.setColor(0.054f, 0.529f, 0.062f);
                t6.rotate(90f, 0f, 0f);
                alas.Add(t6);
                t7 = new Cone();
                t7.createvertices(-9.1f, -0.3f, 2.3f, 1.3f, 1f, 1f);
                t7.setupObject(shader_vert, shader_frag);
                t7.setColor(0.054f, 0.529f, 0.062f);
                t7.rotate(90f, 0f, 0f);
                alas.Add(t7);
                t8 = new Cone();
                t8.createvertices(-9.1f, -0.3f, 3.3f, 0.7f, 0.7f, 0.9f);
                t8.setupObject(shader_vert, shader_frag);
                t8.setColor(0.054f, 0.529f, 0.062f);
                t8.rotate(90f, 0f, 0f);
                alas.Add(t8);

                //Wall
                wall1 = new Sphere();
                wall1.createvertices(0f, 0f, 5f, 1f, 1f, 1f);
                wall1.setupObject(shader_vert, shader_frag);
                wall1.setColor(1f, 0.737f, 0.121f);
                wall1.rotate(90f, 0f, 0f);
                alas.Add(wall1);
                wall2 = new Cone();
                wall2.createvertices(0f, 0f, 6.8f, 0.05f, 0.05f, 0.5f);
                wall2.setupObject(shader_vert, shader_frag);
                wall2.setColor(1f, 0.8f, 0.2f);
                wall2.rotate(90f, 0f, 0f);
                alas.Add(wall2);
                wall3 = new Cone();
                wall3.createvertices(0f, -5f, 1.8f, 0.05f, 0.05f, 0.5f);
                wall3.setupObject(shader_vert, shader_frag);
                wall3.setColor(1f, 0.8f, 0.2f);
                wall3.rotate(0f, 90f, 0f);
                alas.Add(wall3);
                wall4 = new Cone();
                wall4.createvertices(0f, -5f, 1.8f, 0.05f, 0.05f, 0.5f);
                wall4.setupObject(shader_vert, shader_frag);
                wall4.setColor(1f, 0.8f, 0.2f);
                wall4.rotate(0f, -90f, 0f);
                alas.Add(wall4);
                wall9 = new Cone();
                wall9.createvertices(0f, 0f, -3.2f, 0.05f, 0.05f, 0.5f);
                wall9.setupObject(shader_vert, shader_frag);
                wall9.setColor(1f, 0.8f, 0.2f);
                wall9.rotate(270f, 0f, 0f);
                alas.Add(wall9);

                wall5 = new Cone();
                wall5.createvertices(3.4f, 0f, 5.3f, 0.05f, 0.05f, 0.5f);
                wall5.setupObject(shader_vert, shader_frag);
                wall5.setColor(1f, 0.8f, 0.2f);
                wall5.rotate(90f, -45f, 0f);
                alas.Add(wall5);

                wall6 = new Cone();
                wall6.createvertices(-3.4f, 0f, 5.3f, 0.05f, 0.05f, 0.5f);
                wall6.setupObject(shader_vert, shader_frag);
                wall6.setColor(1f, 0.8f, 0.2f);
                wall6.rotate(90f, 45f, 0f);
                alas.Add(wall6);

                wall7 = new Cone();
                wall7.createvertices(-3.5f, 0f, -1.75f, 0.05f, 0.05f, 0.5f);// -3.5 -1.3
                wall7.setupObject(shader_vert, shader_frag);
                wall7.setColor(1f, 0.8f, 0.2f);
                wall7.rotate(90f, 135f, 0f);
                alas.Add(wall7);

                wall8 = new Cone();
                wall8.createvertices(3.5f, 0f, -1.75f, 0.05f, 0.05f, 0.5f);// -3.5 -1.3
                wall8.setupObject(shader_vert, shader_frag);
                wall8.setColor(1f, 0.8f, 0.2f);
                wall8.rotate(90f, -135f, 0f);
                alas.Add(wall8);
            }
            {
                temp = new Curve();
                List<Vector3d> positions = new List<Vector3d>();
                positions.Add(new Vector3d(scale * -0.2, scale * 0.05, 0.0));
                positions.Add(new Vector3d(scale * -0.15, scale * -0.2, 0.0));
                positions.Add(new Vector3d(scale * 0.0, scale * -0.3, 0.0));
                positions.Add(new Vector3d(scale * 0.15, scale * -0.2, 0.0));
                positions.Add(new Vector3d(scale * 0.2, scale * 0.05, 0.0));
                temp.createvertices(positions);
                temp.setupObject(shader_vert, shader_frag);
                temp.rotate(10.0f, 0.0f, 0.0f);
                temp.translate(0.0f * scale, -0.0f * scale, -0.275f * scale);
            }

            {//batang
                temp = new EllipticCylinder();
                temp.createvertices(6.25f, 0.0f, 0.975f, 0.35f, 1.5f, 50f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.4f, 0.0f);
                temp.rotate(90f, 0f, 0f);
                atas.Add(temp);
                temp = new EllipticCylinder();
                //kanankiri, majumundur ,atasbawah
                temp.createvertices(5.965f, 0.0f, 3.0f, 0.075f, 3.0f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.5f, 0.0f);
                temp.rotate(-90f, 37.5f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                //kanankiri, majumundur ,atasbawah
                temp.createvertices(5.965f, 0.0f, 3.2f, 0.075f, 0.075f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.5f, 0.0f);
                temp.rotate(-90f, 37.5f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                //kanankiri, majumundur ,atasbawah
                temp.createvertices(5.965f, 0.0f, 3.21f, 0.055f, 0.055f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.6f, 0.0f);
                temp.rotate(-90f, 37.5f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                //kanankiri, majumundur ,atasbawah
                temp.createvertices(5.965f, 0.0f, 3.22f, 0.025f, 0.025f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.7f, 0.0f);
                temp.rotate(-90f, 37.5f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                temp.createvertices(6.25f, 0.0f, 0.975f, 0.35f, 0.35f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.4f, 0.0f);
                temp.rotate(90f, 0f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                temp.createvertices(6.25f, 0.0f, 0.974f, 0.25f, 0.25f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.5f, 0.0f);
                temp.rotate(90f, 0f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                temp.createvertices(6.25f, 0.0f, 0.973f, 0.15f, 0.15f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.6f, 0.0f);
                temp.rotate(90f, 0f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                temp.createvertices(6.25f, 0.0f, 0.972f, 0.05f, 0.05f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.7f, 0.0f);
                temp.rotate(90f, 0f, 0f);
                atas.Add(temp);

                temp = new EllipticCylinder();
                temp.createvertices(-6.25f, 0.0f, 0.975f, 0.35f, 1.5f, 50f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.4f, 0.0f);
                temp.rotate(90f, 0f, 0f);
                atas.Add(temp);
                temp = new EllipticCylinder();
                //kanankiri, majumundur ,atasbawah
                temp.createvertices(-3.965f, 0.0f, -4.6f, 0.075f, 3.0f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.5f, 0.0f);
                temp.rotate(-90f, 37.5f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                //kanankiri, majumundur ,atasbawah
                temp.createvertices(-3.965f, 0.0f, -4.4f, 0.075f, 0.075f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.5f, 0.0f);
                temp.rotate(-90f, 37.5f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                //kanankiri, majumundur ,atasbawah
                temp.createvertices(-3.965f, 0.0f, -4.39f, 0.055f, 0.055f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.6f, 0.0f);
                temp.rotate(-90f, 37.5f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                //kanankiri, majumundur ,atasbawah
                temp.createvertices(-3.965f, 0.0f, -4.38f, 0.025f, 0.025f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.7f, 0.0f);
                temp.rotate(-90f, 37.5f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                temp.createvertices(-6.25f, 0.0f, 0.975f, 0.35f, 0.35f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.4f, 0.0f);
                temp.rotate(90f, 0f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                temp.createvertices(-6.25f, 0.0f, 0.974f, 0.25f, 0.25f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.5f, 0.0f);
                temp.rotate(90f, 0f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                temp.createvertices(-6.25f, 0.0f, 0.973f, 0.15f, 0.15f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.6f, 0.0f);
                temp.rotate(90f, 0f, 0f);
                atas.Add(temp);
                temp = new Sphere();
                temp.createvertices(-6.25f, 0.0f, 0.972f, 0.05f, 0.05f, 0f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.8f, 0.7f, 0.0f);
                temp.rotate(90f, 0f, 0f);
                atas.Add(temp);
            }
            {
                //calvert
                // HEAD
                temp = new Sphere();
                temp.createvertices(0.0f, 0.0f, 0.0f, 0.5f, 0.4f, 0.5f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.203f, 0.505f, 0.725f);
                calvert.Add(temp);

                // BODY
                temp = new Sphere();
                temp.createvertices(0.0f, 0.85f, 0.0f, 0.55f, 0.5f, 0.6f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.643f, 0.901f, 0.956f);
                calvert.Add(temp);

                // LEFT BALL
                temp = new Sphere();
                temp.createvertices(-0.2f, 0.5f, -0.66f, 0.07f, 0.07f, 0.07f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 1.0f);
                temp.rotate(0.07f, 90f, -20f);
                calvert.Add(temp);

                // RIGHT BALL
                temp = new Sphere();
                temp.createvertices(0.2f, 0.5f, -0.66f, 0.07f, 0.07f, 0.07f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 1.0f);
                temp.rotate(0.07f, 90f, -20f);
                calvert.Add(temp);

                // MOUTH
                temp = new ElipticParaboloid();
                temp.createvertices(0.0f, -0.1f, -0.63f, 0.07f, 0.07f, 0.07f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.960f, 0.796f, 0.270f);
                temp.rotate(0.0f, 90f, -25f);
                calvert.Add(temp);

                // LEFT EYES
                temp = new Sphere();
                temp.createvertices(-0.2f, 0.15f, -0.35f, 0.07f, 0.15f, 0.1f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.062f, 0.062f, 0.058f);
                temp.rotate(0.05f, 90f, 50f);
                calvert.Add(temp);

                // WHITE LEFT EYES
                temp = new Sphere();
                temp.createvertices(-0.2f, 0.15f, -0.45f, 0.02f, 0.05f, 0.01f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 1.0f);
                temp.rotate(0.05f, 90f, 50f);
                calvert.Add(temp);

                // RIGHT EYES
                temp = new Sphere();
                temp.createvertices(0.2f, 0.15f, -0.35f, 0.07f, 0.15f, 0.1f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.062f, 0.062f, 0.058f);
                temp.rotate(0.05f, 90f, 50f);
                calvert.Add(temp);

                // WHITE RIGHT EYES
                temp = new Sphere();
                temp.createvertices(0.2f, 0.15f, -0.45f, 0.02f, 0.05f, 0.01f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(1.0f, 1.0f, 1.0f);
                temp.rotate(0.05f, 90f, 50f);
                calvert.Add(temp);

                // TAIL 1
                temp = new Sphere();
                temp.createvertices(1.1f, -0.1f, -0.2f, 0.1f, 0.3f, 0.1f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.203f, 0.505f, 0.725f);
                temp.rotate(45f, 0.0f, 45f);
                calvert.Add(temp);

                // TAIL 2
                temp = new Sphere();
                temp.createvertices(1.1f, 0.1f, -0.2f, 0.1f, 0.3f, 0.1f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.203f, 0.505f, 0.725f);
                temp.rotate(135f, 0.0f, 45f);
                calvert.Add(temp);

                // TAIL 3
                temp = new Sphere();
                temp.createvertices(1.1f, 0.1f, 0.0f, 0.1f, 0.3f, 0.1f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.203f, 0.505f, 0.725f);
                temp.rotate(0.0f, 0.0f, 45f);
                calvert.Add(temp);

                // PAHA 1
                temp = new ElipticParaboloid();
                temp.createvertices(0.1f, 1.0f, 0.48f, 0.12f, 0.12f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.203f, 0.505f, 0.725f);
                temp.rotate(0.0f, 235f, 0.0f);
                calvert.Add(temp);

                // PAHA 2
                temp = new ElipticParaboloid();
                temp.createvertices(-0.1f, 1.0f, 0.48f, 0.12f, 0.12f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.203f, 0.505f, 0.725f);
                temp.rotate(0.0f, 300f, 0.0f);
                calvert.Add(temp);

                // KAKI 1
                temp = new Sphere();
                temp.createvertices(0.1f, 0.9f, 0.9f, 0.25f, 0.3f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.960f, 0.796f, 0.270f);
                temp.rotate(0.0f, 235f, 0.0f);
                calvert.Add(temp);

                // KAKI 2
                temp = new Sphere();
                temp.createvertices(-0.1f, 0.9f, 0.9f, 0.25f, 0.3f, 0.15f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.960f, 0.796f, 0.270f);
                temp.rotate(0.0f, 300f, 0.0f);
                calvert.Add(temp);

                // TANGAN 1
                temp = new Sphere();
                temp.createvertices(0.0f, -0.3f, 0.9f, 0.2f, 0.4f, 0.1f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.203f, 0.505f, 0.725f);
                temp.rotate(-60f, 0.0f, 0.0f);
                calvert.Add(temp);

                // TANGAN 2
                temp = new Sphere();
                temp.createvertices(0.0f, -0.3f, -0.9f, 0.2f, 0.4f, 0.1f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.203f, 0.505f, 0.725f);
                temp.rotate(60f, 0.0f, 0.0f);
                calvert.Add(temp);

                // TANDUK 1
                temp = new Cone();
                temp.createvertices(0.0f, 0.0f, 0.55f, 0.05f, 0.05f, 0.1f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.458f, 0.329f, 0.019f);
                temp.rotate(60f, 0.0f, 0.0f);
                calvert.Add(temp);

                // TANDUK 2
                temp = new Cone();
                temp.createvertices(0.0f, 0.0f, 0.55f, 0.05f, 0.05f, 0.1f);
                temp.setupObject(shader_vert, shader_frag);
                temp.setColor(0.458f, 0.329f, 0.019f);
                temp.rotate(120f, 0.0f, 0.0f);
                calvert.Add(temp);

                coord.Add(new Vector3d(0.12, -0.2, 0.0));
                coord.Add(new Vector3d(0.065, 0.02, 0.0));
                coord.Add(new Vector3d(0.0, 0.065, 0.0));
                coord.Add(new Vector3d(-0.065, 0.02, 0.0));
                coord.Add(new Vector3d(-0.12, -0.2, 0.0));

                Curve Kurva = new Curve();
                Kurva.createvertices(coord);
                Kurva.setupObject(shader_vert, shader_frag);
                Kurva.setColor(0.0f, 0.0f, 0.0f);
                calvert_curve.Add(Kurva);
            }
            {
                //cloud 
                cloud1 = new Sphere();
                cloud1.createvertices(5.5f, -5f, 0.0f, 1f, 0.7f, 0.7f);
                cloud1.setupObject(shader_vert, shader_frag);
                cloud1.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud1);
                cloud2 = new Sphere();
                cloud2.createvertices(6.3f, -5f, 0.0f, 0.5f, 0.5f, 0.5f);
                cloud2.setupObject(shader_vert, shader_frag);
                cloud2.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud2);
                cloud3 = new Sphere();
                cloud3.createvertices(4.7f, -5f, 0.0f, 0.5f, 0.5f, 0.5f);
                cloud3.setupObject(shader_vert, shader_frag);
                cloud3.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud3);
                cloud4 = new Sphere();
                cloud4.createvertices(5.5f, -5.5f, 0.0f, 0.5f, 0.5f, 0.5f);
                cloud4.setupObject(shader_vert, shader_frag);
                cloud4.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud4);
                cloud5 = new Sphere();
                cloud5.createvertices(6f, -5.4f, 0.0f, 0.4f, 0.4f, 0.4f);
                cloud5.setupObject(shader_vert, shader_frag);
                cloud5.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud5);
                cloud6 = new Sphere();
                cloud6.createvertices(5f, -5.4f, 0.0f, 0.4f, 0.4f, 0.4f);
                cloud6.setupObject(shader_vert, shader_frag);
                cloud6.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud6);

                //cloud 
                cloud7 = new Sphere();
                cloud7.createvertices(-5.5f, -5f, 0.0f, 1f, 0.7f, 0.7f);
                cloud7.setupObject(shader_vert, shader_frag);
                cloud7.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud7);
                cloud8 = new Sphere();
                cloud8.createvertices(-6.3f, -5f, 0.0f, 0.5f, 0.5f, 0.5f);
                cloud8.setupObject(shader_vert, shader_frag);
                cloud8.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud8);
                cloud9 = new Sphere();
                cloud9.createvertices(-4.7f, -5f, 0.0f, 0.5f, 0.5f, 0.5f);
                cloud9.setupObject(shader_vert, shader_frag);
                cloud9.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud9);
                cloud10 = new Sphere();
                cloud10.createvertices(-5.5f, -5.5f, 0.0f, 0.5f, 0.5f, 0.5f);
                cloud10.setupObject(shader_vert, shader_frag);
                cloud10.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud10);
                cloud11 = new Sphere();
                cloud11.createvertices(-6f, -5.4f, 0.0f, 0.4f, 0.4f, 0.4f);
                cloud11.setupObject(shader_vert, shader_frag);
                cloud11.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud11);
                cloud12 = new Sphere();
                cloud12.createvertices(-5f, -5.4f, 0.0f, 0.4f, 0.4f, 0.4f);
                cloud12.setupObject(shader_vert, shader_frag);
                cloud12.setColor(0.929f, 0.941f, 0.960f);
                alas.Add(cloud12);

            }
            {
                //LIAUW

                //Telinga Kanan1, Kiri1, Kanan2, Kiri2
                temp17 = new Ellipsoid();
                temp17.createvertices(0, 3.8985f - 2f, -0.25f, 0.02f, 0.05f, 0.25f);
                temp17.setupObject(shader_vert, shader_frag);
                temp17.setColor(1f, 1f, 1f);
                temp17.rotate(0f, 90f, 90f);
                temp17.scale(1.5f);
                liauw.Add(temp17);

                //Telinga Kiri1
                temp18 = new Ellipsoid();
                temp18.createvertices(0, 4.1025f - 2f, -0.25f, 0.02f, 0.05f, 0.25f);
                temp18.setupObject(shader_vert, shader_frag);
                temp18.setColor(1f, 1f, 1f);
                temp18.rotate(0f, 90f, 90f);
                temp18.scale(1.5f);
                liauw.Add(temp18);

                //Telinga Kanan2
                temp19 = new Ellipsoid();
                temp19.createvertices(0.005f, 3.8985f - 2f, -0.25f, 0.05f, 0.025f, 0.225f);
                temp19.setupObject(shader_vert, shader_frag);
                temp19.setColor(1f, 0.8f, 0.8f);
                temp19.rotate(0f, 90f, 90f);
                temp19.scale(1.5f);
                liauw.Add(temp19);
                //Telinga Kiri2
                temp20 = new Ellipsoid();
                temp20.createvertices(0.005f, 4.1025f - 2f, -0.25f, 0.05f, 0.025f, 0.225f);
                temp20.setupObject(shader_vert, shader_frag);
                temp20.setColor(1f, 0.8f, 0.8f);
                temp20.rotate(0f, 90f, 90f);
                temp20.scale(1.5f);
                liauw.Add(temp20);

                //Muka, 
                temp21 = new Sphere();
                temp21.createvertices(0 + y, 0, 0, 0.3f, 0.275f, 0.275f);
                temp21.setupObject(shader_vert, shader_frag);
                temp21.setColor(1f, 1f, 1f);
                temp21.scale(1.5f);
                //temp5.rotate(0f, 90f, 90f);
                liauw.Add(temp21);

                //Mata1,
                temp22 = new Sphere();
                temp22.createvertices(0.3f / 4f + y, -0.3f / 2.5f, -0.225f, 0.025f, 0.025f, 0.025f);
                temp22.setupObject(shader_vert, shader_frag);
                temp22.setColor(0f, 0f, 0f);
                temp22.scale(1.5f);
                //temp5.rotate(0f, 90f, 90f);
                liauw.Add(temp22);

                // Mata2
                temp23 = new Sphere();
                temp23.createvertices(-0.3f / 4f + y, -0.3f / 2.5f, -0.225f, 0.025f, 0.025f, 0.025f);
                temp23.setupObject(shader_vert, shader_frag);
                temp23.setColor(0f, 0f, 0f);
                temp23.scale(1.5f);
                //temp5.rotate(0f, 90f, 90f);
                liauw.Add(temp23);

                //Bayangan Bawah
                temp24 = new ElipticParaboloid();
                temp24.createvertices(0.0f + y, 0.0175f, -0.265f, 0.025f, 0.05f, 0f);
                temp24.setupObject(shader_vert, shader_frag);
                temp24.setColor(0.9f, 0.9f, 0.9f);
                temp24.scale(1.5f);
                liauw.Add(temp24);

                //Hidung1
                temp25 = new Ellipsoid();
                temp25.createvertices(0f + y, -0.075f, -0.255f, 0.0265f, 0.025f, 0.02f);
                temp25.setupObject(shader_vert, shader_frag);
                temp25.setColor(0f, 0f, 0f);
                temp25.scale(1.5f);
                liauw.Add(temp25);

                //Hidung2
                temp26 = new Ellipsoid();
                temp26.createvertices(0f + y, -0.075f, -0.26f, 0.021f, 0.02f, 0.02f);
                temp26.setupObject(shader_vert, shader_frag);
                temp26.setColor(1f, 1f, 1f);
                temp26.scale(1.5f);
                liauw.Add(temp26);

                //Mulut
                temp27 = new Ellipsoid();
                temp27.createvertices(0f + y, 0.03f, -0.275f, 0.025f, 0.0525f, 0.02f);
                temp27.setupObject(shader_vert, shader_frag);
                temp27.setColor(1.0f, 0.2f, 0.2f);
                temp27.scale(1.5f);
                liauw.Add(temp27);

                //Blush Kanan
                temp28 = new Ellipsoid();
                temp28.createvertices(0.1f + y, -0.05f, -0.25f, 0.035f, 0.02f, 0.02f);
                temp28.setupObject(shader_vert, shader_frag);
                temp28.setColor(1.0f, 0.8f, 0.8f);
                temp28.scale(1.5f);
                liauw.Add(temp28);

                //Blush Kiri
                temp29 = new Ellipsoid();
                temp29.createvertices(-0.1f + y, -0.05f, -0.25f, 0.035f, 0.02f, 0.02f);
                temp29.setupObject(shader_vert, shader_frag);
                temp29.setColor(1.0f, 0.8f, 0.8f);
                temp29.scale(1.5f);
                liauw.Add(temp29);

                //Cone
                temp30 = new Cone();
                temp30.createvertices(0f + y, 0f, 0.9f, 0.175f, 0.175f, 0.5f);
                temp30.setupObject(shader_vert, shader_frag);
                temp30.setColor(1.0f, 0.6f, 0.2f);
                temp30.rotate(-90.0f, 0f, 0f);
                temp30.scale(1.5f);
                liauw.Add(temp30);

                p2.Add(new Vector3d(0.09 + y - 0.8465f, 0.3, 0.0));
                p2.Add(new Vector3d(0.065 + y - 0.8465f, 0.8, 0.0));
                p2.Add(new Vector3d(0.0 + y - 0.8465f, 0.85, 0.0));
                p2.Add(new Vector3d(-0.065 + y - 0.8465f, 0.8, 0.0));
                p2.Add(new Vector3d(-0.09 + y - 0.8465f, 0.3, 0.0));

                Curve Kurva = new Curve();
                Kurva.createvertices(p2);
                Kurva.setupObject(shader_vert, shader_frag);
                Kurva.setColor(0.0f, 0.0f, 0.0f);
                liauw_curve.Add(Kurva);

                p1.Add(new Vector3d(0.09 + y - 1.155f, 0.3, 0.0));
                p1.Add(new Vector3d(0.065 + y - 1.155f, 0.8, 0.0));
                p1.Add(new Vector3d(0.0 + y - 1.155f, 0.85, 0.0));
                p1.Add(new Vector3d(-0.065 + y - 1.155f, 0.8, 0.0));
                p1.Add(new Vector3d(-0.09 + y - 1.155f, 0.3, 0.0));

                Kurva = new Curve();
                Kurva.createvertices(p1);
                Kurva.setupObject(shader_vert, shader_frag);
                Kurva.setColor(0.0f, 0.0f, 0.0f);
                liauw_curve.Add(Kurva);
            }
            {
                //JOVIAN
                //Badan
                temp1 = new Sphere();
                temp1.createvertices(x + 0.0f, 0.0f, 0.0f, 0.7f, 0.7f, 0.7f);
                temp1.setupObject(shader_vert, shader_frag);
                temp1.setColor(1f, 0.611f, 0.843f);
                jovian.Add(temp1);
                //Topi 1
                temp2 = new EllipticCylinder();
                temp2.createvertices(-2.0f, -3.45f, -1.2f, 0.6f, 1.2f, 0.9f);
                temp2.setupObject(shader_vert, shader_frag);
                temp2.setColor(0.090f, 0.027f, 0.058f);
                temp2.rotate(30f, 90f, 90f);
                jovian.Add(temp2);
                //Topi 2
                temp3 = new Sphere();
                temp3.createvertices(x + 0.0f, -0.5f, 0.0f, 1f, 0.1f, 0.7f);
                temp3.setupObject(shader_vert, shader_frag);
                temp3.setColor(0.090f, 0.027f, 0.058f);
                jovian.Add(temp3);
                //Topi 3
                temp4 = new Sphere();
                temp4.createvertices(x + 0.0f, -1.2f, 0.0f, 0.6f, 0.0f, 0.65f);
                temp4.setupObject(shader_vert, shader_frag);
                temp4.setColor(0.090f, 0.027f, 0.058f);
                jovian.Add(temp4);
                //Topi 4
                temp5 = new EllipticCylinder();
                temp5.createvertices(-2.0f, -3.45f, -0.65f, 0.61f, 0.15f, 0.9f);
                temp5.setupObject(shader_vert, shader_frag);
                temp5.setColor(0.968f, 0.945f, 0.145f);
                temp5.rotate(30f, 90f, 90f);
                jovian.Add(temp5);

                // Hand Kanan
                temp6 = new EllipticParaboloid2();
                temp6.createvertices(0.0f, 0.0f, -4.9f, 0.6f, 0.7f, 1f);
                temp6.setupObject(shader_vert, shader_frag);
                temp6.setColor(1f, 0.560f, 0.882f);
                temp6.rotate(90f, 90f, 180f);
                jovian.Add(temp6);

                // Hand Kiri
                temp7 = new EllipticParaboloid2();
                temp7.createvertices(0.0f, 0.0f, 3.1f, 0.6f, 0.7f, 1f);
                temp7.setupObject(shader_vert, shader_frag);
                temp7.setColor(1f, 0.560f, 0.882f);
                temp7.rotate(90f, -90f, 180f);
                jovian.Add(temp7);

                // Mata kiri
                temp8 = new Ellipsoid();
                temp8.createvertices(x + 0.2f, -0.15f, -0.66f, 0.07f, 0.15f, 0.1f);
                temp8.setupObject(shader_vert, shader_frag);
                temp8.setColor(0.062f, 0.062f, 0.058f);
                jovian.Add(temp8);

                // Putih kiri
                temp9 = new Ellipsoid();
                temp9.createvertices(x - 0.2f, -0.2f, -0.72f, 0.04f, 0.08f, 0.05f);
                temp9.setupObject(shader_vert, shader_frag);
                temp9.setColor(1.0f, 1.0f, 1.0f);
                jovian.Add(temp9);

                // Mata kanan
                temp10 = new Ellipsoid();
                temp10.createvertices(x - 0.2f, -0.15f, -0.65f, 0.07f, 0.15f, 0.1f);
                temp10.setupObject(shader_vert, shader_frag);
                temp10.setColor(0.062f, 0.062f, 0.058f);
                jovian.Add(temp10);


                // Putih kanan
                temp11 = new Ellipsoid();
                temp11.createvertices(x + 0.2f, -0.2f, -0.72f, 0.04f, 0.08f, 0.05f);
                temp11.setupObject(shader_vert, shader_frag);
                temp11.setColor(1.0f, 1.0f, 1.0f);
                jovian.Add(temp11);

                // Kaki kanan
                temp12 = new Ellipsoid();
                temp12.createvertices(-2.4f, 0.79f, -3.7f, 0.45f, 0.18f, 0.25f);
                temp12.setupObject(shader_vert, shader_frag);
                temp12.setColor(1f, 0.168f, 0.572f);
                temp12.rotate(180f, 60f, 180f);
                jovian.Add(temp12);

                // Kaki kiri
                temp13 = new Ellipsoid();
                temp13.createvertices(1.6f, 0.8f, -3.3f, 0.45f, 0.18f, 0.25f);
                temp13.setupObject(shader_vert, shader_frag);
                temp13.setColor(1f, 0.168f, 0.572f);
                temp13.rotate(180f, 120f, 180f);
                jovian.Add(temp13);

                // Blush kiri
                temp14 = new Ellipsoid();
                temp14.createvertices(-0.05f, 3.35f, 1.6f, 0.05f, 0.09f, 0.02f);
                temp14.setupObject(shader_vert, shader_frag);
                temp14.setColor(0.949f, 0.121f, 0.729f);
                temp14.rotate(215f, 180f, 90f);
                jovian.Add(temp14);

                // Blush kanan
                temp15 = new Ellipsoid();
                temp15.createvertices(-0.05f, 3.2f, -3f, 0.05f, 0.09f, 0.02f);
                temp15.setupObject(shader_vert, shader_frag);
                temp15.setColor(0.949f, 0.121f, 0.729f);
                temp15.rotate(145f, 180f, 90f);
                jovian.Add(temp15);

                // Mulut
                temp16 = new Ellipsoid();
                temp16.createvertices(-0.12f, 4f, -0.7f, 0.09f, 0.12f, 0.02f);
                temp16.setupObject(shader_vert, shader_frag);
                temp16.setColor(0.941f, 0.086f, 0.368f);
                temp16.rotate(180f, 180f, 90f);
                jovian.Add(temp16);

                //lantai
                lantai = new Sphere();
                lantai.createvertices(0.0f, 1.5f, 0.0f, 10f, 0.001f, 3f);
                lantai.setupObject(shader_vert, shader_frag);
                lantai.setColor(0.968f, 0.509f, 0.360f);
                alas.Add(lantai);


                float x1 = 7, y1 = 0.7f, z1 = 3;
                c1.Add(new Vector3d(9.17 * 0.1 + x1, 7.4 * 0.1 - y1, 0.0));
                c1.Add(new Vector3d(0.32 * 0.1 + x1, -1.83 * 0.1 - y1, 0.0));
                c1.Add(new Vector3d(-4.87 * 0.1 + x1, 5.97 * 0.1 - y1, 0.0));
                c1.Add(new Vector3d(0.7 * 0.1 + x1, 6.6 * 0.1 - y1, 0.0));

                Curve Kurva = new Curve();
                Kurva.createvertices(c1);
                Kurva.setupObject(shader_vert, shader_frag);
                Kurva.setColor(0.0f, 0.0f, 0.0f);
                jovian_curve.Add(Kurva);
                jovian_curve[0].scale(0.5f);
                jovian_curve[0].translate(0f, 0f, 0.7f);

                c2.Add(new Vector3d(9.17 * 0.1 + x1, 7.4 * 0.1 - y1, 0.0));
                c2.Add(new Vector3d(0.32 * 0.1 + x1, -1.83 * 0.1 - y1, 0.0));
                c2.Add(new Vector3d(-4.87 * 0.1 + x1, 5.97 * 0.1 - y1, 0.0));
                c2.Add(new Vector3d(0.7 * 0.1 + x1, 6.6 * 0.1 - y1, 0.0));

                Kurva = new Curve();
                Kurva.createvertices(c2);
                Kurva.setupObject(shader_vert, shader_frag);
                Kurva.setColor(0.0f, 0.0f, 0.0f);
                jovian_curve.Add(Kurva);
                jovian_curve[1].scale(0.5f);
                jovian_curve[1].translate(-8f, 0f, -0.7f);
                jovian_curve[1].rotate(0f, 180f, 0f);
            }
            {//rumput
                r12 = new Cone();
                r12.createvertices(9f, 1f, 0f, 0.5f, 0.3f, 1f);
                r12.setupObject(shader_vert, shader_frag);
                r12.setColor(0.5f, 0.9f, 0.2f);
                r12.rotate(90f, 0f, 0f);
                alas.Add(r12);
                r9 = new Cone();
                r9.createvertices(7.5f, 1.5f, 0f, 0.5f, 0.3f, 1f);
                r9.setupObject(shader_vert, shader_frag);
                r9.setColor(0.5f, 0.9f, 0.2f);
                r9.rotate(90f, 0f, 0f);
                alas.Add(r9);
                r8 = new Cone();
                r8.createvertices(6f, 2f, 0f, 0.5f, 0.3f, 1f);
                r8.setupObject(shader_vert, shader_frag);
                r8.setColor(0.5f, 0.9f, 0.2f);
                r8.rotate(90f, 0f, 0f);
                alas.Add(r8);
                r7 = new Cone();
                r7.createvertices(4.5f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r7.setupObject(shader_vert, shader_frag);
                r7.setColor(0.5f, 0.9f, 0.2f);
                r7.rotate(90f, 0f, 0f);
                alas.Add(r7);
                r6 = new Cone();
                r6.createvertices(3f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r6.setupObject(shader_vert, shader_frag);
                r6.setColor(0.5f, 0.9f, 0.2f);
                r6.rotate(90f, 0f, 0f);
                alas.Add(r6);
                r5 = new Cone();
                r5.createvertices(1.5f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r5.setupObject(shader_vert, shader_frag);
                r5.setColor(0.5f, 0.9f, 0.2f);
                r5.rotate(90f, 0f, 0f);
                alas.Add(r5);
                r4 = new Cone();
                r4.createvertices(0f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r4.setupObject(shader_vert, shader_frag);
                r4.setColor(0.5f, 0.9f, 0.2f);
                r4.rotate(90f, 0f, 0f);
                alas.Add(r4);
                r1 = new Cone();
                r1.createvertices(-1.5f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r1.setupObject(shader_vert, shader_frag);
                r1.setColor(0.5f, 0.9f, 0.2f);
                r1.rotate(90f, 0f, 0f);
                alas.Add(r1);
                r2 = new Cone();
                r2.createvertices(-3f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r2.setupObject(shader_vert, shader_frag);
                r2.setColor(0.5f, 0.9f, 0.2f);
                r2.rotate(90f, 0f, 0f);
                alas.Add(r2);
                r3 = new Cone();
                r3.createvertices(-4.5f, 2.5f, 0f, 0.5f, 0.3f, 1f);
                r3.setupObject(shader_vert, shader_frag);
                r3.setColor(0.5f, 0.9f, 0.2f);
                r3.rotate(90f, 0f, 0f);
                alas.Add(r3);
                r10 = new Cone();
                r10.createvertices(-6f, 2f, 0f, 0.5f, 0.3f, 1f);
                r10.setupObject(shader_vert, shader_frag);
                r10.setColor(0.5f, 0.9f, 0.2f);
                r10.rotate(90f, 0f, 0f);
                alas.Add(r10);
                r11 = new Cone();
                r11.createvertices(-7.5f, 1.5f, 0f, 0.5f, 0.3f, 1f);
                r11.setupObject(shader_vert, shader_frag);
                r11.setColor(0.5f, 0.9f, 0.2f);
                r11.rotate(90f, 0f, 0f);
                alas.Add(r11);
                r13 = new Cone();
                r13.createvertices(-7.5f, 1.5f, 0f, 0.5f, 0.3f, 1f);
                r13.setupObject(shader_vert, shader_frag);
                r13.setColor(0.5f, 0.9f, 0.2f);
                r13.rotate(90f, 0f, 0f);
                alas.Add(r13);
                r14 = new Cone();
                r14.createvertices(-9f, 1f, 0f, 0.5f, 0.3f, 1f);
                r14.setupObject(shader_vert, shader_frag);
                r14.setColor(0.5f, 0.9f, 0.2f);
                r14.rotate(90f, 0f, 0f);
                alas.Add(r14);
            }
            ////-------------------------------------------------------------------------------------------------------------------------------------------------//       


            //// mulut.createvertices(0.0f, 0.0f, 0.3f, 0.0f, -0.05f, 0.0f);
            ////  mulut.setupObject(shader_vert, shader_frag);

            ////positions.Add(new Vector3d(-0.05f, -0.05f, 0.0f));
            ////positions.Add(new Vector3d(-0.0f, -0.1f, 0.0f));
            ////positions.Add(new Vector3d(0.05f, -0.05f, 0.0f));

            ////mulut.createvertices(positions);
            ////mulut.setupObject(shader_vert, shader_frag);
            ////mulut.translate(0.0f, 0.4f, 0.2f);

            for (int i = 0; i < calvert.Count; i++)
            {
                calvert[i].rotate(180.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < alas.Count; i++)
            {
                alas[i].rotate(180.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < jovian.Count; i++)
            {
                jovian[i].rotate(180.0f, 0.0f, 0.0f);
            }
            for (int i = 0; i < liauw.Count; i++)
            {
                liauw[i].rotate(180.0f, 0.0f, 0.0f);
            }
            //for (int i = 0; i < atas.Count; i++)
            //{
            //    atas[i].rotate(180.0f, 0.0f, 0.0f);
            //}

            for (int i = 0; i < calvert_curve.Count; i++)
            {
                calvert_curve[i].translate(0.0f, 0.63f, 0.02f);
                calvert_curve[i].rotate(0.0f, 90f, 108f);
            }

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (count < 200)
            {
                for (int i = 0; i < liauw.Count; i++)
                {
                    liauw[i].translate(0f, 0.005f, 0f);
                }
                for (int i = 0; i < jovian.Count; i++)
                {
                    jovian[i].translate(0.005f, 0f, 0f);
                }
                for (int i = 0; i < calvert.Count; i++)
                {
                    calvert[i].translate(0.0f, 0.0f, 0.005f);
                }
                for (int i = 0; i < liauw_curve.Count; i++)
                {
                    liauw_curve[i].translate(0f, 0.005f, 0f);
                }
                for (int i = 0; i < calvert_curve.Count; i++)
                {
                    calvert_curve[i].translate(0.0f, 0.0f, 0.005f);
                }
                for (int i = 0; i < jovian_curve.Count; i++)
                {
                    jovian_curve[i].translate(0.005f, 0f, 0f);
                }

                cloud1.translate(0.01f, 0.0f, 0.0f);
                cloud2.translate(0.01f, 0.0f, 0.0f);
                cloud3.translate(0.01f, 0.0f, 0.0f);
                cloud4.translate(0.01f, 0.0f, 0.0f);
                cloud5.translate(0.01f, 0.0f, 0.0f);
                cloud6.translate(0.01f, 0.0f, 0.0f);
                cloud7.translate(-0.01f, 0.0f, 0.0f);
                cloud8.translate(-0.01f, 0.0f, 0.0f);
                cloud9.translate(-0.01f, 0.0f, 0.0f);
                cloud10.translate(-0.01f, 0.0f, 0.0f);
                cloud11.translate(-0.01f, 0.0f, 0.0f);
                cloud12.translate(-0.01f, 0.0f, 0.0f);

                t[0].translate(0f, -0.005f, 0.0f);
                t[1].translate(0f, -0.005f, 0.0f);
                t[2].translate(0f, -0.005f, 0.0f);
                t[3].translate(0f, -0.005f, 0.0f);

                liauw[13].translate(0.0f, -0.001f, 0.0f);
                liauw[0].translate(0.0005f, 0, 0);
                liauw[1].translate(-0.0005f, 0, 0);
                liauw[2].translate(0.0005f, 0, 0);
                liauw[3].translate(-0.0005f, 0, 0);
                liauw_curve[0].translate(0.0005f, 0, 0);
                liauw_curve[1].translate(-0.0005f, 0, 0);

                temp2.translate(0.0f, 0.002f, 0.0f);
                temp3.translate(0.0f, 0.002f, 0.0f);
                temp4.translate(0.0f, 0.002f, 0.0f);
                temp5.translate(0.0f, 0.002f, 0.0f);
                temp6.translate(0.0f, -0.0001f, 0.0f);
                temp7.translate(0.0f, -0.0001f, 0.0f);
                temp12.translate(0.001f, 0.0f, 0.0f);
                temp13.translate(-0.001f, 0.0f, 0.0f);

                calvert[9].translate(0.0f, 0.001f, 0.0f);
                calvert[10].translate(0.0f, 0.001f, 0.0f);
                calvert[11].translate(0.0f, 0.001f, 0.0f);

                calvert[12].translate(0.0f, 0.0005f, 0.0f);
                calvert[13].translate(0.0f, -0.0005f, 0.0f);
                calvert[14].translate(0.0f, 0.0005f, 0.0f);
                calvert[15].translate(0.0f, -0.0005f, 0.0f);

                calvert[16].translate(0.0f, 0.001f, 0.0f);
                calvert[17].translate(0.0f, 0.001f, 0.0f);

                wall2.translate(0.0f, 0.002f, 0.0f);
                wall3.translate(0.002f, 0.0f, 0.0f);
                wall4.translate(-0.002f, 0.0f, 0.0f);

                wall5.translate(-0.002f, 0.0f, 0.0f);
                wall6.translate(0.002f, 0.0f, 0.0f);

                wall7.translate(0.002f, 0.0f, 0.0f);
                wall8.translate(-0.002f, 0.0f, 0.0f);
                wall9.translate(0.0f, -0.002f, 0.0f);
                count++;

            }
            else if (count >= 200)
            {
                for (int i = 0; i < liauw.Count; i++)
                {
                    liauw[i].translate(0f, -0.005f, 0f);
                }
                for (int i = 0; i < jovian.Count; i++)
                {
                    jovian[i].translate(-0.005f, 0f, 0f);
                }
                for (int i = 0; i < calvert.Count; i++)
                {
                    calvert[i].translate(0.0f, 0f, -0.005f);
                }
                for (int i = 0; i < liauw_curve.Count; i++)
                {
                    liauw_curve[i].translate(0f, -0.005f, 0f);
                }
                for (int i = 0; i < calvert_curve.Count; i++)
                {
                    calvert_curve[i].translate(0.0f, 0.0f, -0.005f);
                }
                for (int i = 0; i < jovian_curve.Count; i++)
                {
                    jovian_curve[i].translate(-0.005f, 0f, 0f);
                }
                cloud1.translate(-0.01f, 0.0f, 0.0f);
                cloud2.translate(-0.01f, 0.0f, 0.0f);
                cloud3.translate(-0.01f, 0.0f, 0.0f);
                cloud4.translate(-0.01f, 0.0f, 0.0f);
                cloud5.translate(-0.01f, 0.0f, 0.0f);
                cloud6.translate(-0.01f, 0.0f, 0.0f);
                cloud7.translate(0.01f, 0.0f, 0.0f);
                cloud8.translate(0.01f, 0.0f, 0.0f);
                cloud9.translate(0.01f, 0.0f, 0.0f);
                cloud10.translate(0.01f, 0.0f, 0.0f);
                cloud11.translate(0.01f, 0.0f, 0.0f);
                cloud12.translate(0.01f, 0.0f, 0.0f);

                t[0].translate(0f, 0.005f, 0.0f);
                t[1].translate(0f, 0.005f, 0.0f);
                t[2].translate(0f, 0.005f, 0.0f);
                t[3].translate(0f, 0.005f, 0.0f);

                liauw[0].translate(-0.0005f, 0, 0);
                liauw[1].translate(0.0005f, 0, 0);
                liauw[2].translate(-0.0005f, 0, 0);
                liauw[3].translate(0.0005f, 0, 0);
                liauw[13].translate(0.0f, 0.001f, 0.0f);
                liauw_curve[0].translate(-0.0005f, 0, 0);
                liauw_curve[1].translate(0.0005f, 0, 0);

                temp2.translate(0.0f, -0.002f, 0.0f);
                temp3.translate(0.0f, -0.002f, 0.0f);
                temp4.translate(0.0f, -0.002f, 0.0f);
                temp5.translate(0.0f, -0.002f, 0.0f);
                temp6.translate(0.0f, 0.0001f, 0.0f);
                temp7.translate(0.0f, 0.0001f, 0.0f);
                temp12.translate(-0.001f, 0.0f, 0.0f);
                temp13.translate(0.001f, 0.0f, 0.0f);

                calvert[9].translate(0.0f, -0.001f, 0.0f);
                calvert[10].translate(0.0f, -0.001f, 0.0f);
                calvert[11].translate(0.0f, -0.001f, 0.0f);

                calvert[12].translate(0.0f, -0.0005f, 0.0f);
                calvert[13].translate(0.0f, 0.0005f, 0.0f);
                calvert[14].translate(0.0f, -0.0005f, 0.0f);
                calvert[15].translate(0.0f, 0.0005f, 0.0f);

                calvert[16].translate(0.0f, -0.001f, 0.0f);
                calvert[17].translate(0.0f, -0.001f, 0.0f);

                wall2.translate(0.0f, -0.002f, 0.0f);
                wall3.translate(-0.002f, 0.0f, 0.0f);
                wall4.translate(0.002f, 0.0f, 0.0f);

                wall5.translate(0.002f, 0.0f, 0.0f);
                wall6.translate(-0.002f, 0.0f, 0.0f);

                wall7.translate(-0.002f, 0.0f, 0.0f);
                wall8.translate(0.002f, 0.0f, 0.0f);
                wall9.translate(0.0f, 0.002f, 0.0f);

                count++;
                if (count == 400)
                {
                    count = 0;
                }
            }

            for (int i = 0; i < calvert.Count; i++)
            {
                calvert[i].render(_camera);
                calvert[i].rotate(0.0f, 0.5f, 0.0f);
            }
            for (int i = 0; i < alas.Count; i++)
            {
                alas[i].render(_camera);

            }
            for (int i = 0; i < jovian.Count; i++)
            {
                jovian[i].render(_camera);
                jovian[i].rotate(0.2f, 0.0f, 0.0f);

            }
            for (int i = 0; i < liauw.Count; i++)
            {
                liauw[i].render(_camera);
                liauw[i].rotate(-0.5f, 0.0f, 0.0f);
            }
            for (int i = 0; i < atas.Count; i++)
            {
                atas[i].render(_camera);
            }
            for (int i = 0; i < t.Count; i++)
            {
                t[i].render(_camera);
            }
            for (int i = 0; i < liauw_curve.Count; i++)
            {
                liauw_curve[i].render(_camera);
                liauw_curve[i].rotate(-0.5f, 0.0f, 0.0f);
            }
            for (int i = 0; i < calvert_curve.Count; i++)
            {
                calvert_curve[i].render(_camera);
                calvert_curve[i].rotate(0.0f, 0.5f, 0.0f);
            }

            for (int i = 0; i < jovian_curve.Count; i++)
            {
                jovian_curve[i].render(_camera);
                jovian_curve[i].rotate(0.2f, 0.0f, 0.0f);
            }

            SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            if (!IsFocused)
            {
                return;
            }

            const float cameraSpeed = 1.5f;
            const float sensitivity = 0.2f;


            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            if (input.IsKeyPressed(Keys.Q)) //Mengecil
            {
                for (int i = 0; i < calvert.Count; i++)
                {
                    calvert[i].scale(0.9f);
                }
                for (int i = 0; i < liauw.Count; i++)
                {
                    liauw[i].scale(0.9f);
                }
                for (int i = 0; i < jovian.Count; i++)
                {
                    jovian[i].scale(0.9f);
                }
                for (int i = 0; i < t.Count; i++)
                {
                    t[i].scale(0.9f);
                }
                for (int i = 0; i < liauw_curve.Count; i++)
                {
                    liauw_curve[i].scale(0.9f);
                }
                for (int i = 0; i < calvert_curve.Count; i++)
                {
                    calvert_curve[i].scale(0.9f);
                }
                for (int i = 0; i < jovian_curve.Count; i++)
                {
                    jovian_curve[i].scale(0.9f);
                }
            }
            if (input.IsKeyPressed(Keys.E)) //Membesar
            {
                for (int i = 0; i < calvert.Count; i++)
                {
                    calvert[i].scale(1.2f);
                }
                for (int i = 0; i < liauw.Count; i++)
                {
                    liauw[i].scale(1.2f);
                }
                for (int i = 0; i < jovian.Count; i++)
                {
                    jovian[i].scale(1.2f);
                }
                for (int i = 0; i < t.Count; i++)
                {
                    t[i].scale(1.2f);
                }
                for (int i = 0; i < liauw_curve.Count; i++)
                {
                    liauw_curve[i].scale(1.2f);
                }
                for (int i = 0; i < calvert_curve.Count; i++)
                {
                    calvert_curve[i].scale(1.2f);
                }
                for (int i = 0; i < jovian_curve.Count; i++)
                {
                    jovian_curve[i].scale(1.2f);
                }
            }

            if (input.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time; //Forward 
            }

            if (input.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time; //Backwards
            }

            if (input.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time; // Left
            }

            if (input.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time; // Right
            }

            if (input.IsKeyDown(Keys.Up))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time; // Up
            }

            if (input.IsKeyDown(Keys.Down))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time; // Down
            }
            _camera.Debug();

            var mouse = MouseState;
            if (_firstMove) // this bool variable is initially set to true
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);

                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity; // reversed since y-coordinates range from bottom to top
            }

            base.OnUpdateFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }
    }
}