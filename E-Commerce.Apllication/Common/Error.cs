using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Apllication.Common
{
    public sealed record Error(string code,string description, ErrorType Type=ErrorType.Failure)
    {
        public static Error Failure(string code = "General.Failure", string description="A General Failure Has Occurred")
            => new Error(code,description,ErrorType.Failure);

        public static Error Validation (string code = "General.Validation", string description = "A Validation Failure Has Occurred")
            => new Error(code, description, ErrorType.Validation);
        public static Error NotFound (string code = "General.NotFound", string description = "The Requested Resource Not Found")
            => new Error(code, description, ErrorType.NotFound);
        public static Error Conflict(string code = "General.Conflict", string description = "A Conflict Ocurred With The Current State")
            => new Error(code, description, ErrorType.Conflict);
        public static Error Unauthorized(string code = "General.Unauthorized", string description = "Access Is Denied Due To Lack Of Authorization")
            => new Error(code, description, ErrorType.Unauothorized);
        public static Error Forbidden(string code = "General.Forbidden", string description = " The Operation Is Forbidden")
            => new Error(code, description, ErrorType.Forbidden);
        public static Error InvalidCredentials(string code = "General.InvalidCredentials", string description = "The Provided Credentials Are Not Valid")
            => new Error(code, description, ErrorType.InvalidCredentials);
    }
}
