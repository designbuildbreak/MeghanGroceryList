using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeghanGroceryList.Models
{
    public class GroceryItem
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public Boolean GotIt { get; set; }

        public GroceryItem()
        {
            GotIt = false;
        }

    }


    public class GroceryItemDBContext : DbContext
    {
        public DbSet<GroceryItem> GroceryItems { get; set; }
    }

}