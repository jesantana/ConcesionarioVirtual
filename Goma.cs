using System;
using Tao.OpenGl;
using Materiales;

public class Goma:Element
	{
		Point3D start;
		double rad;

		public Goma(Point3D pst,double radio)
		{
			start=pst;
			rad=radio;
			this.Recompile();
		}

		public override void Recompile()
		{
			Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
			Gl.glPushMatrix();
			CauchoNegro cn=new CauchoNegro();
            Gl.glDisable(Gl.GL_CULL_FACE);
			Gl.glColor3d(cn.Ambient.r,cn.Ambient.g,cn.Ambient.b);
			cn.Set();
			Gl.glTranslated(start.x,start.y,start.z);
			Glu.GLUquadric cil;
			cil=Glu.gluNewQuadric();
			Glu.gluQuadricNormals(cil,Glu.GLU_SMOOTH);
			Glu.gluCylinder(cil,rad,rad,rad/2,32,32);
			
			cil=Glu.gluNewQuadric();
			Glu.gluQuadricNormals(cil,Glu.GLU_SMOOTH);
			Glu.gluDisk(cil,0.55*rad,rad,32,32);

			Gl.glTranslated(0,0,rad/2);
			cil=Glu.gluNewQuadric();
			Glu.gluQuadricNormals(cil,Glu.GLU_SMOOTH);
			Glu.gluDisk(cil,0.55*rad,rad,32,32);
			cn.UnSet();
			
			Gl.glEnable(Gl.GL_CULL_FACE);
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

