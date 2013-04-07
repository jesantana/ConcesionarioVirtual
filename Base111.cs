using System;
using Tao.OpenGl;
using Materiales;
using Tao.Glut;

public class Base111:Element
{
	public Carro car;
	int rad;
	Point3D start;
	float[] col;
	public int crang;
	public bool rotando=true;
	int inc =2;
	Glu.GLUquadric	q;										// Quadratic For Drawing A Sphere

	float		zoom		= -4.0f;						// Depth Into The Screen
	float		height		=  2.7f;	


	public Base111(Point3D pst,int radio,float[] color)
	{
		start=pst;
		col=color;
		rad=radio;
		car=new mb380();
		crang=0;
		
		this.Recompile();
	}


	void DrawFloor()										// Draws The Floor
	{
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,Otros.texture[9]);
		Gl.glPushMatrix();
		Gl.glDisable(Gl.GL_CULL_FACE);
		q=Glu.gluNewQuadric();
		Glu.gluQuadricOrientation(q,Glu.GLU_OUTSIDE);
		Glu.gluQuadricTexture(q,Glu.GLU_TRUE);
		Glu.gluQuadricNormals(q,Glu.GLU_SMOOTH);
		Glu.gluDisk(q,0,7,32,32);
		
	Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);
		Gl.glEnable(Gl.GL_CULL_FACE);
		Gl.glPopMatrix();
	}


	public override void Recompile()
	{
		car.Recompile();
		idVisualizar=Gl.glGenLists(3);
		
		#region Lista 1
		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
		Gl.glPushMatrix();
		//			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
		//double[] eqr = {0,-1,0,0};


		Gl.glDisable(Gl.GL_CULL_FACE);
		Gl.glTranslated(start.x,start.y,start.z);
		Gl.glRotated(90,1,0,0);
		Material m=new Jade();
			
		Gl.glColor3d(0.2,0.4,0.8);
		m.Set();
		Glu.GLUquadric cil;
		cil=Glu.gluNewQuadric();
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,Otros.texture[2]);
		Glu.gluQuadricOrientation(cil,Glu.GLU_INSIDE);
		Glu.gluQuadricTexture(cil,Otros.texture[1]);
			
		Glu.gluCylinder(cil,rad,rad,rad/3,32,32);
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);
		
		
		
		double[] eqr = {0.0f,-1.0f, 0.0f, 0.0f};			// Plane Equation To Use For The Reflected Objects

		//Gl.glLoadIdentity();									// Reset The Modelview Matrix
		//Gl.glTranslatef(0.0f, -0.6f, zoom);					// Zoom And Raise Camera Above The Floor (Up 0.6 Units)
		//Gl.glColorMask(0,0,0,0);								// Set Color Mask
		Gl.glEnable(Gl.GL_STENCIL_TEST);							// Enable Stencil Buffer For "marking" The Floor
		Gl.glStencilFunc(Gl.GL_ALWAYS, 1, 1);						// Always Passes, 1 Bit Plane, 1 As Mask
		Gl.glStencilOp(Gl.GL_KEEP, Gl.GL_KEEP, Gl.GL_REPLACE);			// We Set The Stencil Buffer To 1 Where We Draw Any Polygon
		// Keep If Test Fails, Keep If Test Passes But Buffer Test Fails
		// Replace If Test Passes
		Gl.glDisable(Gl.GL_DEPTH_TEST);							// Disable Depth Testing
		DrawFloor();										// Draw The Floor (Draws To The Stencil Buffer)
		// We Only Want To Mark It In The Stencil Buffer
		Gl.glEnable(Gl.GL_DEPTH_TEST);							// Enable Depth Testing
		Gl.glColorMask(1,1,1,1);								// Set Color Mask to TRUE, TRUE, TRUE, TRUE
		Gl.glStencilFunc(Gl.GL_EQUAL, 1, 1);						// We Draw Only Where The Stencil Is 1
		// (I.E. Where The Floor Was Drawn)
		Gl.glStencilOp(Gl.GL_KEEP, Gl.GL_KEEP, Gl.GL_KEEP);				// Don't Change The Stencil Buffer
		Gl.glEnable(Gl.GL_CLIP_PLANE0);							// Enable Clip Plane For Removing Artifacts
		// (When The Object Crosses The Floor)
		Gl.glClipPlane(Gl.GL_CLIP_PLANE0, eqr);					// Equation For Reflected Objects
		Gl.glPushMatrix();										// Push The Matrix Onto The Stack
		Gl.glScalef(1.0f, 1.0f, -1.0f);					// Mirror Y Axis
		Gl.glTranslatef(0.0f,  0.0f,-height);				// Position The Object
		Gl.glEndList();
		#endregion Lista1
		
		DrawObject();									// Draw The Sphere (Reflection)
		
		#region Lista 2

		Gl.glNewList(idVisualizar+1,Gl.GL_COMPILE);
		Gl.glPopMatrix();										// Pop The Matrix Off The Stack
		Gl.glDisable(Gl.GL_CLIP_PLANE0);							// Disable Clip Plane For Drawing The Floor
		Gl.glDisable(Gl.GL_STENCIL_TEST);							// We Don't Need The Stencil Buffer Any More (Disable)
		Gl.glEnable(Gl.GL_BLEND);									// Enable Blending (Otherwise The Reflected Object Wont Show)
		Gl.glColor4f(0f, 0f, 0f, 0.6f);					// Set Color To White With 80% Alpha
		Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);	// Blending Base111d On Source Alpha And 1 Minus Dest Alpha
		Gl.glRotated(180,1,0,0);
		DrawFloor();										// Draw The Floor To The Screen
		Gl.glRotated(180,1,0,0);
		Gl.glEnable(Gl.GL_LIGHTING);								// Enable Lighting
		Gl.glDisable(Gl.GL_BLEND);								// Disable Blending
		Gl.glTranslatef(0.0f,  0.0f,-height);					// Position The Ball At Proper Height
		Gl.glEndList();
		#endregion Lista 2
		
		DrawObject();										// Draw The Ball
		
		#region Lista 3
		Gl.glNewList(idVisualizar+2,Gl.GL_COMPILE);
		m.UnSet();
		Gl.glEnable(Gl.GL_CULL_FACE);
		Gl.glPopMatrix();
		Gl.glEndList();
