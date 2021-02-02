using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MpaCore.PhoneBook.Persons.Dto;

namespace MpaCore.PhoneBook.Persons
{
    public interface IPersonAppService : IApplicationService
    {
        /// <summary>
        /// 根据查询条件获取联系人分页列表
        /// </summary>
        Task<PagedResultDto<PersonListDto>> GetPagedPersonsAsync(GetPersonInput input);

        /// <summary>
        /// 通过指定id获取联系人ListDto信息
        /// </summary>
        Task<PersonListDto> GetPersonByIdAsync(EntityDto input);

        /// <summary>
        /// 通过Id获取联系人信息进行编辑或修改 
        /// </summary>
        Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 新增或更改联系人
        /// </summary>
        Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input);

        /// <summary>
        /// 新增联系人
        /// </summary>
        Task<PersonEditDto> CreatePersonAsync(PersonEditDto input);

        /// <summary>
        /// 更新联系人
        /// </summary>
        Task UpdatePersonAsync(PersonEditDto input);

        /// <summary>
        /// 删除联系人
        /// </summary>
        Task DeletePersonAsync(EntityDto input);

        /// <summary>
        /// 批量删除联系人
        /// </summary>
        Task BatchDeletePersonAsync(IEnumerable<int> input);
    }
}