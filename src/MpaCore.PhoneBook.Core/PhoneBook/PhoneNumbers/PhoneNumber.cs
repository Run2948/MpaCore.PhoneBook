using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MpaCore.PhoneBook.PhoneBook.Persons;

namespace MpaCore.PhoneBook.PhoneBook.PhoneNumbers
{
    public class PhoneNumber : Entity<int>, IHasCreationTime
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(11)]
        public string Number { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public PhoneNumberType Type { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}