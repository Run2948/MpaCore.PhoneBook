using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MpaCore.PhoneBook.Persons;

namespace MpaCore.PhoneBook.PhoneNumbers
{
    /// <summary>
    /// 电话本实体信息
    /// </summary>
    public class PhoneNumber : CreationAuditedEntity<long>
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(PhoneBookConsts.MaxNumberLength)]
        public virtual string Number { get; set; }

        /// <summary>
        /// 电话类型
        /// </summary>
        [Required]
        public virtual PhoneNumberType Type { get; set; }

        /// <summary>
        /// 联系人id
        /// </summary>
        public virtual int PersonId { get; set; }

        [ForeignKey(nameof(PersonId))] 
        public virtual Person Person { get; set; }
    }
}