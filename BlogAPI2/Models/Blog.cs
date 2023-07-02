using Amazon.DynamoDBv2.DataModel;

namespace BlogAPI2.Models
{
    [DynamoDBTable("blogs")]
    public class Blog
    {
        [DynamoDBHashKey("id")]
        public int Id { get; set; }

        [DynamoDBProperty("title")]
        public string? Title { get; set; }

        [DynamoDBProperty("content")]
        public string? Content { get; set; }

        [DynamoDBProperty("dateCreated")]
        public string? DateCreated { get; set; }

        [DynamoDBProperty("dateModified")]
        public string? DateModified { get; set; }

    }
}
