namespace Adres.Procurement.Api.Utils;

public static class FileUtils
{
    public static byte[] GetFileBytes(IFormFile file)
    {
        using var ms = new MemoryStream();
        file.CopyTo(ms);
        return ms.ToArray();
    }
}
