using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using OfficeOpenXml;

namespace CE.Chepeat.Infraestructure.Services;

public class FileService : IFileExportServiceInfraestructure
{
    public async Task<byte[]> ExportToExcelAsync<T>(IEnumerable<T> data)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var package = new ExcelPackage(new MemoryStream()); // Utiliza un MemoryStream explícito
        var worksheet = package.Workbook.Worksheets.Add("Data");

        worksheet.Cells["A1"].LoadFromCollection(data, true);

        return await Task.FromResult(package.GetAsByteArray());
    }

    public async Task<byte[]> ExportToCsvAsync<T>(IEnumerable<T> data)
    {
        using var memoryStream = new MemoryStream();
        using var writer = new StreamWriter(memoryStream, Encoding.UTF8);
        using var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));

        await csvWriter.WriteRecordsAsync(data);
        await writer.FlushAsync();

        return memoryStream.ToArray();
    }
}