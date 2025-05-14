using iText.Html2pdf;
using iText.Kernel.Pdf;
using System.Text;

namespace Web.Server.Common.Services;

public class PdfService
{
    public byte[] GeneratePdfFromHtml(string htmlContent)
    {
        using var memoryStream = new MemoryStream();
        
        var writer = new PdfWriter(memoryStream);
        var pdf = new PdfDocument(writer);
        
        var converterProperties = new ConverterProperties();

        HtmlConverter.ConvertToPdf(
            new MemoryStream(Encoding.UTF8.GetBytes(htmlContent)),
            memoryStream,
            converterProperties);

        return memoryStream.ToArray();
    }
} 
