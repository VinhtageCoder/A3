using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelEfficiency.Models
{
    public class ListContainer
    {
        private List<CarValueModel> modelList;

        public List<CarValueModel> ModelList { get => modelList; set => modelList = value; }

        public  ListContainer()
        {
            modelList = new List<CarValueModel>();
        }
        

    }
        
}
