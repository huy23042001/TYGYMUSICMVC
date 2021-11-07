using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYGYMUSICOBJ
{
    public class Guitars
    {
		public string guitar_id { get; set; }
		public string guitar_name { get; set; }
		public string guitar_origin { get; set; }
		public string guitar_designs { get; set; }
		public string guitar_paint { get; set; }
		public string guitar_face_wood { get; set; }
		public string guitar_back_side_wood { get; set; }
		public string guitar_neck_headstock_wood { get; set; }
		public string guitar_truss_rod { get; set; }
		public string guitar_strings { get; set; }
		public string guitar_pegs { get; set; }
		public string guitar_nut_bridge_wood { get; set; }
		public int guitar_isurance { get; set; }
		public string guitar_eq { get; set; }
		public int quantity { get; set; }
		public string descriptions { get; set; }
		public bool active { get; set; }
		public string image_base { get; set; }
		public List<GuitarImages> guitar_images { get; set; }
		public float guitar_price { get; set; }
	}
}
