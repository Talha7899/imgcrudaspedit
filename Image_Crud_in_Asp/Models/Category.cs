using System;
using System.Collections.Generic;

namespace Image_Crud_in_Asp.Models;

public partial class Category
{
    public int Catid { get; set; }

    public string CatName { get; set; } = null!;

    public string CatDescription { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
