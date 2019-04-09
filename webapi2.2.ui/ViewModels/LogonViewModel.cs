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
using webapi22.example.dtos.DtoClasses;
using static webapi22.example.data_access.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace webapi2._2.ui.ViewModels
{
    public class LogonViewModel : DotvvmViewModelBase
    {
        public Guid _userListSelectedValue { get; set; }
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

        public void Dummy()
        {

        }
    }
}