#endregion Lista 3 
	}

	public override Point3D PuntoRotacion
	{
		get
		{
			return start;
		}
	}

	void DrawObject() // Draw Our Ball
	{
		Gl.glColor3f(1.0f, 1.0f, 1.0f); // Set Color To White
		Gl.glBindTexture(Gl.GL_TEXTURE_2D, Otros.texture[1]); // Select Texture 2 (1)
		Glu.GLUquadric q;
		q = Glu.gluNewQuadric(); // Create A New Quadratic
		Glu.gluQuadricNormals(q,Gl.GL_SMOOTH); // Generate Smooth Normals For The Quad
		Glu.gluQuadricTexture(q,Gl.GL_TRUE);
		
		Glu.gluSphere(q, 0.35f, 32, 16); // Draw First Sphere

		Gl.glBindTexture(Gl.GL_TEXTURE_2D, Otros.texture[0]); // Select Texture 3 (2)
		Gl.glColor4f(1.0f, 1.0f, 1.0f, 0.4f); // Set Color To White With 40% Alpha
		Gl.glEnable(Gl.GL_BLEND); // Enable Blending
		Gl.glBlendFunc(Gl.GL_SRC_ALPHA,Gl.GL_ONE); // Set Blending Mode To Mix Base111d On SRC Alpha
		Gl.glEnable(Gl.GL_TEXTURE_GEN_S); // Enable Sphere Mapping
		Gl.glEnable(Gl.GL_TEXTURE_GEN_T); // Enable Sphere Mapping
		Glu.gluSphere(q, 0.35f, 32, 16); // Draw Another Sphere Using New Texture
		// Textures Will Mix Creating A MultiTexture Effect (Reflection)
		Gl.glDisable(Gl.GL_TEXTURE_GEN_S); // Disable Sphere Mapping
		Gl.glDisable(Gl.GL_TEXTURE_GEN_T); // Disable Sphere Mapping
		Gl.glDisable(Gl.GL_BLEND); // Disable Blending
	}

	public override void Draw()
	{
		if(idVisualizar != 0)
		{
			Gl.glPushMatrix();
			if(rotando)
				crang=(crang+this.inc);
			if(Math.Abs(crang)>=90)
				inc=-inc;
			this.Rota();
			this.Rota(crang,0,1,0);
			//car.Draw();
			//
			Gl.glCallList(idVisualizar);
			
			Gl.glPushMatrix();
			Gl.glRotated(-90,1,0,0);
			Gl.glTranslated(-car.car.Trans[0],-car.car.Trans[1],-car.car.Trans[2]);

			car.Draw();

			Gl.glPopMatrix();
			
			Gl.glCallList(idVisualizar+1);
			
			Gl.glPushMatrix();
			//			Gl.glTranslated(car.car.Trans[0],car.car.Trans[1],car.car.Trans[2]);
			//			Gl.glRotated(car.car.Rot[2], 0, 0, 1);
			//			Gl.glRotated(car.car.Rot[1], 0, 1, 0);
			//			Gl.glRotated(car.car.Rot[0], 1, 0, 0);
			//			Gl.glScaled(car.car.Scl[0], car.car.Scl[1],car.car.Scl[2]);
			
//			Gl.glScaled(-car.car.Scl[0], -car.car.Scl[1],-car.car.Scl[2]);
//			Gl.glRotated(-car.car.Rot[0], 1, 0, 0);
//			Gl.glRotated(-car.car.Rot[1], 0, 1, 0);
//			Gl.glRotated(-car.car.Rot[2], 0, 0, 1);
			Gl.glRotated(-90,1,0,0);
			Gl.glTranslated(-car.car.Trans[0],-car.car.Trans[1],-car.car.Trans[2]);

			car.Draw();

			Gl.glPopMatrix();
			
			Gl.glCallList(idVisualizar+2);
			Gl.glPopMatrix();
		}
	}



}

