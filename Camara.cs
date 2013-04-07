using System;
using Tao.OpenGl;


	public class Camara
	{
		public Camara()
		{
			
		}


		//SetPos(new Point3D(0,0,cz),new Point3D(0,0,-17),0,1,0);
		public void SetPos(Point3D start,Point3D obj,double vecx,double vecy,double vecz)
		{
		
		Gl.glLoadIdentity();
		Glu.gluLookAt(start.x,start.y,start.z,obj.x,obj.y,obj.z,vecx,vecy,vecz);
				
		}
	}

