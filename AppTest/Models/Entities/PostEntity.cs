using System.Formats.Asn1;
using System.Runtime.InteropServices.Marshalling;

namespace AppTest.Models.Entities
{
    public class PostEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }=String.Empty;
        public string Title { get; set; } = String.Empty;
        public virtual List<ImageEntity> Images { get; set; } = [];
        public virtual UserPageEntity UserPage { get; set; }
        public DateTime time { get; set; }

        public virtual List<CommentEntity> Comments { get; set; } = [];
        public virtual List<ReportEntity> Reports { get; set; } = [];
    }
}
