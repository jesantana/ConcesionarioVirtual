using System;
using Tao.OpenGl;

public class Silla:Element
	{
		Ortoedro[] patas;
		Ortoedro asient;
		Ortoedro[] madesp;

		public Silla(Point3D pcom,double larmesp,double lasi,double lpat,float[] colmad,float[] coltap)
		{
			patas=new Ortoedro[4];
			double apat=lpat/30.0;
			
			for(int i=0;i<patas.Length;i++)
			{
				patas[i]=new Ortoedro(new Point3D(pcom.x+(lasi/8.0)+((int)(i/2))*lasi*6/8,pcom.y-larmesp,pcom.z-((int)(i%2))*lasi*6/8.0-lasi/8.0),2*apat,apat,lpat,colmad);
			}
			madesp=new Ortoedro[2];
			double anchmesp=larmesp/25.0;
			
			for(int i=0;i<madesp.Length;i++)
			{
			madesp[i]=new Ortoedro(new Point3D(pcom.x,pcom.y,pcom.z-((i%2)*(lasi-anchmesp))),3*anchmesp,anchmesp,larmesp,colmad);
			}

			double aasi=lasi/12.0;
			asient=new Ortoedro(new Point3D(pcom.x,pcom.y-larmesp+aasi,pcom.z),lasi,lasi,aasi,coltap);
			
			this.Recompile();
		}
	
	
		public override void Recompile()
		{
			asient.Recompile();
			foreach(Ortoedro o in patas)
				o.Recompile();
			foreach(Ortoedro o in madesp)
				o.Recompile();
			
			Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
			Gl.glPushMatrix();			
			Gl.glDisable(Gl.GL_CULL_FACE);
			
			Glu.GLUquadric sph=Glu.gluNewQuadric();
			Glu.gluQuadricOrientation(sph,Glu.GLU_OUTSIDE);
			Gl.glTranslated(madesp[0].Inicio.x,madesp[0].Inicio.y-madesp[0].Alto/5.0,madesp[0].Inicio.z-asient.Largo+madesp[0].Largo);
			Gl.glColor3fv(asient.Color);
			Gl.glClipPlane(Gl.GL_CLIP_PLANE0,new double[]{1.0,0.0,0,0.0});
			Gl.glEnable(Gl.GL_CLIP_PLANE0);

			
			Glu.gluCylinder(sph,madesp[0].Alto/5,madesp[0].Alto/5,asient.Ancho-2*madesp[0].Largo,32,32);
			
			sph=Glu.gluNewQuadric();
			
			Glu.gluDisk(sph,0,madesp[0].Alto/5,32,32);

			sph=Glu.gluNewQuadric();
			Gl.glTranslated(0,0,asient.Largo-2*madesp[0].Largo);
			
			Glu.gluDisk(sph,0,madesp[0].Alto/5,32,32);
			
			Gl.glPopMatrix();

			Gl.glBegin(Gl.GL_POLYGON);
			Gl.glTexCoord2d(0,0);Gl.glVertex3d(madesp[0].Inicio.x+0.05,madesp[0].Inicio.y,madesp[0].Inicio.z-madesp[0].Largo);
			Gl.glTexCoord2d(1,0);Gl.glVertex3d(madesp[0].Inicio.x+0.05,madesp[0].Inicio.y-2*madesp[0].Alto/5,madesp[0].Inicio.z-madesp[0].Largo);
			Gl.glTexCoord2d(1,1);Gl.glVertex3d(madesp[0].Inicio.x+0.05,madesp[0].Inicio.y-2*madesp[0].Alto/5,madesp[0].Inicio.z-asient.Largo+madesp[0].Largo);
			Gl.glTexCoord2d(0,1);Gl.glVertex3d(madesp[0].Inicio.x+0.05,madesp[0].Inicio.y,madesp[0].Inicio.z-asient.Largo+madesp[0].Largo);
			Gl.glEnd();

			Gl.glDisable(Gl.GL_CLIP_PLANE0);
			Gl.glEnable(Gl.GL_CULL_FACE);
			
			
			
			
			Gl.glEndList();
		}

		public override void Draw()
		{
			Gl.glPushMatrix();
			this.Rota();
			asient.Draw();
			foreach(Ortoedro o in patas)
				o.Draw();
			foreach(Ortoedro o in madesp)
				o.Draw();
			Gl.glCallList(idVisualizar);
			Gl.glPopMatrix();
		}


		public override Point3D PuntoRotacion
		{
			get
			{
				return asient.PuntoRotacion;
			}
		}

	}

