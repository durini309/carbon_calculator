using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carbon_calculator.Helpers
{
    public class Specie
    {
        public Specie(string treeName)
        {
            ground_index = new Dictionary<string, double>();
            coefs_height = new double[1];
            coefs_dap = new double[4];
            coefs_area = new double[4];
            coefs_volumen = new double[4];
            setSpecie(treeName);
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

        public bool correct_specie { get; set; }

        protected Dictionary<string, double> ground_index;


        /// <summary>
        /// Asigna groundIndex a especie
        /// </summary>
        /// <param name="ground_type"></param>
        /// <param name="index"></param>
        public void setGroundIndex(string ground_type, double index)
        {
            ground_index.Add(ground_type, index);
        }

        /// <summary>
        /// Obtiene groundIndex de especie
        /// </summary>
        /// <param name="ground_type"></param>
        /// <returns></returns>
        public double getGroundIndex(string ground_type)
        {
            int start = ground_type.IndexOf('(') + 1;
            int end = ground_type.Length - start - 2;
            string parenthesisContent = ground_type.Substring(start, end);
            
            return Double.Parse(parenthesisContent);
        }

        /// <summary>
        /// Método que inicializa especie según nombre
        /// </summary>
        /// <param name="treeName"></param>
        private void setSpecie(string treeName)
        {
            this.name = treeName;
            this.correct_specie = true;
            switch (treeName)
            {
                case "Pinabete":
                    this.name += " (Pashaque, Abeto)";
                    this.fancy_name = "Abies guatemalensis Rehder";
                    this.coefs_height[0] = -20.378291;
                    this.coefs_dap = new double[] { 4.627246, -11.360686, -0.006167, -0.00133 };
                    this.coefs_area = new double[] { 5.447094, -21.576918, -0.015678, -0.001387 };
                    this.coefs_volumen = new double[] { 8.352033, -41.928436, 0.014195, -0.00184 };

                    this.coef_forma = 0.5;
                    this.limit_year = 18;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 8.58);
                    break;

                case "Cedro Rosado":
                    this.name += " (Cedro roso, Mundani)";
                    this.fancy_name = "Acrocarpus fraxinifolius Wight &Arn";
                    this.coefs_height[0] = -3.638221;
                    this.coefs_dap = new double[] { 2.805506, -2.624873, 0.029507, -0.000251 };
                    this.coefs_area = new double[] { 1.649195, -5.046975, 0.054066, 0.001012 };
                    this.coefs_volumen = new double[] { 3.117363, -8.840466, 0.107077, 0.000951 };

                    this.coef_forma = 0.5;
                    this.limit_year = 18;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 16.7);
                    this.setGroundIndex("Medio", 21.9);
                    this.setGroundIndex("Excelente", 27.9);
                    break;

                case "Aliso":
                    this.name = treeName;
                    this.fancy_name = "Alnus jorullensis Kunth";
                    this.coefs_height[0] = -5.183772;
                    this.coefs_dap = new double[] { 3.479904, -5.100774, 0.005329, -0.000192 };
                    this.coefs_area = new double[] { 2.046634, -13.359966, 0.071346, 0.001672 };
                    this.coefs_volumen = new double[] { 5.002828, -19.579749, 0.028559, 0.001735 };

                    this.coef_forma = 0.5;
                    this.limit_year = 20;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 13.91);
                    break;

                case "Nim":
                    this.name += " (Neem)";
                    this.fancy_name = "Azadirachta indica A. Juss";
                    this.coefs_height[0] = -1.725435;
                    this.coefs_dap = new double[] { 1.567832, -2.675935, 0.100498, 0.000284 };
                    this.coefs_area = new double[] { -0.421023, -5.328057, 0.199157, 0.001581 };
                    this.coefs_volumen = new double[] { -0.96776, -7.358693, 0.307991, 0.002469 };

                    this.coef_forma = 0.5;
                    this.limit_year = 9;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Malo", 6.51);
                    this.setGroundIndex("Bueno", 10.09);
                    break;

                case "Aripin":
                    this.fancy_name = "Caesalpinia velutina";
                    this.coefs_height[0] = -1.872405;
                    this.coefs_dap = new double[] { 1.983661, -2.330208, 0.095564, -0.000385 };
                    this.coefs_area = new double[] { 0.83226, -4.71375, 0.189626, -0.000097 };
                    this.coefs_volumen = new double[] { 1.278762, -7.15454, 0.35243, -0.000352 };

                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 8.03);
                    break;

                case "Santa María":
                    this.name = treeName + " (Marío, leche)";
                    this.fancy_name = "Calophyllum brasiliense Cambess";
                    this.coefs_height[0] = -7.657288;
                    this.coefs_dap = new double[] { 3.861522, -7.008542, 0.027548, -0.001144 };
                    this.coefs_area = new double[] { 4.181024, -13.83883, 0.051651, -0.001286 };
                    this.coefs_volumen = new double[] { 6.72825, -21.067206, 0.087027, -0.002144 };

                    this.coef_forma = 0.5;
                    this.limit_year = 15;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 11.72);
                    break;

                case "Casuarina":
                    this.fancy_name = "Casuarina equisetifolia L.";
                    this.coefs_height[0] = -5.886381;
                    this.coefs_dap = new double[] { 3.041145, -8.076789, -0.014162, -0.000069 };
                    this.coefs_area = new double[] { 2.462079, -17.066455, -0.019585, 0.00093 };
                    this.coefs_volumen = new double[] { 4.147779, -16.451739, -0.039504, 0.000229 };

                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 7.1);
                    break;

                case "Cedro":
                    this.name += " (Cedro rojo)";
                    this.fancy_name = "Cedrela odorata L.";
                    this.coefs_height[0] = -4.034014;
                    this.coefs_dap = new double[] { 2.334384, -4.530798, 0.145447, -0.001743 };
                    this.coefs_area = new double[] { -0.173934, -9.532625, 0.302835, -0.000013 };
                    this.coefs_volumen = new double[] { 0.988436, -11.063187, 0.417214, -0.002467 };

                    this.coef_forma = 0.5;
                    this.limit_year = 15;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 7);
                    break;

                case "Cipres Común":
                    this.name += " (Ciprés)";
                    this.fancy_name = "Cupressus lusitanica Mill.";
                    this.coefs_height[0] = -6.731967;
                    this.coefs_dap = new double[] { 2.707584, -5.677218, 0.067381, -0.000247 };
                    this.coefs_area = new double[] { 2.045355, -10.794574, 0.118218, 0.00037 };
                    this.coefs_volumen = new double[] { 3.118363, -17.429548, 0.215077, 0.000309 };

                    this.coef_forma = 0.5;
                    this.limit_year = 19;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 6);
                    this.setGroundIndex("Malo", 9.25);
                    this.setGroundIndex("Medio", 12.50);
                    this.setGroundIndex("Bueno", 14.75);
                    this.setGroundIndex("Excelente", 17);
                    break;

                case "Conacaste":
                    this.fancy_name = "Enterolobium cyclocarpum";
                    this.coefs_height[0] = -4.624413;
                    this.coefs_dap = new double[] { 2.274322, -6.302477, 0.086746, 0.000159 };
                    this.coefs_area = new double[] { 1.102299, -12.647657, 0.170789, 0.001247 };
                    this.coefs_volumen = new double[] { 2.049391, -18.839421, 0.264324, 0.001348 };

                    this.coef_forma = 0.5;
                    this.limit_year = 15;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 9);
                    break;

                case "Melina":
                    this.fancy_name = "Gmelina arbórea Roxb. ex. Sm";
                    this.coefs_height[0] = -4.589766;
                    this.coefs_dap = new double[] { 2.476769, -3.669808, 0.048356, -0.000258 };
                    this.coefs_area = new double[] { 0.780617, -7.094758, 0.092946, 0.001186 };
                    this.coefs_volumen = new double[] { 1.918322, -11.678936, 0.160806, 0.001068 };

                    this.coef_forma = 0.5;
                    this.limit_year = 15;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 8.62);
                    this.setGroundIndex("Malo", 14.31);
                    this.setGroundIndex("Medio", 20.01);
                    this.setGroundIndex("Bueno", 24.18);
                    this.setGroundIndex("Excelente", 28.35);
                    break;

                case "Caulote":
                    this.fancy_name = "Guazuma ulmifolia Lam";
                    this.coefs_height[0] = -0.684405;
                    this.coefs_dap = new double[] { 2.762289, -2.32964, 0.014772, -0.000567 };
                    this.coefs_area = new double[] { 2.143734, -4.666703, 0.028075, -0.000276 };
                    this.coefs_volumen = new double[] { 1.966696, -6.206873, 0.119088, 0.000292 };

                    this.coef_forma = 0.5;
                    this.limit_year = 15;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 6.54);
                    break;

                case "Canoj":
                    this.fancy_name = "Guazuma ulmifolia Lam";
                    this.coefs_height[0] = -8.798094;
                    this.coefs_dap = new double[] { 3.112788, -6.202454, 0.078664, -0.001055 };
                    this.coefs_area = new double[] { 2.642654, -12.355272, 0.1598, -0.00112 };
                    this.coefs_volumen = new double[] { 4.313634, -21.102053, 0.245205, -0.001508 };

                    this.coef_forma = 0.5;
                    this.limit_year = 15;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 13.33);
                    break;

                case "Pino Caribe":
                    this.name += " (Pino de Petén)";
                    this.tree_code = "PINUCH";
                    this.name = treeName;
                    this.fancy_name = "Pinus Caribaea var. hondurensis (Sénécl.) W. H. Barret & Golfari";
                    /* Asignacion de coeficientes de altura dominante */
                    this.coefs_height[0] = -7.458911;
                    /* Asignacion de coeficientes de DAP */
                    this.coefs_dap[0] = 2.673197;
                    this.coefs_dap[1] = -5.545766;
                    this.coefs_dap[2] = 0.056028;
                    this.coefs_dap[3] = -0.000142;
                    /* Asignacion de coeficientes de Area basal */
                    this.coefs_area[0] = 1.325956;
                    this.coefs_area[1] = -11.038033;
                    this.coefs_area[2] = 0.091341;
                    this.coefs_area[3] = 0.001634;
                    /* Asignacion de coeficientes de volumen */
                    this.coefs_volumen[0] = 2.671109;
                    this.coefs_volumen[1] = -18.578108;
                    this.coefs_volumen[2] = 0.171615;
                    this.coefs_volumen[3] = 0.001541;
                    this.coef_forma = 0.5;
                    this.limit_year = 25;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 9.43);
                    this.setGroundIndex("Malo", 12.46);
                    this.setGroundIndex("Medio", 15.49);
                    this.setGroundIndex("Bueno", 17.36);
                    this.setGroundIndex("Excelente", 19.23);
                    break;

                case "Pino Candelillo":
                    this.tree_code = "PINUMI";
                    this.name = treeName;
                    this.fancy_name = "Pinus Maximinoi H. E. Moore";

                    /* Asignacion de coeficientes de altura dominante */
                    this.coefs_height[0] = -6.96328;
                    /* Asignacion de coeficientes de DAP */
                    this.coefs_dap[0] = 2.853221;
                    this.coefs_dap[1] = -5.94932;
                    this.coefs_dap[2] = 0.055943;
                    this.coefs_dap[3] = -0.000218;
                    /* Asignacion de coeficientes de Area basal */
                    this.coefs_area[0] = 1.91575;
                    this.coefs_area[1] = -11.592777;
                    this.coefs_area[2] = 0.100823;
                    this.coefs_area[3] = 0.000843;
                    /* Asignacion de coeficientes de volumen */
                    this.coefs_volumen[0] = 3.160695;
                    this.coefs_volumen[1] = -18.203956;
                    this.coefs_volumen[2] = 0.182736;
                    this.coefs_volumen[3] = 0.000775;

                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 8.18);
                    this.setGroundIndex("Malo", 11.65);
                    this.setGroundIndex("Medio", 15.12);
                    this.setGroundIndex("Bueno", 18.26);
                    this.setGroundIndex("Excelente", 21.40);
                    break;

                case "Pino Ocote":
                    this.name += " (Pino colorado)";
                    this.tree_code = "PINUOO";
                    this.name = treeName;
                    this.fancy_name = "Pinus sp Schiede";
                    /* Asignacion de coeficientes de altura dominante */
                    this.coefs_height[0] = -6.498108;
                    /* Asignacion de coeficientes de DAP */
                    this.coefs_dap[0] = 2.426552;
                    this.coefs_dap[1] = -6.706013;
                    this.coefs_dap[2] = 0.075921;
                    this.coefs_dap[3] = 0.00004;
                    /* Asignacion de coeficientes de Area basal */
                    this.coefs_area[0] = 1.060976;
                    this.coefs_area[1] = -13.35596;
                    this.coefs_area[2] = 0.15187;
                    this.coefs_area[3] = 0.001278;
                    /* Asignacion de coeficientes de volumen */
                    this.coefs_volumen[0] = 2.246512;
                    this.coefs_volumen[1] = -20.855741;
                    this.coefs_volumen[2] = 0.242321;
                    this.coefs_volumen[3] = 0.001267;
                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 5.92);
                    this.setGroundIndex("Malo", 9.67);
                    this.setGroundIndex("Medio", 13.42);
                    this.setGroundIndex("Bueno", 15.64);
                    this.setGroundIndex("Excelente", 17.86);
                    break;

                case "Pino Pátula":
                    this.fancy_name = "Pinus patula Schltdl. & Cham.";
                    this.coefs_height[0] = -6.921948;
                    this.coefs_dap = new double[] { 1.842624, -7.912709, 0.204784, -0.000193 };
                    this.coefs_area = new double[] { 0.592964, -16.050104, 0.399771, 0.000318 };
                    this.coefs_volumen = new double[] { 1.57958, -21.303008, 0.507162, 0.000117 };

                    this.coef_forma = 0.5;
                    this.limit_year = 10;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 8.53);
                    break;

                case "Pino Triste":
                    this.name += " (Pino blanco)";
                    this.fancy_name = "Pinus pseudostrobus Lindl";
                    this.coefs_height[0] = -11.729867;
                    this.coefs_dap = new double[] { 3.298035, -10.936875, 0.065073, -0.000083 };
                    this.coefs_area = new double[] { 2.367995, -21.373573, 0.153433, 0.001055 };
                    this.coefs_volumen = new double[] { 4.039077, -32.749693, 0.242141, 0.000967 };

                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 9.71);
                    this.setGroundIndex("Medio", 13.45);
                    this.setGroundIndex("Excelente", 16.01);
                    break;

                case "Palo de Sangre":
                    this.name += " (Sangre y cahué)";
                    this.fancy_name = "Pinus pseudostrobus Lindl";
                    this.coefs_height[0] = -8.864079;
                    this.coefs_dap = new double[] { 2.533776, -6.885158, 0.065936, -0.000115 };
                    this.coefs_area = new double[] { 1.129202, -14.091632, 0.126178, 0.001344 };
                    this.coefs_volumen = new double[] { 2.56331, -23.018699, 0.214254, 0.001243 };

                    this.coef_forma = 0.5;
                    this.limit_year = 15;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 11.21);
                    this.setGroundIndex("Medio", 13.32);
                    this.setGroundIndex("Excelente", 16.05);
                    break;

                case "Casia":
                    this.fancy_name = "Pinus pseudostrobus Lindl";
                    this.coefs_height[0] = -6.116833;
                    this.coefs_dap = new double[] { 1.49521, -1.851407, 0.116224, -0.000438 };
                    this.coefs_area = new double[] { -0.306671, -4.378177, 0.225725, -0.000003 };
                    this.coefs_volumen = new double[] { 0.584018, -9.960148, 0.294692, 0.000274 };

                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 10.17);
                    break;

                case "Palo Volador":
                    this.fancy_name = "Simira salvadorensis";
                    this.coefs_height[0] = -7.563575;
                    this.coefs_dap = new double[] { 2.624014, -10.108301, 0.030276, 0.000414 };
                    this.coefs_area = new double[] { 1.609769, -20.178575, 0.060325, 0.001922 };
                    this.coefs_volumen = new double[] { 5.394304, -23.23099, 0.128387, -0.001331 };

                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 14.47);
                    break;

                case "Caoba":
                    this.name += " (Caoba del norte)";
                    this.fancy_name = "Swietenia macrophylla";
                    this.coefs_height[0] = -10.900122;
                    this.coefs_dap = new double[] { 2.630349, -10.089983, 0.075246, 0.000075 };
                    this.coefs_area = new double[] { 0.830452, -20.722084, 0.164495, 0.001994 };
                    this.coefs_volumen = new double[] { 2.239672, -32.894188, 0.260104, 0.002181 };

                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 5.40);
                    this.setGroundIndex("Malo", 9.32);
                    this.setGroundIndex("Medio", 13.24);
                    this.setGroundIndex("Bueno", 15.60);
                    this.setGroundIndex("Excelente", 17.96);
                    break;

                case "Palo Blanco":
                    this.tree_code = "TABEDO";
                    this.name = "Palo Blanco";
                    this.fancy_name = "Tabebuia donnel-smithii Rose";
                    /* Asignacion de coeficientes de altura dominante */
                    this.coefs_height[0] = -3.617786;
                    /* Asignacion de coeficientes de DAP */
                    this.coefs_dap[0] = 1.663888;
                    this.coefs_dap[1] = -2.480653;
                    this.coefs_dap[2] = 0.089199;
                    this.coefs_dap[3] = -0.000146;
                    /* Asignacion de coeficientes de Area basal */
                    this.coefs_area[0] = -0.668643;
                    this.coefs_area[1] = -4.714003;
                    this.coefs_area[2] = 0.181244;
                    this.coefs_area[3] = 0.00101;
                    /* Asignacion de coeficientes de volumen */
                    this.coefs_volumen[0] = 0.117821;
                    this.coefs_volumen[1] = -8.184507;
                    this.coefs_volumen[2] = 0.271737;
                    this.coefs_volumen[3] = 0.000896;
                    this.coef_forma = 0.5;
                    this.limit_year = 15;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 6.15);
                    this.setGroundIndex("Malo", 9.55);
                    this.setGroundIndex("Medio", 12.95);
                    this.setGroundIndex("Bueno", 15.74);
                    this.setGroundIndex("Excelente", 18.53);
                    break;

                case "Matilisguate":
                    this.fancy_name = "Swietenia macrophylla";
                    this.coefs_height[0] = -3.662898;
                    this.coefs_dap = new double[] { 1.320543, -4.009256, 0.158326, -0.000237 };
                    this.coefs_area = new double[] { -1.422144, -8.124784, 0.299527, 0.001255 };
                    this.coefs_volumen = new double[] { -1.137584, -12.265933, 0.4431, 0.001109 };

                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 3.83);
                    this.setGroundIndex("Malo", 5.90);
                    this.setGroundIndex("Medio", 7.97);
                    this.setGroundIndex("Bueno", 10.85);
                    this.setGroundIndex("Excelente", 13.73);
                    break;

                case "Teca":
                    this.tree_code = "TECTGR";
                    this.name = treeName;
                    this.fancy_name = "Tectona GrandisL. f.";
                    /* Asignacion de coeficientes de altura dominante */
                    this.coefs_height[0] = -3.891677;
                    /* Asignacion de coeficientes de DAP */
                    this.coefs_dap[0] = 2.293225;
                    this.coefs_dap[1] = -4.118555;
                    this.coefs_dap[2] = 0.052407;
                    this.coefs_dap[3] = -0.000131;
                    /* Asignacion de coeficientes de Area basal */
                    this.coefs_area[0] = 0.613447;
                    this.coefs_area[1] = -7.899548;
                    this.coefs_area[2] = 0.09739;
                    this.coefs_area[3] = 0.001207;
                    /* Asignacion de coeficientes de volumen */
                    this.coefs_volumen[0] = 1.605596;
                    this.coefs_volumen[1] = -12.336335;
                    this.coefs_volumen[2] = 0.166684;
                    this.coefs_volumen[3] = 0.001142;
                    this.coef_forma = 0.5;
                    this.limit_year = 17;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Pésimo", 7.60);
                    this.setGroundIndex("Malo", 13.34);
                    this.setGroundIndex("Medio", 19.07);
                    this.setGroundIndex("Bueno", 24.36);
                    this.setGroundIndex("Excelente", 29.65);
                    break;

                case "Pukté":
                    this.fancy_name = "Terminalia buceras";
                    this.coefs_height[0] = -1.741207;
                    this.coefs_dap = new double[] { 3.257189, -3.956527, 0.009321, 0 };
                    this.coefs_area = new double[] { 3.695791, -7.913055, -0.018641, 0 };
                    this.coefs_volumen = new double[] { 4.588308, -10.377622, 0.049617, 0 };

                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 9.92);
                    break;

                case "Guayabon":
                    this.fancy_name = "Terminalia buceras";
                    this.coefs_height[0] = -7.206822;
                    this.coefs_dap = new double[] { 2.537212, -5.780087, 0.00923, 0.00057 };
                    this.coefs_area = new double[] { 1.203433, -11.513972, 0.018414, 0.00251 };
                    this.coefs_volumen = new double[] { 3.066308, -19.106921, 0.07381, 0.002185 };

                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 14.47);
                    break;

                case "San Juan":
                    this.fancy_name = "Vochysia guatemalensis Donn. Sm.";
                    this.coefs_height[0] = -8.904588;
                    this.coefs_dap = new double[] { 2.769514, -7.431654, 0.050203, -0.000043 };
                    this.coefs_area = new double[] { 1.651327, -15.314681, 0.099127, 0.001388 };
                    this.coefs_volumen = new double[] { 1.140516, -32.901795, 0.275811, 0.003415 };

                    this.coef_forma = 0.5;
                    this.limit_year = 16;
                    this.materia_seca = 0.5;
                    this.setGroundIndex("Único", 13.8);
                    break;

                default:
                    this.correct_specie = false;
                    break;
            }
        }

        /// <summary>
        /// Función que retorna una lista de Strings con todos los índices de sitio de la especie.
        /// Los rotorna en formato: "Categiría de indice (indice)"
        /// </summary>
        /// <returns>Array de Strings con índices de sitio</returns>
        public string[] getIndicesDeSitio()
        {
            List<string> indices = new List<string>();
            int contIndices = this.ground_index.Count;
            foreach(var item in ground_index)
            {
                indices.Add(
                    String.Format("{0} ({1}m)", item.Key, item.Value)
                );
            }
            return indices.ToArray();
        }

    }
}