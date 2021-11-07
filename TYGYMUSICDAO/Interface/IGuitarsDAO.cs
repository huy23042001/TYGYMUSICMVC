using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYGYMUSICOBJ;

namespace TYGYMUSICDAO.Interface
{
	interface IGuitarsDAO
	{
		List<Guitars> GetAllGuitars();
		Guitars_List Get_Guitars_For_Page(int pageIndex, int pageSize, string guitarName);
		Guitars Get_Guitar_Details(string guitar_id);
	}
}
