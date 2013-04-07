using System;
using Materiales;
using Tao.OpenGl;

	public class mb380:Carro
	{
		
		
		public mb380():base("mb_380sl.3DS",new InteriorMB(new Point3D(0,0,-20)))
		{
		}

		
		public override void InitMyMaterial()
		{
		ChangeMaterialFrom3ds("flred rlights",new MiPlasticoRojo());
		ChangeMaterialFrom3ds("florange signal",new MiCrisLater());
		ChangeMaterialFrom3ds("glass_fari",new Plata());
		ChangeMaterialFrom3ds("Metal_Chrome",new Plata());
		ChangeMaterialFrom3ds("tyre",new CauchoNegro());
		ChangeMaterialFrom3ds("glass",new MiCristalCalobar());
		ChangeMaterialFrom3ds("black under",new PlasticoNegro());
		ChangeMaterialFrom3ds("body",new MiMetal(0.5f,1.0f,0f));
		}

		public override bool Actions(obj_type o,bool _shadow, int[] rot, float[] trans, float[] scl)
		{
			if(actList.Contains("maletero") && o.name=="trunk")
			{	
				Gl.glPushMatrix();
				Gl.glTranslated((trans[0]-0.4),trans[1]-1.5,trans[2]);
				Gl.glRotated(-45,0,0,1);
				Gl.glTranslated(-(trans[0]+0.4),- (trans[1]+1.5),-trans[2]);
				o.paint(_shadow, rot, trans, scl);
				Gl.glPopMatrix();
				
				return true;
			}

			
			else if(actList.Contains("capo") && o.name=="hood")
			{
				Gl.glPushMatrix();
				Gl.glTranslated((trans[0]+0.2),trans[1]-1.2,trans[2]);
				Gl.glRotated(45,0,0,1);
				Gl.glTranslated(-(trans[0]-0.2),- (trans[1]+1.2),-trans[2]);
				o.paint(_shadow, rot, trans, scl);
				Gl.glPopMatrix();
				return true;
			}
			else if(actList.Contains("descapotable") && o.name=="glass")
			{
				Gl.glPushMatrix();
				Gl.glClipPlane(Gl.GL_CLIP_PLANE0,new double[]{1,1,0,-2});
				Gl.glEnable(Gl.GL_CLIP_PLANE0);
				o.paint(_shadow, rot, trans, scl);
				Gl.glDisable(Gl.GL_CLIP_PLANE0);
				Gl.glPopMatrix();
			return true;
			}

			else if(actList.Contains("descapotable") && o.name=="trim")
			{
				Gl.glPushMatrix();
				Gl.glClipPlane(Gl.GL_CLIP_PLANE1,new double[]{0,-1,0,0.5});
				Gl.glEnable(Gl.GL_CLIP_PLANE1);
				o.paint(_shadow, rot, trans, scl);
				Gl.glDisable(Gl.GL_CLIP_PLANE1);
				Gl.glPopMatrix();
				return true;
			}

			else if(actList.Contains("descapotable") && o.name=="roof")
			{
				Gl.glPushMatrix();
				Gl.glClipPlane(Gl.GL_CLIP_PLANE0,new double[]{1,0,0,3.5});
				Gl.glClipPlane(Gl.GL_CLIP_PLANE1,new double[]{-1,0,0,-2.0});
				Gl.glEnable(Gl.GL_CLIP_PLANE0);
				Gl.glEnable(Gl.GL_CLIP_PLANE1);
				Gl.glTranslated(-1.0,-0.7,0);
				o.paint(_shadow, rot, trans, scl);
				Gl.glDisable(Gl.GL_CLIP_PLANE1);
				Gl.glDisable(Gl.GL_CLIP_PLANE0);					
				Gl.glPopMatrix();
				return true;
			}

			return false;
		}

		public override float OscuridadCristal
		{
			get
			{
				return ((color_typeF)car.ambient["glass"]).r*255;
			}
			set
			{
				color_typeF c;
				if(value<256 && value>=0)
				{
					c=(color_typeF)car.ambient["glass"];
					c.r=(float)(value/255.0);
					c.g=(float)(value/255.0);
					c.b=(float)(value/255.0);
					car.ambient["glass"]=c;
				}

			}
		}

		
		public override void EnciendeTubEsc(bool on)
		{
			if(on)
			this.tubodeescape=new Particula(new Point3D(-6,-1.7,-18.5));
			else 
				this.tubodeescape=null;
		}

		
		public override Point3D ObjetivoVistaInt(int angle)
		{
			return new Point3D(3*Math.Cos(Math.PI*angle/180.0)-center.x,center.y,center.z-(3*Math.Sin(Math.PI*angle/180.0)));
		}

		public override Point3D OrigenVistaInt()
		{
			return new Point3D(center.x-1.0,center.y+2.7,center.z);
		}

	}

