using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using carbon_calculator.Helpers;



namespace carbon_calculator.Controllers
{
    public class CalculatorController : Controller
    {
        Dictionary<string, Specie> species = new Dictionary<string, Specie>();
        string chose_specie = "PINUMI";
        string chose_ground = "Pésimo";


        // GET: Calculator
        public ActionResult Index()
        {
            species_init();

            return View();
        }

        /// <summary>
        /// Initiate all species to be presented
        /// in the carbon calculator
        /// </summary>
        private void species_init()
        {
            /**
             * Five species would be add it to the calculator
             *      1. Pinus Maximinoii
             *      2. Pinus Caribea
             *      3. Pinus oocarpa
             *      4. Teca (Tectona grandis)
             *      5. Palo Blanco
             */

            /* ----- Pinus Maximinoii -----*/
            Specie maximinoii = new Specie();
            maximinoii.tree_code = "PINUMI";
            maximinoii.name = "Pinus Candelillo";
            maximinoii.fancy_name = "Pinus Maximinoi H. E. Moore";
            maximinoii.coef_one = 3.160695;
            maximinoii.coef_two = -18.203956;
            maximinoii.coef_three = 0.182736;
            maximinoii.coef_four = 0.000775;
            maximinoii.limit_year = 16;
            maximinoii.setGroundIndex("Pésimo", 8.18);
            maximinoii.setGroundIndex("Malo", 11.65);
            maximinoii.setGroundIndex("Medio", 15.12);
            maximinoii.setGroundIndex("Bueno", 18.26);
            maximinoii.setGroundIndex("Excelente", 21.40);

            species.Add(maximinoii.tree_code, maximinoii);

            /* ----- Pinus Caribea -----*/
            Specie caribea = new Specie();
            caribea.tree_code = "PINUCH";
            caribea.name = "Pino Caribe, Pino de Petén";
            caribea.fancy_name = "Pinus Caribaea var. hondurensis (Sénécl.) W. H. Barret & Golfari";
            caribea.coef_one = 2.671109;
            caribea.coef_two = -18.578108;
            caribea.coef_three = 0.171615;
            caribea.coef_four = 0.001541;
            caribea.limit_year = 25;
            caribea.setGroundIndex("Pésimo", 9.43);
            caribea.setGroundIndex("Malo", 12.46);
            caribea.setGroundIndex("Medio", 15.49);
            caribea.setGroundIndex("Bueno", 17.36);
            caribea.setGroundIndex("Excelente", 19.23);

            species.Add(caribea.tree_code, caribea);

            /* ----- Pinus Oocarpa -----*/
            Specie oocarpa = new Specie();
            oocarpa.tree_code = "PINUOO";
            oocarpa.name = "Pino Ocote, Pino Colorado";
            oocarpa.fancy_name = "Pinus Oocarpa Schiede";
            oocarpa.coef_one = 2.246512;
            oocarpa.coef_two = -20.855741;
            oocarpa.coef_three = 0.242321;
            oocarpa.coef_four = 0.001267;
            oocarpa.limit_year = 16;
            oocarpa.setGroundIndex("Pésimo", 5.92);
            oocarpa.setGroundIndex("Malo", 9.67);
            oocarpa.setGroundIndex("Medio", 13.42);
            oocarpa.setGroundIndex("Bueno", 15.64);
            oocarpa.setGroundIndex("Excelente", 17.86);

            species.Add(oocarpa.tree_code, oocarpa);

            /* ----- Teca (Tectona grandis) -----*/
            Specie teca = new Specie();
            teca.tree_code = "TECTGR";
            teca.name = "Teca";
            teca.fancy_name = "Tectona GrandisL. f.";
            teca.coef_one = 1.605596;
            teca.coef_two = -12.336335;
            teca.coef_three = 0.166684;
            teca.coef_four = 0.001142;
            teca.limit_year = 17;
            teca.setGroundIndex("Pésimo", 7.60);
            teca.setGroundIndex("Malo", 13.34);
            teca.setGroundIndex("Medio", 19.07);
            teca.setGroundIndex("Bueno", 24.36);
            teca.setGroundIndex("Excelente", 29.65);

            species.Add(teca.tree_code, teca);

            /* ----- Palo Blanco -----*/
            Specie palo_blanco = new Specie();
            palo_blanco.tree_code = "TABEDO";
            palo_blanco.name = "Palo Blanco";
            palo_blanco.fancy_name = "Tabebuia donnel-smithii Rose";
            palo_blanco.coef_one = 0.117827;
            palo_blanco.coef_two = -8.184507;
            palo_blanco.coef_three = 0.271737;
            palo_blanco.coef_four = 0.000896;
            palo_blanco.limit_year = 15;
            palo_blanco.setGroundIndex("Pésimo", 6.15);
            palo_blanco.setGroundIndex("Malo", 9.55);
            palo_blanco.setGroundIndex("Medio", 12.95);
            palo_blanco.setGroundIndex("Bueno", 15.74);
            palo_blanco.setGroundIndex("Excelente", 18.53);

            species.Add(palo_blanco.tree_code, palo_blanco);

        }

        /// <summary>
        /// Function that calculates total volumen and total
        /// carbon per year for every specie
        /// TODO: raleos
        /// </summary>
        /// <returns></returns>
        private List<double[]> algorithm()
        {
            Specie current_specie = species[chose_specie];
            double current_ground = current_specie.getGroundIndex(chose_specie);
            List<double[]> response = new List<double[]>();

            for (int year = 0; year <= current_specie.limit_year; year++)
            {
                double total_vol = Math.Exp(
                    current_specie.coef_one + 
                    (current_specie.coef_two / year) +
                    (current_specie.coef_three * current_ground) + 
                    (current_specie.coef_four * current_specie.number_of_trees));
                
                response.Add(new double[] {
                        total_vol,
                        total_carbon(total_vol, 5)
                });
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
        private double total_carbon(double volumen, double ms, double cms = 0.5) {
            return volumen * ms * cms;
        }
    }
}