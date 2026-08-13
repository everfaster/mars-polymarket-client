using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsPolymarketClient.Components
{
	public class ListViewItemComparer : IComparer
	{
		string[][] _specials = { 
			new string[] { "↑", "" },
			new string[] { "↓", "-" } 
		};

		int _column = 0;
		bool _acsending;

		public ListViewItemComparer(int column, bool acsending)
		{
			_column = column;
			_acsending = acsending;
		}

		public int Compare(object? x, object? y)
		{
            string textX = x is ListViewItem itemX ? itemX.SubItems[_column].Text : string.Empty;
            string textY = y is ListViewItem itemY ? itemY.SubItems[_column].Text : string.Empty;
            int direction = _acsending ? 1 : -1;

            //DateTime dateValue1, dateValue2;

            //bool isDate1 = DateTime.TryParse(textX, out dateValue1);
            //bool isDate2 = DateTime.TryParse(textY, out dateValue2);

            //if (isDate1 && isDate2)
            //    return dateValue1 > dateValue2 ? direction : -1 * direction;

            bool isNumber1 = double.TryParse(textX, out double result1);
            bool isNumber2 = double.TryParse(textY, out double result2);
			bool isRight = x is ListViewItem item ? item.ListView?.Columns[_column].TextAlign == HorizontalAlignment.Right : false;

            return isNumber1 && isNumber2 ? 
				(result1 > result2 ? direction : -1 * direction) : 
				string.Compare(textX, textY) * direction;
        }
	}
}
