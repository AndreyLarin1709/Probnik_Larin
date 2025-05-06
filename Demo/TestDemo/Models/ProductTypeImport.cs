using System;
using System.Collections.Generic;

namespace TestDemo.Models;

public partial class ProductTypeImport
{
    public string ProductType { get; set; } = null!;

    public decimal? ProductTypeCoefficient { get; set; }

    public virtual ICollection<ProductsImport> ProductsImports { get; set; } = new List<ProductsImport>();
}
