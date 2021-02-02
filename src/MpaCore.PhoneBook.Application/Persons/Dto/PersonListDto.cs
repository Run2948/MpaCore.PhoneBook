using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MpaCore.PhoneBook.Persons.Dto
{
    /// <summary>
    /// 联系人列表Dto
    /// </summary>
    [AutoMap(typeof(Person))]
    public class PersonListDto : EntityDto<int>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// 地址信息
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}