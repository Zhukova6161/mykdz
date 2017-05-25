using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mashaProject
{
    class Abonement
    {
        private Int32 id;
        public Int32 Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private String desc;
        public String Desc
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
            }
        }

        private Decimal cost;
        public Decimal Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }

        private Int32 visitsCount;
        public Int32 VisitsCount
        {
            get
            {
                return visitsCount;
            }
            set
            {
                visitsCount = value;
            }
        }

        private Int32 visitsCountRem;
        public Int32 VisitsCountRem
        {
            get
            {
                return visitsCountRem;
            }
            set
            {
                visitsCountRem = value;
            }
        }

        private Int32 idCust;
        public Int32 IdCust
        {
            get
            {
                return idCust;
            }
            set
            {
                idCust = value;
            }
        }


    }
}
