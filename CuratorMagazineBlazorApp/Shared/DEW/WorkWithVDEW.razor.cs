using CuratorMagazineBlazorApp.Data.Services;
using CuratorMagazineBlazorApp.Models.States;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace CuratorMagazineBlazorApp.Shared.DEW;

public partial class WorkWithVDEW
{
    [Parameter]
    public User? CurrentUser { get; set; }

    [Inject]
    public UserService? UserService { get; set; }

    [Parameter]
    public StateRoleNavBar? StateRoleNavBar { get; set; } = new();

    [Parameter]
    public EventCallback<StateRoleNavBar> StateRoleNavBarCallback { get; set; }

    private List<User>? _users = new();

    //public void ChangeOnDefaultStateRoleNavBar()
    //{
    //    StateRoleNavBar = new StateRoleNavBar() { RoleName = default };
    //    StateRoleNavBarCallback.InvokeAsync(StateRoleNavBar);
    //}

    void DeleteVDEW(User user)
    {

    }

    public void AddVDEW(User user)
    {

    }

    protected override async Task OnInitializedAsync()
    {
        var users = await UserService?.PostAsync()!;
        _users = JsonConvert.DeserializeObject<List<User>>(users.Result.Items?.ToString() ?? string.Empty);
    }

    private bool IsVisibleModalAddVdewWindow { get; set; }


    public void ModalAddVdewWindow()
    {
        if (IsVisibleModalAddVdewWindow)
        {
            IsVisibleModalAddVdewWindow = false;
        }
        else
        {
            IsVisibleModalAddVdewWindow = true;
        }
    }
}