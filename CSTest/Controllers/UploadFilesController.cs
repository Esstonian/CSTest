using CSTest.Interfaces;
using CSTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSTest.Controllers {
    public class UploadFilesController : Controller {
        List<AllData> allDatas = new List<AllData>();
        private IFileOperations _fileOperations;
        public UploadFilesController(IFileOperations fileOperations) {
            _fileOperations = fileOperations;
        }

        [HttpPost]
        public IActionResult AddFiles() {
            if (Request.Form.Files.Count > 0) {
                foreach (var file in Request.Form.Files) {
                    if (file != null && file.Length > 0) {
                        _fileOperations.parseXml(file.OpenReadStream());
                    }
                }
            }
            return RedirectToAction("Index", "Home", new { });
        }
    }
}
