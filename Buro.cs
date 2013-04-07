using System;
using Tao.OpenGl;

public class Buro:Element
{
	Point3D start;
	Pared[] partes;

	public Buro(Point3D pst,double largo,double ancho,int text)
		{
			start=pst;
			partes=new Pared[4];
			partes[0]=new Pared(start,0,largo,0.4,ancho,text);
			partes[1]=new Pared(new Point3D(start.x-largo/2.0+largo/8.0,start.y-0.15-largo/6.0,start.z+ancho/2.0-ancho/6.0),0,0.25,largo/3.0,0.25,text);
			partes[2]=new Pared(new Point3D(start.x-largo/2.0+largo/8.0,start.y-0.15-largo/6.0,start.z+ancho/2.0-5*ancho/6.0),0,0.25,largo/3.0,0.25,text);
			partes[3]=new Pared(new Point3D(start.x+largo/2.0-largo/6.0,start.y-0.15-largo/6.0,start.z),0,largo/3,largo/3.0,ancho,text);	
	}

	public override void Recompile()
	{
		foreach(Pared p in partes)
			p.Recompile();
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
			foreach(Pared p in partes)
				p.Draw();
			Gl.glPopMatrix();
		}
	}



}

