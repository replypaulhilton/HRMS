﻿using System;
namespace HRMS.Infrastructure.Presistence;

public class DapperSettings
{
    public const string SectionName = "ConnectionStrings";

    public string SqlServer { get; set; } = null!;
}

