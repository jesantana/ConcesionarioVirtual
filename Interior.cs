using System;

public abstract class Interior:Element
	{
	
	protected Point3D start;
	public bool onlp=false;

	public Interior(Point3D pst)
		{
			start=pst;
		}

	public override Point3D PuntoRotacion
	{
		get
		{
			return start;
		}
	}

	}

