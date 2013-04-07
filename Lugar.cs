using System;
using Tao.OpenGl;


public class Lugar:Element
	{
		Pared[] par;
		public Base111 bas;
		Cuadro[] cuad;
		Buro bur;
		Silla sil;
		Mata m;
		Sofa sof;



		public Lugar()
		{
			par=new Pared[7];
			par[0]=new Pared(new Point3D(0,7.5,-40),0,40);
			par[1]=new Pared(new Point3D(-20,7.5,-20),90,40);
			par[2]=new Pared(new Point3D(20,7.5,-20),90,40);
			par[3]=new Pared(new Point3D(0,15,-20),0,50,1,42,7);
			par[4]=new Pared(new Point3D(0,0,-20),0,42,1,42,6);
			par[5]=new Pared(new Point3D(-14.5,3.5,0),0,2.5,0.3,1,8);
			par[6]=new Pared(new Point3D(-11.5,3.5,0),0,2.5,0.3,1,8);
			cuad=new Cuadro[3];
			cuad[0]=new Cuadro(new Point3D(-18.5,7,-25),5,3,90,10,7);
			cuad[1]=new Cuadro(new Point3D(-10,7,-38.5),7,4,0,11,8);
			cuad[2]=new Cuadro(new Point3D(10,7,-38.5),7,3,0,12,7);
			bur=new Buro(new Point3D(-13,3,-22),6,3.5,8);
			sil=new Silla(new Point3D(-16,4,-21),2,2,2,new float[]{0.3f,0.2f,0f},new float[]{0.4f,0f,0f});
			m=new Mata();
			sof=new Sofa();
			bas=new Base111(new Point3D(0,-1.3,-20),7,new float[]{1.0f,0.4f,0.2f,1.0f});
			this.Recompile();
		}

	public override void Recompile()
	{
		foreach(Pared p in par)
			p.Recompile();
		foreach(Cuadro c in cuad)
			c.Recompile();
		sof.Recompile();
		sil.Recompile();
		bur.Recompile();
		bas.Recompile();
		m.Recompile();

		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
		Gl.glPushMatrix();
		Gl.glDisable(Gl.GL_CULL_FACE);

		Gl.glColor4d(0.6,0.6,0.9,0.85);
		Gl.glEnable(Gl.GL_BLEND);
		Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
		
		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glVertex3d(-20,15,0);
		Gl.glVertex3d(20,15,0);
		Gl.glVertex3d(20,9,0);
		Gl.glVertex3d(-20,9,0);
		Gl.glEnd();

		Gl.glBindTexture(Gl.GL_TEXTURE_2D,Otros.texture[14]);
		Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_BLEND);
		Gl.glTexEnvfv(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_COLOR, new float[]{0.6f,0.6f,0.9f,0.85f});
		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glTexCoord2d(0,0);Gl.glVertex3d(-20,9,0);
		Gl.glTexCoord2d(8,0);Gl.glVertex3d(20,9,0);
		Gl.glTexCoord2d(8,1);Gl.glVertex3d(20,7,0);
		Gl.glTexCoord2d(0,1);Gl.glVertex3d(-20,7,0);
		Gl.glEnd();
		Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_DECAL);
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);

		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glVertex3d(-20,7,0);
		Gl.glVertex3d(-16,7,0);
		Gl.glVertex3d(-16,0,0);
		Gl.glVertex3d(-20,0,0);
		Gl.glEnd();

		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glVertex3d(-10,7,0);
		Gl.glVertex3d(20,7,0);
		Gl.glVertex3d(20,0,0);
		Gl.glVertex3d(-10,0,0);
		Gl.glEnd();

		#region Puertas
		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glVertex3d(-15.95,6.95,0);
		Gl.glVertex3d(-13.05,6.95,0);
		Gl.glVertex3d(-13.05,0,0);
		Gl.glVertex3d(-15.95,0,0);
		Gl.glEnd();

		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glVertex3d(-12.95,6.95,0);
		Gl.glVertex3d(-10.05,6.95,0);
		Gl.glVertex3d(-10.05,0,0);
		Gl.glVertex3d(-12.95,0,0);
		Gl.glEnd();
		#endregion Puertas

		Gl.glEnable(Gl.GL_CULL_FACE);
		Gl.glPopMatrix();
		Gl.glEndList();
	}

	public override void Draw()
	{
		if(idVisualizar != 0)
		{
			Gl.glPushMatrix();
			this.Rota();
			
			
			

			Gl.glTranslated(-8,-3.9,4);
			
			foreach(Cuadro c in cuad)
				c.Draw();
			
			sil.Draw();
			
			bur.Rota(90,0,1,0);
			bur.Draw();
			bur.Rota(-90,0,1,0);
		
		
			foreach(Pared p in par)
				p.Draw();
			
			Gl.glTranslated(8,3.9,-4);
			bas.Draw();
			Gl.glTranslated(-8,-3.9,4);
			//m.Draw();
			//sof.Draw();
			Gl.glCallList(idVisualizar);
			
			Gl.glPopMatrix();
		}
	}

	public override Point3D PuntoRotacion
	{
		get
		{
			return new Point3D(0,7.5,-20);
		}
	}


	}

