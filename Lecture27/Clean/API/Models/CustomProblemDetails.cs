using System.Collections.Generic;

namespace API.Models
{
    public class CustomProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
