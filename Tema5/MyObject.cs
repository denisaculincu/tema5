using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tema5
{
	public class MyObject
	{
		public Texture2D texture;
		public Vector2 poz;

		public MyObject(OleDbConnection con)
		{		
			string selectStirng= "SELECT X, Y FROM [OBJECT] WHERE ID=2";
			OleDbCommand selectCommand = new OleDbCommand(selectStirng, con);
			con.Open();

			OleDbDataReader reader = selectCommand.ExecuteReader();

			while (reader.Read())
			{
				poz.X = reader.GetInt32(0);
				poz.Y = reader.GetInt32(1);
			}

			reader.Close();
			con.Close();
		}

		public void updateDB(OleDbConnection con, int dx, int dy)
		{
			//find initial positions
			int newX=11, newY=11;
			string selectStirng = "SELECT X, Y FROM [OBJECT] WHERE ID=2";
			OleDbCommand selectCommand = new OleDbCommand(selectStirng, con);
			con.Open();

			OleDbDataReader reader = selectCommand.ExecuteReader();

			while (reader.Read())
			{
				newX = reader.GetInt32(0)+dx;
				newY = reader.GetInt32(1)+dy;
			}

			reader.Close();

			Console.Write(newX+" "+newY);

			//update positions
			string updateString = "UPDATE [object] SET X=?, Y=? WHERE ID=2;";
			
			OleDbCommand commandUpdate = new OleDbCommand(updateString, con);
			commandUpdate.CommandType = CommandType.Text;
			commandUpdate.Parameters.AddWithValue("X", newX);
			commandUpdate.Parameters.AddWithValue("Y", newY);
			commandUpdate.ExecuteNonQuery();
			con.Close();
			addPosToDB(newX, newY, con);
		}

		public void addPosToDB(int x, int y, OleDbConnection con)
		{
			string insertString = "Insert into Mutare (X,Y) Values(?,?)";
			OleDbCommand command = new OleDbCommand(insertString, con);
			command.CommandType = CommandType.Text;
			command.Parameters.AddWithValue("X", x);
			command.Parameters.AddWithValue("Y", y);

			con.Open();

			command.ExecuteNonQuery();

			con.Close();
		}
	}
}
