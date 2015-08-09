using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptDets
{
    class EventGroup
    {
        Event[] arrEvents = new Event[200];
        int nEventsCount = 0;
        string strFileName = "PresetEvents.csv";


        public void LoadPresetEvents()
        {
            FileReader r = new FileReader(strFileName);

            string[,] strRows = r.LoadFile(ref nEventsCount);

            for (int i = 0; i < strRows.Length/2; i++) // very dangerous! Need a global getMax function!
            {
                Event e = new Event(strRows[i, 0], strRows[i, 1], "");
                
                if( e.GetEventCategory() ==null)
                {
                    return;
                }

                arrEvents[i] = e;
            }

        }

        public bool AddEvent(string strDate, string strCategory, string strEventDetail)
        {
            Event e = new Event(strDate, strCategory, strEventDetail);

           /* if (e.IsValid() == false)
            {
                return false;
            }*/

            arrEvents[nEventsCount++] = e;
            return true;
        }

        public int GetCount() { return nEventsCount; }

        public Event GetEvent(int nPos)
        { 
            if( nPos > GetCount())
            {
                return null;
            }

            return arrEvents[nPos]; 
        }
    }
}
