using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbpTermProject2022
{
    class UiUtilities
    {
        public static void FillListControl(
            ListControl control,
            string displayMember,
            string valueMember,
            DataTable dt,
            bool insertBlank = false,
            string defaultText = "")
        {

            if (insertBlank)
            {
                DataRow row = dt.NewRow();

                row[valueMember] = DBNull.Value; // cannot use C# null, we need to use database null
                row[displayMember] = defaultText;
                dt.Rows.InsertAt(row, 0);
            }

            control.DisplayMember = displayMember;
            control.ValueMember = valueMember;

            control.DataSource = dt;

            return;
        }
    }
}
