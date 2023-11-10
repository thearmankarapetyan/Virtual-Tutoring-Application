///<summary>
/// Entity class representing an AiLog in the UFAR.TUTOR.Data.Entities namespace.
/// The AiLog entity is intended for logging interactions between a bot and users.
/// Contains properties for the unique identifier (Id), the user's request, and the bot's response.
/// Utilizes Data Annotations for specifying attributes, such as the primary key.
///</summary>

using System.ComponentModel.DataAnnotations;  // Data Annotations for specifying attributes

namespace UFAR.TUTOR.Data.Entities
{
    // Definition of the AiLog entity class
    public class AiLog
    {
        [Key]                               // Data Annotation specifying the primary key
        public int Id { get; set; }          // Property for the unique identifier

        public string Request { get; set; }  // Property for storing the user's request

        public string Response { get; set; } // Property for storing the bot's response
    }
}
