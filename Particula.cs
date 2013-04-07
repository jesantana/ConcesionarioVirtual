using System;
using Tao.OpenGl;

public class Particula:Element
	{
	public static int MaxParticles = 500;	// Number of particles to create
	public bool	rainbow = true;				// Rainbow Mode?
	public bool	sp = false;					// Spacebar Pressed?
	public bool	rp = false;					// Enter Key Pressed?

	public float slowdown = 2.0f;			// Slow Down Particles
	public float xspeed = 0.0f;				// Base X Speed (To Allow Keyboard Direction Of Tail)
	public float yspeed = 0.0f;				// Base Y Speed (To Allow Keyboard Direction Of Tail)
	public float zoom = -140.0f;				// Used To Zoom Out

	public uint col = 0;					// Current Color Selection
	public uint delay = 0;					// Rainbow Effect Delay
	public Random rand = null;				// Random number generator
		
		
	Particle[] particle = null;				// Particle Array (Room For Particle Info)

	Point3D start;
	
	public static float[][] colors = new float[12][] {	// Rainbow Of Colors
														 new float[3] {1.0f,0.5f,0.5f}, new float[3] {1.0f,0.75f,0.5f}, 
														 new float[3] {1.0f,1.0f,0.5f}, new float[3] {0.75f,1.0f,0.5f},
														 new float[3] {0.5f,1.0f,0.5f}, new float[3] {0.5f,1.0f,0.75f}, 
														 new float[3] {0.5f,1.0f,1.0f}, new float[3] {0.5f,0.75f,1.0f},
														 new float[3] {0.5f,0.5f,1.0f}, new float[3] {0.75f,0.5f,1.0f}, 
														 new float[3] {1.0f,0.5f,1.0f}, new float[3] {1.0f,0.5f,0.75f} };

	public bool finished;
	public class Particle					// Create A Structure For Particle
	{
		public bool	active;					// Active (Yes/No)
		public float life;					// Particle Life
		public float fade;					// Fade Speed
		public float r, g, b;				// Color
		public float x, y, z;				// Position
		public float xi, yi, zi;			// Direction
		public float xg, yg, zg;			// Gravity
	}


	
	public Particula(Point3D pst)
		{
			this.finished = false;
			this.particle = new Particle[Particula.MaxParticles];
			for (int i=0; i < Particula.MaxParticles; i++)
				this.particle[i] = new Particle();
		start=pst;
		this.rand = new Random();
		for (int loop=0; loop < Particula.MaxParticles; loop++)		// Initials All The Textures
		{
			this.particle[loop].active = true;								// Make All The Particles Active
			this.particle[loop].life = 0.5f;								// Give All The this.particles Full Life
			this.particle[loop].fade = (float)(this.rand.Next(100))/1000.0f+0.003f;	// Random Fade Speed
			this.particle[loop].r = Particula.colors[loop*(12/Particula.MaxParticles)][0];	// Select Red Rainbow Color
			this.particle[loop].g = Particula.colors[loop*(12/Particula.MaxParticles)][1];	// Select Red Rainbow Color
			this.particle[loop].b = Particula.colors[loop*(12/Particula.MaxParticles)][2];	// Select Red Rainbow Color
			this.particle[loop].xi = (float)(this.rand.Next(50)*-10.0f);	// Random Speed On X Axis
			this.particle[loop].yi = (float)((this.rand.Next(50))-25.0f)*5.0f;	// Random Speed On Y Axis
			this.particle[loop].zi = (float)((this.rand.Next(50))-25.0f)*5.0f;	// Random Speed On Z Axis
			this.particle[loop].xg = 0.1f;									// Set Horizontal Pull To Zero
			this.particle[loop].yg = 0.3f;									// Set Vertical Pull Downward
			this.particle[loop].zg = 0.0f;									// Set Pull On Z Axis To Zero
			this.particle[loop].x=(float)pst.x;
			this.particle[loop].y=(float)pst.y;
			this.particle[loop].y=(float)pst.z;
		}


		}

	public override void Recompile()
	{

	}

	public override void Draw()
	{
		
		//Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
		
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,Otros.texture[13]);
		//Gl.glDisable(Gl.GL_DEPTH_TEST);									// Enables Depth Testing
		Gl.glEnable(Gl.GL_BLEND);										// Enable Blending
		Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);						// Type Of Blending To Perform
		Gl.glHint(Gl.GL_POINT_SMOOTH_HINT, Gl.GL_NICEST);
		Gl.glDisable(Gl.GL_CULL_FACE);

		for (int loop=0; loop < Particula.MaxParticles; loop++)	// Loop Through All The Particles
		{
			if (this.particle[loop].active)							// If The Particle Is Active
			{
				float x = this.particle[loop].x;					// Grab Our Particle X Position
				float y = this.particle[loop].y;					// Grab Our Particle Y Position
				float z = this.particle[loop].z;				// Particle Z Pos + Zoom

				// Draw The Particle Using Our RGB Values, Fade The Particle Based On It's Life
				Gl.glColor4f(this.particle[loop].r, this.particle[loop].g, this.particle[loop].b, this.particle[loop].life);

				Gl.glBegin(Gl.GL_TRIANGLE_STRIP);						// Build Quad From A TrianGL.gle Strip
				Gl.glTexCoord2d(1, 1); Gl.glVertex3f(x+0.05f, y+0.05f, z); // Top Right
				Gl.glTexCoord2d(0, 1); Gl.glVertex3f(x-0.05f, y+0.05f, z); // Top Left
				Gl.glTexCoord2d(1, 0); Gl.glVertex3f(x+0.05f, y-0.05f, z); // Bottom Right
				Gl.glTexCoord2d(0, 0); Gl.glVertex3f(x-0.05f, y-0.05f, z); // Bottom Left
				Gl.glEnd();										// Done Building TrianGL.gle Strip

				this.particle[loop].x += this.particle[loop].xi/(slowdown*1000);// Move On The X Axis By X Speed
				this.particle[loop].y += this.particle[loop].yi/(slowdown*1000);// Move On The Y Axis By Y Speed
				this.particle[loop].z += this.particle[loop].zi/(slowdown*1000);// Move On The Z Axis By Z Speed

				this.particle[loop].xi += this.particle[loop].xg;			// Take Pull On X Axis Into Account
				this.particle[loop].yi += this.particle[loop].yg;			// Take Pull On Y Axis Into Account
				this.particle[loop].zi += this.particle[loop].zg;			// Take Pull On Z Axis Into Account
				this.particle[loop].life -= this.particle[loop].fade;		// Reduce Particles Life By 'Fade'

				if (this.particle[loop].life < 0.0f)					// If Particle Is Burned Out
				{
					this.particle[loop].life = 0.5f;					// Give It New Life
					this.particle[loop].fade = (float)(this.rand.Next(100))/1000.0f+0.003f;	// Random Fade Value
					this.particle[loop].x = (float)start.x;						// Center On X Axis
					this.particle[loop].y = (float)start.y;						// Center On Y Axis
					this.particle[loop].z = (float)start.z;						// Center On Z Axis
					this.particle[loop].xi = this.xspeed+(float)(-1*this.rand.Next(50));	// X Axis Speed And Direction
					this.particle[loop].yi = this.yspeed+(float)((this.rand.Next(60)-30.0f)/2.0f);	// Y Axis Speed And Direction
					this.particle[loop].zi = (float)((this.rand.Next(60)-30.0f)/2.0f);	// Z Axis Speed And Direction
					this.particle[loop].r = Particula.colors[this.col][0];			// Select Red From Color Table
					this.particle[loop].g = Particula.colors[this.col][1];			// Select Green From Color Table
					this.particle[loop].b = Particula.colors[this.col][2];			// Select Blue From Color Table
				}
			}
		}

		if (this.rainbow && (this.delay > 25))
		{
			this.delay = 0;						// Reset The Rainbow Color Cycling Delay
			this.col = (this.col + 1) % 12;		// Change The Particle Color
		}

		delay++;							// Increase Rainbow Mode Color Cycling Delay Counter
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,0);
		Gl.glEnable(Gl.GL_DEPTH_TEST);									// Enables Depth Testing
		Gl.glDisable(Gl.GL_BLEND);	// Enable Blending
		Gl.glEnable(Gl.GL_CULL_FACE);
		
//		Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);						// Type Of Blending To Perform
//		Gl.glHint(Gl.GL_POINT_SMOOTH_HINT, Gl.GL_NICEST);
		
	}

	public override Point3D PuntoRotacion
	{
		get
		{
			return new Point3D (0,0,0);
		}
	}




	



	}

