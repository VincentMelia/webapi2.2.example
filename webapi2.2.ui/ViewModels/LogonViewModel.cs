using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Controls;
using DotVVM.BusinessPack;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Runtime.Filters;
using DotVVM.Framework.ViewModel.Validation;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Binding;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;
using webapi22.example.dtos.DtoClasses;
using static webapi22.example.data_access.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace webapi2._2.ui.ViewModels
{
    public class LogonViewModel : DotvvmViewModelBase
    {
        public List<User> _userList { get; set; }
        public GridViewDataSet<User> UserGridView { get; set; }

        public override Task Init()
        {
            return base.Init();
        }

        public override Task Load()
        {
            if (!Context.IsPostBack)
            {
                _userList = AbstractGetUsers();
                if (UserGridView == null) UserGridView = new GridViewDataSet<User>();
            }

            return base.Load();
        }

        public override Task PreRender()
        {
            if (UserGridView.IsRefreshRequired) UserGridView.LoadFromQueryable(_userList.AsQueryable());

            return base.PreRender();
        }

        public void LogonAs(Guid clickedUserId)
        {
            var userlist = AbstractGetUsers();

            //var validatedUser = userlist.Where(u => u.UserName.ToLower() == userName.ToLower()).ToList()[0];
            //HttpContext.Session.SetString("UserId", validatedUser.UserId.ToString());
            //return new User() { UserId = validatedUser.UserId, UserName = validatedUser.UserName };
            //Context.HttpContext.
            AppContext.Current.Session.SetString("UserId", clickedUserId.ToString());
            
            Context.RedirectToRoute("todos");
        }
    }
}

