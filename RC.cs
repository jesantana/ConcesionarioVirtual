using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Materiales;

public class RC : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
	private System.Windows.Forms.Button button6;
	private System.Windows.Forms.Button button7;
	private System.Windows.Forms.Button button8;
	private System.Windows.Forms.Button button9;
	private System.Windows.Forms.Button button10;
		Form1 form;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		
		public RC(Form1 fo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			form=fo;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Aqua;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Control Remoto";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.button1.Location = new System.Drawing.Point(8, 80);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(208, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "Cambiar Color";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.button2.Location = new System.Drawing.Point(8, 112);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(208, 32);
			this.button2.TabIndex = 2;
			this.button2.Text = "Abrir Maletero";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button3.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.button3.Location = new System.Drawing.Point(8, 144);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(208, 32);
			this.button3.TabIndex = 3;
			this.button3.Text = "Abrir Capo";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button4.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.button4.Location = new System.Drawing.Point(8, 176);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(208, 32);
			this.button4.TabIndex = 4;
			this.button4.Text = "Quitar Techo";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Enabled = false;
			this.button5.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button5.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.button5.Location = new System.Drawing.Point(8, 208);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(208, 32);
			this.button5.TabIndex = 5;
			this.button5.Text = "Para sentarse tiene que estar detenido";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button6.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.button6.Location = new System.Drawing.Point(8, 272);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(208, 32);
			this.button6.TabIndex = 6;
			this.button6.Text = "Encender Motor!!!";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button7.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.button7.Location = new System.Drawing.Point(8, 240);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(208, 32);
			this.button7.TabIndex = 7;
			this.button7.Text = "Detener Rotacion";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button8.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.button8.Location = new System.Drawing.Point(8, 304);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(208, 32);
			this.button8.TabIndex = 8;
			this.button8.Text = "LimpiaParabrisas/On";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button9.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.button9.Location = new System.Drawing.Point(8, 336);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(208, 40);
			this.button9.TabIndex = 9;
			this.button9.Text = "Cambiar oscuridad a los cristales";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(8, 376);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(208, 32);
			this.button10.TabIndex = 10;
			this.button10.Text = "Ver Solo Interior";
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// RC
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
			this.BackColor = System.Drawing.Color.Maroon;
			this.ClientSize = new System.Drawing.Size(224, 496);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = new System.Drawing.Point(10, 10);
			this.Name = "RC";
			this.Opacity = 0.5;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "RC";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			if(button2.Text=="Abrir Maletero")
			{
				((Lugar)form.scene.element).bas.car.actList.Add("maletero");
				button2.Text="Cerrar Maletero";
			}
			else
			{
				((Lugar)form.scene.element).bas.car.actList.Remove("maletero");
				button2.Text="Abrir Maletero";
			}
			((Lugar)form.scene.element).bas.car.Recompile();
			form.Focus();
			form.Refresh();
		}

	private void button4_Click(object sender, System.EventArgs e)
	{
		if(button4.Text=="Quitar Techo")
		{
			((Lugar)form.scene.element).bas.car.actList.Add("descapotable");
			button4.Text="Poner Techo";
		}
		else
		{
			((Lugar)form.scene.element).bas.car.actList.Remove("descapotable");
			button4.Text="Quitar Techo";
		}
		((Lugar)form.scene.element).bas.car.Recompile();
		form.Focus();
		form.Refresh();
	}

	private void button3_Click(object sender, System.EventArgs e)
	{
		if(button3.Text=="Abrir Capo")
		{
			((Lugar)form.scene.element).bas.car.actList.Add("capo");
			button3.Text="Cerrar Capo";
		}
		else
		{
			((Lugar)form.scene.element).bas.car.actList.Remove("capo");
			button3.Text="Abrir Capo";
		}
		((Lugar)form.scene.element).bas.car.Recompile();
		form.Focus();
		form.Refresh();
	}

	private void button1_Click(object sender, System.EventArgs e)
	{
		Col c1=new Col(((Lugar)form.scene.element).bas.car.Colores);
		c1.ShowDialog();
		int x=c1.selInd;
		c1.Close();
		form.Focus();
		((Lugar)form.scene.element).bas.car.ChangeMaterialFrom3ds("body",new MiMetal(((Lugar)form.scene.element).bas.car.Colores[x].r,((Lugar)form.scene.element).bas.car.Colores[x].g,((Lugar)form.scene.element).bas.car.Colores[x].b));
		((Lugar)form.scene.element).bas.car.Recompile();
		form.Focus();
		form.Refresh();
	}

	private void button5_Click(object sender, System.EventArgs e)
	{
	
		//form.scene.cam.SetPos(((Lugar)form.scene.element).bas.car.OrigenVistaInt(),((Lugar)form.scene.element).bas.car.ObjetivoVistaInt(((Lugar)form.scene.element).bas.crang),0,1,0);
		Lugar l=(Lugar)form.scene.element;
		Point3D p1=l.bas.car.ObjetivoVistaInt(l.bas.crang);
		Point3D p=l.bas.car.OrigenVistaInt();
		form.scene.OrigCam=new Point3D(p.x,p.y,p.z);
		form.scene.ObjCam=new Point3D(p1.x,p1.y,p1.z);
		form.Focus();
		//form.Refresh();
	}

	private void button7_Click(object sender, System.EventArgs e)
	{
		if(button7.Text=="Detener Rotacion")
		{
			((Lugar)form.scene.element).bas.rotando=false;
			button5.Font=new System.Drawing.Font("Rockwell", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			button5.Text="Sentarse Adentro";
			button5.Enabled=true;
			button7.Text="Reanudar Rotacion";
		}
		else
		{
			((Lugar)form.scene.element).bas.rotando=true;
			button5.Font=new System.Drawing.Font("Rockwell", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));;
			button5.Text="Para sentarse tiene que estar detenido";
			button5.Enabled=false;
			button7.Text="Detener Rotacion";
		}
		form.Focus();
		form.Refresh();

	}

	private void button6_Click(object sender, System.EventArgs e)
	{
		if(button6.Text=="Encender Motor!!!")
		{
		((Lugar)form.scene.element).bas.car.EnciendeTubEsc(true);
			button6.Text="Apagar Motor";
		}
		else
		{
			((Lugar)form.scene.element).bas.car.EnciendeTubEsc(false);
			button6.Text="Encender Motor!!!";
		}
		form.Focus();
	}

	private void button8_Click(object sender, System.EventArgs e)
	{
		if(button8.Text=="LimpiaParabrisas/On")
		{
			((Lugar)form.scene.element).bas.car.EnciendeParabrisas(true);
			button8.Text="LimpiaParabrisas/Off";
		}
		else {
			((Lugar)form.scene.element).bas.car.EnciendeParabrisas(false);
			button8.Text="LimpiaParabrisas/On";
		}
		form.Focus();
	}

	private void button9_Click(object sender, System.EventArgs e)
	{
		calob calb=new calob(((Lugar)form.scene.element).bas.car.OscuridadCristal,form);
		calb.ShowDialog();
		form.Focus();
	}

	private void button10_Click(object sender, System.EventArgs e)
	{
		if(button10.Text=="Ver Solo Interior")
		{
			((Lugar)form.scene.element).bas.car.todo=false;
			button10.Text="Ver Carro Completo";
		}
		else 
		{
			((Lugar)form.scene.element).bas.car.todo=true;
			button10.Text="Ver Solo Interior";
		}
		form.Focus();
	
	}
	}

