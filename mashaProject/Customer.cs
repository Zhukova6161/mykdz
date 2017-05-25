using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mashaProject
{
    class Customer
    {
        private Int32 customerId;
        public Int32 CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
            }
        }
        private String fio;
        public String Fio
        {
            get
            {
                return fio;
            }
            set
            {
                fio = value;
            }

        }
        private Decimal balance;
        public Decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }

        }
    }
}
