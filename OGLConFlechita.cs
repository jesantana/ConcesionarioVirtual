using System;
using System.ComponentModel;
using System.Windows.Forms;

public class OGLConFlechita:Tao.Platform.Windows.SimpleOpenGlControl
	{
		public OGLConFlechita():base()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	protected override bool IsInputChar(char charCode)
	{
		if(charCode==(char)Keys.Up || charCode==(char)Keys.Down || charCode==(char)Keys.Left  || charCode==(char)Keys.Right )return true;
		
		return base.IsInputChar (charCode);
	}
  	

}

