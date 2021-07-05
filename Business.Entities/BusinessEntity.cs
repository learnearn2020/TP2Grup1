using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {
        public BusinessEntity()
        {

        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private States state;

        public States State
        {
            get { return state; }
            set { state = value; }
        }
        
        public enum States
        {
            Delete,
            New,
            Modified,
            Unmodified
        }
    }
}
