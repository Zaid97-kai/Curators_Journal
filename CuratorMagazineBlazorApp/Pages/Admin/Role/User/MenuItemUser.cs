using AntDesign;
using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using WebClient.Data.Services;

namespace WebClient.Pages.Admin.Role.User;

/// <summary>
/// Class MenuItemUser.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class MenuItemUser
{
    /// <summary>
    /// Gets or sets the user service.
    /// </summary>
    /// <value>The user service.</value>
    [Inject]
    private UserService? UserService { get; set; }

    /// <summary>
    /// The divisions
    /// </summary>
    private List<API.Models.Entities.Domains.User>? _users;

    /// <summary>
    /// The selected rows
    /// </summary>
    private IEnumerable<API.Models.Entities.Domains.User>? _selectedRows;

    /// <summary>
    /// The table
    /// </summary>
    private ITable? _table;

    /// <summary>
    /// The edit cache
    /// </summary>
    private IDictionary<string, (bool edit, API.Models.Entities.Domains.User? data)> _editCache = new Dictionary<string, (bool edit, API.Models.Entities.Domains.User? data)>();

    /// <summary>
    /// The page index
    /// </summary>
    int _pageIndex = 1;

    /// <summary>
    /// The page size
    /// </summary>
    int _pageSize = 10;

    /// <summary>
    /// The total
    /// </summary>
    int _total = 0;

    /// <summary>
    /// The i
    /// </summary>
    int i = 0;

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
        var ret = await UserService?.PostAsync()!;
        _users = JsonConvert.DeserializeObject<List<API.Models.Entities.Domains.User>>(ret.Result.Items?.ToString() ?? string.Empty);

        _users?.ForEach(item =>
        {
            _editCache[item.Id.ToString()] = (false, item);
        });

        if (_users != null) _total = _users.Count;
    }

    /// <summary>
    /// Starts the edit.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private void StartEdit(string id)
    {
        var data = _editCache[id];
        _editCache[id] = (true, data.data);
    }

    /// <summary>
    /// Cancels the edit.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private void CancelEdit(string id)
    {
        if (_users != null)
        {
            var data = _users.FirstOrDefault(item => item.Id == Convert.ToInt32(id));
            _editCache[id] = (false, data)!;
        }
    }

    /// <summary>
    /// Saves the edit.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private async void SaveEdit(string id)
    {
        if (_users != null)
        {
            var index = _users.FindIndex(item => item.Id == Convert.ToInt32(id));
            _users[index] = _editCache[id].data;
            _editCache[id] = (false, _users[index]);
        }

        var ret = await UserService?.PutAsync(_editCache[id].data)!;

        Console.WriteLine(ret.Success ? $"{_editCache[id].data} is updated!" : ret.Error);
    }

    /// <summary>
    /// Called when [change].
    /// </summary>
    /// <param name="queryModel">The query model.</param>
    public async Task OnChange(QueryModel<API.Models.Entities.Domains.User> queryModel)
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
            var selected = _selectedRows.Where(x => x.Id != id);
            _selectedRows = selected;
        }
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private void Delete(int id)
    {
        if (_users != null)
        {
            _users = _users.Where(x => x.Id != id).ToList();
            _total = _users.Count;
        }
    }
}