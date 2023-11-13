namespace Qoniac.WebApi.Services
{
    public interface INumberConversionService
    {
        Task<string> GetConvertedNumber(double number);
    }
}
