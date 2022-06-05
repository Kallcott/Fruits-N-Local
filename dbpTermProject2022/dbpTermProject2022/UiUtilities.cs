using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbpTermProject2022
{
    public class UIUtilities
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

        public static void ClearControls(Control.ControlCollection controls)
        {
            foreach (Control ctl in controls)
            {
                switch (ctl)
                {
                    case TextBox txt:
                        txt.Clear();
                        break;
                    case CheckBox chk:
                        chk.Checked = false;
                        break;
                    case GroupBox gB:
                        ClearControls(gB.Controls);
                        break;
                }
            }
        }

        /// <summary>
        /// This will rotate the columns and Rows of a Table. This sets a size constraint of 6, 
        /// which will create new line every 6 columns, due to this Tables with more than one row will become offset.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable RotateTable(DataTable dt, int columWidth = 5)
        {
            DataTable tempTable = new DataTable();

            //tempTable.Columns.Add("Field Name");

            // Fill temp table with dt, limit columns by Width
            for (int i = 0; i < ((dt.Rows.Count >= columWidth) ?columWidth : dt.Rows.Count); i++)
            {
                tempTable.Columns.Add();
            }

            // Loop through Columns
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataRow NewRow = tempTable.NewRow();

                // Loop throw Rows
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    //New Line every 6 cells, but not on the first pass.
                    if (j % columWidth == 0 && j != 0)
                    {
                        tempTable.Rows.Add(NewRow);
                        NewRow = tempTable.NewRow();
                    }

                    NewRow[j % columWidth] = dt.Rows[j][i];

                }
                tempTable.Rows.Add(NewRow);

            }
            return tempTable;
        }

        public static void AutoResizeDgv(DataGridView dgv)
        {
            dgv.AutoResizeColumns();
            var width = dgv.Columns.GetColumnsWidth(DataGridViewElementStates.None);
            var height = dgv.Rows.GetRowsHeight(DataGridViewElementStates.None);
            dgv.ClientSize = new Size(width, height + 20);
        }

    }
}
