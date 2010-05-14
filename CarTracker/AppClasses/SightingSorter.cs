using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace CarTracker
{
    // Implementation of the IComparer
    // interface for sorting ArrayList items.
    public class SightingSorter : IComparer<Sightings>
    {
        bool ascending;


        // Constructor requires the sort order;
        // true if ascending, otherwise descending.
        public SightingSorter(bool asc)
        {
            this.ascending = asc;
        }

        // Implemnentation of the IComparer:Compare
        // method for comparing two objects.
        public int Compare(Sightings xItem, Sightings yItem)
        {
            string xText = xItem.CarName;
            string yText = yItem.CarName;
            return xText.CompareTo(yText) * (this.ascending ? 1 : -1);
        }
    }

}
