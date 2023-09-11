//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }

        public double GetProductionCost()  
         //Calcular el costo total de producir un poducto final
        {
            double totalSupplies = 0.0;
            double totalEquipment = 0.0;
            foreach (Step step in this.steps)
            {
                totalSupplies += step.Input.UnitCost;
                totalEquipment += step.Equipment.HourlyCost*(step.Time/60.0);
            }
            double totalCost = totalSupplies + totalEquipment;
            return totalCost;
        }
    }
}

/* Para asignar esta responsabilidad, utilicé el patrón expert, que plantea que dbebemos asignar
la responsabilidad a la clase que tiene la información necesaria para cumplir con la misma. 
En este caso "Recipe" conoce los pasos y los productos involucrados en cada paso de la receta, 
a partir de esto el método puede recorrer el Array privado de Recipe y calcular el costo total. 
Como el Array es de tipo privado, únicamente se pueden acceder a esos datos utilizando 
un metodo dentro de la clase Recipe y no en las otras. */