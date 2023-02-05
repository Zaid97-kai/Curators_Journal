using AntDesign;
using AntDesign.TableModels;
using API.Models.Authorization;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using WebClient.Data.Services;
using ITable = AntDesign.ITable;

namespace WebClient.Pages.Admin.Role.Role;

/// <summary>
/// Class MenuItemRole.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class MenuItemRole
{
    /// <summary>
    /// Gets or sets the role service.
    /// </summary>
    /// <value>The role service.</value>
    [Inject]
    private ApplicationRoleService? RoleService { get; set; }

    /// <summary>
    /// The divisions
    /// </summary>
    private List<ApplicationRoleListViewModel>? _roles;

    /// <summary>
    /// The selected rows
    /// </summary>
    private IEnumerable<ApplicationRoleListViewModel>? _selectedRows;

    /// <summary>
    /// The table
    /// </summary>
    private ITable? _table;

    /// <summary>
    /// The edit cache
    /// </summary>
    private IDictionary<string?, (bool edit, ApplicationRoleListViewModel data)> _editCache = new Dictionary<string?, (bool edit, ApplicationRoleListViewModel data)>();

    /// <summary>
    /// The page index
    /// </summary>
    private int _pageIndex = 1;

    /// <summary>
    /// The page size
    /// </summary>
    private int _pageSize = 10;

    /// <summary>
    /// The total
    /// </summary>
    private int _total = 0;

    /// <summary>
    /// The i
    /// </summary>
    private int i = 0;

    /// <summary>
    /// The edit identifier
    /// </summary>
    private string? _editId;

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        var ret = await RoleService?.GetAsync()!;
        _roles = ret.Result;

        _roles?.ForEach(item =>
        {
            _editCache[item.Id?.ToString()] = (false, item);
        });

        if (_roles != null) 
            _total = _roles.Count;
    }

    /// <summary>
    /// Starts the edit.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private void StartEdit(string? id)
    {
        var data = _editCache[id];
        _editCache[id] = (true, data.data);
    }

    /// <summary>
    /// Cancels the edit.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private void CancelEdit(string? id)
    {
        if (_roles != null)
        {
            var data = _roles.FirstOrDefault(item => item.Id == id);
            _editCache[id] = (false, data)!;
        }
    }

    /// <summary>
    /// Saves the edit.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private async void SaveEdit(string? id)
    {
        if (_roles != null)
        {
            var index = _roles.FindIndex(item => item.Id == id);
            _roles[index] = _editCache[id].data;
            _editCache[id] = (false, _roles[index]);
        }

        var ret = await RoleService?.CreateRole("0", _editCache[id].data)!;

        Console.WriteLine(ret.Success ? $"{_editCache[id].data} is updated!" : ret.Error);
    }

    /// <summary>
    /// Called when [change].
    /// </summary>
    /// <param name="queryModel">The query model.</param>
    public async Task OnChange(QueryModel<ApplicationRoleListViewModel> queryModel)
    {
        Console.WriteLine(JsonConvert.SerializeObject(queryModel));
    }

    /// <summary>
    /// Removes the selection.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public void RemoveSelection(int id)
    {
        if (_selectedRows != null)
        {
            var selected = _selectedRows.Where(x => x.Id != id.ToString());
            _selectedRows = selected;
        }
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private void Delete(int id)
    {
        if (_roles != null)
        {
            _roles = _roles.Where(x => x.Id != id.ToString()).ToList();
            _total = _roles.Count;
        }
    }
}