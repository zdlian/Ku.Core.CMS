//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//
// <copyright file="IMemberRepository.cs">
//        最后生成时间：2017-08-03 15:40
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Vino.Core.CMS.Core.Data;
using Vino.Core.CMS.Data.Common;
using Vino.Core.CMS.Domain.Entity.Membership;

namespace Vino.Core.CMS.Data.Repository.Membership
{
    /// <summary>
    /// 会员 仓储接口
    /// </summary>
    public partial interface IMemberRepository : IRepository<Member>
    {
    }

    /// <summary>
    /// 会员 仓储接口实现
    /// </summary>
    public partial class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(VinoDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}