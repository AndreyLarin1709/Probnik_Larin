using System;
using System.Collections.Generic;

namespace TestDemo.Models;

public partial class ProductsImport
{
    public string ProductType { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int Article { get; set; }

    public decimal MinimumCostForPartner { get; set; }

    public virtual ICollection<PartnerProductsImport> PartnerProductsImports { get; set; } = new List<PartnerProductsImport>();

    public virtual ProductTypeImport ProductTypeNavigation { get; set; } = null!;
}
