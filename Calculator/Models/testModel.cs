using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.Models
{


    public interface itestModel
    {
        string val { get; set; }
        void doSomething();
    }

    public class testModel : itestModel
    {
        private string _val;

        public string val
        {
            get
            {
                return _val;
            }

            set
            {
                _val = value;
            }
        }

        public void doSomething()
        {
            throw new NotImplementedException();
        }
    }
    
}