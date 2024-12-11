﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FitnessTrackingApp.Web.Infrastructure.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var displayAttribute = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault()?
            .GetCustomAttribute<DisplayAttribute>();

        return displayAttribute?.Name ?? enumValue.ToString();
    }
}