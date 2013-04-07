using System;
//using System.Collections;
using System.Text;
using System.IO;
using Tao.OpenGl;
using System.Collections;
using Materiales;


	public struct vertex
	{
		public float x, y, z;
	}

	

	public struct vertex_type
	{
		public vertex point;
		public vertex normal;
	}

// The polygon (trianGl.gle), 3 numbers that aim 3 vertices
	public struct polygon_type
	{
		public int a, b, c;
		public vertex normal;
	}

// The mapcoord type, 2 texture coordinates for each vertex
	public struct mapcoord_type
	{
		public float u, v;
	}

// The object type
	public class obj_type
	{
		public string name;
    
		public int vertices_qty;
		public int polygons_qty;

		public vertex_type[] vertex;
		public polygon_type[] polygon;
		public mapcoord_type[] mapcoord;
		public int id_texture = 0;
		public string mat_name = "";
		public _3dsLoader loader;


		public void paint(bool _shadow, int[] rot, float[] trans, float[] scl)
		{
			Gl.glPushMatrix();

			Gl.glTranslated(trans[0], trans[1], trans[2]);
			Gl.glRotated(rot[2], 0, 0, 1);
			Gl.glRotated(rot[1], 0, 1, 0);
			Gl.glRotated(rot[0], 1, 0, 0);
			Gl.glScaled(scl[0], scl[1], scl[2]);

			//Gl.glDisable(Gl.gl_COLOR_MATERIAL);

			color_typeF amb = (color_typeF)(loader.ambient[mat_name]);
			color_typeF dif = (color_typeF)(loader.diffuse[mat_name]);
			color_typeF spec = (color_typeF)(loader.specular[mat_name]);
			float shi = (float)(loader.shininess[mat_name]);
			float al=amb.a;
			
			if(al<1.0f){
				Gl.glEnable(Gl.GL_BLEND);
				Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
			}
			Gl.glColor4f(amb.r, amb.g, amb.b, al);
			if (mapcoord != null)
				Gl.glEnable(Gl.GL_TEXTURE_2D);
			//Gl.gl.Gl.glBindTexture(Gl.gl.Gl.gl_TEXTURE_2D, Textures.idt[1]);
			//Gl.gl.Gl.glColor4f(1, 1, 1, alpha);
			Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT, new float[] { amb.r, amb.g, amb.b });
			Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_DIFFUSE, new float[] { dif.r, dif.g, dif.b });
			Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_SPECULAR, new float[] { spec.r, spec.g, spec.b });
			Gl.glMaterialf(Gl.GL_FRONT_AND_BACK, Gl.GL_SHININESS, shi);

			Gl.glBegin(Gl.GL_TRIANGLES); // Gl.glBegin and Gl.glEnd delimit the vertices that define a primitive (in our case trianGl.gles)

			for (int l_index = 0; l_index < polygons_qty; l_index++)
			{
				// Calculate normal vertor 
				//----------------- FIRST VERTEX -----------------
				// Texture coordinates of the first vertex
				if (mapcoord != null)
					Gl.glTexCoord2f(mapcoord[polygon[l_index].a].u,
								mapcoord[polygon[l_index].a].v);
				// Coordinates of the first vertex
				Gl.glNormal3d(vertex[polygon[l_index].a].normal.x*-1,
							vertex[polygon[l_index].a].normal.y * -1,
							vertex[polygon[l_index].a].normal.z * -1); //Normal definition
				Gl.glVertex3f(vertex[polygon[l_index].a].point.x,
							vertex[polygon[l_index].a].point.y,
							vertex[polygon[l_index].a].point.z); //Vertex definition

				//----------------- SECOND VERTEX -----------------
				// Texture coordinates of the second vertex
				if (mapcoord != null)
					Gl.glTexCoord2f(mapcoord[polygon[l_index].b].u,
							  mapcoord[polygon[l_index].b].v);
				// Coordinates of the second vertex
				Gl.glNormal3d(vertex[polygon[l_index].b].normal.x * -1,
							vertex[polygon[l_index].b].normal.y * -1,
							vertex[polygon[l_index].b].normal.z * -1); //Normal definition
				Gl.glVertex3f(vertex[polygon[l_index].b].point.x,
							vertex[polygon[l_index].b].point.y,
							vertex[polygon[l_index].b].point.z);

				//----------------- THIRD VERTEX -----------------
				// Texture coordinates of the third vertex
				if (mapcoord != null)
					Gl.glTexCoord2f(mapcoord[polygon[l_index].c].u,
							  mapcoord[polygon[l_index].c].v);
				// Coordinates of the Third vertex
				Gl.glNormal3d(vertex[polygon[l_index].c].normal.x * -1,
							vertex[polygon[l_index].c].normal.y * -1,
							vertex[polygon[l_index].c].normal.z * -1); //Normal definition
				Gl.glVertex3f(vertex[polygon[l_index].c].point.x,
							vertex[polygon[l_index].c].point.y,
							vertex[polygon[l_index].c].point.z);
			}
			Gl.glEnd();
			if (mapcoord != null)
				Gl.glDisable(Gl.GL_TEXTURE_2D);
			if(al<1.0f)
			{
				Gl.glDisable(Gl.GL_BLEND);
			}
			//Gl.gl.Gl.glEnable(Gl.gl.Gl.gl_COLOR_MATERIAL);

			Gl.glPopMatrix();
		}
	}

	class _3dsMath
	{
		public static vertex cross(vertex v1, vertex v2)
		{
			vertex v = new vertex();
			v.x = v1.y * v2.z - v1.z * v2.y;
			v.y = v1.z * v2.x - v1.x * v2.z;
			v.z = v1.x * v2.y - v1.y * v2.x;
			return v;
		}

		public static vertex normalize(vertex v)
		{
			vertex nv = new vertex();
			float l = (float)(Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z));
			if (l != 0.0)
			{
				nv.x = v.x / l;
				nv.y = v.y / l;
				nv.z = v.z / l;
			}
			else
				nv = v;
			return nv;
		}

		public static vertex sum(vertex v1, vertex v2)
		{
			vertex v = new vertex();
			v.x = v1.x + v2.x;
			v.y = v1.y + v2.y;
			v.z = v1.z + v2.z;
			return v;
		}

		public static vertex dif(vertex v1, vertex v2)
		{
			vertex v = new vertex();
			v.x = v1.x - v2.x;
			v.y = v1.y - v2.y;
			v.z = v1.z - v2.z;
			return v;
		}
	}

	public class _3dsLoader
	{
		/**********************************************************
		 *
		 * FUNCTION Load3DS (obj_type_ptr, char *)
		 *
		 * This function loads a mesh from a 3ds file.
		 * Please note that we are loading only the vertices, polygons and mapping lists.
		 * If you need to load meshes with advanced features as for example: 
		 * multi objects, materials, lights and so on, you must insert other chunk parsers.
		 *
		 *********************************************************/

		public string ID;
		public string Name;
		public int[] Rot;
		public float[] Trans;
		public float[] Scl;
		public Hashtable objects = new Hashtable();
		public Hashtable ambient = new Hashtable();
		public Hashtable diffuse = new Hashtable();
		public Hashtable specular = new Hashtable();
		public Hashtable shininess = new Hashtable();
		public Hashtable shininessST = new Hashtable();

		public _3dsLoader(string id, string name, int[] rot, float[] trans, float[] scl)
		{
			ID = id;
			Name = name;
			Rot = rot;
			Trans = trans;
			Scl = scl;
		}

		private  vertex normals(vertex v1, vertex v2, vertex v3)
		{
			vertex d1, d2, norm;

			d1 = _3dsMath.dif(v2, v1);
			d2 = _3dsMath.dif(v3, v1);

			norm = _3dsMath.cross(d1, d2);

			norm = _3dsMath.normalize(norm);

			return norm;
		}

		public void ComputeNormals()
		{
			foreach (DictionaryEntry di in objects)
			{
				obj_type o = (obj_type)(di.Value);

				for (int i = 0; i < o.polygons_qty; i++)
					o.polygon[i].normal = normals(o.vertex[o.polygon[i].c].point, o.vertex[o.polygon[i].b].point, o.vertex[o.polygon[i].a].point);

				for (int i = 0; i < o.vertices_qty; i++)
				{
					vertex temp = new vertex();
					for (int j = 0; j < o.polygons_qty; j++)
						if (o.polygon[j].a == i || o.polygon[j].b == i || o.polygon[j].c == i)
							temp = _3dsMath.sum(temp, o.polygon[j].normal);
							//temp = o.polygon[j].normal;
					o.vertex[i].normal = _3dsMath.normalize(temp);
				}
			}
		}

		public int Load3DS(string p_filename)
		{
			int i; //Index variable

			objects = new Hashtable();
			ambient = new Hashtable();
			diffuse = new Hashtable();
			specular = new Hashtable();
			shininess = new Hashtable();
			shininessST = new Hashtable();
			obj_type p_object = null;
			BinaryReader l_file; //File pointer
	
			ushort l_chunk_id; //Chunk identifier
			uint l_chunk_lenght; //Chunk lenght

			char l_char; //Char variable
			ushort l_qty; //Number of elements in each chunk

			ushort l_face_flags; //Flag that stores some face information
			bool l_end = false;

			string l_mat_name = "";
			color_typeF cl;
			float per;

			using (l_file = new BinaryReader(File.Open(p_filename, FileMode.Open, FileAccess.Read)))
			{
				while (!l_end) //Loop to scan the whole file 
				{
					try
					{
						l_chunk_id = l_file.ReadUInt16();
						l_chunk_lenght = l_file.ReadUInt32();

						switch (l_chunk_id)
						{
							//----------------- MAIN3DS -----------------
							// Description: Main chunk, contains all the other chunks
							// Chunk ID: 4d4d 
							// Chunk Lenght: 0 + sub chunks
							//-------------------------------------------
							case 0x4d4d:
								break;

							//----------------- EDIT3DS -----------------
							// Description: 3D Editor chunk, objects layout info 
							// Chunk ID: 3d3d (hex)
							// Chunk Lenght: 0 + sub chunks
							//-------------------------------------------
							case 0x3d3d:
								break;

							//--------------- EDIT_OBJECT ---------------
							// Description: Object block, info for each object
							// Chunk ID: 4000 (hex)
							// Chunk Lenght: len(object name) + sub chunks
							//-------------------------------------------
							case 0x4000:
								p_object = new obj_type();
								p_object.name = "";
								p_object.loader = this;
								do
								{
									l_char = l_file.ReadChar();
									if (l_char > 0)
										p_object.name = p_object.name + l_char;
								} while (l_char != 0);
								objects.Add(p_object.name, p_object);
								break;

							//--------------- OBJ_TRIMESH ---------------
							// Description: Triangular mesh, contains chunks for 3d mesh info
							// Chunk ID: 4100 (hex)
							// Chunk Lenght: 0 + sub chunks
							//-------------------------------------------
							case 0x4100:
								break;

							//--------------- TRI_VERTEXL ---------------
							// Description: Vertices list
							// Chunk ID: 4110 (hex)
							// Chunk Lenght: 1 x unsigned short (number of vertices) 
							//             + 3 x float (vertex coordinates) x (number of vertices)
							//             + sub chunks
							//-------------------------------------------
							case 0x4110:
								l_qty = l_file.ReadUInt16();
								p_object.vertices_qty = l_qty;
								p_object.vertex = new vertex_type[l_qty];
								for (i = 0; i < l_qty; i++)
								{
									p_object.vertex[i].point.x = l_file.ReadSingle();
									p_object.vertex[i].point.y = l_file.ReadSingle();
									p_object.vertex[i].point.z = l_file.ReadSingle();
								}
								break;

							//--------------- TRI_FACEL1 ----------------
							// Description: Polygons (faces) list
							// Chunk ID: 4120 (hex)
							// Chunk Lenght: 1 x unsigned short (number of polygons) 
							//             + 3 x unsigned short (polygon points) x (number of polygons)
							//             + sub chunks
							//-------------------------------------------
							case 0x4120:
								l_qty = l_file.ReadUInt16();
								p_object.polygons_qty = l_qty;
								p_object.polygon = new polygon_type[l_qty];
								for (i = 0; i < l_qty; i++)
								{
									p_object.polygon[i].a = l_file.ReadUInt16();
									p_object.polygon[i].b = l_file.ReadUInt16();
									p_object.polygon[i].c = l_file.ReadUInt16();
									l_face_flags = l_file.ReadUInt16();
								}
								break;

							//------------------- MATERIAL ID -----------------
							// Description: Material name asigned to the object
							// Chunk ID: 4130 (hex)
							// Chunk Length: len(mat_name)
							//				 + 2 x unsigned short
							//-------------------------------------------------
							case 0x4130:
								p_object.mat_name = "";
								do
								{
									l_char = l_file.ReadChar();
									if (l_char > 0)
										p_object.mat_name = p_object.mat_name + l_char;
								} while (l_char != 0);
								int entr = l_file.ReadUInt16();
								int face;
								for (i = 0; i < entr; i++)
									face = l_file.ReadUInt16();
								break;

							//------------- TRI_MAPPINGCOORS ------------
							// Description: Vertices list
							// Chunk ID: 4140 (hex)
							// Chunk Lenght: 1 x unsigned short (number of mapping points) 
							//		       + 2 x float (mapping coordinates) x (number of mapping points)
							//             + sub chunks
							//-------------------------------------------
							case 0x4140:
								l_qty = l_file.ReadUInt16();
								p_object.mapcoord = new mapcoord_type[l_qty];
								for (i = 0; i < l_qty; i++)
								{
									p_object.mapcoord[i].u = l_file.ReadSingle();
									p_object.mapcoord[i].v = l_file.ReadSingle();
								}
								break;

							case 0xAFFF:
								break;

							case 0xA000:
								l_mat_name = "";
								do
								{
									l_char = l_file.ReadChar();
									if (l_char > 0)
										l_mat_name = l_mat_name + l_char;
								} while (l_char != 0);
								break;

							case 0xA010:
								l_chunk_id = l_file.ReadUInt16();
								l_chunk_lenght = l_file.ReadUInt32();

								cl = new color_typeF();
								cl.r = (l_file.ReadByte())/255.0f;
								cl.g = (l_file.ReadByte())/255.0f;
								cl.b = (l_file.ReadByte())/255.0f;
								cl.a=1.0f;
								ambient.Add(l_mat_name, cl);
								break;

							case 0xA020:
								l_chunk_id = l_file.ReadUInt16();
								l_chunk_lenght = l_file.ReadUInt32();

								cl = new color_typeF();
								cl.r = (l_file.ReadByte())/255.0f;
								cl.g = (l_file.ReadByte())/255.0f;
								cl.b = (l_file.ReadByte())/255.0f;
								cl.a=1.0f;
								diffuse.Add(l_mat_name, cl);
								break;

							case 0xA030:
								l_chunk_id = l_file.ReadUInt16();
								l_chunk_lenght = l_file.ReadUInt32();

								cl = new color_typeF();
								cl.r = (l_file.ReadByte())/255.0f;
								cl.g = (l_file.ReadByte())/255.0f;
								cl.b = (l_file.ReadByte())/255.0f;
								cl.a=1.0f;
								specular.Add(l_mat_name, cl);
								break;

							case 0xA040:
								l_chunk_id = l_file.ReadUInt16();
								l_chunk_lenght = l_file.ReadUInt32();

								per = (l_file.ReadUInt16())/255.0f;

								shininess.Add(l_mat_name, (float)per);
								break;

							case 0xA041:
								l_chunk_id = l_file.ReadUInt16();
								l_chunk_lenght = l_file.ReadUInt32();

								per = (l_file.ReadUInt16())/255.0f;

								shininessST.Add(l_mat_name,(float) per);
								break;
							//----------- Skip unknow chunks ------------
							//We need to skip all the chunks that currently we don't use
							//We use the chunk lenght information to set the file pointer
							//to the same level next chunk
							//-------------------------------------------
							default:
								l_file.BaseStream.Seek(l_chunk_lenght - 6, SeekOrigin.Current);
								break;
						}
					}
					catch (EndOfStreamException e)
					{
						l_end = true;
					}
				}
			}
			return (1); // Returns ok
		}

		public void paint(bool shadow,I3dsTaken c)
		{
			obj_type aux=null;
			foreach (obj_type o in objects.Values)
			{
				if(o.name=="glass")
				{	aux=o;
					
				}
				else if(c.Actions(o,shadow, Rot, Trans, Scl))
				{
					
				}
				
				else o.paint(shadow, Rot, Trans, Scl);
				
			}
			
			if(aux!=null)
			{
				if(c.Actions(aux,shadow, Rot, Trans, Scl))
				{
				
				}
				else aux.paint(shadow, Rot, Trans, Scl);
			}
		}
	}

