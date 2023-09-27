using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Coordinates
    {
        private double _latitude;
        private double _longitude;

        public double Latitude { get { return _latitude; } set { _latitude = value; } }
        public double Longitude { get { return _longitude; } set { _longitude = value; } }
    }

    public class US
    {
        private string _id;
        private Coordinates _coordinates;

        public string Id { get { return _id; } set { _id = value; } }
        public Coordinates Coordinates { get { return _coordinates; } set { _coordinates = value; } }
    }

}
