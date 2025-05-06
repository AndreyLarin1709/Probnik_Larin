using System;
using System.Collections.Generic;

namespace TestDemo.Models;

public partial class PartnerProductsImport
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string PartnerName { get; set; } = null!;

    public int QuantityOfProducts { get; set; }

    public DateOnly SaleDate { get; set; }

    public virtual PartnersImport PartnerNameNavigation { get; set; } = null!;

    public virtual ProductsImport ProductNameNavigation { get; set; } = null!;
}
