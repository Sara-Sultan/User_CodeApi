using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PagingInputDto : IPagingInputDto
    {
        private int pageNumber;
        private int pageSize;

        public int PageNumber { get => pageNumber == 0 ? 1 : pageNumber; set => pageNumber = value; }
        public int PageSize { get => pageSize == 0 ? 10 : pageSize; set => pageSize = value; }
    }
}
