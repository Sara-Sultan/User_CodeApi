using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string EntityName, string id)
            : base($"The { EntityName } with the identifier {id} was not found.")
        {
        }
    }
}
