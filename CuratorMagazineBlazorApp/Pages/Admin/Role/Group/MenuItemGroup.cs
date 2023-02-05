using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using WebClient.Data.Services;
using ITable = AntDesign.ITable;

namespace WebClient.Pages.Admin.Role.Group;

/// <summary>
/// Class MenuItemGroup.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class MenuItemGroup
{
    /// <summary>
    /// Gets or sets the group service.
    /// </summary>
    /// <value>The group service.</value>
    [Inject]
    private GroupService? GroupService { get; set; }

    /// <summary>
    /// The groups
    /// </summary>
    private List<CuratorMagazineWebAPI.Models.Entities.Domains.Group>? _groups;

    /// <summary>
    /// The selected rows
    /// </summary>
    private IEnumerable<CuratorMagazineWebAPI.Models.Entities.Domains.Group>? _selectedRows;

    /// <summary>
    /// The table
    /// </summary>
    private ITable? _table;

    /// <summary>
    /// The edit cache
    /// </summary>
    private IDictionary<string, (bool edit, CuratorMagazineWebAPI.Models.Entities.Domains.Group data)> _editCache = new Dictionary<string, (bool edit, CuratorMagazineWebAPI.Models.Entities.Domains.Group data)>();

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
        var ret = await GroupService?.PostAsync()!;
        _groups = JsonConvert.DeserializeObject<List<CuratorMagazineWebAPI.Models.Entities.Domains.Group>>(ret.Result.Items?.ToString() ?? string.Empty);

        _groups?.ForEach(item =>
        {
            _editCache[item.Id.ToString()] = (false, item);
        });

        if (_groups != null) _total = _groups.Count;
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
        if (_groups != null)
        {
            var data = _groups.FirstOrDefault(item => item.Id == Convert.ToInt32(id));
            _editCache[id] = (false, data)!;
        }
    }

    /// <summary>
    /// Saves the edit.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private async void SaveEdit(string id)
    {
        if (_groups != null)
        {
            var index = _groups.FindIndex(item => item.Id == Convert.ToInt32(id));
            _groups[index] = _editCache[id].data;
            _editCache[id] = (false, _groups[index]);
        }

        var ret = await GroupService?.PutAsync(_editCache[id].data)!;

        Console.WriteLine(ret.Success ? $"{_editCache[id].data} is updated!" : ret.Error);
    }

    /// <summary>
    /// Called when [change].
    /// </summary>
    /// <param name="queryModel">The query model.</param>
    public async Task OnChange(QueryModel<CuratorMagazineWebAPI.Models.Entities.Domains.Group> queryModel)
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
        if (_groups != null)
        {
            _groups = _groups.Where(x => x.Id != id).ToList();
            _total = _groups.Count;
        }
    }
}