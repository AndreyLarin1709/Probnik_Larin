using System;
using System.Collections.Generic;

namespace TestDemo.Models;

public partial class MaterialTypeImport
{
    public string MaterialType { get; set; } = null!;

    public string PercentageOfDefectiveMaterial { get; set; } = null!;
}
