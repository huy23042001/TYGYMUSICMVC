using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYGYMUSICOBJ;
using TYGYMUSICDAO;
using TYGYMUSICBUS.Interface;

namespace TYGYMUSICBUS
{
    public class GuitarsBUS:IGuitarsBUS
    {
		GuitarsDAO dao = new GuitarsDAO();
		public List<Guitars> GetAllGuitars()
		{
			return dao.GetAllGuitars();
		}
		public Guitars_List Get_Guitars_For_Page(int pageIndex, int pageSize, string guitarName)
		{
			return dao.Get_Guitars_For_Page(pageIndex, pageSize, guitarName);
		}
		public Guitars Get_Guitar_Details(string guitar_id)
		{
			return dao.Get_Guitar_Details(guitar_id);
		}
	}
}
