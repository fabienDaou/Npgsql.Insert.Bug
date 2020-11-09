using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Npgsql.Insert.Bug
{
    public sealed class DocumentWrapper<T> where T : IDbDocument
    {
        [Key]
        [MaxLength(512)]
        public string Id { get; set; }

        [Column(TypeName = "jsonb")]
        [Required]
        public T Document { get; set; }
    }

    public interface IDbDocument
    {
        string Id { get; }
    }

    public class SomeSpecificDocument : IDbDocument
    {
        public string Id => Domain;
        public string Domain { get; set; }
        public int Rank { get; set; }
    }

    public static class DocumentExtensions
    {
        public static DocumentWrapper<TDocument> Wrap<TDocument>(this TDocument document) where TDocument : IDbDocument
        {
            return new DocumentWrapper<TDocument>
            {
                Id = document.Id,
                Document = document
            };
        }
    }
}
