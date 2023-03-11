using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class Basket
    {
        // This is declaring the variable and instantiating it all in the same line
        // First part declares, second part instatiates. 
        public List<BasketLineItem> Items { get; set; }  = new List<BasketLineItem>();
        
        public virtual void AddItem(Project proj, int qty)
        {
            // Go search the current basket list and find the project associated with that project's ID
            BasketLineItem line = Items
                .Where(p => p.Project.ProjectId == proj.ProjectId)
                .FirstOrDefault();

            // If there isn't any line item associated with the project, create one
            if (line == null)
            {
                // Using the default .Add operator to add to the list of type BasketLineItem
                // The project for the line item is the proj passed in,
                // the quantity is the qty passed in
                Items.Add(new BasketLineItem
                {
                    Project = proj,
                    Quantity = qty
                });
            }
            // Else, (if there already is a project found in list)  we are going to
            // increment it up by the quantity
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Project proj)
        {
            Items.RemoveAll(x => x.Project.ProjectId == proj.ProjectId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);
                
            return sum;

        }
    }

    

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Project Project { get; set; }
        public int Quantity { get; set; }
    }
}
