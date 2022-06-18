namespace MedicationManager.UI.Common.Immutable
{
    public static class ValidationErrors
    {
        public static string EmptyField = "Данное поле не может быть пустым";
        public static string FutureDate = "Дата не может быть позже чем сегодня";
        public static string ComboBoxEmptyValue = "Выберите значение из выпадающего списка";
        public static class Medications
        {
            public static string InvalidPrice = "Стоимость должна быть больше 0 BYN";
        }

        public static class Providers
        {
            public static string InvalidPrice = "Стоимость должна быть больше 0 BYN";
            public static string ProductIsNull = "Должен быть выбран продукт";
        }

        public static class Stocks
        {
            public static string EmptyDate = "Укажите дату";
            public static string InvalidCount = "Количество товара должно быть больше 0";
            public static string InvalidPrice = "Стоимость должна быть больше 0 BYN";
            public static string UnavailableCount = "На складе нету столько товара.";
        }
    }
}
