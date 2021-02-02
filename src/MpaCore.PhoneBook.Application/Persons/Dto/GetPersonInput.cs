using System;
using System.Collections.Generic;
using System.Text;
using Abp.Runtime.Validation;
using MpaCore.PhoneBook.Common.Dto;

namespace MpaCore.PhoneBook.Persons.Dto
{
    /// <summary>
    /// 联系人查询Dto
    /// </summary>
    public class GetPersonInput : PagedAndSortedInputDto, IShouldNormalize
    {
        // TODO:在这里增加查询参数

        /// <summary>
        /// 模糊查询参数
        /// </summary>
        public string FilterText { get; set; }

        /// <summary>
        /// 用于排序的默认值
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}