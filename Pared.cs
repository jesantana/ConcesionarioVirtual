using System;
using Tao.OpenGl;

public class Pared:Element
	{
		double x,y,z;
		int text,mos;
		Point3D start;
		int ang;
	
		public Pared(Point3D pst,int angle,double larx)
		{
			start=pst;
			ang=angle;
			x=larx;
			y=15;
			z=2;
			text=5;
			mos=4;
			this.Recompile();
		}

	public Pared(Point3D pst,int angle,double larx,double lary,double larz,int textur)
	{
		start=pst;
		ang=angle;
		x=larx;
		y=lary;
		z=larz;
		text=textur;
		mos=4;
		this.Recompile();
	}

	public override void Recompile()
	{
			Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
			Gl.glPushMatrix();
		Gl.glDisable(Gl.GL_CULL_FACE);
			x=x/2; y=y/2; z=z/2;
			
			if(text != -1)Gl.glBindTexture(Gl.GL_TEXTURE_2D,  Otros.texture[text]);//id textura segundo parametro
			
			Gl.glBegin(Gl.GL_QUAD_STRIP);
			// cuadrado
			Gl.glTexCoord2f(0, mos);
			Gl.glNormal3d(  0, 0,1);
			Gl.glVertex3d(-x, -y, z);

			Gl.glTexCoord2f(0, 0);
			Gl.glNormal3d( 0, 0,1);
			Gl.glVertex3d(-x,  y, z);

			Gl.glTexCoord2f(mos, mos);
			Gl.glNormal3d(  0, 0,1);
			Gl.glVertex3d( x, -y, z);

			Gl.glTexCoord2f(mos, 0);
			Gl.glNormal3d( 0, 0, 1);
			Gl.glVertex3d( x,  y, z);

			//lateral derecha
			Gl.glTexCoord2f(0, mos);
			Gl.glNormal3d(  0, 0,-1);
			Gl.glVertex3d(x, -y, -z);
			Gl.glTexCoord2f(0, 0);
			Gl.glNormal3d(  0, 0,-1);
			Gl.glVertex3d(x, y, -z);
			
			//lateral de atras
			Gl.glTexCoord2f(mos, mos);
			Gl.glNormal3d(  0, 0,-1);
			Gl.glVertex3d(-x, -y, -z);
			Gl.glTexCoord2f(mos, 0);
			Gl.glNormal3d(  0, 0,-1);
			Gl.glVertex3d(-x, y, -z);
				
			//lateral izquierda
			Gl.glTexCoord2f(0, mos);	
			Gl.glNormal3d(  -1, 0,0);
			Gl.glVertex3d(-x, -y, z);
			Gl.glTexCoord2f(0, 0);	
			Gl.glNormal3d(  -1, 0,0);
			Gl.glVertex3d(-x, y, z);

			Gl.glEnd();

			Gl.glBegin(Gl.GL_QUADS);
			
			//horizontal superior
			Gl.glTexCoord2f(0, 0);
			Gl.glNormal3d( 0, 0, -1);
			Gl.glVertex3d(-x, y, z);
		
			Gl.glTexCoord2f(mos, 0);
			Gl.glNormal3d( 0, 0, -1);
			Gl.glVertex3d(x, y, z);
		
			Gl.glTexCoord2f(mos, mos);
			Gl.glNormal3d( 0, 0, -1);
			Gl.glVertex3d(x, y, -z);
		
			Gl.glTexCoord2f(0, mos);
			Gl.glNormal3d( 0, 0, -1);
			Gl.glVertex3d(-x, y, -z);
			Gl.glEnd();

			Gl.glBegin(Gl.GL_QUADS);
	
			//horizontal inferior
		
			Gl.glTexCoord2f(0, 0);
			Gl.glNormal3d( 0, 0, -1);
			Gl.glVertex3d(-x, -y, z);

			Gl.glTexCoord2f(mos, 0);		
			Gl.glNormal3d( 0, 0, -1);
			Gl.glVertex3d(x, -y, z);

			Gl.glTexCoord2f(mos, mos);	
			Gl.glNormal3d( 0, 0, -1);
			Gl.glVertex3d(x, -y, -z);
	
			Gl.glTexCoord2f(0, mos);
			Gl.glNormal3d( 0, 0, -1);
			Gl.glVertex3d(-x, -y, -z);
			
			Gl.glEnd();

			Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
		Gl.glEnable(Gl.GL_CULL_FACE);
		x=x*2;
		y=y*2;
		z=z*2;
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
			
			Gl.glTranslated(start.x,start.y,start.z);
			Gl.glRotated(ang,0,1,0);
			Gl.glCallList(idVisualizar);
			Gl.glPopMatrix();
		}
	}
	}

