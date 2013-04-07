using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

public class calob : System.Windows.Forms.Form
	{
		Form1 form1;
	private System.Windows.Forms.TrackBar trackBar1;
	private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public calob(float initVal,Form1 form)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			form1=form;
			this.trackBar1.Value=(int)initVal;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
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
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// trackBar1
			// 
			this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar1.Location = new System.Drawing.Point(24, 16);
			this.trackBar1.Maximum = 255;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar1.Size = new System.Drawing.Size(45, 152);
			this.trackBar1.SmallChange = 5;
			this.trackBar1.TabIndex = 1;
			this.trackBar1.TickFrequency = 5;
			this.trackBar1.Value = 1;
			this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.button1.Location = new System.Drawing.Point(8, 200);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(208, 40);
			this.button1.TabIndex = 2;
			this.button1.Text = "Poner Este Color";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// calob
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Maroon;
			this.ClientSize = new System.Drawing.Size(224, 256);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.trackBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = new System.Drawing.Point(10, 506);
			this.Name = "calob";
			this.Opacity = 0.5;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "calob";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

	private void trackBar1_Scroll(object sender, System.EventArgs e)
	{
		((Lugar)form1.scene.element).bas.car.OscuridadCristal=trackBar1.Value;
		((Lugar)form1.scene.element).bas.car.Recompile();
		form1.Refresh();
	}

	private void button1_Click(object sender, System.EventArgs e)
	{
		this.Close();
	}

	private void trackBar1_Scroll_1(object sender, System.EventArgs e)
	{
	
	}

	private void trackBar1_ValueChanged(object sender, System.EventArgs e)
	{
		((Lugar)form1.scene.element).bas.car.OscuridadCristal=trackBar1.Value;
		((Lugar)form1.scene.element).bas.car.Recompile();
		form1.Refresh();
	}
	}

