using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carbon_calculator.Helpers
{
    public class Specie
    {
        public Specie()
        {
            ground_index = new Dictionary<string, double>();
            coefs_height = new double[1];
            coefs_dap = new double[4];
            coefs_area = new double[4];
            coefs_volumen = new double[4];
        }
        
        public string tree_code { get; set; }

        public string name { get; set; }

        public string fancy_name { get; set; }

        public double[] coefs_height { get; set; }

        public double[] coefs_dap { get; set; }

        public double[] coefs_area { get; set; }

        public double[] coefs_volumen { get; set; }

        public double coef_forma { get; set; }

        public double materia_seca { get; set; }

        public int limit_year { get; set; }

        protected Dictionary<string, double> ground_index;


        /// <summary>
        /// Setting new ground types for a specie
        /// </summary>
        /// <param name="ground_type"></param>
        /// <param name="index"></param>
        public void setGroundIndex(string ground_type, double index)
        {
            ground_index.Add(ground_type, index);
        }

        /// <summary>
        /// Getting index's for ground types in a specie
        /// </summary>
        /// <param name="ground_type"></param>
        /// <returns></returns>
        public double getGroundIndex(string ground_type)
        {
            return ground_index[ground_type];
        }


    }
}