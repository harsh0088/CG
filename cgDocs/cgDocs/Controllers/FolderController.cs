using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cgDocs.Models;
using cgDocs.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cgDocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly CG_DOCSContext _cgDocsContext;
        public FolderController(CG_DOCSContext Folderinfo)
        {
            _cgDocsContext = Folderinfo;
        }


        // GET: api/Folder
        [HttpGet]
        public IActionResult Get()
        {
            var getFolder = _cgDocsContext.Folders.ToList();
            return Ok(getFolder);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _cgDocsContext.Folders.Where(obj => obj.FolderCreatedBy == id);
                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error!");
            }
        }
        [HttpPost]
        public void Post([FromBody] FolderRequest value)
        {
            Folders obj = new Folders();
            obj.FolderName = value.FolderName;
            obj.FolderCreatedBy = value.FolderCreatedBy;
            obj.FolderCreatedAt = value.FolderCreatedAt;
            obj.FolderIsDeleted = value.FolderIsDeleted;
            _cgDocsContext.Folders.Add(obj);
            _cgDocsContext.SaveChanges();
        }

        // Get: api/Folder/5
        //for searching
        [HttpGet("{id}/{value}")]
        public IActionResult Get(int id, string value)
        {
            var result = _cgDocsContext.Folders.Where(e => e.FolderCreatedBy == id).Where(o => o.FolderName.Contains(value));
            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delete = _cgDocsContext.Documents.Where(res => res.FolderId == id).ToList();
            delete.ForEach(res => _cgDocsContext.Documents.Remove(res));
            var del = _cgDocsContext.Folders.Where(res => res.FolderId == id).ToList();
            del.ForEach(res => _cgDocsContext.Folders.Remove(res));
            _cgDocsContext.SaveChanges();
        }


    }
}