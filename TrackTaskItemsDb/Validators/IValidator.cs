using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackTaskItemsDb.Validators
{
    public interface IValidator<T>
    {
        bool TryInvalidate(T input, out string errorMessage);
    }
}
