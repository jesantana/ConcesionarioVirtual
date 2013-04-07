using System;
using System.Drawing.Imaging;
using System.Drawing;
using Tao.OpenGl;
using System.Windows.Forms;


public class Otros
{
	public static int[] texture;
	
	public Otros()
	{
			//
			// TODO: Add constructor logic here
			//
	}
	public static void LoadTexture()
	{	
		Bitmap bitmap=null;
		BitmapData bitmapData=null;	

		string[] tx={"relojes.bmp","ford1.bmp","benz1.jpg","motor.bmp","acelera.bmp","papel1.jpg","piso.jpg","madera2.jpg","madera3.jpg","papel1.jpg","Focus.jpg","fordrunner.jpg","mbne.jpg","particle.bmp","benz.jpg"};
		Gl.glEnable(Gl.GL_TEXTURE_2D);
		Gl.glEnable(Gl.GL_DEPTH_TEST);
//		Gl.gl.Gl.glEnable(Gl.gl.Gl.gl_BLEND);
//		Gl.gl.Gl.glBlendFunc(Gl.gl.Gl.gl_SRC_ALPHA,Gl.gl.Gl.gl_ONE_MINUS_SRC_ALPHA);
		Rectangle rect;
		texture=new int[tx.Length];
		Gl.glGenTextures(tx.Length, texture);
		for(int i=0; i<tx.Length; i++)
		{
			bitmap = new Bitmap(Application.StartupPath + "\\" + "Textures\\"+tx[i]);
			rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			bitmapData =bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, 
				System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[i]);
			Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, (int) Gl.GL_RGB8, bitmap.Width, bitmap.Height, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);
		}

		Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
		Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
		Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
		Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
		Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_DECAL);
			
		Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);

		bitmap.UnlockBits(bitmapData);
		bitmap.Dispose();
			
	}
}

