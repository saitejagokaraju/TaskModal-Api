using Proventech.Radio.Core.Models;
public interface IRepositoryModel
{
    Task<(bool, string)> CreateAndUpdate(ModelTaskClass model);
    List<ModelTaskClass> GetDocuments();
    ModelTaskClass GetDocumentById(int id);

    List<Department> GetDepartments();
    Department GetDepartmentNameByID(int id);
    Task<(bool, string)> DeleteDocument(int id);
}
