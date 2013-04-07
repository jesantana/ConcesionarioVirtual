using System;
using Tao.OpenGl;
using System.Xml;
using Materiales;
using System.Collections;
using System.Windows.Forms;


public class Sofa:Element,I3dsTaken
{
	
	public _3dsLoader sof;
	protected Point3D center;

	public Sofa()
	{
	
		sof=this.load3ds("sofa.3ds");
		sof.ComputeNormals();
		this.Recompile();
	}

	public override void Recompile()
	{
		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
		Gl.glPushMatrix();
		Gl.glDisable(Gl.GL_CULL_FACE);
		sof.paint(false,this);
		Gl.glEnable(Gl.GL_CULL_FACE);
		Gl.glPopMatrix();
		Gl.glEndList();
	}

	public override Point3D PuntoRotacion
	{
		get
		{
			return center;
		}
	}

	public  bool Actions(obj_type o,bool _shadow, int[] rot, float[] trans, float[] scl)
	{
		return false;
	
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

