using Proventech.Radio.Core.Models;

public class RepositoryModel : IRepositoryModel
{
    private readonly Context _context;

    public RepositoryModel(Context context)
    {
        _context = context;
    }

    public async Task<(bool, string)> CreateAndUpdate(ModelTaskClass model)
    {
        try
        {
            var existingDocument = _context.ModelTasks.Find(model.Id);

            if (existingDocument == null)
            {
                // If the document does not exist, create a new one
                _context.ModelTasks.Add(model);
                await _context.SaveChangesAsync();
                return (true, "Document created successfully");
            }
            else
            {
                // If the document exists, update it
                existingDocument.DepartmentId = model.DepartmentId;
                existingDocument.DocumentName = model.DocumentName;
                await _context.SaveChangesAsync();
                return (true, "Document updated successfully");
            }
        }
        catch (Exception ex)
        {
            return (false, $"Error creating or updating document: {ex.Message}");
        }
    }

    public List<ModelTaskClass> GetDocuments()
    {
        return _context.ModelTasks.ToList();
    }


    public ModelTaskClass GetDocumentById(int id)
    {
        return _context.ModelTasks.Find(id);
    }

    public List<Department> GetDepartments()
    {
        return _context.DepartmentTable.ToList();
    }
    public Department GetDepartmentNameByID(int DepId)
    {
        return _context.DepartmentTable.Find(DepId);
    }

    public async Task<(bool, string)> DeleteDocument(int id)
    {
        try
        {
            var document = await _context.ModelTasks.FindAsync(id);

            if (document == null)
            {
                return (false, "Document not found");
            }

            _context.ModelTasks.Remove(document);
            await _context.SaveChangesAsync();

            return (true, "Document deleted successfully");
        }
        catch (Exception ex)
        {
            return (false, $"Error deleting document: {ex.Message}");
        }
    }

}
