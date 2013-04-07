using System;
using Tao.OpenGl;
using Tao.Glut;


	public class Timon:Element
	{
		Point3D start;
		double radio;
		float[] color;

		public Timon(Point3D pst,double radius,float[] col)
		{
			start=pst;
			radio=radius;
			color=col;
			this.Recompile();
		
		}

		public override void Recompile()
		{
			Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
			Gl.glPushMatrix();
			Gl.glColor3fv(color);
			Gl.glTranslated(start.x,start.y,start.z);
			Glut.glutSolidTorus(radio/8.0,radio,32,32);
			Glu.GLUquadric sph;
			sph=Glu.gluNewQuadric();
			Glu.gluSphere(sph,radio/6.0,32,32);
			
			for(int i=0;i<3;i++)
			{
				Gl.glPushMatrix();
				Gl.glRotated(120*i,0,0,1);
				Gl.glRotated(-90,1,0,0);
				sph=Glu.gluNewQuadric();
				Glu.gluCylinder(sph,radio/8.0,radio/8.0,radio,32,32);
				Gl.glPopMatrix();
			}
			
			Gl.glPopMatrix();
			Gl.glEndList();
		}

		public override Point3D PuntoRotacion
		{
			get
			{
				return start;
			}
		}


	}

