using System;
using Materiales;
using Tao.OpenGl;

public class InteriorMB:Interior
{
		
		
		Asiento[] delant;
		
		Timon t;
		Goma respuesto;
		LimpParab[] lp;
		int lpang=21;
		int lpincf=1;

	public InteriorMB(Point3D pst):base(pst)
		{
			
			delant=new Asiento[2];
			lp=new LimpParab[2];
			lp[0]=new LimpParab(new Point3D(pst.x+1,pst.y+0.5,pst.z+0.25),1);
			lp[1]=new LimpParab(new Point3D(pst.x-1,pst.y+0.4,pst.z+0.17),1);
			for(int i=0;i<2;i++)
			{
				delant[i]=new Asiento(new Point3D(start.x-1.5,start.y-0.5,start.z+0.3-i*2),1.5,1.5,2.5,new float[]{0.55f,0.55f,0.55f});
			}
			t=new Timon(new Point3D(start.x+1.7,start.y+0.2,start.z-1),0.6,new float[]{0.3f,0.3f,0.2f});
			respuesto=new Goma(new Point3D(start.x-5,start.y-0.5,start.z),0.8);
			Recompile();
		}

	public override void Recompile()
	{
		foreach(Asiento a in delant)
			a.Recompile();
		foreach(LimpParab a in lp)
			a.Recompile();
		t.Recompile();
		respuesto.Recompile();
		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
		Gl.glPushMatrix();
		
		Gl.glDisable(Gl.GL_CULL_FACE);		
		Material pn=new PlasticoNegro();
		Gl.glColor3d(pn.Ambient.r,pn.Ambient.g,pn.Ambient.b);
		pn.Set();

		Gl.glBegin(Gl.GL_POLYGON);
			Gl.glNormal3d(0,-1,0);
			Gl.glVertex3d(start.x-1.7,start.y-1.9,start.z-2.5);
			Gl.glVertex3d(start.x+3.35,start.y-1.9,start.z-2.5);
			Gl.glVertex3d(start.x+3.35,start.y-1.9,start.z+2.5);
			Gl.glVertex3d(start.x-1.7,start.y-1.9,start.z+2.5);
		Gl.glEnd();

		Gl.glBegin(Gl.GL_POLYGON);
		
		Gl.glVertex3d(start.x-1.7,start.y-1.9,start.z-2.4);
		Gl.glVertex3d(start.x-1.7,start.y-1.9,start.z+2.4);
		Gl.glVertex3d(start.x-3.7,start.y+0.1,start.z+2.4);
		Gl.glVertex3d(start.x-3.7,start.y+0.1,start.z-2.4);
		Gl.glEnd();
		

		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glNormal3d(0,1,0);
		Gl.glVertex3d(start.x+7,start.y-0.2,start.z-2.4);
		Gl.glVertex3d(start.x+7,start.y-0.9,start.z-2.4);
		Gl.glVertex3d(start.x+7,start.y-0.9,start.z+2.4);
		Gl.glVertex3d(start.x+7,start.y-0.2,start.z+2.4);
		Gl.glEnd();
		
		
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,Otros.texture[4]);
		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glNormal3d(0,1,0);
		Gl.glTexCoord2d(0,0);
		Gl.glVertex3d(start.x+3,start.y-0.2,start.z-2.4);
		Gl.glTexCoord2d(1,0);
		Gl.glVertex3d(start.x+3,start.y-0.2,start.z+2.4);
		Gl.glTexCoord2d(1,1);
		Gl.glVertex3d(start.x+2,start.y-1.9,start.z+2.4);
		Gl.glTexCoord2d(0,1);
		Gl.glVertex3d(start.x+2,start.y-1.9,start.z-2.4);
		Gl.glEnd();
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);

		pn.UnSet();

		
		pn=new Plata();
		Gl.glColor3d(pn.Ambient.r,pn.Ambient.g,pn.Ambient.b);
		pn.Set();
		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glNormal3d(0,1,0);
		Gl.glVertex3d(start.x-6,start.y-1,start.z-2);
		Gl.glVertex3d(start.x-4,start.y-1,start.z-2);
		Gl.glVertex3d(start.x-4,start.y-1,start.z+2);
		Gl.glVertex3d(start.x-6,start.y-1,start.z+2);
		Gl.glEnd();
		pn.UnSet();

		
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,Otros.texture[3]);
		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glNormal3d(0,1,0);
		Gl.glTexCoord2d(1,0);Gl.glVertex3d(start.x+7,start.y-0.2,start.z-2.4);
		Gl.glTexCoord2d(1,1);Gl.glVertex3d(start.x+3,start.y-0.2,start.z-2.4);
		Gl.glTexCoord2d(0,1);Gl.glVertex3d(start.x+3,start.y-0.2,start.z+2.4);
		Gl.glTexCoord2d(0,0);Gl.glVertex3d(start.x+7,start.y-0.2,start.z+2.4);
		Gl.glEnd();
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);
		
		


		Gl.glColor3d(0.7,0.7,0.5);
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,Otros.texture[0]);
		Gl.glBegin(Gl.GL_POLYGON);
			Gl.glNormal3d(0,-1,0);
			Gl.glTexCoord2d(0,0);Gl.glVertex3d(start.x+2.3,start.y+0.2,start.z-2.45);
			Gl.glTexCoord2d(1,0);Gl.glVertex3d(start.x+2.3,start.y+0.2,start.z+2.45);
			Gl.glTexCoord2d(1,1);Gl.glVertex3d(start.x+2,start.y-0.5,start.z+2.45);
			Gl.glTexCoord2d(0,1);Gl.glVertex3d(start.x+2,start.y-0.5,start.z-2.45);
		Gl.glEnd();
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);


		Gl.glColor3d(0,0,0);
		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glNormal3d(0,1,0);
		Gl.glVertex3d(start.x+2.35,start.y+0.2,start.z-2.45);
		Gl.glVertex3d(start.x+2.35,start.y+0.2,start.z+2.45);
		Gl.glVertex3d(start.x+2.05,start.y-0.5,start.z+2.45);
		Gl.glVertex3d(start.x+2.05,start.y-0.5,start.z-2.45);
		Gl.glEnd();


		
		Gl.glBegin(Gl.GL_POLYGON);
		Gl.glNormal3d(0,1,0);
		Gl.glVertex3d(start.x+2.35,start.y+0.4,start.z-1);
		Gl.glVertex3d(start.x+2.35,start.y+0.4,start.z+1);
		Gl.glVertex3d(start.x+2.25,start.y,start.z+1);
		Gl.glVertex3d(start.x+2.25,start.y,start.z-1);
		Gl.glEnd();


		Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
		Gl.glNormal3d(0,1,0);
		Gl.glVertex3d(start.x+2.35,start.y+0.4,start.z+1);
		Gl.glVertex3d(start.x+2.25,start.y,start.z+2.3);
		Gl.glVertex3d(start.x+2.25,start.y,start.z+1);
		Gl.glEnd();


		Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
		Gl.glNormal3d(0,1,0);
		Gl.glVertex3d(start.x+2.35,start.y+0.4,start.z-1);
		Gl.glVertex3d(start.x+2.25,start.y,start.z-2.3);
		Gl.glVertex3d(start.x+2.25,start.y,start.z-1);
		Gl.glEnd();
				
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
			t.Rota(90,0,1,0);
			
			t.Draw();
			
			if(onlp)
			{
				lpang+=lpincf;
				if(lpang>=90 || lpang<=20)
					lpincf=-lpincf;
			}
			

			lp[1].Rota(-10,0,1,0);
			
			
			
			Gl.glPushMatrix();
			lp[1].Rota(56,-1,0,0);
			lp[1].Rota(lpang,0,0,1);
			lp[1].Draw();
			Gl.glPopMatrix();
			

			
			
			lp[1].Rota(10,0,1,0);

			lp[0].Rota(10,0,1,0);
			
			Gl.glPushMatrix();
			lp[0].Rota(55,-1,0,0);
			lp[0].Rota(lpang,0,0,1);
			lp[0].Draw();
			Gl.glPopMatrix();
			

			lp[0].Rota(-10,0,1,0);

			
			t.Rota(-90,0,1,0);
			respuesto.Rota(90,1,0,0);
			respuesto.Draw();
			respuesto.Rota(-90,1,0,0);
			foreach(Asiento a in delant)
				a.Draw();
			Gl.glCallList(idVisualizar);
			Gl.glPopMatrix();
		}
	}



}

