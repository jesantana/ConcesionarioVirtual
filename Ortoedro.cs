using System;
using Tao.OpenGl;
using Tao.Glut;

	public class Ortoedro:Element
	{
		Point3D start;
		double ancho,alto,largo;
		float[] col;
	
		public Ortoedro(Point3D inicio,double anch,double lar,double alt,float[] color):base()
		{
			start=inicio;
			ancho=anch;
			largo=lar;
			alto=alt;
			col=color;
			this.Recompile();
		}

		public override void Recompile()
		{
			Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
			Gl.glPushMatrix();
			Gl.glTranslated(start.x+ancho/2.0,start.y-alto/2.0,start.z-largo/2.0);
			Gl.glScaled(this.ancho,this.alto,this.largo);
			
			Gl.glColor3fv(col);
			Glut.glutSolidCube(1);

//			Gl.glColor3d(1.0,1.0,0.2);
//			Gl.glBegin(Gl.gl.Gl.gl_POINTS);
//				Gl.glVertex3d(0,0,0);
//				Gl.glVertex3d(-0.5,0.5,0.5);
//			Gl.glEnd();
						
			Gl.glPopMatrix();
			Gl.glEndList();
		}

		public override void Draw()
		{
			Gl.glPushMatrix();
			this.Rota();
			Gl.glCallList(idVisualizar);
			Gl.glPopMatrix();
			
			
//			Gl.glBegin(Gl.gl.Gl.gl_POINTS);
//			Gl.glVertex3d(this.PuntoRotacion.x,this.PuntoRotacion.y,this.PuntoRotacion.z);
//			Gl.glEnd();
		}


		public override Point3D PuntoRotacion
		{
			get
			{
				return new Point3D(start.x,start.y,start.z);
			}
		}

		public Point3D Inicio{
			get{return this.start;}
            }
		public double Alto{
			get{return this.alto;}
		}
		public double Ancho
		{
			get{return this.ancho;}
		}

		public float[] Color{
			get{return this.col;}
		}

		public double Largo
		{
			get{return this.largo;}
		}
	}

