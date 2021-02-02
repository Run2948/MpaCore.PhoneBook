using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace MpaCore.PhoneBook.Common.Dto
{
    public class PagedAndSortedInputDto : IPagedAndSortedResultRequest
    {
        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }
        public string Sorting { get; set; }
    }
}
