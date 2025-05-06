using System;
using System.Collections.Generic;

namespace TestDemo.Models;

public partial class PartnersImport
{
    public string PartnerType { get; set; } = null!;

    public string PartnerName { get; set; } = null!;

    public string Director { get; set; } = null!;

    public string PartnerEmail { get; set; } = null!;

    public string PartnerPhone { get; set; } = null!;

    public string PartnersLegalAddress { get; set; } = null!;

    public decimal Tin { get; set; }

    public int Rating { get; set; }

    public int? Discount { get; set; }

    public virtual ICollection<PartnerProductsImport> PartnerProductsImports { get; set; } = new List<PartnerProductsImport>();
}
