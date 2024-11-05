namespace LifeRoutineV0.Domain.Extensions;

public static class DateTimeExtensions
{
    public static DateTime DataInicial(this DateTime dateTime, int? ano = null, int? mes = null)
        => new (ano ?? dateTime.Year, mes ?? dateTime.Month, day: 1);

    public static DateTime DataFinal(this DateTime dateTime, int? ano = null, int? mes = null)
        => new DateTime(ano ?? dateTime.Year, mes ?? dateTime.Month, day: 1).AddMonths(1).AddDays(-1);
}