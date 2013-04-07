using System;
using Tao.OpenGl;

public class Cuadro:Element
{
	Point3D start;
	double lar,anch;
	int pint,marc;
	Pared[] tab;
	int ang;
	
	public Cuadro(Point3D pst,double largo,double ancho,int angle,int text,int mtext)
	{
		start=pst;
		lar=largo;
		anch=ancho;
		ang=angle;
		pint=text;
		marc=mtext;
		tab=new Pared[4];
		tab[0]=new Pared(new Point3D(start.x+largo/2,start.y-0.1,start.z),0,largo,0.2,0.3,mtext);
		tab[1]=new Pared(new Point3D(start.x+largo,start.y-ancho/2,start.z),0,0.2,ancho,0.3,mtext);
		tab[2]=new Pared(new Point3D(start.x+largo/2,start.y-ancho+0.1,start.z),0,largo,0.2,0.3,mtext);
		tab[3]=new Pared(new Point3D(start.x,start.y-ancho/2,start.z),0,0.2,ancho,0.3,mtext);	
		this.Recompile();
	}


	public override void Recompile()
	{
		foreach(Pared p in tab)
			p.Recompile();
		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
			Gl.glPushMatrix();
		Gl.glDisable(Gl.GL_CULL_FACE);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D,Otros.texture[pint]);
		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glTexCoord2d(0,0); Gl.glVertex3d(start.x,start.y,start.z);
		Gl.glTexCoord2d(1,0); Gl.glVertex3d(start.x+lar,start.y,start.z);
		Gl.glTexCoord2d(1,1); Gl.glVertex3d(start.x+lar,start.y-anch,start.z);
		Gl.glTexCoord2d(0,1); Gl.glVertex3d(start.x,start.y-anch,start.z);
		Gl.glEnd();
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);

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
			this.Rota(ang,0,1,0);
			foreach(Pared p in tab)
				p.Draw();
			Gl.glCallList(idVisualizar);
			Gl.glPopMatrix();
		}
	}


}
