using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carbon_calculator.Helpers;
using System.Web.Services;

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

        private Specie getSpecie(string treeCode)
        {
            Specie sp = new Specie();

            switch (treeCode)
            {
                case "PINUMI":
                    sp.tree_code = "PINUMI";
                    sp.name = "Pinus Candelillo";
                    sp.fancy_name = "Pinus Maximinoi H. E. Moore";
                    sp.coef_one = 3.160695;
                    sp.coef_two = -18.203956;
                    sp.coef_three = 0.182736;
                    sp.coef_four = 0.000775;
                    sp.coef_forma = 0.5;
                    sp.limit_year = 16;
                    sp.setGroundIndex("Pésimo", 8.18);
                    sp.setGroundIndex("Malo", 11.65);
                    sp.setGroundIndex("Medio", 15.12);
                    sp.setGroundIndex("Bueno", 18.26);
                    sp.setGroundIndex("Excelente", 21.40);
                    break;
                case "PINUCH":
                    sp.tree_code = "PINUCH";
                    sp.name = "Pino Caribe, Pino de Petén";
                    sp.fancy_name = "Pinus Caribaea var. hondurensis (Sénécl.) W. H. Barret & Golfari";
                    sp.coef_one = 2.671109;
                    sp.coef_two = -18.578108;
                    sp.coef_three = 0.171615;
                    sp.coef_four = 0.001541;
                    sp.coef_forma = 0.5;
                    sp.limit_year = 25;
                    sp.setGroundIndex("Pésimo", 9.43);
                    sp.setGroundIndex("Malo", 12.46);
                    sp.setGroundIndex("Medio", 15.49);
                    sp.setGroundIndex("Bueno", 17.36);
                    sp.setGroundIndex("Excelente", 19.23);
                    break;
                case "PINUOO":
                    sp.tree_code = "PINUOO";
                    sp.name = "Pino Ocote, Pino Colorado";
                    sp.fancy_name = "Pinus sp Schiede";
                    sp.coef_one = 2.246512;
                    sp.coef_two = -20.855741;
                    sp.coef_three = 0.242321;
                    sp.coef_four = 0.001267;
                    sp.coef_forma = 0.5;
                    sp.limit_year = 16;
                    sp.setGroundIndex("Pésimo", 5.92);
                    sp.setGroundIndex("Malo", 9.67);
                    sp.setGroundIndex("Medio", 13.42);
                    sp.setGroundIndex("Bueno", 15.64);
                    sp.setGroundIndex("Excelente", 17.86);
                    break;
                case "TECTGR":
                    sp.tree_code = "TECTGR";
                    sp.name = "Teca";
                    sp.fancy_name = "Tectona GrandisL. f.";
                    sp.coef_one = 1.605596;
                    sp.coef_two = -12.336335;
                    sp.coef_three = 0.166684;
                    sp.coef_four = 0.001142;
                    sp.coef_forma = 0.5;
                    sp.limit_year = 17;
                    sp.setGroundIndex("Pésimo", 7.60);
                    sp.setGroundIndex("Malo", 13.34);
                    sp.setGroundIndex("Medio", 19.07);
                    sp.setGroundIndex("Bueno", 24.36);
                    sp.setGroundIndex("Excelente", 29.65);
                    break;
                case "TABEDO":
                    sp.tree_code = "TABEDO";
                    sp.name = "Palo Blanco";
                    sp.fancy_name = "Tabebuia donnel-smithii Rose";
                    sp.coef_one = 0.117827;
                    sp.coef_two = -8.184507;
                    sp.coef_three = 0.271737;
                    sp.coef_four = 0.000896;
                    sp.coef_forma = 0.5;
                    sp.limit_year = 15;
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

        /// <summary>
        /// Método que retorna el Tree Code de una especie
        /// </summary>
        /// <param name="especie"></param>
        /// <returns></returns>
        private string getTreeCode(string especie)
        {
            switch (especie.ToLower())
            {
                case "pinus maximinoii": return "PINUMI";
                case "pinus caribea": return "PINUCH";
                case "pinus oocarpa": return "PINUOO";
                case "teca": return "TECTGR";
                case "palo blanco": return "TABEDO";
                default: return "";
            }
        }

        #region Carbono actual

        /// <summary>
        /// Función que obtiene el coeficiente de forma dependiendo de la especie mandada
        /// </summary>
        /// <param name="especie"></param>
        /// <returns> coeficiente de forma </returns>
        private double getCoeficienteForma(string especie)
        {
            string treeCode = getTreeCode(especie);
            return treeCode.Length > 0 ? getSpecie(treeCode).coef_forma : 0.5;
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
        /// <param name="ms"></param>
        /// <returns> carbono total </returns>
        private double actualCarbon(string especie, double dap, int numArboles, double altura, double ms)
        {
            //return $vol * $ms * $cms;
            double volumen = woodVolume(
                    dap, 
                    numArboles, 
                    altura, 
                    getCoeficienteForma(especie)
                );
            return totalCarbon(volumen, ms);
        }

        #endregion

        /// <summary>
        /// Function that calculates total volumen and total
        /// carbon per year for every specie
        /// TODO: raleos
        /// </summary>
        /// <returns></returns>
        private double[] projectedCarbon(string especie, string indiceSitio, double ms, int numArboles)
        {
            Specie current_specie = getSpecie(getTreeCode(especie));
            double current_ground = current_specie.getGroundIndex(indiceSitio);
            double[] response = new double[current_specie.limit_year];
            for (int year = 1; year <= current_specie.limit_year; year++)
            {
                double total_vol = Math.Exp(
                    current_specie.coef_one +
                    (current_specie.coef_two / year) +
                    (current_specie.coef_three * current_ground) +
                    (current_specie.coef_four * numArboles));

                response[year - 1] = Math.Round(totalCarbon(total_vol, ms), 8);
                //response.Add(new double[] {
                //        total_vol,
                //        total_carbon(total_vol, 5)
                //});
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
        public ActionResult calculoActual(string especie, double dap, int numArboles, double altura, double ms)
        {
            double carbon = actualCarbon(especie, dap, numArboles, altura, ms);

            return Json(new
            {
                status = "200", 
                response = Math.Round(carbon, 2)
            });
        }

        [HttpPost]
        public ActionResult calculoProyectado(string especie, string indice_sitio, double ms, int numArboles)
        {
            // Lógica del cálculo
            double[] data = projectedCarbon(especie, indice_sitio, ms, numArboles);
            return Json(new{
                status = "200",
                response = data
            });
        }

    }
}