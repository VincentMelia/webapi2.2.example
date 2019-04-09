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
using webapi22.example.dtos.DtoClasses.UserTodoListsTypes;
using static webapi22.example.data_access.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using webapi2._2.ui;
using AppContext = webapi2._2.ui.AppContext;

namespace webapi2_2.ui.ViewModels
{
    public class TodosViewModel : DotvvmViewModelBase
    {
        public Guid _userListSelectedValue { get; set; }
        public UserTodoLists _userTodoList { get; set; }
        public GridViewDataSet<TodoList> TodoListGridView { get; set; }

        public override Task Init()
        {
            return base.Init();
        }

        public override Task Load()
        {
            if (!Context.IsPostBack)
            {
                _userTodoList = AbstractGetListsForUser(new Guid(AppContext.Current.Session.GetString("UserId")));
                if (TodoListGridView == null)
                    TodoListGridView = new GridViewDataSet<TodoList>();
            }

            return base.Load();
        }

        public override Task PreRender()
        {
            if (TodoListGridView.IsRefreshRequired) TodoListGridView.LoadFromQueryable(_userTodoList.TodoLists.AsQueryable());

            return base.PreRender();
        }


    }
}

