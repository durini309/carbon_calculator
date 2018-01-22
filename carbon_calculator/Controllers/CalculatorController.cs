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

        private Specie getSpecie(string treeName)
        {
            Specie sp = new Specie();

            switch (treeName)
            {
                case "Pino Candelillo":
                    sp.tree_code = "PINUMI";
                    sp.name = treeName;
                    sp.fancy_name = "Pinus Maximinoi H. E. Moore";
                    sp.coef_one = 3.160695;
                    sp.coef_two = -18.203956;
                    sp.coef_three = 0.182736;
                    sp.coef_four = 0.000775;
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
                    sp.coef_one = 2.671109;
                    sp.coef_two = -18.578108;
                    sp.coef_three = 0.171615;
                    sp.coef_four = 0.001541;
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
                    sp.coef_one = 2.246512;
                    sp.coef_two = -20.855741;
                    sp.coef_three = 0.242321;
                    sp.coef_four = 0.001267;
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
                    sp.coef_one = 1.605596;
                    sp.coef_two = -12.336335;
                    sp.coef_three = 0.166684;
                    sp.coef_four = 0.001142;
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
                    sp.coef_one = 0.117827;
                    sp.coef_two = -8.184507;
                    sp.coef_three = 0.271737;
                    sp.coef_four = 0.000896;
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
        private double[] projectedCarbon(string especie, string indiceSitio, int numArboles, int years)
        {
            Specie current_specie = getSpecie(especie);
            double current_ground = current_specie.getGroundIndex(indiceSitio);
            double ms = current_specie.materia_seca;
            double[] response = new double[years + 1];
            
            for (int year = 1; year <= years; year++)
            {
                double total_vol = Math.Exp(
                    current_specie.coef_one +
                    (current_specie.coef_two / year) +
                    (current_specie.coef_three * current_ground) +
                    (current_specie.coef_four * numArboles));

                response[year] = Math.Round(totalCarbon(total_vol, ms), 8);
            }

            return response;
        }

        private List<double[,]> projectedCarbonRaleos(string especie, string indiceSitio, int numArboles, int years, Dictionary<string, string> raleo)
        {
            double aux_raleo = 0;
            Specie current_specie = getSpecie(especie);
            double current_ground = current_specie.getGroundIndex(indiceSitio);
            double ms = current_specie.materia_seca;
            List <double[,]> response = new List<double[,]>();

            response.Add(new double[1, 2] { { 0, 0 } });

            for (int year = 1; year <= years; year++)
            {
                double total_vol = Math.Exp(
                    current_specie.coef_one +
                    (current_specie.coef_two / year) +
                    (current_specie.coef_three * current_ground) +
                    (current_specie.coef_four * numArboles));

                response.Add(new double[1, 2] { { year, Math.Round(totalCarbon(total_vol, ms), 8) } });

                if (raleo.ContainsKey(year.ToString()) && raleo[year.ToString()] != "")
                {
                    aux_raleo = numArboles * Convert.ToDouble(double.Parse(raleo[year.ToString()]) / 100);
                    numArboles -= Convert.ToInt16(aux_raleo);

                    total_vol = Math.Exp(
                        current_specie.coef_one +
                        (current_specie.coef_two / year) +
                        (current_specie.coef_three * current_ground) +
                        (current_specie.coef_four * numArboles));

                    response.Add(new double[1, 2] { { year, Math.Round(totalCarbon(total_vol, ms), 8) } });
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
            return volumen * ms * CMS;
        }

        [HttpPost]
        public ActionResult calculoActual(string especie, double dap, int numArboles, double altura)
        {
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
                double[] data = projectedCarbon(especie, indice_sitio, numArboles, int.Parse(ms));
                return Json(new
                {
                    status = "200",
                    response = data
                });
            }
        }

        /**
          * TODO: 
          *     - cantidad de vida de especies que sea un input
          *     - Raleo
          *     - Hoja de cómo se calculó todo
          *     - % materia seca que sea input (por confirmar)
          */

    }
}