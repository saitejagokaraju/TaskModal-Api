using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Proventech.Radio.Core.Contracts.IRepositories;
using Proventech.Radio.Core.Models;

namespace Proventech.Radio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userrepository;
        private readonly Context _db;

        public UserController(IUserRepo userrepositor,Context db)
        {
            _userrepository = userrepositor;
            _db = db;
        }
        [HttpGet("Users")]
        public ActionResult<UserModel> GetUsers()
        {
            var document = _db.User.ToList();
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> GetDocuments()
        {
            var document = _userrepository.GetUser();

            // documents = document.ConvertAll(doc => new Document { Id = doc.Id, DepartmentId = doc.DepartmentId, DocumentName = doc.DocumentName });

            //var department = _userrepository.GetUser();
            //if (documents == null || department == null)
            //{
            //    return Ok();
            //}

            //documents.ForEach(i =>
            //{
            //    i.DepartmentName = department.Where(id => id.Id == i.DepartmentId).Select(j => j.DepartmentName).FirstOrDefault();
            //});

            //foreach (var document in documents)
            //{
            //    document.Department = department.Where(i => i.Id == document.DepartmentId).Select(j => j.DepartmentName).ToString();
            //}

            return Ok(document);
        }
    }
}
