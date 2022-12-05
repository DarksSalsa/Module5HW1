using System;

namespace ALevelSample.Dtos.Responses
{
    public class UserUpdateAndPatchResponse
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
