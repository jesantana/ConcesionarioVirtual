using System;
using Tao.OpenGl;
using Tao.Glut;

public class Asiento:Element
{
	Point3D start;
	double largo;
	double ancho;
	double alto;
	float[] color;
	Ortoedro abaj;
	
	public Asiento(Point3D pst,double lar,double anc,double alt,float[] col)
	{
		this.start=pst;
		largo=lar;
		ancho=anc;
		alto=alt;
		color=col;
		abaj=new Ortoedro(new Point3D(pst.x,pst.y-alt/2+alt/3.0,pst.z+lar),anc,lar,alt/6.0,col);
		this.Recompile();
	}

	public override void Recompile()
	{
		this.abaj.Recompile();
		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
		Gl.glPushMatrix();

		Gl.glDisable(Gl.GL_CULL_FACE);
		
		Glu.GLUquadric sph=Glu.gluNewQuadric();
		Glu.gluQuadricOrientation(sph,Glu.GLU_OUTSIDE);
		Gl.glTranslated(start.x,start.y,start.z);
		Gl.glTranslated(-(Math.Sqrt(Math.Pow(this.alto,2)-Math.Pow(this.alto,2)/4)),0,0);
		Gl.glRotated(15,0,0,1);
		Gl.glColor3fv(color);
		Gl.glClipPlane(Gl.GL_CLIP_PLANE0,new double[]{1.0,0.0,0,-(Math.Sqrt(Math.Pow(this.alto,2)-Math.Pow(this.alto,2)/4))});
		Gl.glEnable(Gl.GL_CLIP_PLANE0);
		Glu.gluQuadricNormals(sph,Glu.GLU_SMOOTH);
		Glu.gluCylinder(sph,this.alto,this.alto,this.largo,32,32);
		sph=Glu.gluNewQuadric();
		Glu.gluQuadricNormals(sph,Glu.GLU_SMOOTH);
		Glu.gluDisk(sph,0,this.alto,32,32);

		sph=Glu.gluNewQuadric();
		Glu.gluQuadricNormals(sph,Glu.GLU_SMOOTH);
		Gl.glTranslated(0,0,this.largo);
		Glu.gluDisk(sph,0,this.alto,32,32);
		Gl.glDisable(Gl.GL_CLIP_PLANE0);
		
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

	public override void Draw()
	{
		if(idVisualizar != 0)
		{
			Gl.glPushMatrix();
			this.Rota();
			abaj.Draw();
			Gl.glCallList(idVisualizar);
			Gl.glPopMatrix();
		}
	}


}

