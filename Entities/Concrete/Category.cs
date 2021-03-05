
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //The classes in the "Concrete" folder correspond to a database table.

    //If a class doesn't have interface implementation or class inheritance, it will create problems in future.
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
