using System;
using Tao.OpenGl;
using System.Windows.Forms;
using System.Xml;
using Materiales;
using System.Collections;
	/// <summary>
	/// Summary description for Carro.
	/// </summary>
public abstract class Carro:Element,I3dsTaken
{
	public _3dsLoader car;
	protected Point3D center;
	protected Interior inter;
	public ArrayList actList;
	protected color_typeF[] colores;
	public Particula tubodeescape;
	public bool todo=true;

		public Carro(string path,Interior interior)
		{
		car=load3ds(path);
		car.ComputeNormals();
		colores=new color_typeF[]{new color_typeF(0.5f,1.0f,0f),new color_typeF(1f,1f,0.4f),new color_typeF(1f,0.5f,1f),new color_typeF(0.5f,0.5f,1f),new color_typeF(0.7f,0f,0f)};
		InitMyMaterial();
		inter=interior;
		actList=new ArrayList();
			
	//	this.actList.Add("capo");
	//	this.actList.Add("maletero");
		

		this.Recompile();
		}

		
		public virtual color_typeF[] Colores
		{
			get{return colores;}
		
		}
		
		public abstract void EnciendeTubEsc(bool on);
		
		
	public  abstract bool Actions(obj_type o,bool _shadow, int[] rot, float[] trans, float[] scl);
		public abstract float OscuridadCristal
		{
			get;
			set;
		
		}
		
		public virtual void EnciendeParabrisas(bool on)
		{
		this.inter.onlp=on;
		
		}

		public override void Recompile()
		{
			inter.Recompile();
			Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
			Gl.glPushMatrix();
			Gl.glDisable(Gl.GL_CULL_FACE);
			car.paint(false,this);

			
//
//			Glu.GLUquadric sph=Glu.gluNewQuadric();
//			Glu.gluQuadricOrientation(sph,Glu.GLU_OUTSIDE);
//			Gl.glTranslated(0,0,-20);
//			Glu.gluSphere(sph,3,32,32);
			Gl.glEnable(Gl.GL_CULL_FACE);
			Gl.glPopMatrix();
			Gl.glEndList();
		}

		public abstract void InitMyMaterial();

		public abstract Point3D ObjetivoVistaInt(int angle);
		public abstract Point3D OrigenVistaInt();
		
		public override void Draw()
		{
			if(idVisualizar != 0)
			{
				Gl.glPushMatrix();
				this.Rota();
				
				inter.Draw();
				
				if(todo)
				Gl.glCallList(idVisualizar);
				if(this.tubodeescape!=null)
					this.tubodeescape.Draw();
				
				Gl.glPopMatrix();
			}
		}


		public override Point3D PuntoRotacion
		{
			get
			{
				return center;
			}
		}

		public virtual void ChangeMaterialFrom3ds(string mat3dsname,Material nuevo)
		{
			this.car.ambient[mat3dsname]=nuevo.Ambient;
			this.car.diffuse[mat3dsname]=nuevo.Diffuse;
			this.car.specular[mat3dsname]=nuevo.Specular;
			this.car.shininess[mat3dsname]=nuevo.Shininess;
		}


		private _3dsLoader load3ds(string path)
		{
			XmlTextReader doc = new XmlTextReader(Application.StartupPath + "\\" + "Models\\" + "models.xml");
			string id = "";
			_3dsLoader temp = null;
			string name = "";
			int[] rot = null;
			float[] trans = null;
			float[] scl = null;
			bool notdone=true;
			while (doc.Read() && notdone)
			{
				switch (doc.NodeType)
				{
					case XmlNodeType.Element:
					switch (doc.Name)
					{
						case "model":
							if(doc.GetAttribute("id")!=path)
								doc.Skip();
							else
								id = doc.GetAttribute("id");
								break;

						case "name":
							name = (string)(doc.GetAttribute("id"));
							break;
						case "rot":
							rot = new int[3];
							rot[0] = Int32.Parse(doc.GetAttribute("x"));
							rot[1] = Int32.Parse(doc.GetAttribute("y"));
							rot[2] = Int32.Parse(doc.GetAttribute("z"));
							break;
						case "trans":
							trans = new float[3];
							trans[0] = Single.Parse(doc.GetAttribute("x"));
							trans[1] = Single.Parse(doc.GetAttribute("y"));
							trans[2] = Single.Parse(doc.GetAttribute("z"));
							break;
						case "scl":
							scl = new float[3];
							scl[0] = Single.Parse(doc.GetAttribute("x"));
							scl[1] = Single.Parse(doc.GetAttribute("y"));
							scl[2] = Single.Parse(doc.GetAttribute("z"));
							break;
					}
						break;

					case XmlNodeType.EndElement:
					switch (doc.Name)
					{
						case "model":
							temp = new _3dsLoader(id, name, rot, trans, scl);
							center=new Point3D(trans[0],trans[1],trans[2]);
							temp.Load3DS(Application.StartupPath + "\\" + "Models\\" + temp.ID);
							notdone=false;
							return temp;
							
					}
						break;
				}
			
			}
			return null;
		}
	}

