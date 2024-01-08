using Microsoft.AspNetCore.Mvc;
using Proventech.Radio.Core.Models;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class ModelController : ControllerBase
{
    private readonly IRepositoryModel _repository;

    public ModelController(IRepositoryModel repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("CreateOrUpdate")]
    public async Task<IActionResult> CreateOrUpdate([FromBody] ModelTaskClass document)
    {
        if (document == null)
        {
            return BadRequest();
        }

        if (document.Id != 0)
        {
            var existingDocument = _repository.GetDocumentById(document.Id);

            if (existingDocument == null)
            {
                return NotFound();
            }

            var result = await _repository.CreateAndUpdate(document);

            if (result.Item1)
            {
                return Ok(new { Message = result.Item2 });
            }
            else
            {
                return BadRequest(new { Error = result.Item2 });
            }
        }
        else
        {
            var result = await _repository.CreateAndUpdate(document);

            if (result.Item1)
            {
                return Ok(new { Message = result.Item2 });
            }
            else
            {
                return BadRequest(new { Error = result.Item2 });
            }
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<ModelTaskClass>> GetDocuments()
    {
        var document = _repository.GetDocuments();

        var documents = document.ConvertAll(doc => new Document { Id = doc.Id, DepartmentId = doc.DepartmentId, DocumentName = doc.DocumentName });
        
        var department = _repository.GetDepartments();
        if(documents == null || department == null)
        {
            return Ok();
        }

        documents.ForEach(i =>
        {
            i.DepartmentName = department.Where(x => x.Id == i.DepartmentId).Select(j => j.DepartmentName).FirstOrDefault();
        });

        //foreach (var document in documents)
        //{
        //    document.Department = department.Where(i => i.Id == document.DepartmentId).Select(j => j.DepartmentName).ToString();
        //}

        return Ok(documents);
    }


    [HttpGet("Document/{id}")]
    public ActionResult<ModelTaskClass> GetDocumentById(int id)
    {
        var document = _repository.GetDocumentById(id);
        if (document == null)
        {
            return NotFound();
        }
        return Ok(document);
    }


    [HttpGet("Department")]
    public ActionResult<Department> GetDepartment()
    {
        var document = _repository.GetDepartments();
        if (document == null)
        {
            return NotFound();
        }
        return Ok(document);
    }

    [HttpGet("Department/{DepId}")]
    public ActionResult<Department> GetDepartmentNameByID(int DepId)
    {
        var document = _repository.GetDepartmentNameByID(DepId);
        if (document == null)
        {
            return NotFound();
        }
        return Ok(document);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDocument(int id)
    {
        var result = await _repository.DeleteDocument(id);

        if (result.Item1)
        {
            return Ok(new { message = "Document deleted successfully" });
        }
        else
        {
            return BadRequest(new { message = result.Item2 });
        }
    }
}