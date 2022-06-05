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
    public class DocumentController : ControllerBase
    {
        private readonly CG_DOCSContext __cgDocsContext;
        public DocumentController(CG_DOCSContext documentInfo)
        {
            __cgDocsContext = documentInfo;
        }

        // GET: api/Document
        [HttpGet]
        public IActionResult Get()
        {
            var getDocmument = __cgDocsContext.Documents.ToList();
            return Ok(getDocmument);
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = __cgDocsContext.Documents.Where(obj =>obj.FolderId == id);
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
        public void Post([FromBody] DocumentRequest value)
        {
            Documents obj = new Documents();
            obj.DocumentName = value.DocumentName;
            obj.DocumentContentType = value.DocumentContentType;
            obj.DocumentSize = value.DocumentSize;
            obj.DocumentCreatedBy = value.DocumentCreatedBy;
            obj.DocumentCreatedAt = value.DocumentCreatedAt;
            obj.FolderId = value.FolderId;
            obj.DocumentIsDeleted = value.DocumentIsDeleted;
            __cgDocsContext.Documents.Add(obj);
            __cgDocsContext.SaveChanges();
        }

        // PUT: api/Document/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
