using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Services
{
    public enum DbResponseEnum
    {
        Created,
        NotCreated,
        RecordsReturned,
        Updated,
        NotFound,
        ValidationError,
		Success
    }
}