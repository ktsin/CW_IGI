using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using BLL.DataLandfill;
using Microsoft.AspNetCore.Http;

namespace BLL.Services
{
    public class FilesService
    {
        private readonly DataLandfill.DataLandfillContext _context = null;
        public FilesService(DataLandfill.DataLandfillContext context)
        {
            _context = context;
        }
        private static string EncodeFileToBase64(IFormFile file)
        {
            byte[] buffByte = new byte[file.Length];
            Span<byte> buffer = new(buffByte);
            using (var stream = file.OpenReadStream())
            {
                stream.Read(buffer);
            }
            var res = Convert.ToBase64String(buffer);
            return res;
        }

        public async Task<bool> SaveFileToLandfill(IFormFile file)
        {
            var type = file.ContentType;
            var encoded = EncodeFileToBase64(file);
            var res = $"data:{type.Trim()};base64,{encoded}";
            var guid = Guid.NewGuid();
            bool savingResult = true;
            try
            {
                _context.Add(new DataLandfill.DataItem() {Id = guid.ToString(), Base64String = res});
                var rows = await _context.SaveChangesAsync();
                if (rows == 0)
                    savingResult = false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                savingResult = false;
            }
            return savingResult;
        }

        public async Task<DataItem> GetFileById(string id)
        {
            DataItem result = await _context.Images.FindAsync(id);
            return result;
        }
    }
}