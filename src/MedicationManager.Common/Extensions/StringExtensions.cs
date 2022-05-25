﻿namespace MedicationManager.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsPresent(this string str)
        {
            return !str.IsNullOrEmpty();
        }
    }
}