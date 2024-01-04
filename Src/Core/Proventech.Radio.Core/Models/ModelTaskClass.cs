using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proventech.Radio.Core.Models
{
    public class ModelTaskClass
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string DocumentName { get; set; }
    }


    public class Document
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DocumentName { get; set; }

    }
}
