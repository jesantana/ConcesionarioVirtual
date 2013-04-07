using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;


	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private OGLConFlechita simpleOpenglControl1;
		public Scene scene;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer timer1;
		RC rc;
		
		public Form1()
		{
			scene = new Scene();
			scene.redraw += new EventHandler(scene_redraw);
			
			InitializeComponent();
			
			
			simpleOpenglControl1.InitializeContexts();
			scene.Initialize();
			Otros.LoadTexture();
			scene.element=new Lugar();//new Base111(new Point3D(0,-2.6,-20),7,new float[]{1.0f,0.4f,0.2f,1.0f});
			rc=new RC(this);
			rc.Show();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
					rc.Close();
					
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.simpleOpenglControl1 = new OGLConFlechita();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// simpleOpenglControl1
			// 
			this.simpleOpenglControl1.AccumBits = ((System.Byte)(0));
			this.simpleOpenglControl1.AutoCheckErrors = false;
			this.simpleOpenglControl1.AutoFinish = false;
			this.simpleOpenglControl1.AutoMakeCurrent = true;
			this.simpleOpenglControl1.AutoSwapBuffers = true;
			this.simpleOpenglControl1.BackColor = System.Drawing.Color.Black;
			this.simpleOpenglControl1.ColorBits = ((System.Byte)(32));
			this.simpleOpenglControl1.DepthBits = ((System.Byte)(16));
			this.simpleOpenglControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.simpleOpenglControl1.Location = new System.Drawing.Point(0, 0);
			this.simpleOpenglControl1.Name = "simpleOpenglControl1";
			this.simpleOpenglControl1.Size = new System.Drawing.Size(792, 566);
			this.simpleOpenglControl1.StencilBits = ((System.Byte)(1));
			this.simpleOpenglControl1.TabIndex = 0;
			this.simpleOpenglControl1.Resize += new System.EventHandler(this.simpleOpenglControl1_Resize);
			this.simpleOpenglControl1.Load += new System.EventHandler(this.simpleOpenglControl1_Load);
			this.simpleOpenglControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenglControl1_Paint);
			this.simpleOpenglControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simpleOpenglControl1_KeyDown);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 5;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.simpleOpenglControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closed += new System.EventHandler(this.Form1_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Form1 f=new Form1();
			Application.Run(f);
			while(!f.IsDisposed)
			{
			f.Refresh();
			}
		}

		private void simpleOpenglControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.scene.Draw();
			
		}

		private void simpleOpenglControl1_Resize(object sender, System.EventArgs e)
		{
			scene.Reshape(simpleOpenglControl1.Width, simpleOpenglControl1.Height);
		}

		private void scene_redraw(object sender, EventArgs e)
		{
			this.Refresh();
		}

		private void simpleOpenglControl1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(!DesignMode)
			{
				if(e.KeyValue==(int)Keys.R)
				{
					rc.Visible=!rc.Visible;
				}
				else if(e.KeyValue==(int)Keys.Q)
				{
				this.scene.BombiOn=!this.scene.BombiOn;
				this.scene.EncenderBomb(this.scene.BombiOn);
				}
				else if(e.KeyValue==(int)Keys.W)
				{
					this.scene.AmbiOn=!this.scene.AmbiOn;
					this.scene.EncenderLuzAmb(this.scene.AmbiOn);
				}
				
				scene.ProcessInput(e.KeyValue);
				base.OnKeyDown(e);
				this.Refresh();
			}
		}

		private void simpleOpenglControl1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void Form1_Closed(object sender, System.EventArgs e)
		{
			rc.Close();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.Refresh();
		}

		
		
	}



	

