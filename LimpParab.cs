using System;
using Tao.OpenGl;

public class LimpParab:Element
{
	Point3D start;	
	Ortoedro[] p;
	double largo;
	
	public LimpParab(Point3D pst,double lar)
	{
		start=pst;
		p=new Ortoedro[4];
		largo=lar;
		p[0]=new Ortoedro(pst,lar,lar/20.0,lar/20.0,new float[]{0.9f,0.6f,0.6f});
		p[1]=new Ortoedro(new Point3D(pst.x+lar,pst.y,pst.z),lar/6.0,lar/30.0,lar/30.0,new float[]{0.9f,0.6f,0.6f});
		p[2]=new Ortoedro(new Point3D(pst.x+lar,pst.y,pst.z),lar/6.0,lar/30.0,lar/30.0,new float[]{0.9f,0.6f,0.6f});
		p[3]=new Ortoedro(new Point3D(pst.x+8*lar/10.0,pst.y,pst.z-Math.Sqrt(lar/60)),lar,lar/20.0,lar/20.0,new float[]{0.6f,0.6f,0.6f});
		this.Recompile();
	}

	public override void Recompile()
	{
		foreach(Ortoedro o in p)
			o.Recompile();
		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
		Gl.glPushMatrix();
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
			p[0].Draw();
			
			
			p[1].Rota(45,0,1,0);
			p[1].Draw();
			p[1].Rota(-45,0,1,0);

			Gl.glTranslated(-0.1,0,-largo/30);
			p[2].Rota(135,0,1,0);
			p[2].Draw();
			p[2].Rota(-135,0,1,0);
			Gl.glTranslated(-0.1,0,largo/30);

			p[3].Draw();
			Gl.glCallList(idVisualizar);
			Gl.glPopMatrix();
		}
	}


}

