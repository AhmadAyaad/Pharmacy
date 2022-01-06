//using ExcelDataReader;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Hosting;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//using ZPharmacy.Core.Dtos;
//using ZPharmacy.Core.IServices;

//namespace ZPharmacy.API.Util
//{
//    public class UploadFileUtil
//    {
//        private readonly IUnitService _unitService;

//        public UploadFileUtil(IUnitService unitService)
//        {
//            _unitService = unitService;
//        }
//        public void CreateFile(IHostingEnvironment hostingEnvironment, IFormFile form)
//        {
//            string fileName = $"{hostingEnvironment.ContentRootPath}\\{form.FileName}";

//            using (var filestram = System.IO.File.Create(fileName))
//            {
//                form.CopyTo(filestram);
//                filestram.Flush();
//            }
//        }
//        //public async Task<List<MedicneFileUploadDto>> ReadFileAsync(IFormFile form, List<MedicneFileUploadDto> medicineList)
//        //{
//        //    var fn = $"{Directory.GetCurrentDirectory()}\\{form.FileName}";
//        //    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
//        //    using (var stream = File.Open(fn, FileMode.Open, FileAccess.Read))
//        //    {
//        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
//        //        {
//        //            while (reader.Read() && reader.GetValue(1) != null)
//        //            {
//        //                medicineList.Add(new MedicneFileUploadDto
//        //                {
//        //                    MedicineName = reader.GetValue(0) != null ? reader.GetValue(0).ToString() : "",
//        //                    UnitId = await _unitService.GetUnitIdByName(reader.GetValue(1))
//        //                }); ;
//        //            }

//        //        }

//        //    }
//        //    return medicineList;
//        //}
//    }
//}
