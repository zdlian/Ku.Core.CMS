﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vino.Core.CMS.Domain.Dto.WeChat;
using Vino.Core.CMS.Domain.Entity.WeChat;
using Vino.Core.CMS.IService.WeChat;
using Vino.Core.CMS.Web.Base;
using Vino.Core.CMS.Web.Security;
using Vino.Core.Infrastructure.Exceptions;

namespace Vino.Core.CMS.Web.Backend.Areas.WeChat.Views.Qrcode
{
    [Area("WeChat")]
    [Auth("wechat.qrcode")]
    public class QrcodeController : BackendController
    {
        private IWxQrcodeService _service;
        private IWxAccountService _accountService;

        public QrcodeController(IWxQrcodeService service, IWxAccountService accountService)
        {
            this._service = service;
            this._accountService = accountService;
        }

        [Auth("view")]
        public async Task<IActionResult> Index()
        {
            //取得公众号数据
            var accounts = await _accountService.GetListAsync(null, "Name asc");
            ViewBag.Accounts = accounts;
            return View();
        }

        [Auth("view")]
        public async Task<IActionResult> GetList(int page, int rows, WxQrcodeSearch where)
        {
            var data = await _service.GetListAsync(page, rows, where, "SceneId asc");
            return PagerData(data.items, page, rows, data.count);
        }

        [Auth("edit")]
        public async Task<IActionResult> Edit(long? id, long? AccountId)
        {
            if (id.HasValue)
            {
                //编辑
                var model = await _service.GetByIdAsync(id.Value);
                if (model == null)
                {
                    throw new VinoDataNotFoundException("无法取得数据!");
                }
                model.Account = await _accountService.GetByIdAsync(model.AccountId);
                if (model.Account == null)
                {
                    throw new VinoDataNotFoundException("数据出错!");
                }
                ViewData["Mode"] = "Edit";
                return View(model);
            }
            else
            {
                //新增
                WxQrcodeDto dto = new WxQrcodeDto();
                if (AccountId.HasValue)
                {
                    dto.AccountId = AccountId.Value;
                    dto.Account = await _accountService.GetByIdAsync(AccountId.Value);
                    if (dto.Account == null)
                    {
                        throw new VinoDataNotFoundException("参数出错!");
                    }
                }
                else
                {
                    throw new VinoDataNotFoundException("参数出错!");
                }
                ViewData["Mode"] = "Add";
                return View(dto);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        [HttpPost]
        [Auth("edit")]
        public async Task<IActionResult> Save(WxQrcodeDto model)
        {
            await _service.SaveAsync(model);
            return JsonData(true);
        }
    }
}
