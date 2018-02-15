using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carbon_calculator.Helpers;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace carbon_calculator.Controllers
{
    public class CalculatorController : Controller
    {
        private const double CMS = 0.5;

        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        private Specie getSpecie(string treeName)
        {
            Specie sp = new Specie();

            switch (treeName)
            {
                case "Pino Candelillo":
                    sp.tree_code = "PINUMI";
                    sp.name = treeName;
                    sp.fancy_name = "Pinus Maximinoi H. E. Moore";

                    /* Asignacion de coeficientes de altura dominante */
                    sp.coefs_height[0] = -6.96328;
                    /* Asignacion de coeficientes de DAP */
                    sp.coefs_dap[0] = 2.853221;
                    sp.coefs_dap[1] = -5.94932;
                    sp.coefs_dap[2] = 0.055943;
                    sp.coefs_dap[3] = -0.000218;
                    /* Asignacion de coeficientes de Area basal */
                    sp.coefs_area[0] = 1.91575;
                    sp.coefs_area[1] = -11.592777;
                    sp.coefs_area[2] = 0.100823;
                    sp.coefs_area[3] = 0.000843;
                    /* Asignacion de coeficientes de volumen */
                    sp.coefs_volumen[0] = 3.160695;
                    sp.coefs_volumen[1] = -18.203956;
                    sp.coefs_volumen[2] = 0.182736;
                    sp.coefs_volumen[3] = 0.000775;

                    sp.coef_forma = 0.5;
                    sp.limit_year = 16;
                    sp.materia_seca = 0.5;
                    sp.setGroundIndex("Pésimo", 8.18);
                    sp.setGroundIndex("Malo", 11.65);
                    sp.setGroundIndex("Medio", 15.12);
                    sp.setGroundIndex("Bueno", 18.26);
                    sp.setGroundIndex("Excelente", 21.40);
                    break;
                case "Pino Caribe":
                    sp.tree_code = "PINUCH";
                    sp.name = treeName;
                    sp.fancy_name = "Pinus Caribaea var. hondurensis (Sénécl.) W. H. Barret & Golfari";
                    /* Asignacion de coeficientes de altura dominante */
                    sp.coefs_height[0] = -7.458911;
                    /* Asignacion de coeficientes de DAP */
                    sp.coefs_dap[0] = 2.673197;
                    sp.coefs_dap[1] = -5.545766;
                    sp.coefs_dap[2] = 0.056028;
                    sp.coefs_dap[3] = -0.000142;
                    /* Asignacion de coeficientes de Area basal */
                    sp.coefs_area[0] = 1.325956;
                    sp.coefs_area[1] = -11.038033;
                    sp.coefs_area[2] = 0.091341;
                    sp.coefs_area[3] = 0.001634;
                    /* Asignacion de coeficientes de volumen */
                    sp.coefs_volumen[0] = 2.671109;
                    sp.coefs_volumen[1] = -18.578108;
                    sp.coefs_volumen[2] = 0.171615;
                    sp.coefs_volumen[3] = 0.001541;
                    sp.coef_forma = 0.5;
                    sp.limit_year = 25;
                    sp.materia_seca = 0.5;
                    sp.setGroundIndex("Pésimo", 9.43);
                    sp.setGroundIndex("Malo", 12.46);
                    sp.setGroundIndex("Medio", 15.49);
                    sp.setGroundIndex("Bueno", 17.36);
                    sp.setGroundIndex("Excelente", 19.23);
                    break;
                case "Pino Ocote":
                    sp.tree_code = "PINUOO";
                    sp.name = treeName;
                    sp.fancy_name = "Pinus sp Schiede";
                    /* Asignacion de coeficientes de altura dominante */
                    sp.coefs_height[0] = -6.498108;
                    /* Asignacion de coeficientes de DAP */
                    sp.coefs_dap[0] = 2.426552;
                    sp.coefs_dap[1] = -6.706013;
                    sp.coefs_dap[2] = 0.075921;
                    sp.coefs_dap[3] = 0.00004;
                    /* Asignacion de coeficientes de Area basal */
                    sp.coefs_area[0] = 1.060976;
                    sp.coefs_area[1] = -13.35596;
                    sp.coefs_area[2] = 0.15187;
                    sp.coefs_area[3] = 0.001278;
                    /* Asignacion de coeficientes de volumen */
                    sp.coefs_volumen[0] = 2.246512;
                    sp.coefs_volumen[1] = -20.855741;
                    sp.coefs_volumen[2] = 0.242321;
                    sp.coefs_volumen[3] = 0.001267;
                    sp.coef_forma = 0.5;
                    sp.limit_year = 16;
                    sp.materia_seca = 0.5;
                    sp.setGroundIndex("Pésimo", 5.92);
                    sp.setGroundIndex("Malo", 9.67);
                    sp.setGroundIndex("Medio", 13.42);
                    sp.setGroundIndex("Bueno", 15.64);
                    sp.setGroundIndex("Excelente", 17.86);
                    break;
                case "Teca":
                    sp.tree_code = "TECTGR";
                    sp.name = treeName;
                    sp.fancy_name = "Tectona GrandisL. f.";
                    /* Asignacion de coeficientes de altura dominante */
                    sp.coefs_height[0] = -3.891677;
                    /* Asignacion de coeficientes de DAP */
                    sp.coefs_dap[0] = 2.293225;
                    sp.coefs_dap[1] = -4.118555;
                    sp.coefs_dap[2] = 0.052407;
                    sp.coefs_dap[3] = 0.000131;
                    /* Asignacion de coeficientes de Area basal */
                    sp.coefs_area[0] = 0.613447;
                    sp.coefs_area[1] = -7.899548;
                    sp.coefs_area[2] = 0.09739;
                    sp.coefs_area[3] = 0.001207;
                    /* Asignacion de coeficientes de volumen */
                    sp.coefs_volumen[0] = 1.605596;
                    sp.coefs_volumen[1] = -12.336335;
                    sp.coefs_volumen[2] = 0.166684;
                    sp.coefs_volumen[3] = 0.001142;
                    sp.coef_forma = 0.5;
                    sp.limit_year = 17;
                    sp.materia_seca = 0.5;
                    sp.setGroundIndex("Pésimo", 7.60);
                    sp.setGroundIndex("Malo", 13.34);
                    sp.setGroundIndex("Medio", 19.07);
                    sp.setGroundIndex("Bueno", 24.36);
                    sp.setGroundIndex("Excelente", 29.65);
                    break;
                case "Palo Blanco":
                    sp.tree_code = "TABEDO";
                    sp.name = "Palo Blanco";
                    sp.fancy_name = "Tabebuia donnel-smithii Rose";
                    /* Asignacion de coeficientes de altura dominante */
                    sp.coefs_height[0] = -3.617786;
                    /* Asignacion de coeficientes de DAP */
                    sp.coefs_dap[0] = 1.663888;
                    sp.coefs_dap[1] = -2.480653;
                    sp.coefs_dap[2] = 0.089199;
                    sp.coefs_dap[3] = 0.000146;
                    /* Asignacion de coeficientes de Area basal */
                    sp.coefs_area[0] = -0.668643;
                    sp.coefs_area[1] = -4.714003;
                    sp.coefs_area[2] = 0.181244;
                    sp.coefs_area[3] = 0.00101;
                    /* Asignacion de coeficientes de volumen */
                    sp.coefs_volumen[0] = 0.117827;
                    sp.coefs_volumen[1] = -8.184507;
                    sp.coefs_volumen[2] = 0.271737;
                    sp.coefs_volumen[3] = 0.000896;
                    sp.coef_forma = 0.5;
                    sp.limit_year = 15;
                    sp.materia_seca = 0.5;
                    sp.setGroundIndex("Pésimo", 6.15);
                    sp.setGroundIndex("Malo", 9.55);
                    sp.setGroundIndex("Medio", 12.95);
                    sp.setGroundIndex("Bueno", 15.74);
                    sp.setGroundIndex("Excelente", 18.53);
                    break;
                default:
                    sp = new Specie();
                    break;
            }

            return sp;
        }


        #region Carbono actual

        /// <summary>
        /// Función que obtiene el coeficiente de forma dependiendo de la especie mandada
        /// </summary>
        /// <param name="especie"></param>
        /// <returns> coeficiente de forma </returns>
        private double getCoeficienteForma(string especie)
        {
            return getSpecie(especie).coef_forma;
        }

        /// <summary>
        /// Función que se encarga de calcular el volumen maderal
        /// </summary>
        /// <param name="dap"></param>
        /// <param name="numArboles"></param>
        /// <param name="altura"></param>
        /// <param name="cforma"></param>
        /// <returns> volumen maderal </returns>
        private double woodVolume(double dap, int numArboles, double altura, double cforma)
        {
            // Calculamos el area basal por hectarea
            double ab = Math.Pow(dap, 2) * (Math.PI / 4) * (double)numArboles;

            return ab * altura * cforma;
        }

        /// <summary>
        /// Función que calcula el carbono actual
        /// </summary>
        /// <param name="especie"></param>
        /// <param name="dap"></param>
        /// <param name="numArboles"></param>
        /// <param name="altura"></param>
        /// <returns> carbono total </returns>
        private double actualCarbon(string especie, double dap, int numArboles, double altura)
        {
            Specie current_specie = getSpecie(especie);
            double volumen = woodVolume(
                    dap, 
                    numArboles, 
                    altura, 
                    getCoeficienteForma(especie)
                );
            return totalCarbon(volumen, current_specie.materia_seca);
        }

        #endregion

        /// <summary>
        /// Function that calculates total volumen and total
        /// carbon per year for every specie
        /// TODO: raleos
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, double[]> projectedCarbon(string especie, string indiceSitio, int numArboles, int years)
        {
            /* Variables locales */
            Specie current_specie = getSpecie(especie);
            double current_ground = current_specie.getGroundIndex(indiceSitio);
            double ms = current_specie.materia_seca;

            /* Inicializando valores de respuesta */
            Dictionary<string, double[]> response = new Dictionary<string, double[]>();
            response["altura"] = new double[years + 1];
            response["dap"] = new double[years + 1];
            response["area"] = new double[years + 1];
            response["volumen"] = new double[years + 1];
            response["carbono"] = new double[years + 1];


            for (int year = 1; year <= years; year++)
            {
                /* Proyección de altura dominante */
                response["altura"][year] = alturaDominanteProyectada(current_specie, current_ground, year);

                /* Proyección de DAP */
                response["dap"][year] = dapProyectado(current_specie, current_ground, year, numArboles);

                /* Proyección de Area basal */
                response["area"][year] = areaProyectada(current_specie, current_ground, year, numArboles);

                /* Proyección de volumen */
                double total_vol = 
                    volumenProyectado(current_specie, current_ground, year, numArboles);

                response["volumen"][year] = total_vol;

                /* Proyección de carbono */
                response["carbono"][year] = Math.Round(totalCarbon(total_vol, ms), 8);
            }

            return response;
        }

        private Dictionary<string, List<double[,]>> projectedCarbonRaleos(string especie, string indiceSitio, int numArboles, int years, Dictionary<string, string> raleo)
        {
            /* Variables locales */
            double aux_raleo = 0;
            Specie current_specie = getSpecie(especie);
            double current_ground = current_specie.getGroundIndex(indiceSitio);
            double ms = current_specie.materia_seca;

            /* Inicializando valores de respuesta */
            Dictionary<string, List<double[,]>> response = new Dictionary<string, List<double[,]>>();
            response["altura"] = new List<double[,]>();
            response["dap"] = new List<double[,]>();
            response["area"] = new List<double[,]>();
            response["volumen"] = new List<double[,]>();
            response["carbono"] = new List<double[,]>();

            /* Posicion[0,0] */
            response["altura"].Add(new double[1, 2] { { 0, 0 } });
            response["dap"].Add(new double[1, 2] { { 0, 0 } });
            response["area"].Add(new double[1, 2] { { 0, 0 } });
            response["volumen"].Add(new double[1, 2] { { 0, 0 } });
            response["carbono"].Add(new double[1, 2] { { 0, 0 } });


            for (int year = 1; year <= years; year++)
            {
                /* Proyección de altura dominante - Valor sin raleo */
                response["altura"].Add(new double[1, 2] { { year, alturaDominanteProyectada(current_specie, current_ground, year) } });

                /* Proyección de DAP - Valor sin raleo */
                response["dap"].Add(new double[1, 2] { { year, dapProyectado(current_specie, current_ground, year, numArboles) } });

                /* Proyección de Area basal - Valor sin raleo */
                response["area"].Add(new double[1, 2] { { year, areaProyectada(current_specie, current_ground, year, numArboles) } });

                /* Proyección de volumen - Valor sin raleo */
                double total_vol =
                    volumenProyectado(current_specie, current_ground, year, numArboles);
                response["volumen"].Add(new double[1, 2] { { year, total_vol } });

                /* Proyección de carbono - Valor sin raleo */
                response["carbono"].Add(new double[1, 2] { { year, Math.Round(totalCarbon(total_vol, ms), 8) } });

                if (raleo.ContainsKey(year.ToString()) && raleo[year.ToString()] != "")
                {
                    /* Raleo */
                    aux_raleo = numArboles * Convert.ToDouble(double.Parse(raleo[year.ToString()]) / 100);
                    numArboles -= Convert.ToInt32(aux_raleo);
                    
                    /* Proyección de DAP - Valor sin raleo */
                    response["dap"].Add(new double[1, 2] { { year, dapProyectado(current_specie, current_ground, year, numArboles) } });

                    /* Proyección de Area basal - Valor sin raleo */
                    response["area"].Add(new double[1, 2] { { year, areaProyectada(current_specie, current_ground, year, numArboles) } });

                    /* Proyección de volumen - Valor sin raleo */
                    total_vol = volumenProyectado(current_specie, current_ground, year, numArboles);
                    response["volumen"].Add(new double[1, 2] { { year, total_vol } });

                    /* Proyección de carbono - Valor sin raleo */
                    response["carbono"].Add(new double[1, 2] { { year, Math.Round(totalCarbon(total_vol, ms), 8) } });
                }
            }

            return response;
        }

        /// <summary>
        /// Function that returns total carbon based on 
        /// total volumen 
        /// </summary>
        /// <param name="volumen"></param>
        /// <param name="ms"></param>
        /// <param name="cms"></param>
        /// <returns></returns>
        private double totalCarbon(double volumen, double ms) {
            return Math.Round(volumen * ms * CMS, 3);
        }

        /// <summary>
        /// Función que permite calcular la altura dominante proyectado
        /// en determinado t
        /// </summary>
        /// <param name="act_esp"></param>
        /// <param name="indice_sitio"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private double alturaDominanteProyectada(Specie act_esp, double indice_sitio, int year)
        {
            return Math.Round(Math.Exp(Math.Log(indice_sitio) + act_esp.coefs_height[0] * ((double) 1 / year) - 0.1), 3);
        }

        /// <summary>
        /// Función que permite calcular el DAP proyectado
        /// en determinado t
        /// </summary>
        /// <param name="act_esp"></param>
        /// <param name="indice_sitio"></param>
        /// <param name="year"></param>
        /// <param name="numArboles"></param>
        /// <returns></returns>
        private double dapProyectado(Specie act_esp, double indice_sitio, int year, int numArboles)
        {
            return Math.Round(Math.Exp(act_esp.coefs_dap[0] + (act_esp.coefs_dap[1] / year) + (act_esp.coefs_dap[2] * indice_sitio) + (act_esp.coefs_dap[3] * numArboles)), 3);
        }

        /// <summary>
        /// Función que permite calcular el area proyectada
        /// en determinado t
        /// </summary>
        /// <param name="act_esp"></param>
        /// <param name="indice_sitio"></param>
        /// <param name="year"></param>
        /// <param name="numArboles"></param>
        /// <returns></returns>
        private double areaProyectada(Specie act_esp, double indice_sitio, int year, int numArboles)
        {
            return Math.Round(Math.Exp(act_esp.coefs_area[0] + (act_esp.coefs_area[1] / year) + (act_esp.coefs_area[2] * indice_sitio) + (act_esp.coefs_area[3] * numArboles)), 3);
        }

        /// <summary>
        /// Función que permite calcular el volumen proyectado
        /// en determinado t
        /// </summary>
        /// <param name="act_esp"></param>
        /// <param name="indice_sitio"></param>
        /// <param name="year"></param>
        /// <param name="numArboles"></param>
        /// <returns></returns>
        private double volumenProyectado(Specie act_esp, double indice_sitio, int year, int numArboles)
        {
            return Math.Round(Math.Exp(act_esp.coefs_volumen[0] + (act_esp.coefs_volumen[1] / year) + (act_esp.coefs_volumen[2] * indice_sitio) + (act_esp.coefs_volumen[3] * numArboles)), 3);
        }

        [HttpPost]
        public ActionResult calculoActual(string especie, double dap, int numArboles, double altura)
        {
            dap /= 100;

            double carbon = actualCarbon(especie, dap, numArboles, altura);

            return Json(new
            {
                status = "200", 
                response = Math.Round(carbon, 2)
            });
        }

        [HttpPost]
        public ActionResult calculoProyectado(string especie, string indice_sitio, string ms, int numArboles, string raleo)
        {
            /* Calculo proyectado con raleos */
            if(!(raleo == "{}"))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return Json(new
                {
                    status = "200",
                    response = projectedCarbonRaleos(especie, indice_sitio, numArboles, int.Parse(ms), serializer.Deserialize<Dictionary<string, string>>(raleo))
                });
            }
            /* Calculo proyecto sin raleos */
            else
            {
                Dictionary<string, double[]> data = projectedCarbon(especie, indice_sitio, numArboles, int.Parse(ms));
                return Json(new
                {
                    status = "200",
                    response = data
                });
            }
        }

        /**
          * TODO: 
          *     - Hoja de cómo se calculó todo
          *     - Gráficas UI
          */

    }
}