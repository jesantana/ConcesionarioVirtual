using System;


	public interface IElement
	{
		void Draw();
		void Recompile();
		float Width{
		get;
		set;
		}
		Point3D PuntoRotacion{
		get;
		}
		void RotateX(int direction);
		void RotateY(int direction);
		void RotateZ(int direction);
		string GetObjName(int id);
		int Id{
		get;
		}
	}

