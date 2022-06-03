﻿namespace MedicationManager.UI.Common.Immutable
{
    public static class ValidationErrors
    {
        public static string EmptyField = "Данное поле не может быть пустым";

        public static class Medications
        {
            public static string InvalidPrice = "Стоимость должна быть больше 0 BYN";
        }
    }
}