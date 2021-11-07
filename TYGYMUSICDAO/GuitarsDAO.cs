using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYGYMUSICDAO.Interface;
using TYGYMUSICOBJ;
using System.Data;
using System.Data.SqlClient;

namespace TYGYMUSICDAO
{
    public class GuitarsDAO:IGuitarsDAO
    {
		DataHelper dh;
		public GuitarsDAO()
		{
			dh = new DataHelper();
		}
		public List<Guitars> GetAllGuitars()
		{
			DataTable dt = dh.ExcuteProcedure("dbo.Get_List_Guitars_For_Index_Page");
			List<Guitars> guitars = new List<Guitars>();
			foreach (DataRow dr in dt.Rows)
			{
				Guitars guitar = new Guitars();
				guitar.guitar_id = dr[0].ToString();
				guitar.guitar_name = dr[1].ToString();
				guitar.image_base = dr[3].ToString();
				guitar.guitar_price = float.Parse(dr[2].ToString());
				guitars.Add(guitar);
			}
			return guitars;
		}
		public Guitars_List Get_Guitars_For_Page(int pageIndex, int pageSize, string guitarName)
		{
			Guitars_List guitars_List = new Guitars_List();
			SqlDataReader dr = dh.StoreReader("dbo.Get_Guitars_For_Page", pageIndex, pageSize, guitarName);
			List<Guitars> guitars = new List<Guitars>();
			while(dr.Read())
			{
				Guitars guitar = new Guitars();
				guitar.guitar_id = dr[0].ToString();
				guitar.guitar_name = dr[1].ToString();
				guitar.image_base = dr[2].ToString();
				guitar.guitar_price = float.Parse(dr[3].ToString());
				guitars.Add(guitar);
			}
			guitars_List.Guitars = guitars;
			dr.NextResult();
			while(dr.Read())
			{
				guitars_List.totalCount = dr["totalCount"].ToString();
				break;
			}
			return guitars_List;
		}
		public Guitars Get_Guitar_Details(string guitar_id)
		{
			Guitars guitar = new Guitars();
			SqlDataReader dr = dh.StoreReader("Get_Guitar_Details", guitar_id);
			while(dr.Read())
			{
				guitar.guitar_id = dr["guitar_id"].ToString();
				guitar.guitar_name = dr["guitar_name"].ToString();
				guitar.guitar_origin = dr["origin_name"].ToString();
				guitar.guitar_paint = dr["guitar_paint"].ToString();
				guitar.guitar_face_wood = dr["guitar_face_wood"].ToString();
				guitar.guitar_designs = dr["guitar_designs"].ToString();
				guitar.guitar_back_side_wood = dr["guitar_back_side_wood"].ToString();
				guitar.guitar_neck_headstock_wood = dr["guitar_neck_headstock_wood"].ToString();
				if (bool.Parse(dr["guitar_truss_rod"].ToString()))
					guitar.guitar_truss_rod = "Có";
				else
					guitar.guitar_truss_rod = "Không";
				guitar.guitar_strings = dr["guitar_strings"].ToString();
				guitar.guitar_pegs = dr["guitar_pegs"].ToString();
				guitar.guitar_nut_bridge_wood = dr["guitar_nut_bridge_wood"].ToString();
				guitar.guitar_isurance = int.Parse(dr["guitar_isurance"].ToString());
				if (bool.Parse(dr["guitar_eq"].ToString()))
					guitar.guitar_eq = "Có";
				else
					guitar.guitar_eq = "Không";
				guitar.quantity = int.Parse(dr["quantity"].ToString());
				guitar.descriptions = dr["descriptions"].ToString();
				guitar.guitar_price = float.Parse(dr["price"].ToString());
				break;
			}

			dr.NextResult();
			List<GuitarImages> images = new List<GuitarImages>();
			while(dr.Read())
			{
				GuitarImages image = new GuitarImages();
				image.guitar_id = dr["guitar_id"].ToString();
				image.img_id = dr["img_guitar_id"].ToString();
				image.img_name = dr["img_name"].ToString();
				image.brand = int.Parse(dr["brand"].ToString());
				images.Add(image);
			}
			guitar.guitar_images = images;
			return guitar;
		}

	}
}
